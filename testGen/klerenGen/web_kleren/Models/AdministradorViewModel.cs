using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class LoginAdministradorViewModel
    {
        [ScaffoldColumn(false)]
        public int AdministradorId { get; set; }

        [Display(Prompt = "Introduce tu correo", Description = "Correo del administrador", Name = "Correo:")]
        [Required(ErrorMessage = "El correo del administrador es obligatorio")]

        public string Correo { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Description = "Contraseña del administrador", Name = "Contraseña:")]
        [Required(ErrorMessage = "La contraseña del administrador es obligatoria")]
        [DataType(DataType.Password)]

        public string Pass { get; set; }


    }


    public class AdministradorViewModel
    {
        [ScaffoldColumn(false)]
        public int AdministradorId { get; set; }

        [Display(Prompt = "Introduce tu nombre", Description = "Nombre del administrador", Name = "Nombre:")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce tus apellidos", Description = "Apellidos del administrador", Name = "Apellidos:")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Introduce tu correo", Description = "Correo del administrador", Name = "Correo:")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string Correo { get; set; }

        [Display(Prompt = "Introduce tu teléfono", Description = "Teléfono del administrador", Name = "Teléfono:")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener un formato válido (solo números, 10 dígitos).")]
        public string Telefono { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Description = "Contraseña del administrador", Name = "Contraseña:")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Display(Prompt = "Introduce tu fecha de nacimiento", Description = "Fecha de nacimiento del administrador", Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FNac { get; set; }

        [Display(Prompt = "Introduce tu DNI", Description = "DNI del administrador", Name = "DNI:")]
        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^\d{8}[A-Z]$", ErrorMessage = "El DNI debe tener un formato válido (8 dígitos seguidos de una letra en mayúscula).")]
        public string Dni { get; set; }
    }
}
