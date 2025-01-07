using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Enumerated.Kleren;
using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int ArticuloId { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el nombre del artículo")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del artículo no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del artículo", Name = "Precio" )]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Precio { get; set; }

        [Display(Prompt = "¿El artículo está de oferta?", Description = "¿De oferta?", Name = "Promocion")] 
        public bool Promocion { get; set; }

        [Display(Prompt = "Introduce el precio de oferta del artículo", Description = "Precio oferta del artículo", Name = "Precio oferta")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio de oferta debe ser mayor que 0 y menor que 10000")]
        public float PrecioOferta { get; set; }

        [Display(Prompt = "Introduce la trazabilidad del artículo", Description = "Trazabilida del producto", Name = "Trazabilidad")]
        [Required(ErrorMessage = "Debe indicar la trazabilidad del artículo")]
        public string Trazabilidad { get; set; }

        [Display(Prompt = "Selecciona la categoria de la prenda", Description = "Categoria de la prenda, tipo de prenda", Name = "Categoria")]
        [Required(ErrorMessage = "Debe indicar la categoria de la prenda")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum Categoria { get; set; }

        [Display(Prompt = "Selecciona el sexo de la prenda", Description = "Sexo de la prenda hombre o mujer", Name = "Sexo")]
        [Required(ErrorMessage = "Debe indicar el sexo para el que está destinada la prenda")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum Sexo { get; set; }

        public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> Cuidado { get; set; }

        public int? Composicion {  get; set; }

        [Display(Prompt = "Introduce la si la prenda el una parte de arriba o de abajo", Description = "Parte del cuerpo", Name = "Parte")]
        [Required(ErrorMessage = "Debe indicar si la prenda es una parte de arriba o de abajo")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum Parte { get; set; }

        public bool Favorito { get; set; }

        [ScaffoldColumn(false)]
        public int StockInicial { get; set; }


    }


    public class DetalleArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int ArticuloId { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el nombre del artículo")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del artículo no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del artículo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Precio { get; set; }

        [Display(Prompt = "¿El artículo está de oferta?", Description = "¿De oferta?", Name = "Promocion")]
        public bool Promocion { get; set; }

        [Display(Prompt = "Introduce el precio de oferta del artículo", Description = "Precio oferta del artículo", Name = "Precio oferta")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio de oferta debe ser mayor que 0 y menor que 10000")]
        public float PrecioOferta { get; set; }

        [Display(Prompt = "Introduce la trazabilidad del artículo", Description = "Trazabilida del producto", Name = "Trazabilidad")]
        [Required(ErrorMessage = "Debe indicar la trazabilidad del artículo")]
        public string Trazabilidad { get; set; }

        [Display(Prompt = "Selecciona la categoria de la prenda", Description = "Categoria de la prenda, tipo de prenda", Name = "Categoria")]
        [Required(ErrorMessage = "Debe indicar la categoria de la prenda")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum Categoria { get; set; }

        [Display(Prompt = "Selecciona el sexo de la prenda", Description = "Sexo de la prenda hombre o mujer", Name = "Sexo")]
        [Required(ErrorMessage = "Debe indicar el sexo para el que está destinada la prenda")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum Sexo { get; set; }

        public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> Cuidado { get; set; }

        public int? Composicion { get; set; }

        [Display(Prompt = "Introduce la si la prenda el una parte de arriba o de abajo", Description = "Parte del cuerpo", Name = "Parte")]
        [Required(ErrorMessage = "Debe indicar si la prenda es una parte de arriba o de abajo")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum Parte { get; set; }

        public bool Favorito { get; set; }

        [ScaffoldColumn(false)]
        public int StockInicial { get; set; }

        public IList<ColorEN> Colores { get; set; }

        public IList<TallaEN> Tallas { get; set; }

        public string TallaIdeal { get; set; }


        public ImagenVarianteViewModel ImagenPrincipal { get; set; }


        // Propiedad de variantes (puede tener otro nombre)
        public IList<VarianteEN> Variantes { get; set; }

    }
}
