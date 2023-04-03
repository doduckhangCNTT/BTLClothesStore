using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quanlity { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public int ShoppingCartId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
