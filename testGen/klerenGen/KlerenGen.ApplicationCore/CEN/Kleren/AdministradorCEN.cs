

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
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorRepository _IAdministradorRepository;

public AdministradorCEN(IAdministradorRepository _IAdministradorRepository)
{
        this._IAdministradorRepository = _IAdministradorRepository;
}

public IAdministradorRepository get_IAdministradorRepository ()
{
        return this._IAdministradorRepository;
}

public int Nuevo (string p_nombre, string p_apellidos, string p_correo, string p_telefono, Nullable<DateTime> p_fecha_nac, string p_dni, String p_pass)
{
        AdministradorEN administradorEN = null;
        int oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Correo = p_correo;

        administradorEN.Telefono = p_telefono;

        administradorEN.Fecha_nac = p_fecha_nac;

        administradorEN.Dni = p_dni;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IAdministradorRepository.Nuevo (administradorEN);
        return oid;
}

public void Modificar (int p_Administrador_OID, string p_nombre, string p_apellidos, string p_correo, string p_telefono, Nullable<DateTime> p_fecha_nac, string p_dni, String p_pass)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.AdminId = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Correo = p_correo;
        administradorEN.Telefono = p_telefono;
        administradorEN.Fecha_nac = p_fecha_nac;
        administradorEN.Dni = p_dni;
        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to AdministradorRepository

        _IAdministradorRepository.Modificar (administradorEN);
}

public void Borrar (int adminId
                    )
{
        _IAdministradorRepository.Borrar (adminId);
}

public AdministradorEN DamePorId (int adminId
                                  )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorRepository.DamePorId (adminId);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorRepository.DameTodos (first, size);
        return list;
}
public string Login (int p_Administrador_OID, string p_pass)
{
        string result = null;
        AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (p_Administrador_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.AdminId);

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.AdministradorEN DamePorCorreo (string p_correo)
{
        return _IAdministradorRepository.DamePorCorreo (p_correo);
}



private string Encode (int adminId)
{
        var payload = new Dictionary<string, object>(){
                { "adminId", adminId }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int adminId)
{
        AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (adminId);
        string token = Encode (en.AdminId);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerADMINID (decodedToken);

                AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.AdminId).Equals (ObtenerADMINID (decodedToken))
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


public long ObtenerADMINID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long adminid = (long)results ["adminId"];
                return adminid;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
