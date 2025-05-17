using SupermarketWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Buscar al usuario en la base de datos
            var userInDb = await _context.User
                .FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

            if (userInDb != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInDb.Email),
                    new Claim(ClaimTypes.Email, userInDb.Email),
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            // Si no se encuentra el usuario, agregar error
            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return Page();
        }
    }
}
