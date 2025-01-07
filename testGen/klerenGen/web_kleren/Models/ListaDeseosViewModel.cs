using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class ListaDeseosViewModel
    {
        public string NombreRemitente { get; set; }
        public IList<ArticuloViewModel> Articulos { get; set; }
    }
}
