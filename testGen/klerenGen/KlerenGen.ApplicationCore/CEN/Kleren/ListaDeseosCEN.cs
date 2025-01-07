

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ListaDeseosCEN
 *
 */
public partial class ListaDeseosCEN
{
private IListaDeseosRepository _IListaDeseosRepository;

public ListaDeseosCEN(IListaDeseosRepository _IListaDeseosRepository)
{
        this._IListaDeseosRepository = _IListaDeseosRepository;
}

public IListaDeseosRepository get_IListaDeseosRepository ()
{
        return this._IListaDeseosRepository;
}

public int Nuevo (int p_usuarioRegistrado, int p_articulo)
{
        ListaDeseosEN listaDeseosEN = null;
        int oid;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();

        if (p_usuarioRegistrado != -1) {
                // El argumento p_usuarioRegistrado -> Property usuarioRegistrado es oid = false
                // Lista de oids listaDeseosID
                listaDeseosEN.UsuarioRegistrado = new KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN ();
                listaDeseosEN.UsuarioRegistrado.UsuarioRegistradoId = p_usuarioRegistrado;
        }


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids listaDeseosID
                listaDeseosEN.Articulo = new KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN ();
                listaDeseosEN.Articulo.ArticuloId = p_articulo;
        }



        oid = _IListaDeseosRepository.Nuevo (listaDeseosEN);
        return oid;
}

public void Modificar (int p_ListaDeseos_OID)
{
        ListaDeseosEN listaDeseosEN = null;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();
        listaDeseosEN.ListaDeseosID = p_ListaDeseos_OID;
        //Call to ListaDeseosRepository

        _IListaDeseosRepository.Modificar (listaDeseosEN);
}

public void Borrar (int listaDeseosID
                    )
{
        _IListaDeseosRepository.Borrar (listaDeseosID);
}

public ListaDeseosEN DamePorId (int listaDeseosID
                                )
{
        ListaDeseosEN listaDeseosEN = null;

        listaDeseosEN = _IListaDeseosRepository.DamePorId (listaDeseosID);
        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> list = null;

        list = _IListaDeseosRepository.DameTodos (first, size);
        return list;
}
public KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN DameListaDeDeseos (int p_usuario, int p_articulo)
{
        return _IListaDeseosRepository.DameListaDeDeseos (p_usuario, p_articulo);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> DameListaDeseosPorUsuarioYArticulo (int p_usuario, int p_articulo)
{
        return _IListaDeseosRepository.DameListaDeseosPorUsuarioYArticulo (p_usuario, p_articulo);
}
}
}
