using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{

    /*public enum DeskTopMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer,
    }*/

    public class Desk
    {
        public int DeskId { get; set; }
        
        [Required, Range(24, 97)]
        public decimal Width { get; set; }

        [Required, Range(12, 49)]
        public decimal Depth { get; set; }

        [Required, Range(0, 8)]
        public int NumberOfDrawers { get; set; }

        public int DesktopMaterialId { get; set; }

        public DesktopMaterial DesktopMaterial { get; set; }
    }
}
