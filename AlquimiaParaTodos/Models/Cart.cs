using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlquimiaParaTodos.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string CartOwnerID{ get; set; }
        public int Quantity{ get; set; }
        [ForeignKey("Item")]
        public int ProductID { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product Item { get; set; }
    }
}