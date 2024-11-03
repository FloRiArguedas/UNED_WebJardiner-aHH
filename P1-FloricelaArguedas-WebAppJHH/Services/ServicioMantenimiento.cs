using Newtonsoft.Json;
using P1_FloricelaArguedas_WebAppJHH.Models;
using System.Text;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public class ServicioMantenimiento : IServicioMantenimiento
    {
        private string _url;

        public ServicioMantenimiento()
        {
            _url = "http://localhost:5089";
        }


        //MÉTODOS

        public async Task<List<Mantenimiento>> Index()
        {
            List<Mantenimiento> ListadeMantenimientos = new List<Mantenimiento>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.GetAsync("api/Mantenimiento/Index");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Mantenimiento>>(json_respuesta);
                ListadeMantenimientos = resultado;
            }
            return ListadeMantenimientos;
        }


        public async Task<Mantenimiento> ObtenerMantenimiento(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            //Envío solicitud GET a la URL en el server con el id en la URL
            var response = await client.GetAsync($"api/Mantenimiento/GetOne/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var MantenimientoObtenido = JsonConvert.DeserializeObject<Mantenimiento>(json_respuesta);
                return MantenimientoObtenido;
            }
            else
            {
                return null;
            }
        }

        public async Task<Mantenimiento> Create(Mantenimiento MantenimientoNuevo)
        {

            //Creo la instancia para solicitudes HTTP
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url); //URL Base de la raíz del API

            //Convierto a cadena JSON el Mantenimiento nuevo
            var MantenimientoCreado = new StringContent(JsonConvert.SerializeObject(MantenimientoNuevo), Encoding.UTF8, "application/json");
            //Envío solicitud POST a la URL en el server con el cliente en el body
            var response = await client.PostAsync($"api/Mantenimiento/Create", MantenimientoCreado);


            if (response.IsSuccessStatusCode) //Si la respuesta es exitosa leo la respuesta como JSON
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                //Deserealizo el JSON en Objeto y lo retorno.
                var NuevoMantenimiento = JsonConvert.DeserializeObject<Mantenimiento>(json_respuesta);
                return NuevoMantenimiento;
            }
            else
            {
                return null;
            }
        }

        public async Task<Mantenimiento> Editar(Mantenimiento MantenimientoAEditar)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);


            var MantenimientoActualizar = new StringContent(JsonConvert.SerializeObject(MantenimientoAEditar), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Mantenimiento/Editar", MantenimientoActualizar);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var UpdatedMaintenance = JsonConvert.DeserializeObject<Mantenimiento>(json_respuesta);
                return UpdatedMaintenance;
            }
            else
            {
                throw new HttpRequestException($"Error al editar el Mantenimiento: {response.StatusCode}");
                return null;
            }
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.DeleteAsync($"api/Mantenimiento/Delete/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al eliminar el Mantenimiento: {response.StatusCode}");
            }

        }

    }
}
