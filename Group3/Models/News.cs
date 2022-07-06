using System;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class News
    {

        [Key]
        public string Id { get; set; }

        public string PostId { get; set; }



        public string Header { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }


    }
}
