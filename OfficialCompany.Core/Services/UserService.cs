using Azure;
using Microsoft.AspNetCore.Identity;
using OfficialCompany.Core.DTOs;
using OfficialCompany.Core.Services.Interfaces;
using OfficialCompany.DataLayer.Context;
using OfficialCompany.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.Services
{
	public class UserService : IUserService
	{
		private readonly OfficialWebsiteContext _db;
		private readonly UserManager<AspUser> _manager;

		public UserService(OfficialWebsiteContext db, UserManager<AspUser> manager)
		{
			_db = db;
			_manager = manager;			
		}
		public UserForAdminViewModel GetUsers(short pageId = 1, string filterUsername = "")
		{
			int take = 9;
			int skip = (pageId - 1) * take;

			var res = _db.Users.Where(x => x.UserName!.Contains(string.IsNullOrEmpty(filterUsername) ? "" : filterUsername.Trim())).Select(x => new UsersViewModel()
			{
				Id = x.Id,
				Username = x.UserName,
				Cellphone = x.PhoneNumber,
				FullName = x.FullName,
				IsActive = x.IsActive,

			}).ToList();

			var result = new UserForAdminViewModel()
			{
				Users = res.OrderBy(x => x.Username).Skip(skip).Take(take).ToList(),
				PageCount = (res.Count() / take) + 1,
				CurrentPage = pageId
			};
			return result;
		}

		public async Task<IdentityResult> CreateUserAsync(CreateUsersViewModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Username))
				return IdentityResult.Failed(new IdentityError { Code = "UsernameRequired", Description = "Username is required." });

			if (string.IsNullOrWhiteSpace(model.Password))
				return IdentityResult.Failed(new IdentityError { Code = "PasswordRequired", Description = "Password is required." });

			if (await _manager.FindByNameAsync(model.Username) is not null)
				return IdentityResult.Failed(new IdentityError { Code = "DuplicateUserName", Description = "Username already taken." });

			//if (!string.IsNullOrWhiteSpace(model.Email))
			//{
			//	var byEmail = await _manager.FindByEmailAsync(model.Email);
			//	if (byEmail is not null)
			//		return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "Email already in use." });
			//}
			AspUser identifyUser = new AspUser();

			identifyUser.UserName = model.Username;
			identifyUser.Email = "";
			identifyUser.FullName = model.FullName;
			identifyUser.IsActive = model.IsActive;
			identifyUser.RegDate = DateTime.Now;
			identifyUser.LockoutEnabled = false;
			identifyUser.ActivationCode = Guid.NewGuid().ToString("N");
			identifyUser.EmailConfirmed = true;
			identifyUser.PhoneNumberConfirmed = true;


			var result = await _manager.CreateAsync(identifyUser, model.Password);
			if (!result.Succeeded) return result;

			
			//if (model.Roles is { Count: > 0 })
			//{
			//	var addRoles = await _manager.AddToRolesAsync(user, model.Roles);
			//	if (!addRoles.Succeeded) return addRoles;
			//}	

			return IdentityResult.Success;


		}

		
	}
}
