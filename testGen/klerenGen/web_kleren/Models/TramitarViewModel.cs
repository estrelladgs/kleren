using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class TramitarViewModel
    {
        [ScaffoldColumn(false)]
        public int PedidoId { get; set; }

        [Display(Prompt = "Introduce el estado del pedido", Description = "Estado del pedido", Name = "EstadoP")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum EstadoP { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double Total { get; set; }

        [Display(Prompt = "Introduce el total descuento del pedido", Description = "Total descuento del pedido", Name = "TotalDescuento")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double TotalDescuento { get; set; }

        [ScaffoldColumn(false)]
        public int DirEnvioId { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Calle { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Puerta { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Ciudad { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Provincia { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public int Numero { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public int Escalera { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public int Piso { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public int CodPos { get; set; }

        [ScaffoldColumn(false)]
        public int MetodoPago { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public int Puntos { get; set; }


    }

    public class FacturaViewModel
    {
        [ScaffoldColumn(false)]
        public int FacturaId { get; set; }

        [ScaffoldColumn(false)]
        public int PedidoId { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float SubTotal { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Total { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Iva { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Descuento { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Email { get; set; }

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Telefono { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
