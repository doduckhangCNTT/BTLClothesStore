using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string ModifiedAt { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int AvaliablityId { get; set; }

        public virtual Availability Avaliablity { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
