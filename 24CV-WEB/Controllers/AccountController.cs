using _24CV_WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _24CV_WEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AspNetUser> _userManager;
		private readonly SignInManager<AspNetUser> _signInManager;

        public AccountController(UserManager<AspNetUser> userManager,
			SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
			_signInManager = signInManager;
        }

		public IActionResult Login()
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
	}
}
