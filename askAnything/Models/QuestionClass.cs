using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace askAnything.Models
{
    public class QuestionModel
    {
        public int Question_id { get; set; }

        public int User_id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Question_date { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Type Your Question..!")]
        public string Info_file { get; set; }

        public int No_of_Answer { get; set; }
    }
}