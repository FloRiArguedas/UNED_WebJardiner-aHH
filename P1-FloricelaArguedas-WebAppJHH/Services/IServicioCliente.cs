using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public interface IServicioCliente
    {
        public Task<List<Cliente>> Index();

        public Task<Cliente> ObtenerCliente(int id);

        public Task<Cliente> Create(Cliente ClienteNuevo);

        public Task<Cliente> Editar(Cliente ClienteEditado);

        public Task Delete(int id);

        public Task<List<Cliente>> GetReportWeek();
    }

}
