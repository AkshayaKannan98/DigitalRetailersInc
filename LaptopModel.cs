using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    [Table("tblLaptop")]
    public class LaptopModel
    {
        [Key]
        public int Sno { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Specifications { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

    }
}
