using KlerenGen.ApplicationCore.EN.Kleren;
using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class LinPedViewModel
    {
        [ScaffoldColumn(false)]
        public int LineaId { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del artículo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Precio { get; set; }

        [Display(Prompt = "Introduce la cantidad del artículo", Description = "Cantidad del artículo", Name = "Cantidad")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero")]
        public int Cantidad { get; set; }

        [ScaffoldColumn(false)]
        public int VarianteId { get; set; }

        [ScaffoldColumn(false)]
        public int Stock { get; set; }

        [ScaffoldColumn(false)]
        public int TallaId { get; set; }

        [Display(Prompt = "Introduce la talla del artículo", Description = "Talla del artículo", Name = "Talla")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum Talla { get; set; }

        [ScaffoldColumn(false)]
        public int ColorId { get; set; }

        [ScaffoldColumn(false)]
        public string Codigo { get; set; }

        [Display(Prompt = "Introduce el color del artículo", Description = "Color del artículo", Name = "Color")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum Nombre { get; set; }

        [ScaffoldColumn(false)]
        public int ArtId { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string NombreArt { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public float PrecioArt { get; set; }

        [Display(Prompt = "Introduce el precio de oferta del artículo", Description = "Precio oferta del artículo", Name = "Precio oferta")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio de oferta debe ser mayor que 0 y menor que 10000")]
        public float PrecioOf { get; set; }

        [Display(Prompt = "¿El artículo está de oferta?", Description = "¿De oferta?", Name = "Promocion")]
        public bool Prom { get; set; }

        [Display(Prompt = "Introduce el nombre del talla", Description = "Nombre del talla", Name = "TallaS")]
        public string TallaS { get; set; }

        [Display(Prompt = "Introduce el nombre del color", Description = "Nombre del color", Name = "ColorS")]
        public string ColorS { get; set; }


    }

    public class LinpedEditarViewModel
    {
        [ScaffoldColumn(false)]
        public int LineaId { get; set; }

        [ScaffoldColumn(false)]
        public int ArtId { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string NombreArt { get; set; }

        public IList<ColorEN> Colores { get; set; }

        public IList<TallaEN> Tallas { get; set; }
    } 
}
