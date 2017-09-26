using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Products
{
    public class Products
    {
        [Key]
        public Int64 IDProduct { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Name { get; set; }
        [Required(ErrorMessage = "El Codigo es requerido")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 20")]
        public String Code { get; set; }
        public Boolean State { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 50")]
        public String Description { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public Decimal Price { get; set; }
        public Int64 IdProvider { get; set; }
    }
}
