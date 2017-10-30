using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Users
{
    public class Users
    {
        [Key]
        public Int64 IDUser { get; set; }

        [RegularExpression(@"^[^-\s][a-zA-Z\-]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El nickname es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String Nickname { get; set; }

        [RegularExpression(@"^[^-\s][A-Za-z0-9]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "El password es requerido")]
        [DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 10")]
        public String Password { get; set; }

        public Boolean Type { get; set; }

        public Boolean State { get; set; }
    }
}
