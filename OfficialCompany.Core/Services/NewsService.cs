using Microsoft.EntityFrameworkCore;
using OfficialCompany.Core.DTOs;
using OfficialCompany.Core.Services.Interfaces;
using OfficialCompany.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCompany.Core.Services
{
	public class NewsService : INewsService
	{
		private readonly OfficialWebsiteContext _db;
		public NewsService(OfficialWebsiteContext db)
		{
			_db = db;
		}
		public List<NewsViewModel> GetLastNews()
		{
			var res = _db.News.Include(x => x.NewsGroup).Where(x => x.IsActive == true).OrderByDescending(x => x.RegDate).Take(3).Select(x => new NewsViewModel()
			{
				NewsId = x.NewsId,
				NewsTitle = x.NewsTitle,
				NewsDesc=x.NewsDesc,
				NewsGroupTitle = x.NewsGroup!.GroupTitle,
				Slug = x.Slug,
				NewsDate = x.RegDate
			}).ToList();
			return res;
		}
	}
}
