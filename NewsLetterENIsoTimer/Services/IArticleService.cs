using NewsLetterENIsoTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterENIsoTimer.Services
{
   public interface IArticleService
    {

        List<Article> GetArticlesByCategory(string cat1, string cat2, string cat3, string cat4);
    }
}
