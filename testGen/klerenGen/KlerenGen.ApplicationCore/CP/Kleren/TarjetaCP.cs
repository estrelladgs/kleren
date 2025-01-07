
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.Utils;



namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class TarjetaCP : GenericBasicCP
{
public TarjetaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public TarjetaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
