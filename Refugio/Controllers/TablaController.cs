using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Refugio.Models;
using Refugio.Models.ViewModels;

namespace Refugio.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
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
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (refugioEntities db = new refugioEntities())
                    {
                        var gato = new Gatos();
                        gato.NOMBRE = model.NOMBRE;
                        gato.RAZA = model.RAZA; 
                        gato.EDAD = model.EDAD;
                        gato.CASTRADO = model.CASTRADO;

                        db.Gatos.Add(gato);
                        db.SaveChanges();
                    }
                return Redirect("~/Tabla/Index");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (refugioEntities db = new refugioEntities())
            {
                var gato = db.Gatos.Find(id);

                model.NOMBRE = gato.NOMBRE;
                model.RAZA = gato.RAZA;
                model.EDAD = gato.EDAD;
                model.CASTRADO = gato.CASTRADO;
                model.ID = gato.ID;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (refugioEntities db = new refugioEntities())
                    {
                        var gato = db.Gatos.Find(model.ID);
                        gato.NOMBRE = model.NOMBRE;
                        gato.RAZA = model.RAZA;
                        gato.EDAD = model.EDAD;
                        gato.CASTRADO = model.CASTRADO;

                        db.Entry(gato).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]

        public ActionResult Eliminar(int id)
        {
            using (refugioEntities db = new refugioEntities())
            {
                var gato = db.Gatos.Find(id);
                db.Gatos.Remove(gato);
                db.SaveChanges();
            }

            return Redirect("~/Tabla/Index");
        }
    }
}