using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Persons
{
    public class Persons
    {
        [Key]
        public Int64 IDPerson { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 20")]
        public String Name { get; set; }
        [Required(ErrorMessage = "El primer apellido es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 15")]
        public String SecondName { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(40, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 40")]
        public String Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(9, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 9")]
        public String Phone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(9, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 9")]
        public String CellPhone { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [DataType(DataType.Text)]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 70")]
        public String Address { get; set; }
        [Required(ErrorMessage = "La indentificacion es requerida")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El numero de caracteres debe ser menor a 20")]
        public String identification { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(40, MinimumLength = 0, ErrorMessage = "El numero de caracteres debe ser menor a 40")]
        public String NameCompany { get; set; }
    }
}
