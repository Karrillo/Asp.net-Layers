using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.SubCategories
{
    public class SubCategories
    {
        [Key]
        public Int64 IDSubCategory { get; set; }

        [RegularExpression(@"^([ñÑa-zA-Z0-9]+\s)*[ñÑa-zA-Z0-9]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "Nombre de sub-categoria requerida")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Name { get; set; }

        public Int64 IdCategory { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
