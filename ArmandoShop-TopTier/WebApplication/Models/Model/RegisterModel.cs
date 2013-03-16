using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArmandoShop.WebApplication.Models.Application.Access.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArmandoShop.WebApplication.Models.Model
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
    public class RegisterModel
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}