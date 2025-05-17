using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Threading.Tasks;

namespace SupermarketWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SupermarketContext _context;

        public RegisterModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Verificar si ya existe un usuario con el mismo email
            var existingUser = _context.User.FirstOrDefault(u => u.Email == User.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "El correo ya está registrado.");
                return Page();
            }

            // Guardar usuario en la base de datos
            _context.User.Add(User);
            await _context.SaveChangesAsync();

            // Redirigir al login u otra página
            return RedirectToPage("/Account/Login");
        }
    }
}
