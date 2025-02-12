using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Models;
using MvcCoreEF.Repositories;

namespace MvcCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospitales repository;

        public HospitalesController(RepositoryHospitales repo)
        {
            this.repository = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitales = await this.repository.GetHospitalesAsync();
            return View(hospitales);
        }
        public async Task<IActionResult> Details(int id)
        {
            Hospital hospital = await this.repository.FindHospitalAsync(id);

            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hospital hospital)
        {
            await this.repository.InsertHospitalAsync(hospital.HospitalCod, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.NumCama);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.DeteleHospitalAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Hospital hospital = await this.repository.FindHospitalAsync(id);
            return View(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Hospital hospital)
        {
            await this.repository.UpdateHospitalAsync(hospital.HospitalCod, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.NumCama);
            return RedirectToAction("Index");
        }
    }
}
