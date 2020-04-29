using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Esse3Gamal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IConfiguration config;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IFacultyRepository facultyRepository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> 
            signInManager, ILogger<AccountController> logger, IConfiguration config, 
            RoleManager<IdentityRole> roleManager, IFacultyRepository facultyRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.config = config;
            this.roleManager = roleManager;
            this.facultyRepository = facultyRepository;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userVector = model.Email.Split("@")[0];
                var firstName = (userVector.Split(".")[0]).ToUpper();
                var lastName = (userVector.Split(".")[1]).ToUpper();    
                var user = new ApplicationUser { Email = model.Email, UserName = model.Email, FirstName = firstName, LastName = lastName };
                
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    ViewBag.ErrorMessage = $"Cannot create user";
                    return View(model);
                }
                var role = await roleManager.FindByNameAsync("Secretary");
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with name SECRETARY cannot be found";
                    return View(model);
                }

                result = await userManager.AddToRoleAsync(user, role.Name);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Cannot add user to role";
                    return View(model);
                }
               
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmEmailLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
                logger.LogInformation(confirmEmailLink);
                await signInManager.SignInAsync(user, isPersistent: false);
                SendEmail(confirmEmailLink);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user == null)
                    {
                        return View(model);
                    }
                    var userVector = model.Email.Split("@");
                    var firstName = (userVector[0].Split(".")[0]).ToUpper();
                    var lastName = (userVector[0].Split(".")[1]).ToUpper();
                    
                    HttpContext.Session.SetString("UserFirstName", firstName);
                    HttpContext.Session.SetString("UserLastName", lastName);
                    HttpContext.Session.SetString("Email", model.Email);
                    HttpContext.Session.SetString("SerialNumber", user.SerialNumber);

                    if ((await userManager.IsInRoleAsync(user, "Secretary")) == true)
                    {
                        return RedirectToAction("Home", "Secretary");
                    }
                    else if((await userManager.IsInRoleAsync(user, "Student")) == true)
                    {
                        return RedirectToAction("Home", "Student");
                    }
                    else if ((await userManager.IsInRoleAsync(user, "Teacher")) == true)
                    {
                        return RedirectToAction("Teacher", "Teacher");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(String.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Error", "Error", new {message = "L'utilisateur n'a pas été trouvé dans le systems"});
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                SendPasswordResetLink(user.Email);
                var message = $"Votre non d'utilisateur a été confirmé avec succès. Sous peu vous receverez un courier electronique pour initialiser votre mot de passe";
                return RedirectToAction("Message", "Message", new { message = message}); ;
            }
            return RedirectToAction("Error", "Error", new {message = $"Le nom d'utilisateur {user.UserName} n'a pas été confirmé" });
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid Password Reset token");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =  await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            return RedirectToAction("Error", "Error", new { message = "Impossibile de réinitialiser le mot de passe" });
        }
        public void SendEmail(string emailBody)
        {
            MailMessage mailMessage = new MailMessage("elhadjtahirou.minthe@gmail.com", "elhadjtahorou.minthe@gmail.com");
            mailMessage.Body = emailBody;
            mailMessage.Subject = "Registration";
            var credentials = new NetworkCredential(config.GetValue<string>("Email:Smtp:Username"), config.GetValue<string>("Email:Smtp:Password"));
            var smtpClient = new SmtpClient()
            {
                Port = config.GetValue<int>("Email:Smtp:Port"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = config.GetValue<string>("Email:Smtp:Host"),
                EnableSsl = true,
                Credentials = credentials
            };
            smtpClient.Send(mailMessage);
        }

        private void SendPasswordResetLink(string toEmail)
        {   
            var user = userManager.FindByEmailAsync(toEmail).GetAwaiter().GetResult();
            var token = userManager.GeneratePasswordResetTokenAsync(user).GetAwaiter().GetResult();

            var resetPasswordLink = Url.Action("ResetPassword", "Account", new { email = toEmail, token = token}, Request.Scheme);
            MailMessage mailMessage = new MailMessage("elhadjtahirou.minthe@gmail.com", toEmail);
            StringBuilder messageBody = new StringBuilder();
            messageBody.Append("UNIVERSITE GAMAL ABDEL NASSER DE CONAKRY" + Environment.NewLine);
            messageBody.Append("Cher " + user.FirstName + " " + user.LastName + Environment.NewLine);
            messageBody.Append("Veuillez cliquer sur le lien ci-dessous pour initialiser votre mot de passe" + Environment.NewLine);
            messageBody.Append(resetPasswordLink + Environment.NewLine);
            messageBody.Append("UGANC");

            mailMessage.Subject = "Initialisation mot de passe";
            mailMessage.Body = messageBody.ToString();

            var credentials = new NetworkCredential(config.GetValue<string>("Email:Smtp:Username"), config.GetValue<string>("Email:Smtp:Password"));
            var smtpClient = new SmtpClient()
            {
                Port = config.GetValue<int>("Email:Smtp:Port"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = config.GetValue<string>("Email:Smtp:Host"),
                EnableSsl = true,
                Credentials = credentials
            };
            smtpClient.Send(mailMessage);
        }
    }   
}   