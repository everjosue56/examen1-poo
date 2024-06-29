using System.ComponentModel.DataAnnotations;

namespace ExamenDePOO.Dtos.Inventario
{
    public class InventarioCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Name { get; set; }

        [Display(Name = "precio")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres.")]
        public string Precio { get; set; }

    }
}
