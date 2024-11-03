using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public interface IServicioMantenimiento
    {
        public Task<List<Mantenimiento>> Index();

        public Task<Mantenimiento> ObtenerMantenimiento(int id);

        public Task<Mantenimiento> Create(Mantenimiento MantenimimentoNuevo);

        public Task<Mantenimiento> Editar(Mantenimiento MantenimientoEditado);

        public Task Delete(int id);

    }
}
