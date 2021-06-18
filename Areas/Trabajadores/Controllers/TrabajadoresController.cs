using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaWebClase.Areas.Categoria.Models;
using SistemaWebClase.Areas.Trabajadores.Models;
using SistemaWebClase.Controllers;
using SistemaWebClase.Data;
using SistemaWebClase.Library;
using SistemaWebClase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Trabajadores.Controllers
{
    [Area("Trabajadores")]
    public class TrabajadoresController : Controller
    {

        private LTrabajador LTrabajado;

        private tbTrabajador _Trabajador;

        private SignInManager<IdentityUser> _singInManager;

        private static DataPaginacion<tbTrabajador> models;

        public TrabajadoresController(ApplicationDbContext context, SignInManager<IdentityUser> singleInManager)
        {
            _singInManager = singleInManager;
            LTrabajado = new LTrabajador(context);

        }
        [HttpPost]

        public string PostTrabajadores(DataPaginacion<tbTrabajador> model)
        {
            if (model.Input.Nombre != null && model.Input.Apellidos != null)
            {

                var data = LTrabajado.Registrar_Trabajador(model.Input);
                return "Guardado";

            }
            else
            {
                return "Llene todos los campos";
            }

        }

        public IActionResult Index(int id, string search, int registros )
        {
            if (_singInManager.IsSignedIn(User))
            {


                Object[] Objetos = new Object[3]; 

               
                var datos = LTrabajado.GetTrabador(search);

                if (datos.Count >0 )
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    Objetos = new LPaginador<tbTrabajador>().paginador(LTrabajado.GetTrabador(search), id, registros, "Trabajadores", "Trabajadores", "index", url);

                }
                else
                {
                    Objetos[0] = "No hay datos que coincidan con la busqueda";
                    Objetos[1] = "No hay datos que coincidan con la busqueda";
                    Objetos[2] = "No hay datos que coincidan con la busqueda";
                }



                models = new DataPaginacion<tbTrabajador>
                {
                    List = (List<tbTrabajador>)Objetos[2],
                    Pagi_info = (string)Objetos[0],
                    Pagi_Navegacion = (string)Objetos[1],
                    Input = new tbTrabajador()

                };

                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index)); 
            }


        }
    }
}
