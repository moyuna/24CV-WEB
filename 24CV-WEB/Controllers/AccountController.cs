using _24CV_WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _24CV_WEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AspNetUser> _userManager;
		private readonly RoleManager<AspNetRole> _roleManager;
		private readonly SignInManager<AspNetUser> _signInManager;

        public AccountController(UserManager<AspNetUser> userManager,
			SignInManager<AspNetUser> signInManager, RoleManager<AspNetRole> roleManager)
        {
            _userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
        }

		public IActionResult Login()
		{
			return View();	
		}

		public IActionResult AccessDenied()
		{
			return View();
		}


        [HttpPost]
        public async Task<IActionResult> Login(string user, string pass)
		{
			var result = await _userManager.FindByEmailAsync(user);

			if (result != null)
			{
				var resultSignIn = await _signInManager.PasswordSignInAsync(user, pass, false, false);

				if (resultSignIn.Succeeded)
				{
					return RedirectToAction("Index","Home");
				}
			}

			return View();
		}

		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			await _signInManager.SignOutAsync();
			HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
			return RedirectToAction("Login","Account");
		}

		public bool SeedUser()
		{
			AspNetRole roleAdmin = new AspNetRole() { Name = "Administrador" };
			AspNetRole roleManager = new AspNetRole() { Name = "Manager" };

			AspNetUser userAdmin = new AspNetUser() 
			{ Email = "jm.torres1592@gmail.com", UserName = "jm.torres1592@gmail.com" };
			AspNetUser userManager = new AspNetUser() 
			{ Email = "moises.torres1992@gmail.com", UserName = "moises.torres1992@gmail.com" };

			var existeRol = _roleManager.FindByNameAsync(roleAdmin.Name).Result;
			if (existeRol == null)
			{
				var resultRol = _roleManager.CreateAsync(roleAdmin).Result;
			}
			var existeRolManager = _roleManager.FindByNameAsync(roleManager.Name).Result;
			if (existeRolManager == null)
			{
				var resultRol = _roleManager.CreateAsync(roleManager).Result;
			}

			var existUserAdmin = _userManager.FindByEmailAsync(userAdmin.Email).Result;

			if (existUserAdmin == null)
			{
				var resultUser = _userManager.CreateAsync(userAdmin, "Demo@24cv").Result;
				_userManager.AddToRoleAsync(userAdmin, roleAdmin.Name);
			}

			var existUserManager = _userManager.FindByEmailAsync(userManager.Email).Result;

			if (existUserManager == null)
			{
				var resultUser = _userManager.CreateAsync(userManager, "Demo@24cv").Result;
				_userManager.AddToRoleAsync(userManager, roleManager.Name);
			}

			return true;
		}
	}
}
