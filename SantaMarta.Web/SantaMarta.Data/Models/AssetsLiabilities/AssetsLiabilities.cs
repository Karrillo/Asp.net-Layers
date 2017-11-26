using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Models.AssetsLiabilities
{
    public class AssetsLiabilities
    {
        [Key]
        public Int64 IDAssetLiability { get; set; }


        public DateTime CurrentDate { get; set; }

        [RegularExpression(@"^[^-\s][A-Za-z0-9]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "El numero de documento es requerido")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Code { get; set; }

        [Required(ErrorMessage = "Monto requerido")]
        public Decimal Rode { get; set; }

        [Required(ErrorMessage = "Tipo de operacion requerida")]
        public Boolean Type { get; set; }

        [RegularExpression(@"^[^-\s][.,a-zA-Z0-9_\s-]+$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 100")]
        public String Description { get; set; }

        [RegularExpression(@"^[^-\s][a-zA-Z\s-]+$", ErrorMessage = "Caracteres no permitidas")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Name { get; set; }

        public Boolean State { get; set; }

        public Int64? IdInvoice { get; set; }

        [Required(ErrorMessage = "Cuenta requerida")]
        public Int64 IdAccount { get; set; }

        [Required(ErrorMessage = "Sub-Categoria requerida")]
        public Int64? IdSubCategory { get; set; }

        public Int64? IdUser { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
