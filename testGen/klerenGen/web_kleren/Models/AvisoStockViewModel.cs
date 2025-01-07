using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class AvisoStockViewModel
    {
        [Display(Prompt = "Introduce tu correo", Description = "Correo del usuario", Name = "Correo:")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]

        public string Correo { get; set; }
    }
}
