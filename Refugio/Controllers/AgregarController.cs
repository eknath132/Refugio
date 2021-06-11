using Refugio.Models;
using Refugio.Models.SessionLoguin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Controllers
{
    public class AgregarController : Controller
    {
        // GET: Agregar
        public ActionResult Index()
        {
            List<ListSession> list;
            using (refugioEntities db = new refugioEntities())
            {
                list = (from d in db.Adm
                        select new ListSession
                        {
                            ID = d.ID,
                            USUARIO = d.USUARIO,
                            EMAIL= d.EMAIL,
                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        public ActionResult SessionAdd(string user,string email, string pass)
        {
            string ePass = Encrypt.GetSHA256(pass);

            try
            {
                using (refugioEntities db = new refugioEntities())

                {
                    if (ModelState.IsValid)
                    {
                        
                            var oUser = new Adm();
                            oUser.ID = 4; 
                            oUser.USUARIO = user;
                            oUser.EMAIL = email;
                            oUser.PASS = ePass;
                            db.Adm.Add(oUser);
                            db.SaveChanges();

                        
                        return Content("Usuario Agregado");

                    }
                    return Content("~/Agregar/Index");
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}