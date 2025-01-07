

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class VarianteCEN
 *
 */
public partial class VarianteCEN
{
private IVarianteRepository _IVarianteRepository;

public VarianteCEN(IVarianteRepository _IVarianteRepository)
{
        this._IVarianteRepository = _IVarianteRepository;
}

public IVarianteRepository get_IVarianteRepository ()
{
        return this._IVarianteRepository;
}

public int Nueva (int p_stock, int p_articulo, int p_talla, int p_color)
{
        VarianteEN varianteEN = null;
        int oid;

        //Initialized VarianteEN
        varianteEN = new VarianteEN ();
        varianteEN.Stock = p_stock;


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids varianteId
                varianteEN.Articulo = new KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN ();
                varianteEN.Articulo.ArticuloId = p_articulo;
        }


        if (p_talla != -1) {
                // El argumento p_talla -> Property talla es oid = false
                // Lista de oids varianteId
                varianteEN.Talla = new KlerenGen.ApplicationCore.EN.Kleren.TallaEN ();
                varianteEN.Talla.TallaId = p_talla;
        }


        if (p_color != -1) {
                // El argumento p_color -> Property color es oid = false
                // Lista de oids varianteId
                varianteEN.Color = new KlerenGen.ApplicationCore.EN.Kleren.ColorEN ();
                varianteEN.Color.ColorId = p_color;
        }



        oid = _IVarianteRepository.Nueva (varianteEN);
        return oid;
}

public void Modificar (int p_Variante_OID, int p_stock)
{
        VarianteEN varianteEN = null;

        //Initialized VarianteEN
        varianteEN = new VarianteEN ();
        varianteEN.VarianteId = p_Variante_OID;
        varianteEN.Stock = p_stock;
        //Call to VarianteRepository

        _IVarianteRepository.Modificar (varianteEN);
}

public void Borrar (int varianteId
                    )
{
        _IVarianteRepository.Borrar (varianteId);
}

public VarianteEN DamePorId (int varianteId
                             )
{
        VarianteEN varianteEN = null;

        varianteEN = _IVarianteRepository.DamePorId (varianteId);
        return varianteEN;
}

public System.Collections.Generic.IList<VarianteEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<VarianteEN> list = null;

        list = _IVarianteRepository.DameTodos (first, size);
        return list;
}
public KlerenGen.ApplicationCore.EN.Kleren.VarianteEN DamePorTallaYColorYArticulo (int p_talla, int p_color, int p_articulo)
{
        return _IVarianteRepository.DamePorTallaYColorYArticulo (p_talla, p_color, p_articulo);
}
}
}
