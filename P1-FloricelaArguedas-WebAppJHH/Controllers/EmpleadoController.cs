using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class EmpleadoController : Controller
    {
        public static IList<Empleado> ListadeEmpleados = new List<Empleado>();
        

        // GET: EmpleadoController
        public ActionResult Index()
        {
            if (!ListadeEmpleados.Any()) {

                Empleado empleado = new Empleado() {
                
                    Cedula = 115420652,
                    FechaNacimiento = new DateTime(1993, 07, 10),
                    Lateralidad = "Zurdo",
                    FechaIngreso = new DateTime(2015, 03, 23),
                    SalarioxHora = 1900
                };
                ListadeEmpleados.Add(empleado);
            }
            return View(ListadeEmpleados);
        }

        // GET: EmpleadoController/Detalles (LEER)
        public ActionResult Details(int ced)
        {
            if (ListadeEmpleados.Any()) { 
                Empleado EmpleadoALeer = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == ced);
                return View(EmpleadoALeer);
            }
                return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado EmpleadoNuevo)
        {
            try
            {
                if (EmpleadoNuevo == null)
                {
                    return View();
                }
                else { 
                    ListadeEmpleados.Add(EmpleadoNuevo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Editar UPDATE
        public ActionResult Edit(int ced)
        {
            if (ListadeEmpleados.Any())
            {
                Empleado EmpleadoAEditar = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == ced);
                return View(EmpleadoAEditar);
            }
            return View();
        }

        // POST: EmpleadoController/Editar UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleado EmpleadoActualizado)
        {
            try
            {
                if (ListadeEmpleados.Any()) { 
                
                    Empleado EmpleadoAEditar = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == EmpleadoActualizado.Cedula);
                    EmpleadoAEditar.FechaNacimiento = EmpleadoActualizado.FechaNacimiento;
                    EmpleadoAEditar.Lateralidad = EmpleadoActualizado.Lateralidad;
                    EmpleadoAEditar.FechaIngreso = EmpleadoActualizado.FechaIngreso;
                    EmpleadoAEditar.SalarioxHora = EmpleadoActualizado.SalarioxHora;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
