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
            string password = Encrypt.GetSHA256(pass);
            string ePass = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
            try
            {
                using (refugioEntities db = new refugioEntities())

                {
                    var lst = from d in db.Adm
                              where d.USUARIO == usuario && d.PASS == password
                              select d;

                    var User = lst.First();
                    var ePASS = User.PASS;

                    if (User.PASS == ePass)
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