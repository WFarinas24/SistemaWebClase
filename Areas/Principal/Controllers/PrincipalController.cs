using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebClase.Areas.Principal.Controllers
{
    public class PrincipalController : Controller
    {
        [Area("Principal")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
