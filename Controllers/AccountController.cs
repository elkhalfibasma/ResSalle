using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data;
using Reservation.Models;
using System.Security.Claims;
using System.Security.Cryptography;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Affiche la page de connexion sans layout
    public IActionResult Login()
    {
        ViewData["Layout"] = null;
        return View();
    }

    // Traite la soumission du formulaire de connexion ou d'inscription
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, bool IsRegistering)
    {
        if (IsRegistering)
        {
            // Logique d'inscription
            if (ModelState.IsValid)
            {
                // Vérification de l'unicité du nom d'utilisateur ou de l'email
                if (_context.Utilisateurs.Any(u => u.Username == model.Username || u.Email == model.Email))
                {
                    ModelState.AddModelError("Username", "Ce nom d'utilisateur ou email est déjà pris.");
                    return View(model);
                }

                // Hachage du mot de passe
                var salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt); // Générer un salt aléatoire
                }

                var passwordHash = KeyDerivation.Pbkdf2(
                    model.Password,
                    salt,
                    KeyDerivationPrf.HMACSHA256,
                    10000, // Nombre d'itérations
                    32 // Taille du hash
                );

                var utilisateur = new Utilisateur
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = salt,
                    IsAdmin = false // Définir si l'utilisateur est admin ou non
                };

                // Sauvegarder l'utilisateur dans la base de données
                _context.Utilisateurs.Add(utilisateur);
                await _context.SaveChangesAsync();

                // Connexion immédiate après l'inscription
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, utilisateur.Username),
                    new Claim(ClaimTypes.Role, utilisateur.IsAdmin ? "Admin" : "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Authentification de l'utilisateur
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Rediriger vers le tableau de bord après l'inscription et la connexion
                return RedirectToAction("Dashboard", "Home");
            }

            return View(model);
        }
        else
        {
            // Logique de connexion
            if (ModelState.IsValid)
            {
                var utilisateur = _context.Utilisateurs
                    .FirstOrDefault(u => u.Email == model.Email || u.Username == model.Username);

                if (utilisateur == null)
                {
                    ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe incorrect.");
                    return View(model);
                }

                var hashedPassword = KeyDerivation.Pbkdf2(
                    model.Password,
                    utilisateur.PasswordSalt,
                    KeyDerivationPrf.HMACSHA256,
                    10000,
                    32
                );

                if (hashedPassword.SequenceEqual(utilisateur.PasswordHash))
                {
                    // Connexion réussie, créer un cookie d'authentification
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utilisateur.Username),
                        new Claim(ClaimTypes.Role, utilisateur.IsAdmin ? "Admin" : "User")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Authentification de l'utilisateur
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Rediriger vers le tableau de bord de l'utilisateur
                    return RedirectToAction("Dashboard", "Home");
                }

                ModelState.AddModelError("", "Nom d'utilisateur ou mot de passe incorrect.");
            }

            return View(model);
        }
    }

    // Déconnexion de l'utilisateur
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
