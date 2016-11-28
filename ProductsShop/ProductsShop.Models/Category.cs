namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
