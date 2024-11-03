using Newtonsoft.Json;
using P1_FloricelaArguedas_WebAppJHH.Models;
using System.Text;

namespace P1_FloricelaArguedas_WebAppJHH.Services
{
    public class ServiceClient : IServicioCliente
    {
        private string _url;

        public ServiceClient()
        {
            _url = "http://localhost:5089";
        }


        //MÉTODOS

        public async Task<List<Cliente>> Index()
        {
            List<Cliente> listadeClientes = new List<Cliente>();
            var client = new HttpClient();
            client.BaseAddress =new Uri(_url);
            var response = await client.GetAsync("api/Cliente/Index");

            if (response.IsSuccessStatusCode) 
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Cliente>>(json_respuesta);
                listadeClientes = resultado;
            }
            return listadeClientes;
        }


        public  async Task<Cliente> ObtenerCliente(int id) 
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            //Envío solicitud GET a la URL en el server con el id en la URL
            var response = await client.GetAsync($"api/Cliente/GetOne/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var ClienteObtenido = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                return ClienteObtenido;
            }
            else {

                return null;
            }
        }


        public async Task<Cliente> Create(Cliente ClienteNuevo) {

            //Creo la instancia para solicitudes HTTP
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url); //URL Base de la raíz del API

            //Convierto a cadena JSON el cliente nuevo
            var ClienteCreado = new StringContent(JsonConvert.SerializeObject(ClienteNuevo), Encoding.UTF8, "application/json"); 
            //Envío solicitud POST a la URL en el server con el cliente en el body
            var response = await client.PostAsync($"api/Cliente/Create", ClienteCreado);


            if (response.IsSuccessStatusCode) //Si la respuesta es exitosa leo la respuesta como JSON
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                //Deserealizo el JSON en Objeto y lo retorno.
                var newClient = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                return newClient;
            }
            else
            {

                return null;
            }
        }



        public async Task<Cliente> Editar(Cliente ClienteAEditar) {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            
            var ClienteActualizar = new StringContent(JsonConvert.SerializeObject(ClienteAEditar), Encoding.UTF8, "application/json");
        
            var response = await client.PutAsync($"api/Cliente/Editar", ClienteActualizar);

            if (response.IsSuccessStatusCode) 
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                
                var UpdatedClient = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                return UpdatedClient;
            }
            else
            {
                throw new HttpRequestException($"Error al editar el cliente: {response.StatusCode}");
                return null;
            }
        }


        public async Task Delete(int id) {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = await client.DeleteAsync($"api/Cliente/Delete/{id}");
       
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error al eliminar el cliente: {response.StatusCode}");
            }

        }

    }
}
