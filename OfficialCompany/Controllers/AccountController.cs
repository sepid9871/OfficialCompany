using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficialCompany.Core.DTOs;
using OfficialCompany.DataLayer.Entities;

namespace OfficialCompany.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AspUser> _userManager;
		private readonly SignInManager<AspUser> _signInManager;

		public AccountController(UserManager<AspUser> userManager, SignInManager<AspUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[Route("login")]
		public IActionResult Login()
		{
			return View();
		}
		[Route("login")]
		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel user)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("Username", "Please Enter Username and Password!");
			}

			var res = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
			if (res.Succeeded)
			{
				return RedirectToPage("/Admin/UserPart/Home");
			}
			else
			{
				ModelState.AddModelError("Username", "Username or Password is incorrect!");
			}
			return View();
		}
	}
}