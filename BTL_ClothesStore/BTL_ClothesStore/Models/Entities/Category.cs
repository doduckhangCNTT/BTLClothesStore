using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
