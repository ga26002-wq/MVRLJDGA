using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVRLJDGA.BusinessLogic.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una editorial.")] 
        [Display(Name = "Editorial")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(255, ErrorMessage = "El título es demasiado largo.")]
        [Display(Name = "Título")]
      
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor a 0.")]
        [Display(Name = "Precio de Venta")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 9999, ErrorMessage = "El stock no puede ser negativo.")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}


