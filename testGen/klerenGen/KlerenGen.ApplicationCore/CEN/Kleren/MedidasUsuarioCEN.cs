

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class MedidasUsuarioCEN
 *
 */
public partial class MedidasUsuarioCEN
{
private IMedidasUsuarioRepository _IMedidasUsuarioRepository;

public MedidasUsuarioCEN(IMedidasUsuarioRepository _IMedidasUsuarioRepository)
{
        this._IMedidasUsuarioRepository = _IMedidasUsuarioRepository;
}

public IMedidasUsuarioRepository get_IMedidasUsuarioRepository ()
{
        return this._IMedidasUsuarioRepository;
}

public int Nuevo (int p_cintura, int p_pecho, int p_anchoEspalda, int p_caderas, int p_largoBrazo, int p_largoPierna, int p_usuarioRegistrado)
{
        MedidasUsuarioEN medidasUsuarioEN = null;
        int oid;

        //Initialized MedidasUsuarioEN
        medidasUsuarioEN = new MedidasUsuarioEN ();
        medidasUsuarioEN.Cintura = p_cintura;

        medidasUsuarioEN.Pecho = p_pecho;

        medidasUsuarioEN.AnchoEspalda = p_anchoEspalda;

        medidasUsuarioEN.Caderas = p_caderas;

        medidasUsuarioEN.LargoBrazo = p_largoBrazo;

        medidasUsuarioEN.LargoPierna = p_largoPierna;


        if (p_usuarioRegistrado != -1) {
                // El argumento p_usuarioRegistrado -> Property usuarioRegistrado es oid = false
                // Lista de oids medidasUsuarioId
                medidasUsuarioEN.UsuarioRegistrado = new KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN ();
                medidasUsuarioEN.UsuarioRegistrado.UsuarioRegistradoId = p_usuarioRegistrado;
        }



        oid = _IMedidasUsuarioRepository.Nuevo (medidasUsuarioEN);
        return oid;
}

public void Modificar (int p_MedidasUsuario_OID, int p_cintura, int p_pecho, int p_anchoEspalda, int p_caderas, int p_largoBrazo, int p_largoPierna)
{
        MedidasUsuarioEN medidasUsuarioEN = null;

        //Initialized MedidasUsuarioEN
        medidasUsuarioEN = new MedidasUsuarioEN ();
        medidasUsuarioEN.MedidasUsuarioId = p_MedidasUsuario_OID;
        medidasUsuarioEN.Cintura = p_cintura;
        medidasUsuarioEN.Pecho = p_pecho;
        medidasUsuarioEN.AnchoEspalda = p_anchoEspalda;
        medidasUsuarioEN.Caderas = p_caderas;
        medidasUsuarioEN.LargoBrazo = p_largoBrazo;
        medidasUsuarioEN.LargoPierna = p_largoPierna;
        //Call to MedidasUsuarioRepository

        _IMedidasUsuarioRepository.Modificar (medidasUsuarioEN);
}

public void Borrar (int medidasUsuarioId
                    )
{
        _IMedidasUsuarioRepository.Borrar (medidasUsuarioId);
}

public MedidasUsuarioEN DamePorId (int medidasUsuarioId
                                   )
{
        MedidasUsuarioEN medidasUsuarioEN = null;

        medidasUsuarioEN = _IMedidasUsuarioRepository.DamePorId (medidasUsuarioId);
        return medidasUsuarioEN;
}

public System.Collections.Generic.IList<MedidasUsuarioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MedidasUsuarioEN> list = null;

        list = _IMedidasUsuarioRepository.DameTodos (first, size);
        return list;
}
public KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN DameMedidasUsuario (int p_usuario)
{
        return _IMedidasUsuarioRepository.DameMedidasUsuario (p_usuario);
}
}
}
