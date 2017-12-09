using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.Categories
{
    public class Categories
    {
        [Key]
        public Int64 IDCategory { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "Nombre de categoria requerida")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Name { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
