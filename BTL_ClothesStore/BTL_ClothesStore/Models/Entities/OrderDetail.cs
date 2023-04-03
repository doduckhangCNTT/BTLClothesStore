using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public int OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
