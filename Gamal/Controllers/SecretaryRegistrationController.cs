using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamal.Models;
using Gamal.Models.Domain;
using Gamal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Gamal.Controllers
{
	public class SecretaryRegistrationController : Controller
	{
      private readonly UserManager<ApplicationUser> userManager;
      private readonly SignInManager<ApplicationUser> signInManager;
      private readonly ILogger<SecretaryRegistrationController> logger;
		private readonly RoleManager<IdentityRole> roleManager;

		public SecretaryRegistrationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
          signInManager, ILogger<SecretaryRegistrationController> logger, IConfiguration config,
          RoleManager<IdentityRole> roleManager)
      {
         this.userManager = userManager;
         this.signInManager = signInManager;
         this.logger = logger;
			this.roleManager = roleManager;
		}
      public IActionResult Index()
		{
         if (TempData["enrolementState"]?.ToString() == "succeed")
         {
            ViewBag.message = "succeed";
         }
         return View();
		}

      [HttpGet]
      public async Task<IActionResult> Register()
      {
         ViewBag.Message = TempData["Message"];
         TempData["Message"] = "";
         var model = new SecretaryRegistrationViewModel();
         return View(model);
      }
      [HttpPost]
      public async Task<IActionResult> Register(SecretaryRegistrationViewModel model)
      {
         var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
         var unitOfWork = new UnitOfWork(new AppDbContext(optionsBuilder.Options));
         if (ModelState.IsValid)
         {
            var user = new ApplicationUser
            {
               FirstName = model.FirstName,
               LastName = model.FirstName,
               Email = model.Email,
               PhoneNumber = model.PhoneNumber,
               UserName = model.Email,
               SerialNumber = model.SerialNumber
            };

            var result = await userManager.CreateAsync(user, "Fantabamba25?!1_");

            if (!result.Succeeded) 
            {
               ViewBag.Error = $"Une erreur est survenue durant l'inscription de l'enseignant {model.FirstName} {model.LastName}!";
               return View(model);
            }
            
				if ((await roleManager.RoleExistsAsync("Secretary")) == false)
				{
               var role = new IdentityRole();
               role.Name = "Secretary";
               var result1 = await roleManager.CreateAsync(role);
               if (!result1.Succeeded)
					{
                  ViewBag.Error = $"Une erreur est survenue durant la creation du role secrétaire!";
                  return View(model);
               }
               
            }

            var result2 = await userManager.AddToRoleAsync(user, "Secretary");
				if (!result2.Succeeded)
				{
               ViewBag.Error = $"Impossible d'ajouter l'utilisateur {user.FirstName} {user.LastName} au role Secrétaire";
               return View(model);
            }
         }
			else
			{
            return View(model);
         }
         ViewBag.Message = $"Secretaire enregistrer avec succès!";
         return View(model);
      }
   }
}
