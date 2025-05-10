using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers

{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Provider Provider { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var Providers = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);
            if (Providers == null)
            {
                return NotFound();
            }
            else
            {
                Provider = Providers;
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();

            }
            var Providers = await _context.Providers.FindAsync(id);
            if (Providers != null)
            {
                Provider = Providers;
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Providers/Index");
        }


    }
}
