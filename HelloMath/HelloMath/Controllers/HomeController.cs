using HelloMath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMath.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Parabola(ParabolaRequest request)
        {
            var p = new Parabola(request);

            return View("ParabolaOut", p.Parametri);
        }

        [HttpGet]
        public ActionResult Parabola()
        {
            return View("ParabolaIn", new ParabolaRequest());
        }

        public ActionResult Chart()
        {
            return View("ChartJS");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}