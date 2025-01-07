using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class ImagenVarianteViewModel
    {
        // id
        [ScaffoldColumn(false)]
        public int ImagenVarianteId { get; set; }

        [Display(Prompt = "Selecciona el color de la prenda", Description = "Color de prenda", Name = "Color")]
        [Required(ErrorMessage = "Debe seleccionar el color de la prenda")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum Color { get; set; }

        [Display(Prompt = "Selecciona una imagen",  Name = "Imagen")]
        [Required(ErrorMessage = "Debe añadir una imagen (ruta)")]
        public IFormFile RutaArchivo { get; set; }

        [ScaffoldColumn(false)]
        public String RutaArchivoString { get; set; }

        // texto alternativo
        [Display(Prompt = "Introduce el texto alternativo de la imagen", Name = "Texto alternativo")]
        [Required(ErrorMessage = "Debe indicar el texto alternativo de la imagen")]
        [StringLength(maximumLength: 50, ErrorMessage = "El texto alternativo no puede tener más de 50 caracteres")]
        public string TextoAlternativo { get; set; }

        // ruta como string para los metodos GET
        [ScaffoldColumn(false)]
        public string RutaArchivoAMostrar { get; set; }


    }
}
