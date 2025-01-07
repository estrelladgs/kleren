

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class PorcentajeCEN
 *
 */
public partial class PorcentajeCEN
{
private IPorcentajeRepository _IPorcentajeRepository;

public PorcentajeCEN(IPorcentajeRepository _IPorcentajeRepository)
{
        this._IPorcentajeRepository = _IPorcentajeRepository;
}

public IPorcentajeRepository get_IPorcentajeRepository ()
{
        return this._IPorcentajeRepository;
}

public int Nuevo (int p_composicion, int p_material, float p_porcentaje)
{
        PorcentajeEN porcentajeEN = null;
        int oid;

        //Initialized PorcentajeEN
        porcentajeEN = new PorcentajeEN ();

        if (p_composicion != -1) {
                // El argumento p_composicion -> Property composicion es oid = false
                // Lista de oids id
                porcentajeEN.Composicion = new KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN ();
                porcentajeEN.Composicion.ComposicionId = p_composicion;
        }


        if (p_material != -1) {
                // El argumento p_material -> Property material es oid = false
                // Lista de oids id
                porcentajeEN.Material = new KlerenGen.ApplicationCore.EN.Kleren.MaterialEN ();
                porcentajeEN.Material.Id = p_material;
        }

        porcentajeEN.Porcentaje = p_porcentaje;



        oid = _IPorcentajeRepository.Nuevo (porcentajeEN);
        return oid;
}

public void Modificar (int p_Porcentaje_OID, float p_porcentaje)
{
        PorcentajeEN porcentajeEN = null;

        //Initialized PorcentajeEN
        porcentajeEN = new PorcentajeEN ();
        porcentajeEN.Id = p_Porcentaje_OID;
        porcentajeEN.Porcentaje = p_porcentaje;
        //Call to PorcentajeRepository

        _IPorcentajeRepository.Modificar (porcentajeEN);
}

public void Borrar (int id
                    )
{
        _IPorcentajeRepository.Borrar (id);
}

public PorcentajeEN DamePorId (int id
                               )
{
        PorcentajeEN porcentajeEN = null;

        porcentajeEN = _IPorcentajeRepository.DamePorId (id);
        return porcentajeEN;
}

public System.Collections.Generic.IList<PorcentajeEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PorcentajeEN> list = null;

        list = _IPorcentajeRepository.DameTodos (first, size);
        return list;
}
}
}
