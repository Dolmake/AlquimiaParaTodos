using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquimiaParaTodos.Models
{
    /// <summary>
    /// This class represents the options in which a product could be sold.
    /// </summary>
    public class Option
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal ExtraPrice { get; set; }   
    }
}