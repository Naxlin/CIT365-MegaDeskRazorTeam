using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{

    /*public enum Material
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer,
    }*/

    public class DesktopMaterial 
    {
        public int DesktopMaterialId { get; set; }

        public string DesktopMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}
