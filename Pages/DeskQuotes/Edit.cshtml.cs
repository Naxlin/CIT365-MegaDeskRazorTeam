using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskContext _context;

        public EditModel(MegaDeskRazor.Data.MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }
        [BindProperty]
        public Desk Desk { get; set; }
        // [BindProperty]
        // public DesktopMaterial DesktopMaterial { get; set; }

        // [BindProperty]
        // public Delivery Delivery { get; set; }

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
            // DesktopMaterial = await _context.DesktopMaterial.FirstOrDefaultAsync(m => m.DesktopMaterialId == this.Desk.DesktopMaterialId);
            // Delivery = await _context.Delivery.FirstOrDefaultAsync(m => m.DeliveryId == this.DeskQuote.DeliveryId);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "ShippingName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.DesktopMaterial, "DesktopMaterialId", "DesktopMaterialName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!DeskQuoteExists(DeskQuote.DeskQuoteId))
                // {
                //     return NotFound();
                // }
                // else
                // {
                //     throw;
                // }
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            DeskQuote.QuotePrice = DeskQuote.getQuotePrice(_context);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteId == id);
        }
    }
}
