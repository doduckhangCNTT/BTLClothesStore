using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class Availability
    {
        public Availability()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        //public string InStock { get; set; }
        //public string OutOfStock { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
