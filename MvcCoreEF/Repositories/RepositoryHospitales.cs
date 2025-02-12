using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospitales
    {

        private HospitalContext context;

        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital> FindHospitalAsync(int id)
        {
            var consulta = from datos in this.context.Hospitales
                         where datos.HospitalCod == id
                         select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task InsertHospitalAsync(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = new Hospital();
            hospital.HospitalCod = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.NumCama = camas;

            await this.context.Hospitales.AddAsync(hospital);
            await this.context.SaveChangesAsync();
        }

        public async Task DeteleHospitalAsync(int id)
        {
            Hospital hospital = await this.FindHospitalAsync(id);
            this.context.Hospitales.Remove(hospital);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateHospitalAsync(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.NumCama = camas;

            await this.context.SaveChangesAsync();
        }

    }
}
