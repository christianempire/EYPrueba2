using Newtonsoft.Json;
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
        [JsonProperty("code")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
    }

    public class ItemInsertModel
    {
        [Column(TypeName = "varchar(7)")]
        [Display(Name = "Código")]
        [JsonProperty("code")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
        [Display(Name = "Nombre")]
        [JsonProperty("name")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [JsonProperty("description")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Description { get; set; }
        [Display(Name = "Cantidad inicial")]
        [JsonProperty("quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a cero.")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Quantity { get; set; }
    }

    public class ItemUpdateModel
    {
        [Column(TypeName = "varchar(7)")]
        [Display(Name = "Código")]
        [JsonProperty("code")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code { get; set; }
        [Display(Name = "Nombre")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [JsonProperty("description")]
        public string Description { get; set; }
        [Display(Name = "Cantidad")]
        [JsonProperty("quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a cero.")]
        public int? Quantity { get; set; }
    }
}
