using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MVRLJDGA.BusinessLogic.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El rol es requerido para el usuario.")]
        [Display(Name = "Rol asignado")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El nombre de cuenta es requerido.")]
        [StringLength(60, ErrorMessage = "El nombre de cuenta no puede superar los 60 caracteres.")]
        [Display(Name = "Nombre de Cuenta")]
        public string AccountName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave de acceso es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave de Acceso")]
        public string AccessKey { get; set; } = string.Empty;

        [Display(Name = "Nombre del Rol")]
        public string RoleTitle { get; set; } = string.Empty;
    }
}