using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public interface IServicioEmpleado
    {
        public Task<List<Empleado>> Index();

        public Task<Empleado> ObtenerEmpleado(int id);

        public Task<Empleado> Create(Empleado EmpleadoNuevo);

        public Task<Empleado> Editar(Empleado EmpleadoEditado);

        public Task Delete(int id);

    }
}
