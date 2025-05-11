using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products

{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var Products = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (Products == null)
            {
                return NotFound();
            }
            else
            {
                Product= Products;
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();

            }
            var Products = await _context.Products.FindAsync(id);
            if (Products != null)
            {
                Product = Products;
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Products/Index");
        }


    }
}
