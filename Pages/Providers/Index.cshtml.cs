using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;
        public IndexModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        public IList<Provider> Providers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Providers = await _context.Providers.ToListAsync();
        }
    }
}