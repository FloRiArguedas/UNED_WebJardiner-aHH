using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;
using P1_FloricelaArguedas_WebAppJHH.Services;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class ClienteController : Controller
    {

        public static IList<Cliente> listadeClientes = new List<Cliente>();

        //Variable Global para la interfaz de Servicio
        private readonly IServicioCliente _iservicioCliente;

        //Constructor para instanciar la variable Global
        public ClienteController(IServicioCliente iservicioCliente)
        {
            _iservicioCliente = iservicioCliente;

        }

        //MÉTODOS

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            List<Cliente> listadeClientes;
            listadeClientes = await _iservicioCliente.Index();
            return View(listadeClientes);
        }


        // GET: ClienteController/Details/
        public async Task<ActionResult> Details(int id)
        {

            Cliente clienteALeer = await _iservicioCliente.ObtenerCliente(id);
            return View(clienteALeer);
        }

        // GET: ClienteController/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: ClienteController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(int id)
        {
            Cliente clienteAbuscar = await _iservicioCliente.ObtenerCliente(id);
            if (clienteAbuscar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(clienteAbuscar);
            }
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente clienteNuevo)
        {
            try
            {
                await _iservicioCliente.Create(clienteNuevo);
                if (clienteNuevo == null)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ClienteController/Edit/
        public async Task<ActionResult> Edit(int id)
        {          
            Cliente clienteaEditar = await _iservicioCliente.ObtenerCliente(id);
            if (clienteaEditar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(clienteaEditar);
            }
        }

        // POST: ClienteController/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Cliente clienteEditado)
        {
            try
            {
                await _iservicioCliente.Editar(clienteEditado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/
        public async Task<ActionResult> Delete(int id)
        {
            Cliente clienteAEliminar = await _iservicioCliente.ObtenerCliente(id);
            if (clienteAEliminar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(clienteAEliminar);
            }
        }

        // POST: ClienteController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteClient(int id)
        {
            try
            {
               await _iservicioCliente.Delete(id);
               return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("Error al querer eliminar el cliente");
            }
        }

    }
}

