using Microsoft.EntityFrameworkCore;
using NewsLetterENIsoTimer.Data;
using NewsLetterENIsoTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterENIsoTimer.Services
{
    public class ArticleService : IArticleService
    {
        private readonly FuncDbContext _db;

        public ArticleService(FuncDbContext db)
        {

            _db = db;
        }

        public List<Article> GetArticlesByCategory(string cat1, string cat2, string cat3, string cat4)
        {
            var articles = _db.Articles
                .Where(a => a.Category1 == cat1 || a.Category1 == cat2 || a.Category1 == cat3 || a.Category1 == cat4)
                .OrderByDescending(a => a.DateStamp)
                .Take(5).ToList();

            return articles;
        }

    }
}
