using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class AddressModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Pincode { get; set; }
    }
}
