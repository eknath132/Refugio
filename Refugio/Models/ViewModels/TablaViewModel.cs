﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Refugio.Models.ViewModels
{
    public class TablaViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name =" Nombre")]
        public string NOMBRE { get; set; }
        [Required]
        [Display(Name = " Raza")]
        public string RAZA { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int EDAD { get; set; }
        [Required]
        [Display(Name = " Castrado")]
        public string CASTRADO { get; set; }
    }
}