using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class ListaDeseosAssembler
    {
        public ListaDeseosViewModel ConvertirToViewModel(string nombre, IList<ArticuloViewModel> articulos)
        {
            ListaDeseosViewModel lista = new ListaDeseosViewModel();

            lista.NombreRemitente = nombre;
            lista.Articulos = articulos;

            return lista;
        }
    }
}
