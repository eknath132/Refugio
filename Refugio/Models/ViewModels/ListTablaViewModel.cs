using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugio.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string RAZA { get; set; }
        public int EDAD { get; set; }
        public string CASTRADO { get; set; }
    }
}