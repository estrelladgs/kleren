using System.ComponentModel.DataAnnotations;

namespace web_kleren.Models
{
    public class GestionarImagenesVarianteViewModel
    {

        public int ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public IEnumerable<ColorViewModel> Colores { get; set; }
        public int ColorSeleccionado { get; set; }
        public List<ImagenVarianteViewModel> Imagenes { get; set; }
    }
}
