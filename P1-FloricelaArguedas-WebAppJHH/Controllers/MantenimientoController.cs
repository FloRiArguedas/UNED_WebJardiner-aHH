using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;
using P1_FloricelaArguedas_WebAppJHH.Services;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class MantenimientoController : Controller
    {
        //public static IList<Mantenimiento> listadeMantenimientos = new List<Mantenimiento>();

        private readonly IServicioMantenimiento _iservicioMantenimiento;

        public MantenimientoController(IServicioMantenimiento iservicioMantenimiento)
        {
            _iservicioMantenimiento = iservicioMantenimiento;
        }

        //MÉTODOS

        // GET: MantenimientoController
        public async Task<ActionResult> Index()
        {
            List<Mantenimiento> listadeMantenimientos;
            listadeMantenimientos = await _iservicioMantenimiento.Index();
            return View(listadeMantenimientos);
        }

        // GET: MantenimientoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Mantenimiento MantenimientoALeer = await _iservicioMantenimiento.ObtenerMantenimiento(id);
            return View(MantenimientoALeer);
        }

        // GET: MantenimientoController/Search BUSCAR
        public ActionResult Search()
        {
            return View();
        }

        // POST: MantenimientoController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(int Id)
        {
            try
            {
                Mantenimiento MantenimientoEncontrado = await _iservicioMantenimiento.ObtenerMantenimiento(Id);
                    
                if (MantenimientoEncontrado == null) 
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(MantenimientoEncontrado);
                
            }
            catch
            {
                return View();
            }
        }


        // GET: MantenimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

                 

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Mantenimiento MantenimientoNuevo)
        {
            
            try
            {
                await _iservicioMantenimiento.Create(MantenimientoNuevo);
                if (MantenimientoNuevo == null)
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

        // GET: MantenimientoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Mantenimiento MantenimientoAActualizar = await _iservicioMantenimiento.ObtenerMantenimiento(id);
            if (MantenimientoAActualizar == null) 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(MantenimientoAActualizar);
        }

        // POST: MantenimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mantenimiento MantenimientoEditado)
        {
            try
            {
                await _iservicioMantenimiento.Editar(MantenimientoEditado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Mantenimiento MantenimientoAEliminar = await _iservicioMantenimiento.ObtenerMantenimiento(id);
            if (MantenimientoAEliminar ==  null)
            {
                return RedirectToAction(nameof(Index));
                
            }
            return View(MantenimientoAEliminar);
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMantenimiento (int id)
        {
            try
            {
               await _iservicioMantenimiento.Delete(id);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
