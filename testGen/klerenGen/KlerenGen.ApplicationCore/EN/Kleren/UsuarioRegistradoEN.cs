
using System;
// Definición clase UsuarioRegistradoEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class UsuarioRegistradoEN
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
 *	Atributo resenas
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas;



/**
 *	Atributo listaDeseos
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido;



/**
 *	Atributo medidasUsuario
 */
private KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN medidasUsuario;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo dirEnvio
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN> dirEnvio;



/**
 *	Atributo usuarioRegistradoId
 */
private int usuarioRegistradoId;



/**
 *	Atributo puntos
 */
private int puntos;



/**
 *	Atributo tokenCompartido
 */
private string tokenCompartido;






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



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> Resenas {
        get { return resenas; } set { resenas = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN MedidasUsuario {
        get { return medidasUsuario; } set { medidasUsuario = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN> DirEnvio {
        get { return dirEnvio; } set { dirEnvio = value;  }
}



public virtual int UsuarioRegistradoId {
        get { return usuarioRegistradoId; } set { usuarioRegistradoId = value;  }
}



public virtual int Puntos {
        get { return puntos; } set { puntos = value;  }
}



public virtual string TokenCompartido {
        get { return tokenCompartido; } set { tokenCompartido = value;  }
}





public UsuarioRegistradoEN()
{
        resenas = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN>();
        listaDeseos = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN>();
        pedido = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>();
        dirEnvio = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN>();
}



public UsuarioRegistradoEN(int usuarioRegistradoId, string nombre, string apellidos, string correo, string telefono, Nullable<DateTime> fecha_nac, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido, KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN medidasUsuario, String pass, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN> dirEnvio, int puntos, string tokenCompartido
                           )
{
        this.init (UsuarioRegistradoId, nombre, apellidos, correo, telefono, fecha_nac, resenas, listaDeseos, pedido, medidasUsuario, pass, dirEnvio, puntos, tokenCompartido);
}


public UsuarioRegistradoEN(UsuarioRegistradoEN usuarioRegistrado)
{
        this.init (usuarioRegistrado.UsuarioRegistradoId, usuarioRegistrado.Nombre, usuarioRegistrado.Apellidos, usuarioRegistrado.Correo, usuarioRegistrado.Telefono, usuarioRegistrado.Fecha_nac, usuarioRegistrado.Resenas, usuarioRegistrado.ListaDeseos, usuarioRegistrado.Pedido, usuarioRegistrado.MedidasUsuario, usuarioRegistrado.Pass, usuarioRegistrado.DirEnvio, usuarioRegistrado.Puntos, usuarioRegistrado.TokenCompartido);
}

private void init (int usuarioRegistradoId
                   , string nombre, string apellidos, string correo, string telefono, Nullable<DateTime> fecha_nac, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido, KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN medidasUsuario, String pass, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN> dirEnvio, int puntos, string tokenCompartido)
{
        this.UsuarioRegistradoId = usuarioRegistradoId;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Correo = correo;

        this.Telefono = telefono;

        this.Fecha_nac = fecha_nac;

        this.Resenas = resenas;

        this.ListaDeseos = listaDeseos;

        this.Pedido = pedido;

        this.MedidasUsuario = medidasUsuario;

        this.Pass = pass;

        this.DirEnvio = dirEnvio;

        this.Puntos = puntos;

        this.TokenCompartido = tokenCompartido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioRegistradoEN t = obj as UsuarioRegistradoEN;
        if (t == null)
                return false;
        if (UsuarioRegistradoId.Equals (t.UsuarioRegistradoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.UsuarioRegistradoId.GetHashCode ();
        return hash;
}
}
}
