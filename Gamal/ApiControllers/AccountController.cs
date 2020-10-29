using Gamal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gamal.ApiControllers
{

	[Route("api/[controller]")]
	
	public class AccountController : Controller
	{

		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly ILogger<AccountController> logger;
		private readonly IConfiguration config;
		private readonly RoleManager<IdentityRole> roleManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser>
			 signInManager, ILogger<AccountController> logger, IConfiguration config,
			 RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.logger = logger;
			this.config = config;
			this.roleManager = roleManager;
		}

		[HttpPost]
		public JsonResult Post([FromBody] UserLogin userLogin)
		{
			var result = signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false).GetAwaiter().GetResult();
			if (result.Succeeded)
			{
				var user = userManager.FindByEmailAsync(userLogin.UserName).GetAwaiter().GetResult();
				var tokenHanlder = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(this.config["AppSetting:Key"]);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
					{
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.Role, "User"),
						new Claim(ClaimTypes.Version, ""),
					}),
					Expires = DateTime.UtcNow.AddMinutes(25),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};

				var token = tokenHanlder.CreateToken(tokenDescriptor);
				user.Token = tokenHanlder.WriteToken(token);
				if (user.Token != null)
				{
					//Save token in session object
					HttpContext.Session.SetString("JWToken", user.Token);
				}
				return Json(user);
			}
			else
			{
				return Json("User name or password is not correct");
			}
		}

		[Authorize]
		[HttpGet]
		public JsonResult Get()
		{
			return Json("The Authentication has been successfull");
		}


	}

	public class UserLogin
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
