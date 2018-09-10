using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaQR.Controllers
{
    public class PresencaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}