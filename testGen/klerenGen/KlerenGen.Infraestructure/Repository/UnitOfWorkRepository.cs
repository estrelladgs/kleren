

using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using KlerenGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlerenGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRegistradoRepository UsuarioRegistradoRepository {
        get
        {
                this.usuarioregistradorepository = new UsuarioRegistradoRepository ();
                this.usuarioregistradorepository.setSessionCP (session);
                return this.usuarioregistradorepository;
        }
}

public override IAdministradorRepository AdministradorRepository {
        get
        {
                this.administradorrepository = new AdministradorRepository ();
                this.administradorrepository.setSessionCP (session);
                return this.administradorrepository;
        }
}

public override IArticuloRepository ArticuloRepository {
        get
        {
                this.articulorepository = new ArticuloRepository ();
                this.articulorepository.setSessionCP (session);
                return this.articulorepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IDirEnvioRepository DirEnvioRepository {
        get
        {
                this.direnviorepository = new DirEnvioRepository ();
                this.direnviorepository.setSessionCP (session);
                return this.direnviorepository;
        }
}

public override ILinPedRepository LinPedRepository {
        get
        {
                this.linpedrepository = new LinPedRepository ();
                this.linpedrepository.setSessionCP (session);
                return this.linpedrepository;
        }
}

public override IVarianteRepository VarianteRepository {
        get
        {
                this.varianterepository = new VarianteRepository ();
                this.varianterepository.setSessionCP (session);
                return this.varianterepository;
        }
}

public override IColorRepository ColorRepository {
        get
        {
                this.colorrepository = new ColorRepository ();
                this.colorrepository.setSessionCP (session);
                return this.colorrepository;
        }
}

public override ITallaRepository TallaRepository {
        get
        {
                this.tallarepository = new TallaRepository ();
                this.tallarepository.setSessionCP (session);
                return this.tallarepository;
        }
}

public override IParteAbajoRepository ParteAbajoRepository {
        get
        {
                this.parteabajorepository = new ParteAbajoRepository ();
                this.parteabajorepository.setSessionCP (session);
                return this.parteabajorepository;
        }
}

public override IParteArribaRepository ParteArribaRepository {
        get
        {
                this.partearribarepository = new ParteArribaRepository ();
                this.partearribarepository.setSessionCP (session);
                return this.partearribarepository;
        }
}

public override IMetodoPagoRepository MetodoPagoRepository {
        get
        {
                this.metodopagorepository = new MetodoPagoRepository ();
                this.metodopagorepository.setSessionCP (session);
                return this.metodopagorepository;
        }
}

public override IPaypalRepository PaypalRepository {
        get
        {
                this.paypalrepository = new PaypalRepository ();
                this.paypalrepository.setSessionCP (session);
                return this.paypalrepository;
        }
}

public override ITarjetaRepository TarjetaRepository {
        get
        {
                this.tarjetarepository = new TarjetaRepository ();
                this.tarjetarepository.setSessionCP (session);
                return this.tarjetarepository;
        }
}

public override IResenaRepository ResenaRepository {
        get
        {
                this.resenarepository = new ResenaRepository ();
                this.resenarepository.setSessionCP (session);
                return this.resenarepository;
        }
}

public override IMaterialRepository MaterialRepository {
        get
        {
                this.materialrepository = new MaterialRepository ();
                this.materialrepository.setSessionCP (session);
                return this.materialrepository;
        }
}

public override IAvisoStockRepository AvisoStockRepository {
        get
        {
                this.avisostockrepository = new AvisoStockRepository ();
                this.avisostockrepository.setSessionCP (session);
                return this.avisostockrepository;
        }
}

public override ICuidadoRepository CuidadoRepository {
        get
        {
                this.cuidadorepository = new CuidadoRepository ();
                this.cuidadorepository.setSessionCP (session);
                return this.cuidadorepository;
        }
}

public override IListaDeseosRepository ListaDeseosRepository {
        get
        {
                this.listadeseosrepository = new ListaDeseosRepository ();
                this.listadeseosrepository.setSessionCP (session);
                return this.listadeseosrepository;
        }
}

public override IMedidasUsuarioRepository MedidasUsuarioRepository {
        get
        {
                this.medidasusuariorepository = new MedidasUsuarioRepository ();
                this.medidasusuariorepository.setSessionCP (session);
                return this.medidasusuariorepository;
        }
}

public override IFacturaRepository FacturaRepository {
        get
        {
                this.facturarepository = new FacturaRepository ();
                this.facturarepository.setSessionCP (session);
                return this.facturarepository;
        }
}

public override IImagenResenaRepository ImagenResenaRepository {
        get
        {
                this.imagenresenarepository = new ImagenResenaRepository ();
                this.imagenresenarepository.setSessionCP (session);
                return this.imagenresenarepository;
        }
}

public override IDevolucionRepository DevolucionRepository {
        get
        {
                this.devolucionrepository = new DevolucionRepository ();
                this.devolucionrepository.setSessionCP (session);
                return this.devolucionrepository;
        }
}

public override IComposicionRepository ComposicionRepository {
        get
        {
                this.composicionrepository = new ComposicionRepository ();
                this.composicionrepository.setSessionCP (session);
                return this.composicionrepository;
        }
}

public override IPorcentajeRepository PorcentajeRepository {
        get
        {
                this.porcentajerepository = new PorcentajeRepository ();
                this.porcentajerepository.setSessionCP (session);
                return this.porcentajerepository;
        }
}

public override IImagenVarianteRepository ImagenVarianteRepository {
        get
        {
                this.imagenvarianterepository = new ImagenVarianteRepository ();
                this.imagenvarianterepository.setSessionCP (session);
                return this.imagenvarianterepository;
        }
}
}
}

