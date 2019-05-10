using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Board.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Display(Name = "Your question")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Votes")]
        public int VoteCount { get; set; }

        [Display(Name = "Answers")]
        public int AnswerCount { get; set; }

        [Display(Name = "Views")]
        public int ViewrCount { get; set; }

        //public string Body { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        //public SelectList CategoryDropDownList { get; set; }

    }
}