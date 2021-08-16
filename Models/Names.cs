using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compbuild.Models{
    public class Names{
        [Key]
        public int ID { get; set; }
        public String NAME { get; set; }

    }
}