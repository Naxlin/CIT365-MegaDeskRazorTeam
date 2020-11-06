using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {
        public int DeskQuoteId { get; set; }

        [StringLength(256, MinimumLength = 3), Display(Name = "Customer")]
        public string CustomerName { get; set; }
        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }
        [Display(Name = "Quote Price")]
        public decimal QuotePrice { get; set; }
        public int DeliveryId { get; set; }
        public int DeskId { get; set; }

        // Nagivation Properties:
        public Delivery Delivery { get; set; }
        public Desk Desk { get; set; }

        public decimal getQuotePrice(MegaDeskRazor.Data.MegaDeskContext context) 
        { 
            decimal totalPrice = 200.00M;
            /*decimal desktopMaterialPrice = 0.00M;
            var desktopMaterialPrices = context.DesktopMaterial.Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();
            desktopMaterialPrice = desktopMaterialPrices.Cost;

            decimal rushPrice = 0.00M;
            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;

            if (surfaceArea > 1000)
                totalPrice += surfaceArea - 1000;

            var rushPriceRow = context.Delivery.Where(d => d.DeliveryId == this.Delivery.DeliveryId).FirstOrDefault();
            if (surfaceArea < 1000)
                rushPrice = rushPriceRow.ShippingUnder1000;
            else if (surfaceArea <= 2000)
                rushPrice = rushPriceRow.ShippingBetween;
            else if (surfaceArea > 2000)
                rushPrice = rushPriceRow.ShippingOver2000;

            totalPrice +=  rushPrice + (this.Desk.DrawerPrice * this.Desk.NumberOfDrawers);
*/
            return totalPrice; 
        }
    }
}
