using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace SupermarketWEB.Pages.Products

{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketWEB.Data.SupermarketContext _context;
        public IndexModel(SupermarketWEB.Data.SupermarketContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}