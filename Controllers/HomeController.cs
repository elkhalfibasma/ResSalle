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

        // Page de confidentialit�
        public IActionResult Privacy()
        {
            return View();
        }

        // Tableau de bord de l'utilisateur
        [Authorize] // Cette action est prot�g�e et ne sera accessible qu'aux utilisateurs authentifi�s
        public IActionResult Dashboard()
        {
            // Vous pouvez r�cup�rer des donn�es sp�cifiques � l'utilisateur connect� ici
            // Par exemple, vous pouvez r�cup�rer les r�servations ou autres informations li�es � l'utilisateur.

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
