using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace askAnything.Models
{
    public class FeedbackModel
    {
        public int Feedback_id { get; set; }

        public int User_id { get; set; }

        public string Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Feedback_date { get; set; }

        [DataType(DataType.MultilineText)]
        public string User_file { get; set; }

        [DataType(DataType.MultilineText)]
        public string Admin_file { get; set; }

    }
}