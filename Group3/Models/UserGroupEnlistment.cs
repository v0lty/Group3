using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class UserGroupEnlistment
    {

        public int UserGroupEnlistmentID { get; set; }

        public int CategoryId { get; set; }

        public string ApplicationUserID { get; set; }



        public virtual Category Category { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
