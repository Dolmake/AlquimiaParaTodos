using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlquimiaParaTodos.Models
{
    public class Order
    {
        [Key, Column(Order=0)]
        public int ID { get; set; }
        [Key, Column(Order=1)]
        [ForeignKey("Client")]
        public int UserID { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal ExtraPrice { get; set; }
        public OrderState State { get; set; }

        public virtual User Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}