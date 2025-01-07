using KlerenGen.ApplicationCore.EN.Kleren;
using NHibernate;
using NHibernate.Type;
using NUnit.Core;
using System.Security.Cryptography;
using web_kleren.Models;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class LinPedAssembler
    {
        public LinPedViewModel ConvertirENToViewModel (LinPedEN en)
        {
            LinPedViewModel lin = new LinPedViewModel();
            lin.LineaId = en.LineaId;   
            lin.Cantidad = en.Cantidad; 
            lin.Precio = en.Precio;
            lin.VarianteId = en.Variante.VarianteId;
            lin.Stock = en.Variante.Stock;
            lin.TallaId = en.Variante.Talla.TallaId;
            lin.Talla = en.Variante.Talla.Talla;
            lin.ColorId = en.Variante.Color.ColorId;  
            lin.Codigo = en.Variante.Color.Codigo;
            lin.Nombre = en.Variante.Color.Nombre;
            lin.ArtId = en.Variante.Articulo.ArticuloId;
            lin.NombreArt = en.Variante.Articulo.Nombre;
            lin.PrecioArt = en.Variante.Articulo.Precio;
            lin.PrecioOf = en.Variante.Articulo.Precio_oferta;
            lin.Prom = en.Variante.Articulo.Promocion;
            lin.TallaS = en.Variante.Talla.Talla.ToString();
            lin.ColorS = en.Variante.Color.Nombre.ToString();
            return lin;
        }

        public IList<LinPedViewModel> ConvertirListENToViewModel(IList<LinPedEN> ens) { 
            IList<LinPedViewModel> lins = new List<LinPedViewModel>();
            foreach (LinPedEN en in ens)
            {
                lins.Add(ConvertirENToViewModel(en));
            }
            return lins;
        }

        public LinpedEditarViewModel ConvertirLinpedEditarENToViewModel(LinPedEN en, IList<ColorEN> colores, IList<TallaEN> tallas)
        {
            LinpedEditarViewModel lin = new LinpedEditarViewModel();
            lin.LineaId = en.LineaId;
            lin.ArtId = en.Variante.Articulo.ArticuloId;
            lin.NombreArt = en.Variante.Articulo.Nombre;
            lin.Colores = colores;
            lin.Tallas = tallas;
            return lin;
        }
    }
}
