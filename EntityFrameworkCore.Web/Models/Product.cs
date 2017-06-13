using System.Collections.Generic;

namespace EntityFrameworkCore.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


        //many to many relation between Product and Shops using ShopProduct class
        public ICollection<ShopProduct> ProductShops{get;set;}
    }
}