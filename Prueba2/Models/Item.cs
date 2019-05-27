using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba2.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(7)")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
    }

    public class ItemDeleteModel
    {
        [Column(TypeName = "varchar(7)")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
    }

    public class ItemInsertModel
    {
        [Column(TypeName = "varchar(7)")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Description { get; set; }
        [Display(Name = "Cantidad inicial")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a cero.")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Quantity { get; set; }
    }

    public class ItemUpdateModel
    {
        [Column(TypeName = "varchar(7)")]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Cantidad")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a cero.")]
        public int? Quantity { get; set; }
    }
}
