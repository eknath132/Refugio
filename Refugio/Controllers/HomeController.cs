using Refugio.Models;
using Refugio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCat()
        {
            List<ListTablaViewModel> list;
            using (refugioEntities db = new refugioEntities())
            {
                list = (from d in db.Gatos
                        select new ListTablaViewModel
                        {
                            ID = d.ID,
                            NOMBRE = d.NOMBRE,
                            RAZA = d.RAZA,
                            EDAD = d.EDAD,
                            CASTRADO = d.CASTRADO,
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}