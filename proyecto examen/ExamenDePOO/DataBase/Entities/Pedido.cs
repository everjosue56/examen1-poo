using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ExamenDePOO.DataBase.Entities
{
    public class Pedido
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string ID { get; set; }
        [Display(Name = "ClienteID")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string ClientesId { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Fecha { get; set; }
        [Display(Name = "ListaDeProductos")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
       public string ListProductos { get; set; }
        [Display(Name = "Total")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Total { get; set; }
    }
}
