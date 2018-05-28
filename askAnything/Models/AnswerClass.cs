using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace askAnything.Models
{
    public class AnswerModel
    {
        public int Answer_id { get; set; }

        public int User_id { get; set; }

        public int Question_id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Answer_date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Info_file { get; set; }

    }
}