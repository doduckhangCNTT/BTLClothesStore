using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
