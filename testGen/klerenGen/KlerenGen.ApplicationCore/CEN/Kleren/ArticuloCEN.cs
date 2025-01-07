

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloRepository _IArticuloRepository;

public ArticuloCEN(IArticuloRepository _IArticuloRepository)
{
        this._IArticuloRepository = _IArticuloRepository;
}

public IArticuloRepository get_IArticuloRepository ()
{
        return this._IArticuloRepository;
}

public void Modificar (int p_Articulo_OID, float p_precio, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum p_categoria, KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum p_sexo, bool p_promocion, float p_precio_oferta, string p_nombre, string p_trazabilidad, KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum p_parte)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.ArticuloId = p_Articulo_OID;
        articuloEN.Precio = p_precio;
        articuloEN.Categoria = p_categoria;
        articuloEN.Sexo = p_sexo;
        articuloEN.Promocion = p_promocion;
        articuloEN.Precio_oferta = p_precio_oferta;
        articuloEN.Nombre = p_nombre;
        articuloEN.Trazabilidad = p_trazabilidad;
        articuloEN.Parte = p_parte;
        //Call to ArticuloRepository

        _IArticuloRepository.Modificar (articuloEN);
}

public void Borrar (int articuloId
                    )
{
        _IArticuloRepository.Borrar (articuloId);
}

public ArticuloEN DamePorId (int articuloId
                             )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloRepository.DamePorId (articuloId);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorSexoYTipoPrenda (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum? p_sexo, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum ? p_categoria)
{
        return _IArticuloRepository.DameArticulosPorSexoYTipoPrenda (p_sexo, p_categoria);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorNombre (string p_input)
{
        return _IArticuloRepository.DameArticulosPorNombre (p_input);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorColor (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color)
{
        return _IArticuloRepository.DameArticulosPorColor (p_color);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorMaterial (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum ? p_material)
{
        return _IArticuloRepository.DameArticulosPorMaterial (p_material);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorRangoPrecio (int? p_precio_min, int ? p_precio_max)
{
        return _IArticuloRepository.DameArticulosPorRangoPrecio (p_precio_min, p_precio_max);
}
public void AsociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs)
{
        //Call to ArticuloRepository

        _IArticuloRepository.AsociarCuidado (p_Articulo_OID, p_cuidados_OIDs);
}
public void DesasociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs)
{
        //Call to ArticuloRepository

        _IArticuloRepository.DesasociarCuidado (p_Articulo_OID, p_cuidados_OIDs);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnPromocionPorSexo (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum ? p_sexo)
{
        return _IArticuloRepository.DameArticulosEnPromocionPorSexo (p_sexo);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantes (int p_articulo)
{
        return _IArticuloRepository.DameVariantes (p_articulo);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantesPorColor (int p_articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color)
{
        return _IArticuloRepository.DameVariantesPorColor (p_articulo, p_color);
}
}
}
