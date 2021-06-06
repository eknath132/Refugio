using Refugio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Loguin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SessionEnter(string pass, string passRepeat)
        {
            string ePass = Encrypt.GetSHA256(pass);
            string ePassRepeat= Encrypt.GetSHA256(passRepeat);
            string usuario = "admin";

            string passVerify = null;
            try
                {
                if (ePass == ePassRepeat)
                    {
                    passVerify = ePass;
                }
                else
                {
                    return Content("Contraseña invalida");
                }

                using (refugioEntities db = new refugioEntities())

                {
                        if (ModelState.IsValid)
                        {
                            {
                                var oUser = db.Adm.Find(1);
                                oUser.PASS = passVerify;
                                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();

                        }
                           var lst = from d in db.Adm
                                where d.USUARIO == usuario && d.PASS == ePass
                                select d;
                            if (lst.Count() > 0)
                           {
                               Session["User"] = lst.First();
                               return Content("Logueado correctamente!");
                            }
                    }
                    return Redirect("~/Tabla/Index");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}