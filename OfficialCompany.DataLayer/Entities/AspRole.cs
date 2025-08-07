using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.DataLayer.Entities
{
	public class AspRole:IdentityRole<int>
	{
		public bool IsActive { get; set; }
	}
}
