
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using KlerenGen.Infraestructure.CP;
using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.CP.Kleren;
using KlerenGen.Infraestructure.Repository;
using KlerenGen.ApplicationCore.Enumerated.Kleren;
using System.Linq;
using KlerenGen.Infraestructure.EN.Kleren;
using System.Security.Cryptography;


/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRegistradoRepository usuarioregistradorepository = new UsuarioRegistradoRepository ();
                UsuarioRegistradoCEN usuarioregistradocen = new UsuarioRegistradoCEN (usuarioregistradorepository);
                AdministradorRepository administradorrepository = new AdministradorRepository ();
                AdministradorCEN administradorcen = new AdministradorCEN (administradorrepository);
                ArticuloRepository articulorepository = new ArticuloRepository ();
                ArticuloCEN articulocen = new ArticuloCEN (articulorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                DirEnvioRepository direnviorepository = new DirEnvioRepository ();
                DirEnvioCEN direnviocen = new DirEnvioCEN (direnviorepository);
                LinPedRepository linpedrepository = new LinPedRepository ();
                LinPedCEN linpedcen = new LinPedCEN (linpedrepository);
                VarianteRepository varianterepository = new VarianteRepository ();
                VarianteCEN variantecen = new VarianteCEN (varianterepository);
                ColorRepository colorrepository = new ColorRepository ();
                ColorCEN colorcen = new ColorCEN (colorrepository);
                TallaRepository tallarepository = new TallaRepository ();
                TallaCEN tallacen = new TallaCEN (tallarepository);
                ParteAbajoRepository parteabajorepository = new ParteAbajoRepository ();
                ParteAbajoCEN parteabajocen = new ParteAbajoCEN (parteabajorepository);
                ParteArribaRepository partearribarepository = new ParteArribaRepository ();
                ParteArribaCEN partearribacen = new ParteArribaCEN (partearribarepository);
                MetodoPagoRepository metodopagorepository = new MetodoPagoRepository ();
                MetodoPagoCEN metodopagocen = new MetodoPagoCEN (metodopagorepository);
                PaypalRepository paypalrepository = new PaypalRepository ();
                PaypalCEN paypalcen = new PaypalCEN (paypalrepository);
                TarjetaRepository tarjetarepository = new TarjetaRepository ();
                TarjetaCEN tarjetacen = new TarjetaCEN (tarjetarepository);
                ResenaRepository resenarepository = new ResenaRepository ();
                ResenaCEN resenacen = new ResenaCEN (resenarepository);
                MaterialRepository materialrepository = new MaterialRepository ();
                MaterialCEN materialcen = new MaterialCEN (materialrepository);
                AvisoStockRepository avisostockrepository = new AvisoStockRepository ();
                AvisoStockCEN avisostockcen = new AvisoStockCEN (avisostockrepository);
                CuidadoRepository cuidadorepository = new CuidadoRepository ();
                CuidadoCEN cuidadocen = new CuidadoCEN (cuidadorepository);
                ListaDeseosRepository listadeseosrepository = new ListaDeseosRepository ();
                ListaDeseosCEN listadeseoscen = new ListaDeseosCEN (listadeseosrepository);
                MedidasUsuarioRepository medidasusuariorepository = new MedidasUsuarioRepository ();
                MedidasUsuarioCEN medidasusuariocen = new MedidasUsuarioCEN (medidasusuariorepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                ImagenResenaRepository imagenresenarepository = new ImagenResenaRepository ();
                ImagenResenaCEN imagenresenacen = new ImagenResenaCEN (imagenresenarepository);
                DevolucionRepository devolucionrepository = new DevolucionRepository ();
                DevolucionCEN devolucioncen = new DevolucionCEN (devolucionrepository);
                ComposicionRepository composicionrepository = new ComposicionRepository ();
                ComposicionCEN composicioncen = new ComposicionCEN (composicionrepository);
                PorcentajeRepository porcentajerepository = new PorcentajeRepository ();
                PorcentajeCEN porcentajecen = new PorcentajeCEN (porcentajerepository);
                ImagenVarianteRepository imagenvarianterepository = new ImagenVarianteRepository ();
                ImagenVarianteCEN imagenvariantecen = new ImagenVarianteCEN (imagenvarianterepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                Console.WriteLine ("********************************************************************");

                // Crear colores
                int OID_color_azul = colorcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.azul, "#165BAB");
                int OID_color_blanco = colorcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.blanco, "#FFFFFF");
                int OID_color_rosa = colorcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.rosa, "#FFC0CB");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Colores creados");
                Console.WriteLine ("********************************************************************");


                // Crear talla
                int OID_talla_XS = tallacen.NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.XS);
                int OID_talla_S = tallacen.NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.S);
                int OID_talla_M = tallacen.NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.M);
                int OID_talla_L = tallacen.NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.L);
                int OID_talla_XL = tallacen.NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.XL);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Tallas creados");
                Console.WriteLine ("********************************************************************");



                // Crear materiales
                int OID_material_algodon = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.algodon);
                int OID_material_poliester = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.poliester);
                int OID_material_lana = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.lana);
                int OID_material_lino = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.lino);
                int OID_material_lycra = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.lycra);
                int OID_material_nylon = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.nylon);
                int OID_material_seda = materialcen.Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.seda);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Materiales creados");
                Console.WriteLine ("********************************************************************");



                // Crear composiciones de los materiales
                int OID_composicion1 = composicioncen.Nueva ();
                int OID_composicion2 = composicioncen.Nueva ();
                int OID_composicion3 = composicioncen.Nueva ();
                int OID_composicion4 = composicioncen.Nueva ();
                int OID_composicion5 = composicioncen.Nueva ();
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Composiciones creados");
                Console.WriteLine ("********************************************************************");



                // Crear porcentajes de los materiales
                int OID_porcentaje_camiseta_comfi_algodon = porcentajecen.Nuevo (OID_composicion1, OID_material_algodon, 20);
                int OID_porcentaje_camiseta_comfi_poliester = porcentajecen.Nuevo (OID_composicion1, OID_material_poliester, 30);
                int OID_porcentaje_camiseta_comfi_lana = porcentajecen.Nuevo (OID_composicion1, OID_material_lana, 50);

                int OID_porcentaje_pantalon_cargo_poliester = porcentajecen.Nuevo (OID_composicion2, OID_material_poliester, 10);
                int OID_porcentaje_pantalon_cargo_lino = porcentajecen.Nuevo (OID_composicion2, OID_material_lino, 20);
                int OID_porcentaje_pantalon_cargo_lycra = porcentajecen.Nuevo (OID_composicion2, OID_material_lycra, 20);
                int OID_porcentaje_pantalon_cargo_nylon = porcentajecen.Nuevo (OID_composicion2, OID_material_nylon, 50);

                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Materiales creados");
                Console.WriteLine ("El OID de la composicion 1 es :" + OID_composicion1);
                Console.WriteLine ("********************************************************************");


                // Crear cuidados
                // Crear cuidados
                int OID_cuidado1 = cuidadocen.Nuevo ("Lavado a mano");
                int OID_cuidado2 = cuidadocen.Nuevo ("No centrifugar");
                int OID_cuidado3 = cuidadocen.Nuevo ("No usar secadora");
                int OID_cuidado4 = cuidadocen.Nuevo ("Planchar con paño húmedo");
                int OID_cuidado5 = cuidadocen.Nuevo ("Evitar la exposición directa al sol");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Cuidados creados");
                Console.WriteLine ("********************************************************************");



                // Crear articulos

                ArticuloCP articulocp = new ArticuloCP (new SessionCPNHibernate ());

                ArticuloEN articulo_camiseta_oversize = articulocp.Nuevo (
                        20f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        false,
                        0,
                        "camiseta oversize", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        200);

                ArticuloEN articulo_pantalon_cargo = articulocp.Nuevo (
                        38.5f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.pantalon,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.hombre,
                        false,
                        0,
                        "pantalon cargo", "Bulgaria",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.abajo,
                        100);

                ArticuloEN articulo_camiseta_comfi = articulocp.Nuevo (
                        15f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        false,
                        0,
                        "camiseta comfi", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        40);

                ArticuloEN camiseta_basica = articulocp.Nuevo (
                        20.4f,
                        TipoPrendaEnum.camiseta,
                        SexoEnum.mujer,
                        true,
                        17.5f,
                        "Camiseta basica",
                        "China",
                        PartesEnum.arriba,
                        100);
                ArticuloEN top_mangas_cruzadas = articulocp.Nuevo (
                        30.50f,
                        TipoPrendaEnum.top,
                        SexoEnum.mujer,
                        false,
                        0,
                        "Top rosa mangas cruzadas",
                        "China",
                        PartesEnum.arriba,
                        30);

                // Pantalones

                ArticuloEN pantalon_1 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.pantalon,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        true,
                        0,
                        "pantalon 1", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.abajo,
                        100);

                ArticuloEN pantalon_2 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.pantalon,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        false,
                        0,
                        "pantalon 2", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.abajo,
                        100);

                ArticuloEN pantalon_3 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.pantalon,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.hombre,
                        true,
                        0,
                        "pantalon 3", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.abajo,
                        200);

                ArticuloEN pantalon_4 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.pantalon,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.hombre,
                        false,
                        0,
                        "pantalon 4", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.abajo,
                        30);

                // Camisetas

                ArticuloEN camiseta_1 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        true,
                        0,
                        "camiseta 1", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        40);

                ArticuloEN camiseta_2 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.hombre,
                        false,
                        0,
                        "camiseta 2", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        50);

                ArticuloEN camiseta_3 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.hombre,
                        true,
                        0,
                        "camiseta 3", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        60);

                ArticuloEN camiseta_4 = articulocp.Nuevo (
                        40f,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum.camiseta,
                        KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum.mujer,
                        false,
                        0,
                        "camiseta 4", "Alicante, Espania",
                        KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum.arriba,
                        40);

                ArticuloEN pantalon_vaquero = articulocp.Nuevo (
                        30.5f,
                        TipoPrendaEnum.pantalon,
                        SexoEnum.hombre,
                        false,
                        0,
                        "Pantalon vaquero",
                        "Portugal",
                        PartesEnum.abajo,
                        200
                        );


                // Obtener oids de los articulos creados
                int OID_articulo_camiseta_oversize = articulo_camiseta_oversize.ArticuloId;
                int OID_articulo_pantalon_cargo = articulo_pantalon_cargo.ArticuloId;
                int OID_articulo_camiseta_comfi = articulo_camiseta_comfi.ArticuloId;
                int OID_camiseta_basica = camiseta_basica.ArticuloId;
                int OID_top_mangas_cruzadas = top_mangas_cruzadas.ArticuloId;
                int OID_pantalon_1 = pantalon_1.ArticuloId;
                int OID_pantalon_2 = pantalon_2.ArticuloId;
                int OID_pantalon_3 = pantalon_3.ArticuloId;
                int OID_pantalon_4 = pantalon_4.ArticuloId;
                int OID_camiseta_1 = camiseta_1.ArticuloId;
                int OID_camiseta_2 = camiseta_2.ArticuloId;
                int OID_camiseta_3 = camiseta_3.ArticuloId;
                int OID_camiseta_4 = camiseta_4.ArticuloId;
                int OID_pantalon_vaquero = pantalon_vaquero.ArticuloId;

                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Articulos creados");
                Console.WriteLine ("********************************************************************");


                composicioncen.AsociarArticulo(OID_composicion1, OID_articulo_camiseta_oversize);
                composicioncen.AsociarArticulo(OID_composicion2, OID_articulo_pantalon_cargo);
                composicioncen.AsociarArticulo(OID_composicion3, OID_articulo_camiseta_comfi);
                composicioncen.AsociarArticulo(OID_composicion4, OID_camiseta_basica);
                composicioncen.AsociarArticulo(OID_composicion5, OID_top_mangas_cruzadas);
                composicioncen.AsociarArticulo(OID_composicion1, OID_pantalon_1);
                composicioncen.AsociarArticulo(OID_composicion2, OID_pantalon_2);
                composicioncen.AsociarArticulo(OID_composicion1, OID_pantalon_3);
                composicioncen.AsociarArticulo(OID_composicion3, OID_pantalon_4);
                composicioncen.AsociarArticulo(OID_composicion4, OID_camiseta_1);
                composicioncen.AsociarArticulo(OID_composicion5, OID_camiseta_2);
                composicioncen.AsociarArticulo(OID_composicion1, OID_camiseta_3);
                composicioncen.AsociarArticulo(OID_composicion2, OID_camiseta_4);

                /*
                IList<MaterialEN> materiales =  articulocp.DameMaterialesDelArticulo(OID_pantalon_1);
                Console.WriteLine("********************************************************************");
                Console.WriteLine("LOS MATERIALES SON:");
                for (int i = 0; i < materiales.Count; i++)
                {
                    Console.WriteLine("material: " + materiales[i].Material);
                }
                Console.WriteLine("********************************************************************");
                */


                // Crear Parte Abajo
                int idParteAbajo = parteabajocen.Nuevo (TallasEnum.XS, 64, 88, 96);
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Se crea la parte de abajo correctamente. ID: " + idParteAbajo);
                Console.WriteLine ("********************************************************************************************");

                // Crear Parte Arriba
                int idParteArriba = partearribacen.Nuevo (TallasEnum.M, 88, 62, 40);
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Se crea la parte de arriba correctamente. ID: " + idParteArriba);
                Console.WriteLine ("********************************************************************************************");

                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Variantes creados");
                Console.WriteLine ("********************************************************************");



                // Mostrar todos los articulos creados
                IList<ArticuloEN> todosLosArticulos = articulocen.DameTodos (0, -1);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("LOS ARTICULOS QUE EXISTEN SON:");
                for (int i = 0; i < todosLosArticulos.Count; i++) {
                        Console.WriteLine ("articulo: " + todosLosArticulos [i].Nombre);
                }
                Console.WriteLine ("********************************************************************");


                // Mostrar las variantes de todos los articulos creados (chapucero...)
                IList<VarianteEN> variantesDeCamisetaComfi = new List<VarianteEN> ();
                IList<VarianteEN> variantesDeCamisetaOversize = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalonCargo = new List<VarianteEN>();
                IList<VarianteEN> variantesDeCamisetaBasica = new List<VarianteEN>();
                IList<VarianteEN> variantesDeTopMangasCruzadas = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalon1 = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalon2 = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalon3 = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalon4 = new List<VarianteEN>();
                IList<VarianteEN> variantesDeCamiseta1 = new List<VarianteEN>();
                IList<VarianteEN> variantesDeCamiseta2 = new List<VarianteEN>();
                IList<VarianteEN> variantesDeCamiseta3 = new List<VarianteEN>();
                IList<VarianteEN> variantesDeCamiseta4 = new List<VarianteEN>();
                IList<VarianteEN> variantesDePantalonVaquero = new List<VarianteEN>();

                foreach (VarianteEN variante in articulo_camiseta_comfi.Variante) {
                        variantesDeCamisetaComfi.Add (variante);
                }
                foreach (VarianteEN variante in articulo_camiseta_oversize.Variante) {
                        variantesDeCamisetaOversize.Add (variante);
                }
                foreach (VarianteEN variante in articulo_pantalon_cargo.Variante) {
                        variantesDePantalonCargo.Add (variante);
                }
                foreach (VarianteEN variante in camiseta_basica.Variante) {
                        variantesDeCamisetaBasica.Add (variante);
                }
                foreach (VarianteEN variante in top_mangas_cruzadas.Variante) {
                        variantesDeTopMangasCruzadas.Add (variante);
                }
                foreach (VarianteEN variante in pantalon_1.Variante) {
                        variantesDePantalon1.Add (variante);
                }
                foreach (VarianteEN variante in pantalon_2.Variante) {
                        variantesDePantalon2.Add (variante);
                }
                foreach (VarianteEN variante in pantalon_3.Variante) {
                        variantesDePantalon3.Add (variante);
                }
                foreach (VarianteEN variante in pantalon_4.Variante) {
                        variantesDePantalon4.Add (variante);
                }
                foreach (VarianteEN variante in camiseta_1.Variante) {
                        variantesDeCamiseta1.Add (variante);
                }
                foreach (VarianteEN variante in camiseta_2.Variante) {
                        variantesDeCamiseta2.Add (variante);
                }
                foreach (VarianteEN variante in camiseta_3.Variante) {
                        variantesDeCamiseta3.Add (variante);
                }
                foreach (VarianteEN variante in camiseta_4.Variante) {
                        variantesDeCamiseta4.Add (variante);
                }
                foreach (VarianteEN variante in pantalon_vaquero.Variante) {
                        variantesDePantalonVaquero.Add (variante);
                }

                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("ALGUNOS ARTICULOS CON TODAS SUS VARIANTES QUE EXISTEN:");
                Console.WriteLine ("camiseta comfi:");
                foreach (VarianteEN variante in variantesDeCamisetaComfi) {
                        Console.WriteLine ("variante: " + variante.Color.Nombre + " " + variante.Talla.Talla + " " + variante.Stock);
                }
                Console.WriteLine ("pantalon 1:");
                foreach (VarianteEN variante in variantesDePantalon1) {
                        Console.WriteLine ("variante: " + variante.Color.Nombre + " " + variante.Talla.Talla + " " + variante.Stock);
                }
                Console.WriteLine ("pantalon vaquero:");
                foreach (VarianteEN variante in variantesDePantalonVaquero) {
                        Console.WriteLine ("variante: " + variante.Color.Nombre + " " + variante.Talla.Talla + " " + variante.Stock);
                }


                // Filtrar articulos por color
                IList<ArticuloEN> solucionColor = articulocen.DameArticulosPorColor (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.rosa);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("SOLUCION FILTRAR POR COLOR: ");
                for (int i = 0; i < solucionColor.Count; i++) {
                        Console.WriteLine ("articulo: " + solucionColor [i].Nombre);
                }
                Console.WriteLine ("numero de articulos con ese color: " + solucionColor.Count);
                if (solucionColor.Count == 0) {
                        // La pagina deberia de estar vacia y mostrar un mensaje estilo "NO SE HAN ENCONTRADO RESULTADOS PARA ESA BUSQUEDA".
                }
                Console.WriteLine ("********************************************************************");



                // Filtrar articulos por material
                IList<ArticuloEN> solucionMaterial = articulocen.DameArticulosPorMaterial (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum.nylon);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("SOLUCION FILTRAR POR MATERIAL: ");
                for (int i = 0; i < solucionMaterial.Count; i++) {
                        Console.WriteLine ("articulo: " + solucionMaterial [i].Nombre);
                }
                Console.WriteLine ("numero de articulos con ese material: " + solucionMaterial.Count);
                if (solucionMaterial.Count == 0) {
                        // La pagina deberia de estar vacia y mostrar un mensaje estilo "NO SE HAN ENCONTRADO RESULTADOS PARA ESA BUSQUEDA".
                }
                Console.WriteLine ("********************************************************************");



                // Filtrar articulos por rango de precio
                IList<ArticuloEN> solucionRangoPrecio = articulocen.DameArticulosPorRangoPrecio (30, 40);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("SOLUCION FILTRAR POR RANGO PRECIO: ");
                for (int i = 0; i < solucionRangoPrecio.Count; i++) {
                        Console.WriteLine ("articulo: " + solucionRangoPrecio [i].Nombre);
                }
                Console.WriteLine ("numero de articulos con ese rango de precio: " + solucionRangoPrecio.Count);
                if (solucionRangoPrecio.Count == 0) {
                        // La pagina deberia de estar vacia y mostrar un mensaje estilo "NO SE HAN ENCONTRADO RESULTADOS PARA ESA BUSQUEDA".
                }
                Console.WriteLine ("********************************************************************");




                // Devolver los colores de las variantes de un articulo
                IList<ColorEN> colores = articulocp.DameColoresDelArticulo (OID_articulo_camiseta_comfi);
                ArticuloEN articuloDameColores = articulocen.DamePorId (OID_articulo_camiseta_comfi);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Los colores del articulo " + articuloDameColores.Nombre + " son:");
                foreach (ColorEN color in colores) {
                        Console.WriteLine ("Nombre del color: " + color.Nombre);
                }
                Console.WriteLine ("********************************************************************");


                /*
                 *
                 * // Devolver los materiales de las variantes de un articulo
                 * IList<MaterialEN> materiales = articulocp.DameMaterialesDelArticulo (OID_articulo_camiseta_comfi);
                 * ArticuloEN articuloDameMateriales = articulocen.DamePorId (OID_articulo_camiseta_comfi);
                 * Console.WriteLine ("********************************************************************");
                 * Console.WriteLine ("el resultado es: " + materiales);
                 * Console.WriteLine ("Los materiales del articulo " + articuloDameMateriales.Nombre + " son:");
                 * foreach (MaterialEN material in materiales) {
                 *      Console.WriteLine ("Material: " + material.Material);
                 * }
                 * Console.WriteLine ("********************************************************************");
                 *
                 */


                // mal
                // Filtrar articulos por colores, materiales y rango precio una vez filtrado por nombre
                IList<ArticuloEN> solucionNombre = articulocen.DameArticulosPorNombre ("cami");
                IList<int> listaArticuloIds = solucionNombre.Select (art => art.ArticuloId).ToList ();

                // NO BORRAR LO COMENTADO ABAJO QUE ESTOY A MEDIAS :)

                /*
                 *
                 * IList<ArticuloEN> solucionFiltro = articulocen.DameArticulosFiltrados (listaArticuloIds, colorIds.Cast<int>().ToList (), materialIds.Cast<int>().ToList (), precioMin, precioMax, hayColores, hayMateriales, hayPrecioMin, hayPrecioMax);
                 *
                 * IList<ArticuloEN> solucionFiltro = articulocen.Prueba (solucionNombre, coloresFiltrados, hayColores);
                 *
                 * Console.WriteLine("********************************************************************");
                 * Console.WriteLine("SOLUCION FILTRAR UNA VEZ SE HA HECHO UNA BUSQUEDA POR NOMBRE: ");
                 * for (int i = 0; i < solucionFiltro.Count; i++)
                 * {
                 *  Console.WriteLine("articulo: " + solucionFiltro[i].Nombre);
                 * }
                 * Console.WriteLine("numero de articulos que cumplen los filtros: " + solucionFiltro.Count);
                 * if (solucionFiltro.Count == 0)
                 * {
                 *  // La pagina deberia de estar vacia y mostrar un mensaje estilo "NO SE HAN ENCONTRADO RESULTADOS PARA ESA BUSQUEDA".
                 * }
                 * Console.WriteLine("********************************************************************");
                 *
                 */

                // NO BORRAR LO COMENTADO ARRIBA QUE ESTOY A MEDIAS :)

                // Mostrar articulos similares
                IList<ArticuloEN> solucionArticulosSimilares = articulocen.MostrarSimilares (OID_articulo_camiseta_comfi, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.rosa); //pasamos el color que este seleccionado
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("SOLUCION MOSTRAR ARTICULOS SIMILARES: ");
                if (solucionArticulosSimilares != null) {
                        for (int i = 0; i < solucionArticulosSimilares.Count; i++) {
                                Console.WriteLine ("articulo: " + solucionArticulosSimilares [i].Nombre);
                        }
                        Console.WriteLine ("numero de articulos similares: " + solucionArticulosSimilares.Count);
                }
                if (solucionArticulosSimilares == null || solucionArticulosSimilares.Count == 0) {
                        // La pagina deberia de estar vacia y mostrar un mensaje estilo "NO SE HAN ENCONTRADO RESULTADOS PARA ESA BUSQUEDA".
                }
                Console.WriteLine ("********************************************************************");



                //crear usuarios
                int OID_usu1 = usuarioregistradocen.Nuevo ("Sara", "Marquina", "wtf@gmail.com", "658495033", new DateTime (2000, 12, 08), "12345678", 200);
                int OID_usu2 = usuarioregistradocen.Nuevo ("Antonia", "Llorca", "ant@gmail.com", "343435", new DateTime (2001, 11, 01), "2345566", 0);
                int OID_usu3 = usuarioregistradocen.Nuevo ("Marcos", "Montero", "eyeye@gmail.com", "2343920", new DateTime (2003, 4, 10), "232323", 0);
                int OID_usu4 = usuarioregistradocen.Nuevo ("Emilia", "Rouanet", "lsc82@gcloud.ua.es", "633398887", new DateTime (2000, 02, 12), "12345678", 0);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se ha creado el usuario correctamente, con id: " + OID_usu1);
                Console.WriteLine ("Se ha creado el usuario correctamente, con id: " + OID_usu2);
                Console.WriteLine ("Se ha creado el usuario correctamente, con id: " + OID_usu3);
                Console.WriteLine ("Se ha creado el usuario correctamente, con id: " + OID_usu4 + "(cambiar el correo para recibir los correos de resolucion devolucion)");
                Console.WriteLine ("********************************************************************");

                // dame usuario por email
                Console.WriteLine ("********************************************************************");
                usuarioregistradocen.Modificar ("Sara", "Marq", "wtf@gmail.com", "658495033", new DateTime (2000, 12, 08), OID_usu1);
                Console.WriteLine ("El usuario tiene apellido " + usuarioregistradocen.DamePorId (OID_usu1).Apellidos);
                Console.WriteLine ("********************************************************************");

                // dame usuario por email
                Console.WriteLine ("********************************************************************");
                UsuarioRegistradoEN usuPorCorreo = usuarioregistradocen.DamePorCorreo ("wtf@gmail.com");
                Console.WriteLine ("El usuario tiene correo " + usuPorCorreo.Correo);
                Console.WriteLine ("********************************************************************");


                // Crear lista de deseos
                int listadeseos_usu1 = listadeseoscen.Nuevo (OID_usu1, OID_articulo_camiseta_oversize);
                int listadeseos_usu2 = listadeseoscen.Nuevo (OID_usu1, OID_articulo_pantalon_cargo);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se han creado listas de usuario para el usuario 1 y 2");
                Console.WriteLine ("********************************************************************");

                // Obtener articulos en lista de deseos de un usuario

                ListaDeseosEN listaDeseosEN = listadeseoscen.DameListaDeDeseos (OID_usu1, OID_articulo_camiseta_oversize);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("El usuario 1 tiene en su lista de deseos:");
                Console.WriteLine ("********************************************************************");



                //crear direcciones
                int Dir = direnviocen.Nueva ("aaa", 3, 4, 4, "222", 383, "lala", "lolo", OID_usu1);
                int Dir2 = direnviocen.Nueva ("bbb", 3, 4, 4, "2242", 383, "lila", "lelo", OID_usu2);
                int Dir3 = direnviocen.Nueva ("ccc", 3, 4, 4, "2232", 383, "lula", "lalo", OID_usu3);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se ha creado la direccion de envio correctamente, con id: " + Dir);
                Console.WriteLine ("Se ha creado la direccion de envio correctamente, con id: " + Dir2);
                Console.WriteLine ("Se ha creado la direccion de envio correctamente, con id: " + Dir3);
                Console.WriteLine ("********************************************************************");



                //crear metodo pago
                int idPago = metodopagocen.Nuevo ();
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se ha creado el metodo de pago correctamente");
                Console.WriteLine ("********************************************************************");


                // crear tarjetas
                int idTarjeta = tarjetacen.Nueva ("Mastercard Black");
                int idTarjeta2 = tarjetacen.Nueva ("American Express Green");
                int idTarjeta3 = tarjetacen.Nueva ("Visa Gold");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se han creado correctamente las tarjetas");
                Console.WriteLine ("********************************************************************");

                // Crear paypal
                paypalcen.Nuevo ("paypal_1234XXXXX5678");
                paypalcen.Nuevo ("paypal_5678XXXXX5678");
                paypalcen.Nuevo ("paypal_1457XXXXX5678");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se han creado correctamente los pagos por Paypal");
                Console.WriteLine ("********************************************************************");


                //crear pedidos
                int idPedido = pedidocen.Nuevo (Dir, idPago, OID_usu1);
                int idPedido2 = pedidocen.Nuevo (Dir2, idPago, OID_usu2);
                int idPedido3 = pedidocen.Nuevo (Dir3, idPago, OID_usu3);
                int idPedido4 = pedidocen.Nuevo (Dir, idPago, OID_usu1);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se han creado los pedidos correctamente");
                Console.WriteLine ("********************************************************************");



                // Filtrar pedidos por usuario
                IList<PedidoEN> pedidosPorUsu = pedidocen.DamePedidosPorUsuario (OID_usu1);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("FILTRAR PEDIDOS POR USUARIO");
                Console.WriteLine ("EL usuario con nombre " + usuarioregistradocen.DamePorId (OID_usu1).Nombre + "tiene los siguientes pedidos:");
                foreach (PedidoEN pedido in pedidosPorUsu) {
                        Console.WriteLine ("Pedido con Id " + pedido.PedidoId + " y estado " + pedido.Estado);
                }
                Console.WriteLine ("********************************************************************");



                // Modificar pedido
                pedidocen.Modificar (idPedido, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum.enviado);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Pedido con Id " + idPedido + " modificado a estado " + pedidocen.DamePorId (idPedido).Estado + " en fecha " + pedidocen.DamePorId (idPedido).FechaEnviado);
                Console.WriteLine ("********************************************************************");



                // Filtrar pedidos por estado
                IList<PedidoEN> pedidosPorEstado = pedidocen.DamePorEstado (KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum.cesta);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("FILTRAR PEDIDOS POR ESTADO");
                Console.WriteLine ("Pedidos con estado cesta:");
                foreach (PedidoEN pedido in pedidosPorEstado) {
                        Console.WriteLine ("Pedidos con Id " + pedido.PedidoId);
                }
                Console.WriteLine ("********************************************************************");



                //aniadir puntos
                usuarioregistradocen.SumarPuntos (OID_usu1, 200);
                usuarioregistradocen.SumarPuntos (OID_usu2, 400);
                usuarioregistradocen.SumarPuntos (OID_usu3, 100);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se ha aniadido 200 puntos al usuario 1");
                Console.WriteLine ("Se ha aniadido 400 puntos al usuario 2");
                Console.WriteLine ("Se ha aniadido 100 puntos al usuario 3");
                Console.WriteLine ("********************************************************************");



                //Restar puntos
                UsuarioRegistradoEN usuario1EN = usuarioregistradocen.DamePorId (OID_usu1);
                UsuarioRegistradoEN usuario2EN = usuarioregistradocen.DamePorId (OID_usu2);
                UsuarioRegistradoEN usuario3EN = usuarioregistradocen.DamePorId (OID_usu3);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Cantidad del usuario 1 antes de resta: " + usuario1EN.Puntos);
                usuarioregistradocen.SumarPuntos (OID_usu1, 20);
                Console.WriteLine ("Cantidad del usuario 1 despues de resta: " + usuario1EN.Puntos);

                Console.WriteLine ("Cantidad del usuario 2 antes de resta: " + usuario2EN.Puntos);
                usuarioregistradocen.SumarPuntos (OID_usu2, 30);
                Console.WriteLine ("Cantidad del usuario 2 despues de resta: " + usuario2EN.Puntos);

                Console.WriteLine ("Cantidad del usuario 3 antes de resta: " + usuario3EN.Puntos);
                usuarioregistradocen.SumarPuntos (OID_usu3, 50);
                Console.WriteLine ("Cantidad del usuario 3 despues de resta: " + usuario3EN.Puntos);
                Console.WriteLine ("********************************************************************");



                //sumar puntos
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Cantidad del usuario 1 antes de suma: " + usuario1EN.Puntos);
                bool restaUsu1 = usuarioregistradocen.RestarPuntos (OID_usu1, 40);
                Console.WriteLine ("¿Se ha restado?: " + restaUsu1);
                Console.WriteLine ("Cantidad del usuario 1 despues de suma: " + usuario1EN.Puntos);

                Console.WriteLine ("Cantidad del usuario 2 antes de suma: " + usuario2EN.Puntos);
                bool restaUsu2 = usuarioregistradocen.RestarPuntos (OID_usu2, 60);
                Console.WriteLine ("¿Se ha restado?: " + restaUsu1);
                Console.WriteLine ("Cantidad del usuario 2 despues de suma: " + usuario2EN.Puntos);

                Console.WriteLine ("Cantidad del usuario 3 antes de suma: " + usuario3EN.Puntos);
                bool restaUsu3 = usuarioregistradocen.RestarPuntos (OID_usu3, 10);
                Console.WriteLine ("¿Se ha restado?: " + restaUsu1);
                Console.WriteLine ("Cantidad del usuario 3 despues de suma: " + usuario3EN.Puntos);
                Console.WriteLine ("********************************************************************");



                //crear las CP de linped
                LinPedCP linpedCP = new LinPedCP (new SessionCPNHibernate ());
                LinPedCP linpedCP2 = new LinPedCP (new SessionCPNHibernate ());
                LinPedCP linpedCP3 = new LinPedCP (new SessionCPNHibernate ());


                //crear las linped
                linpedCP.Nueva (3, idPedido, variantesDeCamisetaComfi [0].VarianteId);
                linpedCP.Nueva (5, idPedido, variantesDeCamisetaOversize [0].VarianteId);
                linpedCP.Nueva (1, idPedido, variantesDePantalonCargo [0].VarianteId);


                linpedCP2.Nueva (4, idPedido2, variantesDeCamisetaComfi [4].VarianteId);
                linpedCP2.Nueva (1, idPedido2, variantesDePantalonCargo [0].VarianteId);
                linpedCP2.Nueva (6, idPedido2, variantesDePantalonCargo [8].VarianteId);

                linpedCP3.Nueva (2, idPedido3, variantesDeCamisetaComfi [6].VarianteId);
                linpedCP3.Nueva (2, idPedido3, variantesDeCamisetaOversize [8].VarianteId);
                linpedCP3.Nueva (1, idPedido3, variantesDeCamisetaComfi [7].VarianteId);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Se han creado las lineas de pedido correctamente");
                Console.WriteLine ("********************************************************************");



                //crear pedidos
                PedidoEN pedido1 = pedidocen.DamePorId (idPedido);
                PedidoEN pedido2 = pedidocen.DamePorId (idPedido2);
                PedidoEN pedido3 = pedidocen.DamePorId (idPedido3);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("El total del pedido1 es: " + pedido1.Total);
                Console.WriteLine ("El total del pedido2 es: " + pedido2.Total);
                Console.WriteLine ("El total del pedido3 es: " + pedido3.Total);
                Console.WriteLine ("********************************************************************");


                //aplicar descuentos
                PedidoCP pedidocp = new PedidoCP (new SessionCPNHibernate ());
                double descuento = pedidocp.CalcularDescuento (idPedido);
                double descuento2 = pedidocp.CalcularDescuento (idPedido2);
                double descuento3 = pedidocp.CalcularDescuento (idPedido3);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("El descuento del pedido1 es: " + descuento);
                Console.WriteLine ("El descuento del pedido2 es: " + descuento2);
                Console.WriteLine ("El descuento del pedido3 es: " + descuento3);
                Console.WriteLine ("********************************************************************");


                IList<int> listaFotos1 = new List<int> (variantesDeCamisetaComfi [0].VarianteId);
                IList<int> listaFotos2 = new List<int> (variantesDeCamisetaComfi [2].VarianteId);
                IList<int> listaFotos3 = new List<int> (variantesDeCamisetaComfi [4].VarianteId);

                //crear imagenes variantes
                int imgvar1 = imagenvariantecen.Nueva ("https://image.hm.com/assets/hm/1d/25/1d251683c502cbf3b960e3ed0dc982bf6c297346.jpg?imwidth=1260", "Camiseta con detalle de botones dorados en los hombros- Rosa claro - MUJER");
                int imgvar2 = imagenvariantecen.Nueva ("https://image.hm.com/assets/hm/71/43/7143978ad8a7e92d563223274e5df32e06e67588.jpg?imwidth=1260",  "Camiseta con detalle de botones dorados en los hombros plano detalle - Rosa claro - MUJER");
                int imgvar3 = imagenvariantecen.Nueva ("https://image.hm.com/assets/hm/af/1d/af1daf01921f2ced4929bac27da4dcad18e60484.jpg?imwidth=1260",  "Camiseta con detalle de botones dorados en los hombros- Negro - MUJER");
                int imgvar4 = imagenvariantecen.Nueva ("https://image.hm.com/assets/hm/73/9c/739c47ecb08b67feb52f3539f3e6266b806e9dab.jpg?imwidth=1260", "Camiseta con detalle de botones dorados en los hombros plano detalle - Negro - MUJER");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Imagenes variantes creadas");
                Console.WriteLine ("********************************************************************");


                imagenvariantecen.AsociarAVariante(imgvar1, listaFotos1);
                imagenvariantecen.AsociarAVariante(imgvar2, listaFotos1);
                imagenvariantecen.AsociarAVariante(imgvar3, listaFotos2);
                imagenvariantecen.AsociarAVariante(imgvar4, listaFotos3);




                //crear avisos stock
                AvisoStockCP avisostockcp = new AvisoStockCP (new SessionCPNHibernate ());
                DevolucionCP devolucioncp = new DevolucionCP (new SessionCPNHibernate ());
                int OID_avisostock1 = avisostockcen.Nuevo (variantesDeCamisetaComfi [1].VarianteId, "lsc82@alu.ua.es");
                int OID_avisostock2 = avisostockcen.Nuevo (variantesDeCamisetaComfi [0].VarianteId, "lsc82@mscloud.ua.es");
                int OID_avisostock3 = avisostockcen.Nuevo (variantesDeCamisetaComfi [0].VarianteId, "erf24@alu.ua.es");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Avisos stock creados correctamente (cambiar los correos para recibir el aviso)");
                Console.WriteLine ("********************************************************************");



                // avisos segun variante
                variantecen.Modificar (variantesDeCamisetaComfi [2].VarianteId, 200);
                IList<AvisoStockEN> avisos = avisostockcen.DamePorVarianteYEstado (variantesDeCamisetaComfi [2].VarianteId, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum.sinEnviar);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Avisos segun la variante del articulo y estado");
                Console.WriteLine ("********************************************************************");
                foreach (var aviso in avisos) {
                        Console.WriteLine ("********************************************************************");
                        //Console.WriteLine($"Enviando aviso para el articulo: {aviso.Variante.Articulo.Nombre}");
                        Console.WriteLine ("ID del Aviso: " + aviso.AvisoId);
                        Console.WriteLine ("Email de destino: " + aviso.Email);
                        Console.WriteLine ("********************************************************************");
                        //avisostockcp.EnviarAviso (aviso.AvisoId);
                }
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Avisos stock enviados correctamente (cambiar direcciones de correo si deseas recibir el correo)");
                Console.WriteLine ("********************************************************************");

                //crear facturas
                float total1 = (float)pedido2.Total;
                float subTotal1 = (float)(total1 / 1.25);

                float total2 = (float)pedido2.Total;
                float subTotal2 = (float)(total2 / 1.25);

                int idFactura1 = facturacen.Nueva (subTotal1, total1, new DateTime (2004, 04, 24), idPedido2, 21, 0, "Nombre1", "Apellidos1", "email1", "telefono1");
                int idFactura2 = facturacen.Nueva (subTotal2, total2, new DateTime (2004, 04, 25), idPedido3, 21, 10, "Nombre2", "Apellidos2", "email2", "telefono2");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Facturas creadas correctamente");
                Console.WriteLine ("********************************************************************");

                //crear devoluciones
                int idDevolucion1 = devolucioncen.Nueva (idPedido2, "");
                int idDevolucion2 = devolucioncen.Nueva (idPedido3, "");
                int idDevolucion3 = devolucioncen.Nueva (idPedido, "");
                int idDevolucion4 = devolucioncen.Nueva (idPedido4, "");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Devoluciones creadas correctamente");
                Console.WriteLine ("********************************************************************");



                //modificar devoluciones y enviar resoluciones
                devolucioncen.Modificar (idDevolucion1, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum.aceptada, "");
                devolucioncen.Modificar (idDevolucion2, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum.pendiente, "Pequeña");
                devolucioncen.Modificar (idDevolucion3, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum.revision, "Rota");
                devolucioncen.Modificar (idDevolucion4, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum.rechazada, "la camiseta esta manchada de pintura");
                devolucioncp.EnviarResolucion (idDevolucion1);
                devolucioncp.EnviarResolucion (idDevolucion2);
                devolucioncp.EnviarResolucion (idDevolucion3);
                devolucioncp.EnviarResolucion (idDevolucion4);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Devolucion modificada y resolcion enviada");
                Console.WriteLine ("********************************************************************");



                //eliminar cuenta
                usuarioregistradocen.SolicitarBorrarCuenta (OID_usu4, "1234");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Eliminar cuenta fallida, correo enviado (cambiar correo del usuario de ejemplo si deseas recibirlo)");
                Console.WriteLine ("********************************************************************");
                usuarioregistradocen.SolicitarBorrarCuenta (OID_usu4, "12345678");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Cuenta eliminada con exito");
                Console.WriteLine ("********************************************************************");


                /*
                 *
                 * //login usuario
                 * String loginUsu = usuarioregistradocen.Login ("estrelladomsan@gmail.com", "micontra");
                 * Console.WriteLine ("********************************************************************************************");
                 * if (loginUsu != null)
                 *     Console.WriteLine ("El login de usuario es correcto. Token: " + loginUsu);
                 * Console.WriteLine ("********************************************************************************************");
                 *
                 */


                //crear admin
                int idAdmin = administradorcen.Nuevo ("Estrella", "Dominguez", "estrelladomsan@gmail.com", "689450627", new DateTime (2004, 04, 24), "79288232X", "micontra");
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Se crea el admin correctamente. ID: " + idAdmin);
                Console.WriteLine ("********************************************************************************************");



                //login admin
                String loginAdmin = administradorcen.Login (idAdmin, "micontra");
                Console.WriteLine ("********************************************************************************************");
                if (loginAdmin != null)
                        Console.WriteLine ("El login de admin es correcto. Token: " + loginAdmin);
                Console.WriteLine ("********************************************************************************************");



                // escribir Resena
                int idUsuario = OID_usu2;
                int idResena = resenacen.Nueva (idUsuario, OID_top_mangas_cruzadas, NumeroEstrellasEnum.cinco, "Me ha gustado mucho!", new DateTime (2024, 11, 06));
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Se crea la resena correctamente. ID: " + idResena);
                Console.WriteLine ("********************************************************************************************");

                //crear imagenes Resena
                imagenresenacen.Nueva (idResena, "https://image.hm.com/assets/hm/1d/25/1d251683c502cbf3b960e3ed0dc982bf6c297346.jpg?imwidth=1260", "Camiseta con detalle de botones dorados en los hombros- Rosa claro - MUJER");
                imagenresenacen.Nueva (idResena, "https://image.hm.com/assets/hm/71/43/7143978ad8a7e92d563223274e5df32e06e67588.jpg?imwidth=1260", "Camiseta con detalle de botones dorados en los hombros plano detalle - Rosa claro - MUJER");
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("Imagenes resena creadas");
                Console.WriteLine ("********************************************************************");


                // Crear medidas de usuario
                int idMedidasUsuario = medidasusuariocen.Nuevo (70, 90, 40, 95, 60, 85, idUsuario);
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Medidas de usuario creadas correctamente. ID: " + idMedidasUsuario);
                Console.WriteLine ("********************************************************************************************");



                // Calular talla ideal
                MedidasUsuarioCP medidasusuariocp = new MedidasUsuarioCP (new SessionCPNHibernate ());
                medidasusuariocp.CalcularTallaIdeal (idMedidasUsuario);
                string tallaSuperior = medidasusuariocp.MostrarTallaIdeal (idMedidasUsuario, OID_camiseta_basica);
                string tallaInferior = medidasusuariocp.MostrarTallaIdeal (idMedidasUsuario, OID_pantalon_vaquero);
                Console.WriteLine ("********************************************************************************************");
                Console.WriteLine ("Talla ideal calculada para parte superior: " + tallaSuperior);
                Console.WriteLine ("Talla ideal calculada para parte inferior: " + tallaInferior);
                Console.WriteLine ("********************************************************************************************");



                // Verificación de `CalcularTallaIdeal`
                Console.WriteLine ("********************************************************************************************");
                if (tallaSuperior == "L" && tallaInferior == "M") {
                        Console.WriteLine ("CalcularTallaIdeal: Pruebas exitosas.");
                }
                else{
                        Console.WriteLine ("CalcularTallaIdeal: Error en el cálculo de la talla ideal.");
                }
                Console.WriteLine ("********************************************************************************************");


                int idPedido5 = pedidocen.Nuevo (Dir, idPago, OID_usu1);

                LinPedCP linpedCP5 = new LinPedCP (new SessionCPNHibernate ());

                // Crear líneas de pedido
                LinPedEN linPedResult1 = linpedCP5.Nueva (3, idPedido5, variantesDeCamisetaComfi [1].VarianteId);
                int idlp51 = linPedResult1.LineaId; // Obtener el ID de la línea 1

                LinPedEN linPedResult2 = linpedCP5.Nueva (1, idPedido5, variantesDePantalonCargo [4].VarianteId);
                int idlp52 = linPedResult2.LineaId; // Obtener el ID de la línea 2

                // Consultar el pedido y mostrar su total
                PedidoEN pedido5 = pedidocen.DamePorId (idPedido5);
                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("El total del pedido5 es: " + pedido5.Total);
                Console.WriteLine ("********************************************************************");

                // Modificar las líneas
                // linpedCP5.Modificar (idlp51, -1,); // Actualizar cantidad de la línea 1
                //linpedCP5.Modificar (idlp52, 4);  // Actualizar cantidad de la línea 2

                // Volver a consultar el pedido y las líneas actualizadas
                pedido5 = pedidocen.DamePorId (idPedido5); // Asegurarse de tener la versión actualizada del pedido
                LinPedEN linea1Actualizada = linpedcen.DamePorId (idlp51); // Obtener la línea 1 actualizada
                LinPedEN linea2Actualizada = linpedcen.DamePorId (idlp52); // Obtener la línea 2 actualizada

                Console.WriteLine ("********************************************************************");
                Console.WriteLine ("El total del pedido5 es: " + pedido5.Total);
                Console.WriteLine ("La línea 1 del pedido 5 tiene cantidad: " + linea1Actualizada.Cantidad + "y de precio tiene:" + linea1Actualizada.Precio);
                Console.WriteLine ("La línea 2 del pedido 5 tiene cantidad: " + linea2Actualizada.Cantidad + "y de precio tiene:" + linea2Actualizada.Precio);
                Console.WriteLine ("********************************************************************");


                //menesaje final de que todo ha ido correctamente
                Console.WriteLine ("*********************************************************");
                Console.WriteLine ("Todo ha ido bien");
                Console.WriteLine ("*********************************************************");
                /*
                 * //damePorTa
                 * int OID_color_azul = colorcen.Nuevo(KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.azul, "#165BAB");
                 * int OID_color_blanco = colorcen.Nuevo(KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.blanco, "#FFFFFF");
                 * int OID_color_rosa = colorcen.Nuevo(KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum.rosa, "#FFC0CB");
                 * Console.WriteLine("********************************************************************");
                 * Console.WriteLine("Colores creados");
                 * Console.WriteLine("********************************************************************");
                 *
                 *
                 * // Crear talla
                 * int OID_talla_XS = tallacen.NuevaTalla(KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.XS);
                 * int OID_talla_S = tallacen.NuevaTalla(KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.S);
                 * int OID_talla_M = tallacen.NuevaTalla(KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.M);
                 * int OID_talla_L = tallacen.NuevaTalla(KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.L);
                 * int OID_talla_XL = tallacen.NuevaTalla(KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum.XL);
                 * Console.WriteLine("********************************************************************");
                 * Console.WriteLine("Tallas creados");
                 * Console.WriteLine("********************************************************************");
                 *
                 */

                VarianteEN var = variantecen.DamePorTallaYColorYArticulo (OID_talla_XS, OID_color_azul, OID_articulo_camiseta_oversize);


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
