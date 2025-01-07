
using System;
using System.Collections.Generic;
using System.Text;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRegistradoRepository usuarioregistradorepository;
protected IAdministradorRepository administradorrepository;
protected IArticuloRepository articulorepository;
protected IPedidoRepository pedidorepository;
protected IDirEnvioRepository direnviorepository;
protected ILinPedRepository linpedrepository;
protected IVarianteRepository varianterepository;
protected IColorRepository colorrepository;
protected ITallaRepository tallarepository;
protected IParteAbajoRepository parteabajorepository;
protected IParteArribaRepository partearribarepository;
protected IMetodoPagoRepository metodopagorepository;
protected IPaypalRepository paypalrepository;
protected ITarjetaRepository tarjetarepository;
protected IResenaRepository resenarepository;
protected IMaterialRepository materialrepository;
protected IAvisoStockRepository avisostockrepository;
protected ICuidadoRepository cuidadorepository;
protected IListaDeseosRepository listadeseosrepository;
protected IMedidasUsuarioRepository medidasusuariorepository;
protected IFacturaRepository facturarepository;
protected IImagenResenaRepository imagenresenarepository;
protected IDevolucionRepository devolucionrepository;
protected IComposicionRepository composicionrepository;
protected IPorcentajeRepository porcentajerepository;
protected IImagenVarianteRepository imagenvarianterepository;


public abstract IUsuarioRegistradoRepository UsuarioRegistradoRepository {
        get;
}
public abstract IAdministradorRepository AdministradorRepository {
        get;
}
public abstract IArticuloRepository ArticuloRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IDirEnvioRepository DirEnvioRepository {
        get;
}
public abstract ILinPedRepository LinPedRepository {
        get;
}
public abstract IVarianteRepository VarianteRepository {
        get;
}
public abstract IColorRepository ColorRepository {
        get;
}
public abstract ITallaRepository TallaRepository {
        get;
}
public abstract IParteAbajoRepository ParteAbajoRepository {
        get;
}
public abstract IParteArribaRepository ParteArribaRepository {
        get;
}
public abstract IMetodoPagoRepository MetodoPagoRepository {
        get;
}
public abstract IPaypalRepository PaypalRepository {
        get;
}
public abstract ITarjetaRepository TarjetaRepository {
        get;
}
public abstract IResenaRepository ResenaRepository {
        get;
}
public abstract IMaterialRepository MaterialRepository {
        get;
}
public abstract IAvisoStockRepository AvisoStockRepository {
        get;
}
public abstract ICuidadoRepository CuidadoRepository {
        get;
}
public abstract IListaDeseosRepository ListaDeseosRepository {
        get;
}
public abstract IMedidasUsuarioRepository MedidasUsuarioRepository {
        get;
}
public abstract IFacturaRepository FacturaRepository {
        get;
}
public abstract IImagenResenaRepository ImagenResenaRepository {
        get;
}
public abstract IDevolucionRepository DevolucionRepository {
        get;
}
public abstract IComposicionRepository ComposicionRepository {
        get;
}
public abstract IPorcentajeRepository PorcentajeRepository {
        get;
}
public abstract IImagenVarianteRepository ImagenVarianteRepository {
        get;
}
}
}
