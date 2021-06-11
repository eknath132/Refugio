using Refugio.Models;
using Refugio.Models.SessionLoguin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

        public ActionResult Recover()
        {
            return View();
        }

        public ActionResult RecoverPass(string email)
        {
            ListSession model = new ListSession();
            string pass = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
            string emailOrigen = "nslp.refugio@gmail.com";
            string emailDestino = email;
            string password = "refugio.12";
            try
            {
                if (ModelState.IsValid)
                {
                    using (refugioEntities db = new refugioEntities())
                    {
                        var user = db.Adm.Where(d => d.EMAIL == email).FirstOrDefault();

                        if (user != null)
                        {
                            user.PASS = pass;
                            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MailMessage oEmail = new MailMessage(emailOrigen, emailDestino, "Hola","Su nueva contraseña es admin");
                            oEmail.IsBodyHtml = true;
                            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            //smtpClient.Host = "smtp.gmail.com";
                            smtpClient.Port = 587;
                            smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigen, password);

                            smtpClient.Send(oEmail);
                            smtpClient.Dispose();

                            return Content("Contraseña enviada");
                        }
                        else
                        {
                            return Content("El correo no es valido");
                        }
                    }
                }
                return Content("Ocurrio un errror");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private MailMessage MailMessage(string emailOrigen, string emailDestino, string v)
        {
            throw new NotImplementedException();
        }
    }
}