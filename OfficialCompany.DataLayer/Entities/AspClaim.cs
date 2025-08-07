using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.DataLayer.Entities
{
	public class AspClaim
	{
		public AspClaim()
		{
			RoleClaims = new HashSet<AspRoleClaims>();
		}
		public int ClaimId { get; set; }
		public string ClaimName { get; set; }
		public string ClaimValue { get; set; }
		public int? ParentId { get; set; }		
		public bool IsActive { get; set; }
		public virtual ICollection<AspRoleClaims> RoleClaims { get; set; }
	}
}
