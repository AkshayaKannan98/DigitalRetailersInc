using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Models
{
    public class ECommerceDbContext :DbContext
    {
        public ECommerceDbContext()
        {
        }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        { 

        }
        public DbSet<LaptopModel> Laptops { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LaptopModel>().HasData(
                new LaptopModel { Sno = 1, Image="/dell.jpg", Name = "DELL Inspiron", Specifications = "Intel UHD Graphics i7 16GB", Color = "Black",Price = 60000},
                new LaptopModel { Sno = 2, Image = "/lenovo.jpg", Name = "Lenovo", Specifications = "11th Gen Intel Core i5 8GB", Color = "Grey", Price = 65000 },
                new LaptopModel { Sno = 3, Image = "/macbookair.jpg", Name = "MacBook Air", Specifications = "1.8GHz Intel Core i5 8GB", Color = "Rosegold", Price = 92000 },
                new LaptopModel { Sno = 4, Image = "/hp.jpg", Name = "HP Ultra Thin", Specifications = "10th Gen Intel Core i3 8GB", Color = "Jet Black", Price = 35000 },
                new LaptopModel { Sno = 5, Image = "/vivobook.jpg", Name = "VivoBook", Specifications = "10th Gen Intel Core i5 8GB", Color = "Slate grey", Price = 49000 },
                new LaptopModel { Sno = 6, Image = "/microsoft.jpg", Name = "Microsoft", Specifications = "10th Gen Intel Core i5 8GB", Color = "Platinum", Price = 87000 }
                );
        }
    }
}
