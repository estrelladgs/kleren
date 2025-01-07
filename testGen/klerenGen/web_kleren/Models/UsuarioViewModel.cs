using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class LoginUsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int  UsuarioRegistradoId { get; set; }

        [Display(Prompt = "Introduce tu correo", Description ="Correo del usuario", Name="Correo:")]
        [Required(ErrorMessage = "El correo del usuario es obligatorio")]

        public string Correo { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Description ="Contraseña del usuario", Name ="Contraseña:")]
        [Required(ErrorMessage = "La contraseña del usuario es obligatorio")]
        [DataType(DataType.Password)]

        public string Pass { get; set; }    


    }

    public class RegistroUsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int UsuarioRegistradoId { get; set; }

        [Display(Prompt = "Introduce tu nombre", Description = "Nombre del usuario", Name = "Nombre:")]
        [Required(ErrorMessage = "El nombre es obligatorio")]

        public string Nombre{ get; set; }

        [Display(Prompt = "Introduce tus apellidos", Description = "Apellido del usuario", Name = "Apellidos:")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]

        public string Apellidos { get; set; }

        [Display(Prompt = "Introduce tu correo", Description = "Correo del usuario", Name = "Correo:")]
        [Required(ErrorMessage = "El correo es obligatorio")]

        public string Correo { get; set; }


        [Display(Prompt = "Introduce tu telefono", Description = "Telefono del usuario", Name = "Teléfono:")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]

        public string Telefono{ get; set; }

        [Display(Prompt = "Introduce tu fecha de nacimiento", Description = "Fecha de nacimiento del usuario", Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FNac { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Description = "Contraseña del usuario", Name = "Contraseña:")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]

        public string Pass { get; set; }

    }

  


    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int UsuarioRegistradoId { get; set; }

        [Display(Prompt = "Introduce tu nombre", Description = "Nombre del usuario", Name = "Nombre:")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce tus apellidos", Description = "Apellido del usuario", Name = "Apellidos:")]
        [StringLength(200, ErrorMessage = "Los apellidos no pueden superar los 200 caracteres.")]
        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Introduce tu correo", Description = "Correo del usuario", Name = "Correo:")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Correo { get; set; }

        [Display(Prompt = "Introduce tu telefono", Description = "Telefono del usuario", Name = "Teléfono:")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El teléfono debe tener un formato válido (solo números).")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        [Display(Prompt = "Introduce tu fecha de nacimiento", Description = "Fecha de nacimiento del usuario", Name = "Fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? FNac { get; set; }

        [Display(Prompt = "Introduce tu contraseña", Description = "Contraseña del usuario", Name = "Contraseña")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña tiene un formato válido.")]
   
        public string Pass { get; set; }


        [Display(Prompt = "Introduce tu contraseña actual", Description = "Contraseña del usuario", Name = "Contraseña Actual:")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]

        public string ContraActual { get; set; }

        [Display(Prompt = "Introduce tu nueva contraseña", Description = "Contraseña del usuario", Name = "Nueva Contraseña:")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string NuevaContra { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Display(Prompt = "Confirma tu nueva contraseña", Description = "Contraseña del usuario", Name = "Confirmar Contraseña:")]
        [Compare("NuevaContra", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContra { get; set; }

        [ScaffoldColumn(false)]
        public int Puntos { get; set; }

    }

    public class DatosViewModel
    {
        [ScaffoldColumn(false)]
        public int UsuarioRegistradoId { get; set; }

        [Display(Prompt = "Introduce tu nombre", Description = "Nombre del usuario", Name = "Nombre:")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce tus apellidos", Description = "Apellido del usuario", Name = "Apellidos:")]
        [StringLength(200, ErrorMessage = "Los apellidos no pueden superar los 200 caracteres.")]
        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Introduce tu correo", Description = "Correo del usuario", Name = "Correo:")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Correo { get; set; }

        [Display(Prompt = "Introduce tu telefono", Description = "Telefono del usuario", Name = "Teléfono:")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El teléfono debe tener un formato válido (solo números).")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

       /* [Display(Prompt = "Introduce tu fecha de nacimiento", Description = "Fecha de nacimiento del usuario", Name = "Fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no tiene un formato válido.")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? FNac { get; set; }*/
    }

    public class ContraViewModel
    {
        [Display(Prompt = "Introduce tu contraseña actual", Description = "Contraseña del usuario", Name = "Contraseña Actual")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña tiene un formato válido.")]
        [Required(ErrorMessage = "La contraseña actual es obligatoria")]

        public string Pass { get; set; }

        [Display(Prompt = "Introduce tu nueva contraseña", Description = "Contraseña del usuario", Name = "Nueva Contraseña:")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string NuevaContra { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Display(Prompt = "Confirma tu nueva contraseña", Description = "Contraseña del usuario", Name = "Confirmar Contraseña:")]
        [Compare("NuevaContra", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContra { get; set; }
    }

    public class BorrarViewModel
    {
        [Display(Prompt = "Introduce tu contraseña actual", Description = "Contraseña del usuario", Name = "Contraseña Actual")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña tiene un formato válido.")]
        [Required(ErrorMessage = "La contraseña actual es obligatoria")]

        public string Pass { get; set; }

    }


}
