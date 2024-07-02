using NewsLetterENIsoTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterENIsoTimer.Services
{
    public interface IUserService
    {
        List<NewsLetter> GetUsers();
    }
}
