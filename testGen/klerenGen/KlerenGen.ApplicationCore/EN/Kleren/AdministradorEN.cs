
using System;
// Definición clase AdministradorEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class AdministradorEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo correo
 */
private string correo;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo fecha_nac
 */
private Nullable<DateTime> fecha_nac;



/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo adminId
 */
private int adminId;



/**
 *	Atributo pass
 */
private String pass;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Correo {
        get { return correo; } set { correo = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual Nullable<DateTime> Fecha_nac {
        get { return fecha_nac; } set { fecha_nac = value;  }
}



public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual int AdminId {
        get { return adminId; } set { adminId = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public AdministradorEN()
{
}



public AdministradorEN(int adminId, string nombre, string apellidos, string correo, string telefono, Nullable<DateTime> fecha_nac, string dni, String pass
                       )
{
        this.init (AdminId, nombre, apellidos, correo, telefono, fecha_nac, dni, pass);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.AdminId, administrador.Nombre, administrador.Apellidos, administrador.Correo, administrador.Telefono, administrador.Fecha_nac, administrador.Dni, administrador.Pass);
}

private void init (int adminId
                   , string nombre, string apellidos, string correo, string telefono, Nullable<DateTime> fecha_nac, string dni, String pass)
{
        this.AdminId = adminId;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Correo = correo;

        this.Telefono = telefono;

        this.Fecha_nac = fecha_nac;

        this.Dni = dni;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (AdminId.Equals (t.AdminId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.AdminId.GetHashCode ();
        return hash;
}
}
}
