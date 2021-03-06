using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskContext _context;

        public DetailsModel(MegaDeskRazor.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }
        public Desk Desk { get; set; }
        public Delivery Delivery { get; set; }
        public DesktopMaterial DesktopMaterial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).FirstOrDefaultAsync(m => m.DeskQuoteId == id);

            Desk = await _context.Desk.FirstOrDefaultAsync(m => m.DeskId == this.DeskQuote.DeskId);
            DesktopMaterial = await _context.DesktopMaterial.FirstOrDefaultAsync(m => m.DesktopMaterialId == this.Desk.DesktopMaterialId);
            Delivery = await _context.Delivery.FirstOrDefaultAsync(m => m.DeliveryId == this.DeskQuote.DeliveryId);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
