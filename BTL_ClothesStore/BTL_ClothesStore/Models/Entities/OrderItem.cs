using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class OrderItem
    {
        public int ProductId { get; set; }
        public int Quanlity { get; set; }
        public int Id { get; set; }
        public int OrderDetailId { get; set; }

        public virtual OrderDetail OrderDetail { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
