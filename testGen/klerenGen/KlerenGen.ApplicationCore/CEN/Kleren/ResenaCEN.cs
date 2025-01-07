

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ResenaCEN
 *
 */
public partial class ResenaCEN
{
private IResenaRepository _IResenaRepository;

public ResenaCEN(IResenaRepository _IResenaRepository)
{
        this._IResenaRepository = _IResenaRepository;
}

public IResenaRepository get_IResenaRepository ()
{
        return this._IResenaRepository;
}

public int Nueva (int p_usuarioRegistrado, int p_articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum p_numeroEstrellas, string p_comentario, Nullable<DateTime> p_fecha)
{
        ResenaEN resenaEN = null;
        int oid;

        //Initialized ResenaEN
        resenaEN = new ResenaEN ();

        if (p_usuarioRegistrado != -1) {
                // El argumento p_usuarioRegistrado -> Property usuarioRegistrado es oid = false
                // Lista de oids resenaId
                resenaEN.UsuarioRegistrado = new KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN ();
                resenaEN.UsuarioRegistrado.UsuarioRegistradoId = p_usuarioRegistrado;
        }


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids resenaId
                resenaEN.Articulo = new KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN ();
                resenaEN.Articulo.ArticuloId = p_articulo;
        }

        resenaEN.NumeroEstrellas = p_numeroEstrellas;

        resenaEN.Comentario = p_comentario;

        resenaEN.Fecha = p_fecha;



        oid = _IResenaRepository.Nueva (resenaEN);
        return oid;
}

public void Modificar (int p_Resena_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum p_numeroEstrellas, string p_comentario, Nullable<DateTime> p_fecha)
{
        ResenaEN resenaEN = null;

        //Initialized ResenaEN
        resenaEN = new ResenaEN ();
        resenaEN.ResenaId = p_Resena_OID;
        resenaEN.NumeroEstrellas = p_numeroEstrellas;
        resenaEN.Comentario = p_comentario;
        resenaEN.Fecha = p_fecha;
        //Call to ResenaRepository

        _IResenaRepository.Modificar (resenaEN);
}

public void Borrar (int resenaId
                    )
{
        _IResenaRepository.Borrar (resenaId);
}

public ResenaEN DamePorId (int resenaId
                           )
{
        ResenaEN resenaEN = null;

        resenaEN = _IResenaRepository.DamePorId (resenaId);
        return resenaEN;
}

public System.Collections.Generic.IList<ResenaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ResenaEN> list = null;

        list = _IResenaRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> DameResenasPorArticulo (int p_articulo)
{
        return _IResenaRepository.DameResenasPorArticulo (p_articulo);
}
}
}
