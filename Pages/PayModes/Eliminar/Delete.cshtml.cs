using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes

{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public PayMode PayMode { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }
            var PayModes = await _context.PayModes.FirstOrDefaultAsync(m => m.Id == id);
            if (PayModes == null)
            {
                return NotFound();
            }
            else
            {
                PayMode = PayModes;
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();

            }
            var PayModes = await _context.PayModes.FindAsync(id);
            if (PayModes != null)
            {
                PayMode = PayModes;
                _context.PayModes.Remove(PayMode);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/PayModes/Index");
        }


    }
}
