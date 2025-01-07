
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using System.Linq;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Articulo_mostrarSimilares) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class ArticuloCEN
{
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> MostrarSimilares (int p_articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum p_color)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Articulo_mostrarSimilares) ENABLED START*/

        IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulosAMostrar = null;

        // Obter articuloEN del articulo pasado por parametro
        ArticuloEN articuloBase = _IArticuloRepository.DamePorId (p_articulo);

        // Tenemos que saber el color que ha elegido el usuario, supongamos que es el rosa
        IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulosSimilaresPorColor = DameArticulosPorColor (p_color);

        // Obtener articulos con el mismo sexo y tipo de prenda que el articulo pasado por parametro
        IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulosSimilaresPorSexoYTipo = DameArticulosPorSexoYTipoPrenda (articuloBase.Sexo, articuloBase.Categoria);

        // Guardar los elementos comunes de articulosSimilaresPorColor y articulosSimilaresPorSexoYTipo
        articulosAMostrar = articulosSimilaresPorColor
            .Where(articuloColor => articulosSimilaresPorSexoYTipo
                .Any(articuloSexoTipo => articuloSexoTipo.ArticuloId == articuloColor.ArticuloId))
            .ToList();

        // Eliminar el artículo pasado por parámetro (si existe en la lista)
        articulosAMostrar = articulosAMostrar
            .Where(articuloMostrar => articuloMostrar.ArticuloId != p_articulo)
            .ToList();

            return articulosAMostrar;

        /*PROTECTED REGION END*/
}
}
}
