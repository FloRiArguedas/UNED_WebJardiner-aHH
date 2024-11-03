using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public interface IServicioMaquinaria
    {
        public Task<List<Maquinaria>> Index();

        public Task<Maquinaria> ObtenerMaquinaria(int id);

        public Task<Maquinaria> Create(Maquinaria MaquinariaNueva);

        public Task<Maquinaria> Editar(Maquinaria MaquinariaEditada);

        public Task Delete(int id);
    }
}
