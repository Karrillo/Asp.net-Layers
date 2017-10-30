using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Categories
{
    public class Categories
    {
        [Key]
        public Int64 IDCategory { get; set; }

        [RegularExpression(@"^[^-\s][a-zA-Z\s-]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "Nombre de categoria requerida")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Name { get; set; }
    }
}
