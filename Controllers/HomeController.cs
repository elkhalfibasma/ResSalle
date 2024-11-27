using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ResSalle.Models;
using System.Diagnostics; // Importer ce namespace pour utiliser l'attribut [Authorize]

namespace ResSalle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Page d'accueil
        public IActionResult Index()
        {
            return View();
        }

        // Page de confidentialité
        public IActionResult Privacy()
        {
            return View();
        }

        // Tableau de bord de l'utilisateur
        [Authorize] // Cette action est protégée et ne sera accessible qu'aux utilisateurs authentifiés
        public IActionResult Dashboard()
        {
            // Vous pouvez récupérer des données spécifiques à l'utilisateur connecté ici
            // Par exemple, vous pouvez récupérer les réservations ou autres informations liées à l'utilisateur.

            return View();
        }

        // Gestion des erreurs
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
