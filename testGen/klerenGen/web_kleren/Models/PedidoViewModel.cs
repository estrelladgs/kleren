using KlerenGen.ApplicationCore.EN.Kleren;
using System;
using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int PedidoId { get; set; }  // ID del pedido

        [Display(Prompt = "Introduce la fecha del pedido", Description = "Fecha del pedido", Name = "Fecha del pedido")]
        public DateTime? FechaEnviado { get; set; }

        [Display(Prompt = "Introduce la fecha del pedido", Description = "Fecha del pedido", Name = "Fecha del pedido")]
        public DateTime? FechaPagado { get; set; }

        [Display(Prompt = "Introduce la fecha del pedido", Description = "Fecha del pedido", Name = "Fecha del pedido")]
        public DateTime? FechaProcesado { get; set; }

        [Display(Prompt = "Introduce la fecha del pedido", Description = "Fecha del pedido", Name = "Fecha del pedido")]
        public DateTime? FechaEntregado { get; set; }

        public int DirEnvioId { get; set; }  // Relación con la dirección de envío

        [Display(Prompt = "Selecciona el usuario registrado", Description = "Usuario registrado", Name = "Usuario registrado")]
        [Required(ErrorMessage = "Debe seleccionar un usuario registrado")]
        public int UsuarioRegistradoId { get; set; }  // Relación con el usuario registrado*/


        [Display(Prompt = "Indica el estado del pedido", Description = "Estado del pedido", Name = "Estado")]
        public KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double Total { get; set; }

        [Display(Prompt = "Introduce el total descuento del pedido", Description = "Total descuento del pedido", Name = "TotalDescuento")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double TotalDescuento { get; set; }

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

        [Display(Prompt = "Introduce el nombre del artículo", Description = "Nombre del artículo", Name = "NombreArt")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    
        public string Correo { get; set; }


        [ScaffoldColumn(false)]
        public int MetodoPago { get; set; }

        }

    }
