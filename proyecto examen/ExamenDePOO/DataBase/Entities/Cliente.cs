using System.ComponentModel.DataAnnotations;

namespace ExamenDePOO.DataBase.Entities
{
    public class Cliente
    {
            public Guid Id { get; set; }

             
            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
            public string Name { get; set; }

            [Display(Name="Correo electronico")]
            [MinLength(15, ErrorMessage = "La {0} debe tener al menos {1} caracteres.")]
            public string Description { get; set; }

            [Display(Name = "ID")]
            [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
            public string Number { get; set; }


    }
}
