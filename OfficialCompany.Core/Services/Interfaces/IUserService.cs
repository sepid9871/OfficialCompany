using Microsoft.AspNetCore.Identity;
using OfficialCompany.Core.DTOs;
using OfficialCompany.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.Services.Interfaces
{
	public interface IUserService
	{
		UserForAdminViewModel GetUsers(short pageId=1,string filterUsername="");
		Task<IdentityResult> CreateUserAsync(CreateUsersViewModel model);
	}
}
