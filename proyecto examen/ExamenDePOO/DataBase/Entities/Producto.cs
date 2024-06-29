using System.ComponentModel.DataAnnotations;

namespace ExamenDePOO.DataBase.Entities
{
    public class Producto
    {


        [Display(Name = "ID")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Name { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Precio { get; set; }
    }
}
