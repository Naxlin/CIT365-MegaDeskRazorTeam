using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

// Models (delivery, desktopMaterial) ++

//Create.cs page (deskquote)
// DeskQuote.GetQuotePrice(_context)

// [BindProperty] Desk, DeskQuote

//onPostSync
//add desk -> await _context.SaveChangesAsync();
//set deskID, desk, quote date, quote price, add desk quote

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {
        public int DeskQuoteId { get; set; }
        public int DeskId { get; set; }

        [StringLength(256, MinimumLength = 3)]
        public string CustomerName { get; set; }

        public DateTime QuoteDate { get; set; }

        public decimal QuotePrice { get; set; }

        public int DeliveryId { get; set; }

        public Delivery Delivery { get; set; }

        public Desk Desk { get; set; }

        public int getRushOrderPrice() { return 0; }
        /*{
            int[,] rushPrices = new int[3,3];
            int rushPrice = 0;
            string line;
            int col = 0;
            int row = 0;
            StreamReader rushPriceFile = new StreamReader(@"rushOrderPrices.txt");

            try
            {
                while ((line = rushPriceFile.ReadLine()) != null)
                {
                    if (col > 2)
                    {
                        col = 0;
                        row++;
                    }
                    rushPrices[row, col] = int.Parse(line);
                    col++;
                }

                decimal surfaceArea = this.Desk.Depth * this.Desk.Width;

                if (this.DeliveryType == Delivery.Rush3Days) // row 0
                {
                    if (surfaceArea < 1000)
                        rushPrice = rushPrices[0, 0];
                    else if (surfaceArea <= 2000)
                        rushPrice = rushPrices[0, 1];
                    else if (surfaceArea > 2000)
                        rushPrice = rushPrices[0, 2];
                }
                else if (this.DeliveryType == Delivery.Rush5Days) // row 1
                {
                    if (surfaceArea < 1000)
                        rushPrice = rushPrices[1, 0];
                    else if (surfaceArea <= 2000)
                        rushPrice = rushPrices[1, 1];
                    else if (surfaceArea > 2000)
                        rushPrice = rushPrices[1, 2];
                }
                else if (this.DeliveryType == Delivery.Rush7Days) // row 2
                {
                    if (surfaceArea < 1000)
                        rushPrice = rushPrices[2, 0];
                    else if (surfaceArea <= 2000)
                        rushPrice = rushPrices[2, 1];
                    else if (surfaceArea > 2000)
                        rushPrice = rushPrices[2, 2];
                }
                else
                {
                    rushPrice = 0;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("There is an error when you calculate a rushPrice. {0}",
                    err.InnerException.ToString());
            }

            return rushPrice;
        }
        //parameter context
        public decimal getQuotePrice()
        {
            decimal price = BASE_DESK_PRICE;
            decimal surfaceArea = Desk.Width * Desk.Depth;

            //count the price of surface area 
            if(surfaceArea > 1000)
            {
                price += (surfaceArea - 1000) * SURFACE_AREA_COST;
            }


            if (this.Desk.SurfaceMaterial == DeskTopMaterial.Oak)
            {
                price += OAK_COST;
            }
            else if(this.Desk.SurfaceMaterial == DeskTopMaterial.Laminate)
            {
                price += LAMINATE_COST;
            }
            else if (this.Desk.SurfaceMaterial == DeskTopMaterial.Pine)
            {
                price += PINE_COST;
            }
            else if (this.Desk.SurfaceMaterial == DeskTopMaterial.Rosewood)
            {
                price += ROSEWOOD_COST;
            }
            else
            {
                price += VENEER_COST;
            }
            price += DRAWER_COST * this.Desk.NumberOfDrawers;

            price += getRushOrderPrice();

            return price;
        }*/
    }
}
