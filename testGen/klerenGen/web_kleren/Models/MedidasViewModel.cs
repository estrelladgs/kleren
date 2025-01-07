using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
   

    public class MedidasViewModel
    {
        [ScaffoldColumn(false)]
        public int UsuarioRegistradoId { get; set; }

        [Display(Prompt = "Introduce tu medida del pecho", Description = "Medida del pecho del usuario", Name = "Pecho:")]
        [Required(ErrorMessage = "La medida del pecho es obligatoria.")]
        public int Pecho { get; set; }

        [Display(Prompt = "Introduce el ancho de tu espalda", Description = "Ancho de la espalda del usuario", Name = "Ancho de Espalda:")]
        [Required(ErrorMessage = "La medida del ancho de espalda es obligatoria.")]
        public int AnchoEspalda { get; set; }

        [Display(Prompt = "Introduce el largo de tu brazo", Description = "Largo del brazo del usuario", Name = "Largo del Brazo:")]
        [Required(ErrorMessage = "La medida del largo del brazo es obligatoria.")]
        public int LargoBrazo { get; set; }

        [Display(Prompt = "Introduce tu medida de cintura", Description = "Medida de la cintura del usuario", Name = "Cintura:")]
        [Required(ErrorMessage = "La medida de la cintura es obligatoria.")]
        public int Cintura { get; set; }

        [Display(Prompt = "Introduce tu medida de caderas", Description = "Medida de las caderas del usuario", Name = "Caderas:")]
        [Required(ErrorMessage = "La medida de las caderas es obligatoria.")]
        public int Caderas { get; set; }

        [Display(Prompt = "Introduce el largo de tu pierna", Description = "Largo de la pierna del usuario", Name = "Largo de Pierna:")]
        [Required(ErrorMessage = "La medida del largo de la pierna es obligatoria.")]
        public int LargoPierna { get; set; }

    }
}
