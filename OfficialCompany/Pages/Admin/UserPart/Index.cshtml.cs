using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficialCompany.Core.DTOs;
using OfficialCompany.Core.Services.Interfaces;
using OfficialCompany.DataLayer.Entities;

namespace OfficialCompany.Pages.Admin.UserPart
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
		public IndexModel(IUserService userService)
		{
			_userService = userService;
		}
		public UserForAdminViewModel userModel { get; set; }
		public void OnGet(short pageId=1,string filterUsername="")
        {
			userModel=_userService .GetUsers(pageId,filterUsername);
		}
    }
}
