using NewsLetterENIsoTimer.Models;
using NewsLetterENIsoTimer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterENIsoTimer.Services
{
    public class UserService : IUserService
    {
        private readonly FuncDbContext _db;

        public UserService(FuncDbContext db)
        {
            _db = db;
        }

        public List<NewsLetter> GetUsers()
        {
            var result = _db.NewsLetters.ToList();
            return result;
        }
    }
}
