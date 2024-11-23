using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;
using P1_FloricelaArguedas_WebAppJHH.Services;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class EmpleadoController : Controller
    {
        public static IList<Empleado> ListadeEmpleados = new List<Empleado>();

        //Variable Global para la interfaz de Servicio
        private readonly IServicioEmpleado _iservicioEmpleado;

        //Constructor para instanciar la variable Global

        public EmpleadoController(IServicioEmpleado iservicioEmpleado) 
        {
            _iservicioEmpleado = iservicioEmpleado;
        }

        //MÉTODOS

        // GET: EmpleadoController
        public async Task<ActionResult> Index()
        {
            List<Empleado> ListadeEmpleados;
            ListadeEmpleados = await _iservicioEmpleado.Index();
            return View(ListadeEmpleados);
        }

        // GET: EmpleadoController/Detalles (LEER)
        public async Task<ActionResult> Details(int Id)
        {
                Empleado EmpleadoALeer = await _iservicioEmpleado.ObtenerEmpleado(Id);
                return View(EmpleadoALeer);               
        }

        // GET: EmpleadoController/Search (BUSCAR)
        public ActionResult Search()
        {
            return View();
        }

        // POST: EmpleadoController/Search 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(int Id)
        {
                         
            Empleado EmpleadoABuscar = await _iservicioEmpleado.ObtenerEmpleado(Id);

            if (EmpleadoABuscar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View(EmpleadoABuscar);
            }
                    
        }


        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Empleado EmpleadoNuevo)
        {
            try
            {
                await _iservicioEmpleado.Create(EmpleadoNuevo);
                if (EmpleadoNuevo == null) 
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

        // GET: EmpleadoController/Editar UPDATE
        public async Task<ActionResult> Edit(int Id)
        {
            Empleado EmpleadoABuscar = await _iservicioEmpleado.ObtenerEmpleado(Id);

            if (EmpleadoABuscar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(EmpleadoABuscar);
            }
        }

        // POST: EmpleadoController/Editar UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Empleado EmpleadoActualizado)
        {
            try
            {  
                await _iservicioEmpleado.Editar(EmpleadoActualizado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/
        public async Task<ActionResult> Delete(int Id)
        {
            Empleado EmpleadoABuscar = await _iservicioEmpleado.ObtenerEmpleado(Id);

            if (EmpleadoABuscar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(EmpleadoABuscar);
            }
        }

        // POST: EmpleadoController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteClient(int Id)
        {
            try
            {
                await _iservicioEmpleado.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error al querer eliminar el Empleado");
            }
        }
    }
}
