
using System;
// Definición clase MedidasUsuarioEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class MedidasUsuarioEN
{
/**
 *	Atributo medidasUsuarioId
 */
private int medidasUsuarioId;



/**
 *	Atributo cintura
 */
private int cintura;



/**
 *	Atributo pecho
 */
private int pecho;



/**
 *	Atributo anchoEspalda
 */
private int anchoEspalda;



/**
 *	Atributo caderas
 */
private int caderas;



/**
 *	Atributo largoBrazo
 */
private int largoBrazo;



/**
 *	Atributo largoPierna
 */
private int largoPierna;



/**
 *	Atributo usuarioRegistrado
 */
private KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado;



/**
 *	Atributo tallaIdealSuperior
 */
private string tallaIdealSuperior;



/**
 *	Atributo tallaIdealInferior
 */
private string tallaIdealInferior;






public virtual int MedidasUsuarioId {
        get { return medidasUsuarioId; } set { medidasUsuarioId = value;  }
}



public virtual int Cintura {
        get { return cintura; } set { cintura = value;  }
}



public virtual int Pecho {
        get { return pecho; } set { pecho = value;  }
}



public virtual int AnchoEspalda {
        get { return anchoEspalda; } set { anchoEspalda = value;  }
}



public virtual int Caderas {
        get { return caderas; } set { caderas = value;  }
}



public virtual int LargoBrazo {
        get { return largoBrazo; } set { largoBrazo = value;  }
}



public virtual int LargoPierna {
        get { return largoPierna; } set { largoPierna = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN UsuarioRegistrado {
        get { return usuarioRegistrado; } set { usuarioRegistrado = value;  }
}



public virtual string TallaIdealSuperior {
        get { return tallaIdealSuperior; } set { tallaIdealSuperior = value;  }
}



public virtual string TallaIdealInferior {
        get { return tallaIdealInferior; } set { tallaIdealInferior = value;  }
}





public MedidasUsuarioEN()
{
}



public MedidasUsuarioEN(int medidasUsuarioId, int cintura, int pecho, int anchoEspalda, int caderas, int largoBrazo, int largoPierna, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, string tallaIdealSuperior, string tallaIdealInferior
                        )
{
        this.init (MedidasUsuarioId, cintura, pecho, anchoEspalda, caderas, largoBrazo, largoPierna, usuarioRegistrado, tallaIdealSuperior, tallaIdealInferior);
}


public MedidasUsuarioEN(MedidasUsuarioEN medidasUsuario)
{
        this.init (medidasUsuario.MedidasUsuarioId, medidasUsuario.Cintura, medidasUsuario.Pecho, medidasUsuario.AnchoEspalda, medidasUsuario.Caderas, medidasUsuario.LargoBrazo, medidasUsuario.LargoPierna, medidasUsuario.UsuarioRegistrado, medidasUsuario.TallaIdealSuperior, medidasUsuario.TallaIdealInferior);
}

private void init (int medidasUsuarioId
                   , int cintura, int pecho, int anchoEspalda, int caderas, int largoBrazo, int largoPierna, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, string tallaIdealSuperior, string tallaIdealInferior)
{
        this.MedidasUsuarioId = medidasUsuarioId;


        this.Cintura = cintura;

        this.Pecho = pecho;

        this.AnchoEspalda = anchoEspalda;

        this.Caderas = caderas;

        this.LargoBrazo = largoBrazo;

        this.LargoPierna = largoPierna;

        this.UsuarioRegistrado = usuarioRegistrado;

        this.TallaIdealSuperior = tallaIdealSuperior;

        this.TallaIdealInferior = tallaIdealInferior;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MedidasUsuarioEN t = obj as MedidasUsuarioEN;
        if (t == null)
                return false;
        if (MedidasUsuarioId.Equals (t.MedidasUsuarioId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.MedidasUsuarioId.GetHashCode ();
        return hash;
}
}
}
