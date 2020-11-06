using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        [Display(Name = "Shipping")]
        public string ShippingName { get; set; }

        public decimal ShippingUnder1000 { get; set; }

        public decimal ShippingBetween { get; set; }

        public decimal ShippingOver2000 { get; set; }
    }
}
