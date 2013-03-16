using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ArmandoShop.WebApplication.Models.Application.Access.Validation;

namespace ArmandoShop.WebApplication.Models.Model
{
    /// <summary>
    /// Class adapted from VS10 default MVC2 app
    /// </summary>
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Nueva contraseña")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar la nueva contraseña")]
        public string ConfirmPassword { get; set; }
    }
}