//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaWebClase.Areas.Categoria.Models;
using SistemaWebClase.Controllers;
using SistemaWebClase.Data;
using SistemaWebClase.Library;
using SistemaWebClase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Categoria.Controllers
{
    [Area("Categoria")] // agregar siempre
    public class CategoriaController : Controller
    {
        private LCategoria _Lcategoria;

        private TbCategoria _categoria;

        private SignInManager<IdentityUser> _singInManager;

        private static DataPaginacion<TbCategoria> models;

        private static IdentityError identityError;//  para poder cambiar el estado

        public CategoriaController(ApplicationDbContext context, SignInManager<IdentityUser> singleInManager)
        {
            _singInManager = singleInManager;
            _Lcategoria = new LCategoria(context);

        }


        public IActionResult Index( int id, string search, int registros )
        {
            if (_singInManager.IsSignedIn(User))
            {

                Object[] Objetos = new Object[3];


                var datos = _Lcategoria.GetCategoria(search);

                if (datos.Count > 0)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    Objetos = new LPaginador<TbCategoria>().paginador(_Lcategoria.GetCategoria(search), id, registros, "Categoria", "Categoria", "index", url);

                }
                else
                {
                    Objetos[0] = "No hay datos que coincidan con la busqueda";
                    Objetos[1] = "No hay datos que coincidan con la busqueda";
                    Objetos[2] = "No hay datos que coincidan con la busqueda";
                }



                models = new DataPaginacion<TbCategoria>
                {
                    List = (List<TbCategoria>)Objetos[2],
                    Pagi_info = (string)Objetos[0],
                    Pagi_Navegacion = (string)Objetos[1],
                    Input = new TbCategoria()

                };

                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index) );
            }
        }

        //public IActionResult Categoria ()
        //{
        //    if (_singInManager.IsSignedIn(User) )
        //    {
        //        models = new DataPaginacion<TbCategoria>
        //        {
        //            Input = new TbCategoria()

        //        };
        //        return View(models); 
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(HomeController.Index), "Home"); 
        //    }
        //}

        [HttpPost]
        public IActionResult UpdateEstado( int id)
        {
            identityError = _Lcategoria.UpdateEstado(id);
            return Redirect("/Categoria/Index?area=Categoria"); 
        }

        [HttpPost]

        public string PostCategoria( DataPaginacion<TbCategoria> model)
        {
            if (model.Input.Nombre != null && model.Input.Descripcion != null )
            {


                var data = _Lcategoria.Registrar_Categoria(model.Input);
                return "Guardado";

            }
            else
            {
                return "Llene todos los campos";
            }

        }


    }
}
