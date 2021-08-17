using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compbuild.Models{
    public class Category{
        [Key] //This is an Identity Column, Primary Key
        public int ID { get; set; }
        
        [DisplayName("Category Alias")]
        [Required]
        public string NAME { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Order must be > 0")]
        public int ORDER { get; set; }
    }
}