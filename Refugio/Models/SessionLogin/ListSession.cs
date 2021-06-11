using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Refugio.Models.SessionLoguin
{
    public class ListSession
    {
        public int ID { get; set; }
        [Required]

        public string USUARIO { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]

        public string PASS { get; set; }
        
    }
}