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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskContext _context;

        // sort variables
        public string CustomerSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IndexModel(MegaDeskRazor.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            CustomerSort = sortOrder == "Customer" ? "customer_desc" : "Customer";
            CurrentFilter = searchString;

            IQueryable<DeskQuote> DeskQuoteIQ = from s in _context.DeskQuote select s;

            if (!String.IsNullOrEmpty(searchString))
                DeskQuoteIQ = DeskQuoteIQ.Where(s => s.CustomerName.Contains(searchString));

            switch (sortOrder)
            {
                case "customer_desc":
                    DeskQuoteIQ = DeskQuoteIQ.OrderByDescending(s => s.CustomerName);
                    break;
                case "Customer":
                    DeskQuoteIQ = DeskQuoteIQ.OrderBy(s => s.CustomerName);
                    break;
                case "date_desc":
                    DeskQuoteIQ = DeskQuoteIQ.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    DeskQuoteIQ = DeskQuoteIQ.OrderBy(s => s.QuoteDate);
                    break;
            }

            DeskQuote = await DeskQuoteIQ
                .Include(d => d.Delivery)
                .Include(d => d.Desk)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
