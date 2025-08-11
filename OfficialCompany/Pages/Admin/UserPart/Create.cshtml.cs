using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficialCompany.Core.DTOs;
using OfficialCompany.Core.Services.Interfaces;
using OfficialCompany.DataLayer.Entities;

namespace OfficialCompany.Pages.Admin.UserPart
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
		public CreateModel(IUserService userService)
		{
			_userService = userService;
		}
		[BindProperty]
		public CreateUsersViewModel	 userModel { get; set; }
		public void OnGet()
        {
			GetRoleList();

		}
		public async Task<ActionResult> OnPost(int roleList)
		{
			if (!ModelState.IsValid)
			{
				GetRoleList();
				return Page();
			}
			userModel.RoleId = roleList;
			var res = await _userService.CreateUserAsync(userModel);
			if (!res.Succeeded)
			{
				foreach (var e in res.Errors)
				{
					var key = e.Code switch
					{
						"DuplicateUserName" => "userModel.Username",
						"PasswordTooShort" or "PasswordRequiresNonAlphanumeric" or
						"PasswordRequiresDigit" or "PasswordRequiresUpper" or "PasswordRequiresLower"
							=> "userModel.Password",
						_ => string.Empty 
					};

					ModelState.AddModelError(key, e.Description);
				}
				GetRoleList();
				return Page();
			}
			return RedirectToPage("Index", new { pageId = 1, filterUsername = "" });

		}
		private void GetRoleList()
		{
			ViewData["Roles"]= _userService.GetRoles();
		}
	}
}
