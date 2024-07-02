using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterIsoQueue.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateStamp { get; set; }



        [Required]
        [StringLength(255)]
        public string HeadLine { get; set; }

        [Required]
        [StringLength(1000)]
        public string LinkText { get; set; }


    }
}
