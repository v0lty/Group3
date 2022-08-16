using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class UserGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<UserGroupEnlistment> UserGroupEnlistments { get; set; }
    }

    public class UserGroupEnlistment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
