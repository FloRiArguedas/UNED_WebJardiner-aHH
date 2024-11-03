using Newtonsoft.Json;
using P1_FloricelaArguedas_WebAppJHH.Models;
using System.Text;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public class ServicioMaquinaria : IServicioMaquinaria
    {
        private string _url;

        public ServicioMaquinaria()
        {
            _url = "http://localhost:5089";
        }

        //MÉTODOS

        public async Task<List<Maquinaria>> Index()
        {
            List<Maquinaria> ListadeMaquinaria = new List<Maquinaria>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.GetAsync("api/Maquinaria/Index");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Maquinaria>>(json_respuesta);
                ListadeMaquinaria = resultado;
            }
            return ListadeMaquinaria;
        }

        public async Task<Maquinaria> ObtenerMaquinaria(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            //Envío solicitud GET a la URL en el server con el id en la URL
            var response = await client.GetAsync($"api/Maquinaria/GetOne/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var MaquinariaObtenida = JsonConvert.DeserializeObject<Maquinaria>(json_respuesta);
                return MaquinariaObtenida;
            }
            else
            {
                return null;
            }
        }

        public async Task<Maquinaria> Create(Maquinaria MaquinariaNueva)
        {

            //Creo la instancia para solicitudes HTTP
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url); //URL Base de la raíz del API

            //Convierto a cadena JSON el Mantenimiento nuevo
            var MaquinariaCreada = new StringContent(JsonConvert.SerializeObject(MaquinariaNueva), Encoding.UTF8, "application/json");
            //Envío solicitud POST a la URL en el server con el cliente en el body
            var response = await client.PostAsync($"api/Maquinaria/Create", MaquinariaCreada);


            if (response.IsSuccessStatusCode) //Si la respuesta es exitosa leo la respuesta como JSON
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                //Deserealizo el JSON en Objeto y lo retorno.
                var NuevaMaquinaria = JsonConvert.DeserializeObject<Maquinaria>(json_respuesta);
                return NuevaMaquinaria;
            }
            else
            {
                return null;
            }
        }

        public async Task<Maquinaria> Editar(Maquinaria MaquinariaAEditar)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);


            var MaquinariaActualizar = new StringContent(JsonConvert.SerializeObject(MaquinariaAEditar), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Maquinaria/Editar", MaquinariaActualizar);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var UpdatedMachinery = JsonConvert.DeserializeObject<Maquinaria>(json_respuesta);
                return UpdatedMachinery;
            }
            else
            {
                throw new HttpRequestException($"Error al editar la Maquinaria: {response.StatusCode}");
                return null;
            }
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.DeleteAsync($"api/Maquinaria/Delete/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al eliminar la maquinaria: {response.StatusCode}");
            }

        }

    }
}
