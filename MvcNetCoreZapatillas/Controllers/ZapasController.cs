using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;

namespace MvcNetCoreZapatillas.Controllers
{
    public class ZapasController : Controller
    {
        private RepositoryZapatillas repo;

        public ZapasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Zapatilla> zapatillas = this.repo.GetZapatillas();
            return View(zapatillas);
        }

        public IActionResult Details(int idproducto)
        {

            Zapatilla zapatilla = this.repo.FindZapatilla(idproducto);
            return View(zapatilla);
        }

        public IActionResult _ImagenZapatillas(int idproducto, int? posicion)
        {

            //if (posicion == null)
            //{
            //    posicion = 1;
            //}
            //int numregistros = this.repo.GetNumeroDeImagenes(idproducto);
            ////ESTAMOS EN LA POSICION 1, QUE TENEMOS QUE DEVOLVER A LA VISTA?
            //int siguiente = posicion.Value + 1;
            //if (siguiente > numregistros)
            //{
            //    //EFECTO OPTICO
            //    siguiente = numregistros;
            //}
            //int anterior = posicion.Value - 1;
            //if (anterior < 1)
            //{
            //    anterior = 1;
            //}
            //VistaDepartamento vistaDepartamento =
            //    await this.repo.GetVistaDepartamentoAsync(posicion.Value);
            //ViewData["ULTIMO"] = numregistros;
            //ViewData["SIGUIENTE"] = siguiente;
            //ViewData["ANTERIOR"] = anterior;
            //return View(vistaDepartamento);


            List<ImagenZapatilla> imagenZapatillas = this.repo.FindImagenZapatilla(idproducto);
            return PartialView("_ImagenZapatillas", imagenZapatillas);
        }

    }
}
