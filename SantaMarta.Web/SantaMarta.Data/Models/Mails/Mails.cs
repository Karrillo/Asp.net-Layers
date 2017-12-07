using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.Mails
{
    public class Mails
    {
        [EmailAddress(ErrorMessage = "Correo no valido")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo electronico es requerido")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@gmail.+[a-zA-Z]{2,6}$", ErrorMessage = "Correo no valido")]
        public String Email { get; set; }

        [RegularExpression(@"^[^-\s][ñÑA-Za-z0-9]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "El password es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String Password { get; set; }
    }
}
