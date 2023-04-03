using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
