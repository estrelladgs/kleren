using KlerenGen.ApplicationCore.EN.Kleren;
using System;
using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class DevolucionViewModel
    {
        [ScaffoldColumn(false)]
        public int DevolucionId { get; set; }  // ID del pedido


        public int UsuarioRegistradoId { get; set; }  // Relación con el usuario registrado*/

        [Display(Prompt = "Introduce el total del pedido", Description = "Total del pedido", Name = "Total")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double Total { get; set; }


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

        public string Rechazo{ get; set; }

        public KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum Estado{ get; set; }


        [ScaffoldColumn(false)]
        public int MetodoPago { get; set; }

        }

    }
