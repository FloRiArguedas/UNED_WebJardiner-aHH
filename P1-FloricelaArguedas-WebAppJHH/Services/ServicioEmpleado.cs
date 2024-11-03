using Newtonsoft.Json;
using P1_FloricelaArguedas_WebAppJHH.Models;
using System.Collections.Generic;
using System.Text;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public class ServicioEmpleado : IServicioEmpleado
    {

        private string _url;

        public ServicioEmpleado()
        {
            _url = "http://localhost:5089";
        }

        //MÉTODOS

        public async Task<List<Empleado>> Index() 
        {
            List<Empleado> ListaEmpleados = new List<Empleado>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.GetAsync("api/Empleado/Index");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Empleado>>(json_respuesta);
                ListaEmpleados = resultado;
            }
            return ListaEmpleados;

        }


        public async Task<Empleado> ObtenerEmpleado(int id) 
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.GetAsync($"api/Empleado/GetOne/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var EmpleadoObtenido = JsonConvert.DeserializeObject<Empleado>(json_respuesta);
                return EmpleadoObtenido;
            }
            else { return null; }


        }

        public async Task<Empleado> Create(Empleado EmpleadoNuevo)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var EmpleadoCreado = new StringContent(JsonConvert.SerializeObject(EmpleadoNuevo), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/Empleado/Create", EmpleadoCreado);


            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var NewEmployee = JsonConvert.DeserializeObject<Empleado>(json_respuesta);
                return NewEmployee;
            }
            else
            { return null; }

        }

        public async Task<Empleado> Editar(Empleado EmpleadoEditado) 
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);


            var EmpleadoActualizado = new StringContent(JsonConvert.SerializeObject(EmpleadoEditado), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Empleado/Editar", EmpleadoActualizado);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var UpdatedEmployee = JsonConvert.DeserializeObject<Empleado>(json_respuesta);
                return UpdatedEmployee;
            }
            else 
            {
                throw new HttpRequestException($"Error al editar el empleado: {response.StatusCode}");
                return null; 
            }

        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.DeleteAsync($"api/Empleado/Delete/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al eliminar el Empleado: {response.StatusCode}");
            }
        
        }
    }
}
