using System.Collections.Generic;

namespace EntityFrameworkCore.Web.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //many to 1 relation between Shop and Employees
        public ICollection<Employee> Employees { get; set; }


        //many to many relation between Shop and Products using ShopProduct class
        public ICollection<ShopProduct> ShopProducts { get; set; }
    }
}