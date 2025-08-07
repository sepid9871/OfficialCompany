using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.DataLayer.Entities
{
	public class AspUser:IdentityUser<int>
	{
		public string FullName { get; set; } = string.Empty;
		public string ActivationCode { get; set; } = string.Empty;
		public bool IsActive { get; set; } = false;
		public DateTime RegDate { get; set; }
	}
}
