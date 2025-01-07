

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class DevolucionCEN
 *
 */
public partial class DevolucionCEN
{
private IDevolucionRepository _IDevolucionRepository;

public DevolucionCEN(IDevolucionRepository _IDevolucionRepository)
{
        this._IDevolucionRepository = _IDevolucionRepository;
}

public IDevolucionRepository get_IDevolucionRepository ()
{
        return this._IDevolucionRepository;
}

public void Modificar (int p_Devolucion_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum p_estado, string p_motivoRechazo)
{
        DevolucionEN devolucionEN = null;

        //Initialized DevolucionEN
        devolucionEN = new DevolucionEN ();
        devolucionEN.DevolucionId = p_Devolucion_OID;
        devolucionEN.Estado = p_estado;
        devolucionEN.MotivoRechazo = p_motivoRechazo;
        //Call to DevolucionRepository

        _IDevolucionRepository.Modificar (devolucionEN);
}

public void Eliminar (int devolucionId
                      )
{
        _IDevolucionRepository.Eliminar (devolucionId);
}

public DevolucionEN DamePorId (int devolucionId
                               )
{
        DevolucionEN devolucionEN = null;

        devolucionEN = _IDevolucionRepository.DamePorId (devolucionId);
        return devolucionEN;
}

public System.Collections.Generic.IList<DevolucionEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<DevolucionEN> list = null;

        list = _IDevolucionRepository.DameTodos (first, size);
        return list;
}
}
}
