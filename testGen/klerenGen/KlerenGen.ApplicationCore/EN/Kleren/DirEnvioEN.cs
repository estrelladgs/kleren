
using System;
// Definición clase DirEnvioEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class DirEnvioEN
{
/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo escalera
 */
private int escalera;



/**
 *	Atributo piso
 */
private int piso;



/**
 *	Atributo puerta
 */
private string puerta;



/**
 *	Atributo codPost
 */
private int codPost;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo pedidos
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedidos;



/**
 *	Atributo dirEnvioId
 */
private int dirEnvioId;



/**
 *	Atributo usuarioRegistrado
 */
private KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado;






public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual int Escalera {
        get { return escalera; } set { escalera = value;  }
}



public virtual int Piso {
        get { return piso; } set { piso = value;  }
}



public virtual string Puerta {
        get { return puerta; } set { puerta = value;  }
}



public virtual int CodPost {
        get { return codPost; } set { codPost = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> Pedidos {
        get { return pedidos; } set { pedidos = value;  }
}



public virtual int DirEnvioId {
        get { return dirEnvioId; } set { dirEnvioId = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN UsuarioRegistrado {
        get { return usuarioRegistrado; } set { usuarioRegistrado = value;  }
}





public DirEnvioEN()
{
        pedidos = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>();
}



public DirEnvioEN(int dirEnvioId, string calle, int numero, int escalera, int piso, string puerta, int codPost, string ciudad, string provincia, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedidos, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado
                  )
{
        this.init (DirEnvioId, calle, numero, escalera, piso, puerta, codPost, ciudad, provincia, pedidos, usuarioRegistrado);
}


public DirEnvioEN(DirEnvioEN dirEnvio)
{
        this.init (dirEnvio.DirEnvioId, dirEnvio.Calle, dirEnvio.Numero, dirEnvio.Escalera, dirEnvio.Piso, dirEnvio.Puerta, dirEnvio.CodPost, dirEnvio.Ciudad, dirEnvio.Provincia, dirEnvio.Pedidos, dirEnvio.UsuarioRegistrado);
}

private void init (int dirEnvioId
                   , string calle, int numero, int escalera, int piso, string puerta, int codPost, string ciudad, string provincia, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedidos, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado)
{
        this.DirEnvioId = dirEnvioId;


        this.Calle = calle;

        this.Numero = numero;

        this.Escalera = escalera;

        this.Piso = piso;

        this.Puerta = puerta;

        this.CodPost = codPost;

        this.Ciudad = ciudad;

        this.Provincia = provincia;

        this.Pedidos = pedidos;

        this.UsuarioRegistrado = usuarioRegistrado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DirEnvioEN t = obj as DirEnvioEN;
        if (t == null)
                return false;
        if (DirEnvioId.Equals (t.DirEnvioId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.DirEnvioId.GetHashCode ();
        return hash;
}
}
}
