using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;
using P1_FloricelaArguedas_WebAppJHH.Services;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class MaquinariaController : Controller
    {
        //public static IList<Maquinaria> listadeMaquinaria = new List<Maquinaria>();

        private readonly IServicioMaquinaria _iservicioMaquinaria;

        public MaquinariaController(IServicioMaquinaria iservicioMaquinaria)
        {
            _iservicioMaquinaria = iservicioMaquinaria;
        }

        //MÉTODOS

        // GET: MaquinariaController
        public async Task<ActionResult> Index()
        {
            List<Maquinaria> listadeMaquinaria;
            listadeMaquinaria = await _iservicioMaquinaria.Index();
            return View(listadeMaquinaria);
        }

        // GET: MaquinariaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
                Maquinaria MaquinariaALeer = await _iservicioMaquinaria.ObtenerMaquinaria(id);
                return View(MaquinariaALeer);
        }

        // GET: MaquinariaController/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: ClienteController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(int id)
        {
            Maquinaria MaquinariaABuscar = await _iservicioMaquinaria.ObtenerMaquinaria(id);
            
            if (MaquinariaABuscar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(MaquinariaABuscar);
            }
        }


        // GET: MaquinariaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaquinariaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Maquinaria maquinariaNueva)
        {
            try
            {
                await _iservicioMaquinaria.Create(maquinariaNueva);
                if (maquinariaNueva == null)
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

        // GET: MaquinariaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Maquinaria MaquinariaAEditar = await _iservicioMaquinaria.ObtenerMaquinaria(id);
            if (MaquinariaAEditar == null) 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(MaquinariaAEditar);
        }

        // POST: MaquinariaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Maquinaria MaquinariaEditada)
        {
            try
            {
                await _iservicioMaquinaria.Editar(MaquinariaEditada);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Maquinaria MaquinariaEliminar = await _iservicioMaquinaria.ObtenerMaquinaria(id);
            if (MaquinariaEliminar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(MaquinariaEliminar);
        }

        // POST: MaquinariaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMaquinaria(int Id)
        {
            try
            {
                await _iservicioMaquinaria.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error al querer eliminar la Maquinaria");
            }
        }
    }
}
