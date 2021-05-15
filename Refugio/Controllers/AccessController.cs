using Refugio.Models;
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
            try
            {
                using (refugioEntities db = new refugioEntities())

                {
                    var lst = from d in db.Adm
                              where d.USUARIO == usuario && d.PASS == ePass
                              select d;
                    var messageError = "Usuario Invalido";
                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content(messageError);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}