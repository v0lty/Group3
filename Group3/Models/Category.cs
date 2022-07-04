using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Models
{
    public class Category
    {

        public int Id { get; set; }

        public string CategoryName { get; set; }

        public List<Topic> Topics { get; set; }


    }
}
