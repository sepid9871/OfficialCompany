using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficialCompany.Core.DTOs;
using OfficialCompany.Core.Services.Interfaces;

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
        }
		public async Task<ActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var res = await _userService.CreateUserAsync(userModel);
			return RedirectToPage("Index", new { pageId = 1, filterUsername = "" });

		}
	}
}
