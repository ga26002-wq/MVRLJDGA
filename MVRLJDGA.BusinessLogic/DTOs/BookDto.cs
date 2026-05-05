using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace MVRLJDGA.BusinessLogic.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo ID de la editorial es obligatorio.")]
        [Display(Name = "ID del Editor")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(255, ErrorMessage = "El título no puede exceder los 255 caracteres.")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El precio de venta es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio de venta debe ser mayor a cero.")]
        [Display(Name = "Precio de Venta")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 9999, ErrorMessage = "El stock debe ser un valor válido entre 0 y 9999.")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}

