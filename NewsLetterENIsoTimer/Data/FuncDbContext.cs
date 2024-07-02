using NewsLetterENIsoTimer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsLetterENIsoTimer.Data
{
    public class FuncDbContext : IdentityDbContext<User>
    {
        public FuncDbContext(DbContextOptions<FuncDbContext> options) 
            : base(options) { }   
        
        public DbSet<Article> Articles { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }
    }
}
