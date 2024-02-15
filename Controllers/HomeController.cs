using Microsoft.AspNetCore.Mvc;
using MvcMascotas.Models;

namespace MvcMascotas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VistaMascota()
        {
            List<Mascota> mascotas = new List<Mascota>();

                Mascota mascota = new Mascota();
                mascota.Nombre = "rata";
                mascota.Edad = 1;
                mascotas.Add(mascota);
            return View(mascota);
        }
    }
}

