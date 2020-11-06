using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DeliveryId"] = new SelectList(_context.Delivery, "DeliveryId", "ShippingName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.DesktopMaterial, "DesktopMaterialId", "DesktopMaterialName");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DesktopMaterial DesktopMaterial { get; set; }

        [BindProperty]
        public Delivery Delivery { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Desk.DesktopMaterialId = DesktopMaterial.DesktopMaterialId;
            _context.Desk.Add(Desk);

            await _context.SaveChangesAsync();

            DeskQuote.DeskId = Desk.DeskId;
            DeskQuote.DeliveryId = Delivery.DeliveryId;
            DeskQuote.QuoteDate = DateTime.Now;
            DeskQuote.QuotePrice = DeskQuote.getQuotePrice(_context);
            _context.DeskQuote.Add(DeskQuote);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
