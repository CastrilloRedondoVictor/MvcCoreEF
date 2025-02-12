using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.DeptNo == id
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task InsertDepartamentoAsync(int idDepartamento, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.DeptNo = idDepartamento;
            departamento.Dnombre = nombre;
            departamento.Loc = localidad;
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int idDepartamento, string nombre, string localidad)
        {
            Departamento departamento = await this.FindDepartamentoAsync(idDepartamento);
            departamento.Dnombre = nombre;
            departamento.Loc = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento departamento = await this.FindDepartamentoAsync(id);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
