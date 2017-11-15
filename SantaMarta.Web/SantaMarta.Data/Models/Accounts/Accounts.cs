using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.Accounts
{
    public class Accounts
    {
        [Key]
        public Int64 IDAccount { get; set; }

        [RegularExpression(@"^[^-\s][a-zA-Z0-9\s-]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "Nombre de cuenta requerida")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Name { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
