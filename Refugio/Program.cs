using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(Models.refugioEntities db = new Models.refugioEntities())
            {
                Models.Adm oUser = new Models.Adm();
                oUser.USUARIO = "refugio@gmail.com";
                oUser.PASS = Encrypt.GetSHA256("notoquesalosgatos");
                db.Adm.Add(oUser);
                db.SaveChanges();
            }
        }
    }
}