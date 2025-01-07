using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Enumerated.Kleren;
using NHibernate;
using NHibernate.Type;
using NUnit.Core;
using System.Security.Cryptography;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class ArticuloAssembler
    {

       public ArticuloViewModel ConvertirENToViewModel (ArticuloEN en, bool favorito)
        {
            ArticuloViewModel art = new ArticuloViewModel();
            art.ArticuloId = en.ArticuloId;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Promocion = en.Promocion;
            art.PrecioOferta = en.Precio_oferta;
            art.Trazabilidad = en.Trazabilidad;
            art.Categoria = en.Categoria;
            art.Sexo = en.Sexo;
            art.Cuidado = en.Cuidados;
       
            //NHibernateUtil.Initialize(en.Composicion);
            art.Composicion = (en.Composicion != null) ? en.Composicion.ComposicionId : null;

            art.Parte = en.Parte;

            art.Favorito = favorito;

            return art;
        }

        public IList<ArticuloViewModel> ConvertirListENToViewModel (IList<ArticuloEN> ens, bool favorito)
        {
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();
            foreach (ArticuloEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en, favorito));
            }
            return arts;
        }

        public DetalleArticuloViewModel ConvertirENToDetalleViewModel(ArticuloEN en, bool favorito, IList<ColorEN> colores, IList<TallaEN> tallas, string tallaIdeal)
        {
            DetalleArticuloViewModel art = new DetalleArticuloViewModel();
            art.ArticuloId = en.ArticuloId;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Promocion = en.Promocion;
            art.PrecioOferta = en.Precio_oferta;
            art.Trazabilidad = en.Trazabilidad;
            art.Categoria = en.Categoria;
            art.Sexo = en.Sexo;
            art.Cuidado = en.Cuidados;
            art.Colores = colores;
            art.Tallas = tallas;
            art.TallaIdeal = tallaIdeal;
     

            //NHibernateUtil.Initialize(en.Composicion);
            art.Composicion = (en.Composicion != null) ? en.Composicion.ComposicionId : null;

            art.Parte = en.Parte;

            art.Favorito = favorito;

            return art;
        }
    }
}
