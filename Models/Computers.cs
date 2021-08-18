using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compbuild.Models{
    public class Computers{
        [Key]
        public int ID { get; set; }
        [Required]
        public String NAME { get; set; }
        [Required]
        public String CPU {get; set;}
        [Required]
        public String GPU { get; set; }
        [Required]
        public String RAM { get; set; }
        [Required]
        public String CASE { get; set; }
        [Required]
        public String PSU { get; set; }
        [Required]
        public String STORAGE { get; set; }

        public String SECONDARY { get; set; }

        [Required]
        public String IMAGE_URL { get; set; } 

        [Required]
        public int PRICE { get; set; }

    }
}