﻿using Microsoft.AspNetCore.Mvc;
using MvcMascotas.Models;
using MvcMascotas.Repositories;

namespace MvcMascotas.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospital repo;
        
        public HospitalesController() 
        {

            this.repo = new RepositoryHospital();
        }

        public IActionResult Index(int ?eliminar)
        {
            if(eliminar != null)
            {
                this.repo.DeleteHospital(eliminar.Value);
            }


            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int idhospital)
        {
            Hospital hospital = this.repo.FindHospitalById(idhospital);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.InsertHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital insertado!!";
            return View();
        }

        public IActionResult Edit(int idhospital)
        {
            Hospital hospital = this.repo.FindHospitalById(idhospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital actualizado!!";
            return RedirectToAction("Index"); 
        }




    }
}
