using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        public Desk() 
        {
            DrawerPrice = 50.00M;
        }

        public int DeskId { get; set; }
        
        [Required, Range(24, 96)]
        public decimal Width { get; set; }

        [Required, Range(12, 48)]
        public decimal Depth { get; set; }

        [Required, Range(0, 7), Display(Name = "# of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Required]
        public decimal DrawerPrice { get; set; }

        public int DesktopMaterialId { get; set; }

        // Navigation property:
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}
