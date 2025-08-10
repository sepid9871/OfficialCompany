﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.DataLayer.Entities
{
	public class AspRoleClaims
	{
		[Key]
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public int ClaimId { get; set; }
	}
}
