

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using Newtonsoft.Json;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class UsuarioRegistradoCEN
 *
 */
public partial class UsuarioRegistradoCEN
{
private IUsuarioRegistradoRepository _IUsuarioRegistradoRepository;

public UsuarioRegistradoCEN(IUsuarioRegistradoRepository _IUsuarioRegistradoRepository)
{
        this._IUsuarioRegistradoRepository = _IUsuarioRegistradoRepository;
}

public IUsuarioRegistradoRepository get_IUsuarioRegistradoRepository ()
{
        return this._IUsuarioRegistradoRepository;
}

public void Borrar (int usuarioRegistradoId
                    )
{
        _IUsuarioRegistradoRepository.Borrar (usuarioRegistradoId);
}

public UsuarioRegistradoEN DamePorId (int usuarioRegistradoId
                                      )
{
        UsuarioRegistradoEN usuarioRegistradoEN = null;

        usuarioRegistradoEN = _IUsuarioRegistradoRepository.DamePorId (usuarioRegistradoId);
        return usuarioRegistradoEN;
}

public System.Collections.Generic.IList<UsuarioRegistradoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioRegistradoEN> list = null;

        list = _IUsuarioRegistradoRepository.DameTodos (first, size);
        return list;
}
public KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN DamePorCorreo (string p_correo)
{
        return _IUsuarioRegistradoRepository.DamePorCorreo (p_correo);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnListaDeseos (int p_usuario)
{
        return _IUsuarioRegistradoRepository.DameArticulosEnListaDeseos (p_usuario);
}
public string DameTokenPorUsuario (int p_usuario)
{
        return _IUsuarioRegistradoRepository.DameTokenPorUsuario (p_usuario);
}



private string Encode (int usuarioRegistradoId)
{
        var payload = new Dictionary<string, object>(){
                { "usuarioRegistradoId", usuarioRegistradoId }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int usuarioRegistradoId)
{
        UsuarioRegistradoEN en = _IUsuarioRegistradoRepository.ReadOIDDefault (usuarioRegistradoId);
        string token = Encode (en.UsuarioRegistradoId);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerUSUARIOREGISTRADOID (decodedToken);

                UsuarioRegistradoEN en = _IUsuarioRegistradoRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.UsuarioRegistradoId).Equals (ObtenerUSUARIOREGISTRADOID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerUSUARIOREGISTRADOID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long usuarioregistradoid = (long)results ["usuarioRegistradoId"];
                return usuarioregistradoid;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
