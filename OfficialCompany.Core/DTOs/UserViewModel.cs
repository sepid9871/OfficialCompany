using Microsoft.AspNetCore.Identity;
using OfficialCompany.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.DTOs
{
	public partial class LoginViewModel
	{
		public int UserId { get; set; }
		[Required(ErrorMessage = "Enter Username")]
		public required string Username { get; set; }
		[Required(ErrorMessage = "Enter Password")]
		public required string Password { get; set; }
	}
	public class UserForAdminViewModel
	{
		public List<UsersViewModel> Users { get; set; }
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }

	}
	public class UsersViewModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Cellphone { get; set; }
		public string FullName { get; set; }
		public bool IsActive { get; set; }
	}
	public class EditUsersGroupsViewModel
	{
		public string Id { get; set; }
		public string Username { get; set; }
		[Display(Name = "Mobile")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string Cellphone { get; set; }
		public bool IsActive { get; set; }
		public List<CheckBoxViewModel> Roles { get; set; }
	}
	public class CreateUsersViewModel
	{
		[Display(Name = "Username")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string Username { get; set; }
		[Display(Name = "FullName")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string FullName { get; set; }
		[Display(Name = "Password")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string Password { get; set; }
		//[Display(Name = "Mobile No.")]
		//[Required(ErrorMessage = "Please Enter {0}")]
		//public string Cellphone { get; set; }

		public bool IsActive { get; set; }

	}
	public class CheckBoxViewModel
	{
		public string DisplayValue { get; set; }
		public bool IsSelected { get; set; }
	}
	public class RolesForAdminViewModel
	{
		public List<RolesViewModel> Roles { get; set; }
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }

	}
	public class RolesViewModel
	{
		public string Id { get; set; }
		[Display(Name = "Group Title")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string RoleName { get; set; }
		[Display(Name = "Desc")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string Description { get; set; }
	}
	public class EditGroupsViewModel
	{
		public string Id { get; set; }
		[Display(Name = "Group Title")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string RoleName { get; set; }
		[Display(Name = "Desc")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string Description { get; set; }
		public List<CheckBoxViewModel> Claims { get; set; }
	}
	public class ClaimsViewModel
	{
		public int Id { get; set; }
		[Display(Name = "Claim Desc")]
		[Required(ErrorMessage = "Please Enter {0}")]
		public string ClaimName { get; set; }
	}
	public class ClaimsForAdminViewModel
	{
		public List<AspClaim> Claims { get; set; }
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }

	}

}
