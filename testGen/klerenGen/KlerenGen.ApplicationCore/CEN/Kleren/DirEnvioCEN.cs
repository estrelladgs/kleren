

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class DirEnvioCEN
 *
 */
public partial class DirEnvioCEN
{
private IDirEnvioRepository _IDirEnvioRepository;

public DirEnvioCEN(IDirEnvioRepository _IDirEnvioRepository)
{
        this._IDirEnvioRepository = _IDirEnvioRepository;
}

public IDirEnvioRepository get_IDirEnvioRepository ()
{
        return this._IDirEnvioRepository;
}

public int Nueva (string p_calle, int p_numero, int p_escalera, int p_piso, string p_puerta, int p_codPost, string p_ciudad, string p_provincia, int p_usuarioRegistrado)
{
        DirEnvioEN dirEnvioEN = null;
        int oid;

        //Initialized DirEnvioEN
        dirEnvioEN = new DirEnvioEN ();
        dirEnvioEN.Calle = p_calle;

        dirEnvioEN.Numero = p_numero;

        dirEnvioEN.Escalera = p_escalera;

        dirEnvioEN.Piso = p_piso;

        dirEnvioEN.Puerta = p_puerta;

        dirEnvioEN.CodPost = p_codPost;

        dirEnvioEN.Ciudad = p_ciudad;

        dirEnvioEN.Provincia = p_provincia;


        if (p_usuarioRegistrado != -1) {
                // El argumento p_usuarioRegistrado -> Property usuarioRegistrado es oid = false
                // Lista de oids dirEnvioId
                dirEnvioEN.UsuarioRegistrado = new KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN ();
                dirEnvioEN.UsuarioRegistrado.UsuarioRegistradoId = p_usuarioRegistrado;
        }



        oid = _IDirEnvioRepository.Nueva (dirEnvioEN);
        return oid;
}

public void Modificar (int p_DirEnvio_OID, string p_calle, int p_numero, int p_escalera, int p_piso, string p_puerta, int p_codPost, string p_ciudad, string p_provincia)
{
        DirEnvioEN dirEnvioEN = null;

        //Initialized DirEnvioEN
        dirEnvioEN = new DirEnvioEN ();
        dirEnvioEN.DirEnvioId = p_DirEnvio_OID;
        dirEnvioEN.Calle = p_calle;
        dirEnvioEN.Numero = p_numero;
        dirEnvioEN.Escalera = p_escalera;
        dirEnvioEN.Piso = p_piso;
        dirEnvioEN.Puerta = p_puerta;
        dirEnvioEN.CodPost = p_codPost;
        dirEnvioEN.Ciudad = p_ciudad;
        dirEnvioEN.Provincia = p_provincia;
        //Call to DirEnvioRepository

        _IDirEnvioRepository.Modificar (dirEnvioEN);
}

public void Borrar (int dirEnvioId
                    )
{
        _IDirEnvioRepository.Borrar (dirEnvioId);
}

public DirEnvioEN DamePorId (int dirEnvioId
                             )
{
        DirEnvioEN dirEnvioEN = null;

        dirEnvioEN = _IDirEnvioRepository.DamePorId (dirEnvioId);
        return dirEnvioEN;
}

public System.Collections.Generic.IList<DirEnvioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<DirEnvioEN> list = null;

        list = _IDirEnvioRepository.DameTodos (first, size);
        return list;
}
}
}
