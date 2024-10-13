using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class MaquinariaController : Controller
    {
        public static IList<Maquinaria> listadeMaquinaria = new List<Maquinaria>();

        // GET: MaquinariaController
        public ActionResult Index()
        {
            if (!listadeMaquinaria.Any()) 
            {
                Maquinaria maquinaria = new Maquinaria
                {
                    Id = 1,
                    Descripcion = "Chapeadora",
                    Tipo="Corta Setos",
                    HorasUsoActual = 8,
                    HorasUsoMaximo = 1000,
                    HorasMantenimiento = 100
                };
                listadeMaquinaria.Add(maquinaria);
            }
            return View(listadeMaquinaria);
        }

        // GET: MaquinariaController/Details/5
        public ActionResult Details(int id)
        {
            if (listadeMaquinaria.Any()) {
                Maquinaria MaquinariaALeer = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                return View(MaquinariaALeer);

            }
            return View();
        }

        // GET: MaquinariaController/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: ClienteController/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int id)
        {
            if (listadeMaquinaria.Any())
            { 
                Maquinaria MaquinariaABuscar = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                if (MaquinariaABuscar == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(MaquinariaABuscar);
                }
            }
            return View();
        }


        // GET: MaquinariaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaquinariaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maquinaria maquinariaNueva)
        {
            try
            {
                if (maquinariaNueva == null)
                {
                    return View();
                }
                else
                {
                    listadeMaquinaria.Add(maquinariaNueva);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (listadeMaquinaria.Any()) 
            {
                Maquinaria MaquinariaEditar = listadeMaquinaria.FirstOrDefault(Maquinaria => Maquinaria.Id == id);
                return View(MaquinariaEditar); 
            }
            return View();
        }

        // POST: MaquinariaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Maquinaria MaquinariaEditada)
        {
            try
            {
                if (listadeMaquinaria.Any()) 
                {
                    Maquinaria maquinariaAEditar = listadeMaquinaria.FirstOrDefault(maquinaria=>maquinaria.Id == MaquinariaEditada.Id);
                    maquinariaAEditar.Descripcion = MaquinariaEditada.Descripcion;
                    maquinariaAEditar.Tipo = MaquinariaEditada.Tipo;
                    maquinariaAEditar.HorasUsoActual = MaquinariaEditada.HorasUsoActual;
                    maquinariaAEditar.HorasUsoMaximo = MaquinariaEditada.HorasUsoMaximo;
                    maquinariaAEditar.HorasMantenimiento = MaquinariaEditada.HorasMantenimiento;
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Delete/5
        public ActionResult Delete(int id)
        {
            if (listadeMaquinaria.Any())
            {
                Maquinaria MaquinariaEliminar = listadeMaquinaria.FirstOrDefault(Maquinaria => Maquinaria.Id == id);
                return View(MaquinariaEliminar);
            }
            return View();
        }

        // POST: MaquinariaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Maquinaria MaquinariaAEliminar)
        {
            try
            {
                Maquinaria EliminarEstaMaquinaria = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == MaquinariaAEliminar.Id);
                if (EliminarEstaMaquinaria == null)
                {
                    return View();
                }
                else { 
                    listadeMaquinaria.Remove(EliminarEstaMaquinaria);
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
