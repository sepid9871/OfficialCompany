using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.DTOs
{
	public partial class NewsViewModel
	{
		public int NewsId { get; set; }
		public string NewsTitle { get; set; }
		public string NewsDesc { get; set; }
		public string NewsGroupTitle { get; set; }
		public DateTime NewsDate { get; set; }
		public FormFile NewsImage { get; set; }
		public string Slug { get; set; }
	}
}
