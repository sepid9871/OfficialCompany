using OfficialCompany.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.Services.Interfaces
{
	public interface INewsService
	{
		List<NewsViewModel> GetLastNews();
	}
}
