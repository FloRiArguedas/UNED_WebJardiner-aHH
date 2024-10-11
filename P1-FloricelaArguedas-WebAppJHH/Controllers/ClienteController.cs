using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class ClienteController : Controller
    {
        public static IList<Cliente> listadeClientes = new List<Cliente>();
        // GET: ClienteController
        public ActionResult Index()
        {
            if (!listadeClientes.Any())
            { 
                Cliente cliente = new Cliente
                {
                    Id = 1,
                    Nombre = "Floricela",
                    Provincia = "Heredia",
                    Canton = "Santo Domingo",
                    Distrito = "Santo Domingo",
                    DireccionExacta = "Contiguo Templo Católico",
                    MantenimientoInvierno = "Quincenal",
                    MantenimientoVerano = "Mensual"
                };
                listadeClientes.Add(cliente);
            }
            return View(listadeClientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            if (listadeClientes.Any())
            {
                Cliente clienteALeer = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                return View(clienteALeer);
            }
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente clienteNuevo)
        {
            try
            {
                if (clienteNuevo == null)
                {
                    return View();
                }
                else { 
                    listadeClientes.Add (clienteNuevo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (listadeClientes.Any()) {
                Cliente clienteaEditar = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                return View(clienteaEditar);
            }
            return View();

        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente clienteEditado)
        {
            try
            {
                if (listadeClientes.Any())
                {
                    Cliente clienteaEditar = listadeClientes.FirstOrDefault(cliente => cliente.Id == clienteEditado.Id);
                    clienteaEditar.Nombre = clienteEditado.Nombre;
                    clienteaEditar.Provincia = clienteEditado.Provincia;
                    clienteaEditar.Canton = clienteEditado.Canton;
                    clienteaEditar.Distrito = clienteEditado.Distrito;
                    clienteaEditar.DireccionExacta = clienteEditado.DireccionExacta;
                    clienteaEditar.MantenimientoInvierno = clienteEditado.MantenimientoInvierno;
                    clienteaEditar.MantenimientoVerano = clienteEditado.MantenimientoVerano;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (listadeClientes.Any())
            {
                Cliente clienteAEliminar = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                return View(clienteAEliminar);
            }
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente clienteAEliminar)
        {
            try
            {
                if (clienteAEliminar == null)
                {
                    return View();
                }
                else
                {
                    listadeClientes.RemoveAt(clienteAEliminar.Id-1);
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
