using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{

    /*public enum DeliveryDay
    {
        Rush3Days,
        Rush5Days,
        Rush7Days,
        Normal14Days,
    }*/


    public class Delivery
    {
        public int DeliveryId { get; set; }

        public string ShippingName { get; set; }

        public decimal ShippingUnder1000 { get; set; }

        public decimal ShippingBetween { get; set; }

        public decimal ShippingOver2000 { get; set; }
    }
}
