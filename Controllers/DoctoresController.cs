using Microsoft.AspNetCore.Mvc;
using MvcMascotas.Models;
using MvcMascotas.Repositories;

namespace MvcMascotas.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;
        public DoctoresController()
        {

            this.repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult DoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }


        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores = this.repo.FindDoctoresByEspecialidad(especialidad);
            return View(doctores);
        }

    }
}
