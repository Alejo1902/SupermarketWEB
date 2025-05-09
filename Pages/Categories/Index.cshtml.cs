using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly SupermarketContext _context;
        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Category> categories { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.categories != null)
            {
                categories = await _context.Categories.ToListAsync();
            }
        }
    }
}