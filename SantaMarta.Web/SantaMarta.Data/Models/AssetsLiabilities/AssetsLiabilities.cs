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

        [RegularExpression(@"^[,.A-Za-z0-9 ]*$", ErrorMessage = "Caracteres especiales no son permitidos")]
        [Required(ErrorMessage = "Numero de documento requerida")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 30")]
        public String Code { get; set; }

        [Required(ErrorMessage = "Monto requerido")]
        public Decimal Rode { get; set; }

        [Required(ErrorMessage = "Tipo de operacion requerida")]
        public Boolean Type { get; set; }

        public String Description { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
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
