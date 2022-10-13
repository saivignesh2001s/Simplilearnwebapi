using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simplilearnwebapi.Models
{
    public class studentmodel
    {
        [Required()]
        public int studid
        {
            get;set;
        }
        [MaxLength(20,ErrorMessage ="Can't be more than 20")]
        public string studentname
        {
            get;
            set;
        }
        [MaxLength(20, ErrorMessage = "Can't be more than 20")]
        public string subjects
        {
            get;set;
        }
        public int? marks
        {
            get;set;
        }

    }
}