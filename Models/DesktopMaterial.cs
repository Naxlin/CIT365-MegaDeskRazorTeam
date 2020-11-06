using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class DesktopMaterial 
    {
        public int DesktopMaterialId { get; set; }

        [Display(Name = "Material")]
        public string DesktopMaterialName { get; set; }

        public decimal Cost { get; set; }
    }
}
