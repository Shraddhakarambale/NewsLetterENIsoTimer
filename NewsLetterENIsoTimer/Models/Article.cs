using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterENIsoTimer.Models
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime DateStamp { get; set; }
        public string HeadLine { get; set; }
        public string ContentSummary { get; set; }
        public string ImageLink { get; set; }
        public string Category1 { get; set; }
    }
}
