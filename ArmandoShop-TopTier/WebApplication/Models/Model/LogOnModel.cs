using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArmandoShop.WebApplication.Models.Model
{
    /// <summary>
    /// Class adaptaed from MVC2 default app
    /// </summary>
    public class LogOnModel
    {
        [Required]
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [DisplayName("Recordar mi cuenta")]
        public bool RememberMe { get; set; }
    }
}