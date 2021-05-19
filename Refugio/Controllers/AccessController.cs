using Refugio.Models;
using Refugio.Models.SessionLoguin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string pass)
        {
            string ePass = Encrypt.GetSHA256(pass);
            string Usuario = "refugio@gmail.com";
            try
            {
                using (refugioEntities db = new refugioEntities())

                {
                    var lst = from d in db.Adm
                              where d.USUARIO == usuario && d.PASS == ePass
                              select d;

                    var User = lst.First();
                    if (User.USUARIO == Usuario)
                    {
                        Session["User"] = lst.First();
                        return Content("Logueado correctamente, Cambie su usuario y contraseña");
                    }

                    else
                    {
                        Session["User"] = lst.First();
                        return Content("Logueado correctamente!");
                    }
                }
            }
            catch (Exception)
            {
                return Content("No hay un usuario registrado con esa cuenta");
            }
        }
    }
}