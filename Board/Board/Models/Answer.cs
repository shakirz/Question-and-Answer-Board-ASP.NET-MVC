using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Board.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Your answer")]
        public string Body { get; set; }
        public int QuestionId { get; set; }
    }
}