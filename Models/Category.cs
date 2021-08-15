using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compbuild.Models{
    public class Category{
        [Key] //This is an Identity Column, Primary Key
        public int ID { get; set; }
        public int NAME { get; set; }
        public int ORDER { get; set; }
    }
}