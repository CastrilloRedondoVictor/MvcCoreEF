using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Models;
using MvcCoreEF.Repositories;

namespace MvcCoreEF.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamentos repository;

        public DepartamentosController(RepositoryDepartamentos repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repository.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repository.FindDepartamentoAsync(id);
            return View(departamento);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repository.InsertDepartamentoAsync(departamento.DeptNo, departamento.Dnombre, departamento.Loc);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Departamento departamento = await this.repository.FindDepartamentoAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Departamento departamento)
        {
            await this.repository.UpdateDepartamentoAsync(departamento.DeptNo, departamento.Dnombre, departamento.Loc);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.DeleteDepartamentoAsync(id);
            return RedirectToAction("Index");
        }
    }
}
