using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BecDevGenEntradaSalidaCprEvent
{
    class SDK
    {
        public class constantes
        {
            public const int kLongFecha = 24;
            public const int kLongSerie = 12;
            public const int kLongCodigo = 31;
            public const int kLongNombre = 61;
            public const int kLongReferencia = 21;
            public const int kLongDescripcion = 61;
            public const int kLongCuenta = 101;
            public const int kLongMensaje = 3001;
            public const int kLongNombreProducto = 256;
            public const int kLongAbreviatura = 4;
            public const int kLongCodValorClasif = 4;
            public const int kLongDenComercial = 51;
            public const int kLongRepLegal = 51;
            public const int kLongTextoExtra = 51;
            public const int kLongRFC = 21;
            public const int kLongCURP = 21;
            public const int kLongDesCorta = 21;
            public const int kLongNumeroExtInt = 7;
            public const int kLongNumeroExpandido = 31;
            public const int kLongCodigoPostal = 7;
            public const int kLongTelefono = 16;
            public const int kLongEmailWeb = 51;
            public const int kLongSelloSat = 176;
            public const int kLonSerieCertSAT = 21;
            public const int kLongFechaHora = 36;
            public const int kLongSelloCFDI = 176;
            public const int kLongCadOrigComplSAT = 501;
            public const int kLongitudUUID = 37;
            public const int kLongitudRegimen = 101;
            public const int kLongitudMoneda = 61;
            public const int kLongitudFolio = 17;
            public const int kLongitudMonto = 31;
            public const int kLogitudLugarExpedicion = 401;
            public const int kLongitudNomBanExtranjero = 254;
        }

        // Declaracion de Estructura para Cliente / Proveedor
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tCteProv
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoCliente;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String cRazonSocial;//[ kLongNombre + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaAlta;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongRFC)]
            public String cRFC;//[ kLongRFC + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCURP)]
            public String cCURP;//[ kLongCURP + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDenComercial)]
            public String cDenComercial;//[ kLongDenComercial + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongRepLegal)]
            public String cRepLegal;//[ kLongRepLegal + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String cNombreMoneda;//[ kLongNombre + 1 ];
            public int cListaPreciosCliente;
            public double cDescuentoMovto;
            public int cBanVentaCredito; // 0 = No se permite venta a crédito, 1 = Se permite venta a crédito
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente6;//[ kLongCodValorClasif + 1 ];
            public int cTipoCliente; // 1 - Cliente, 2 - Cliente/Proveedor, 3 - Proveedor
            public int cEstatus; // 0. Inactivo, 1. Activo
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaBaja;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaUltimaRevision;//[ kLongFecha + 1 ];
            public double cLimiteCreditoCliente;
            public int cDiasCreditoCliente;
            public int cBanExcederCredito; // 0 = No se permite exceder crédito, 1 = Se permite exceder el crédito
            public double cDescuentoProntoPago;
            public int cDiasProntoPago;
            double cInteresMoratorio;
            public int cDiaPago;
            public int cDiasRevision;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDesCorta)]
            public String cMensajeria;//[ kLongDesCorta + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public String cCuentaMensajeria;//[ kLongDescripcion + 1 ];
            public int cDiasEmbarqueCliente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAlmacen;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAgenteVenta;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAgenteCobro;//[ kLongCodigo + 1 ];
            public int cRestriccionAgente;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencionCliente1;
            public double cRetencionCliente2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor6;//[ kLongCodValorClasif + 1 ];
            public double cLimiteCreditoProveedor;
            public int cDiasCreditoProveedor;
            public int cTiempoEntrega;
            public int cDiasEmbarqueProveedor;
            public double cImpuestoProveedor1;
            public double cImpuestoProveedor2;
            public double cImpuestoProveedor3;
            public double cRetencionProveedor1;
            public double cRetencionProveedor2;
            public int cBanInteresMoratorio; // 0 = No se le calculan intereses moratorios al cliente, 1 = Si se le calculan intereses moratorios al cliente.
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra1;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra2;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra3;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cFechaExtra;//[ kLongFecha + 1 ];
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;

        }

        // Definicion de Estructura para Direcciones
        public struct tDireccion
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodCteProv;
            public int cTipoCatalogo; // 1=Clientes y 2=Proveedores
            public int cTipoDireccion; // 1=Domicilio Fiscal, 2=Domicilio Envio
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cNombreCalle;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNumeroExpandido)]
            public string cNumeroExterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNumeroExpandido)]
            public string cNumeroInterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cColonia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigoPostal)]
            public string cCodigoPostal;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono4;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongEmailWeb)]
            public string cEmail;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongEmailWeb)]
            public string cDireccionWeb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cCiudad;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cEstado;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cPais;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cTextoExtra;
        }

        // Definicion de Estructura para Productos / Servicios
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tProducto
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombreProducto)]
            public string cDescripcionProducto;
            public int cTipoProducto; // 1 = Producto, 2 = Paquete, 3 = Servicio
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaAltaProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaBaja;
            public int cStatusProducto; // 0 - Baja Lógica, 1 - Alta
            public int cControlExistencia;
            public int cMetodoCosteo; // 1 = Costo Promedio en Base a Entradas, 2 = Costo Promedio en Base a Entradas Almacen, 3 = Último costo, 4 = UEPS, 5 = PEPS, 6 = Costo específico, 7 = Costo Estandar
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoUnidadBase;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoUnidadNoConvertible;
            public double cPrecio1;
            public double cPrecio2;
            public double cPrecio3;
            public double cPrecio4;
            public double cPrecio5;
            public double cPrecio6;
            public double cPrecio7;
            public double cPrecio8;
            public double cPrecio9;
            public double cPrecio10;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencion1;
            public double cRetencion2;
            // N.D.8386 La estructura debe recibir el nombre de la característica padre. (ALRH)
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion6;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra1;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra2;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra3;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaExtra;//[ kLongFecha + 1 ];
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;
        }

        // Definicion de Estructura para Unidades de Medida
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tUnidad
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String cNombreUnidad;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongAbreviatura)]
            public String cAbreviatura;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongAbreviatura)]
            public String cDespliegue;
        }

        // Definicion de Estructura para Documento
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDocumento
        {
            public Double aFolio;
            public int aNumMoneda;
            public Double aTipoCambio;
            public Double aImporte;
            public Double aDescuentoDoc1;
            public Double aDescuentoDoc2;
            public int aSistemaOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongSerie)]
            public String aSerie;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String aFecha;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodigoCteProv;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodigoAgente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongReferencia)]
            public String aReferencia;
            public int aAfecta;
            public double aGasto1;
            public double aGasto2;
            public double aGasto3;
        }

        // Definicion de Estructura para Movimientos
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tMovimiento
        {
            public int aConsecutivo;
            public Double aUnidades;
            public Double aPrecio;
            public Double aCosto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodProdSer;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodAlmacen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongReferencia)]
            public String aReferencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodClasificacion;
        }

        // Definicion de Estructura para Series / Capas
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tSeriesCapas
        {
            public double aUnidades;
            public double aTipoCambio;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string aSeries;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aPedimento;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aAgencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaPedimento;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aNumeroLote;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaFabricacion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaCaducidad;

        }

        // Definicion de Estructura para RegLlaveDoc
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct RegLlaveDoc
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongSerie)]
            public String aSerie;
            public double folio;
        }

        // Declaracion de Funciones

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
          UIntPtr hKey,
          string subKey,
          int ulOptions,
          int samDesired,
          out UIntPtr hkResult);


        [DllImport("advapi32")]
        public static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(
            UIntPtr hKey,
            string lpValueName,
            int lpReserved,
            out uint lpType,
            StringBuilder lpData,
            ref uint lpcbData);


        [DllImport("KERNEL32")]
        public static extern int SetCurrentDirectory(string pPtrDirActual);

        [DllImport("MGWServicios.dll")]
        public static extern int fInicializaSDK();

        [DllImport("MGWServicios.dll")]
        public static extern void fTerminaSDK();

        [DllImport("MGWServicios.dll")]
        public static extern int fInicioSesionSDK(string aUsuario, string aContrasenia);

        [DllImport("MGWServicios.dll")]
        public static extern int fInicioSesionSDKCONTPAQi(string aUsuario, string aContrasenia);

        [DllImport("MGWServicios.dll")]
        public static extern int fSetNombrePAQ(string aNombrePAQ);

        [DllImport("MGWServicios.dll")]
        public static extern int fAbreEmpresa(string Directorio);

        [DllImport("MGWServicios.dll")]
        public static extern void fCierraEmpresa();

        [DllImport("MGWServicios.dll")]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        [DllImport("MGWServicios.dll")]
        public static extern int fAltaProducto(ref int aIdProducto, ref tProducto astProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaProducto(String aCodProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fEditaProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoProducto(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fEliminarProducto(String aCodProducto);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoProducto(string aCampo, StringBuilder aValr, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoParametros(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerProducto();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteProducto();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDocumento(ref Int32 aIdDocumento, ref tDocumento atDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern void fBorraDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDocumentoCargoAbono(ref tDocumento atDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSaldarDocumento_Param(string aCodConcepto_Pagar, string aSerie_Pagar, double aFolio_Pagar, string aCodConcepto_Pago, string aSerie_Pago, double aFolio_Pago, double aImporte, int aIdMoneda, string aFecha);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSaldarDocumento(ref RegLlaveDoc astDocAPagar, ref RegLlaveDoc astDocPago, double importe, int moneda, string aFecha);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoDocumento(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fLeeDatoCFDI(StringBuilder aValor, int aDato);

        [DllImport("MGWServicios.dll")]
        public static extern int fDocumentoUUID(string aCodConcepto, string aSerie, double aFolio, StringBuilder atPtrCFDIUUID);

        [DllImport("MGWServicios.dll")]
        public static extern int fObtieneDatosCFDI(ref string atPtrPassword);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSetDatoDocumento(string aCampo, string aValor);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEditarDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fGuardaDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimiento(Int32 aIdDocumento, ref Int32 aIdMovimiento, ref tMovimiento atMovimiento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscarIdMovimiento(Int32 aIdMovimiento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscarIdDocumento(Int32 aIdDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAfectaDocto(ref tDocumento atDocumento, bool aAfectarDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAfectaDocto_Param([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, bool aAfecta);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSiguienteFolio([MarshalAs(UnmanagedType.LPStr)] string aCodigoConcepto, [MarshalAs(UnmanagedType.LPStr)] StringBuilder aSerie, ref double aFolio);

        [DllImport("MGWServicios.dll")]
        public static extern int fInicializaLicenseInfo(byte aSistema);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEmitirDocumento([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, [MarshalAs(UnmanagedType.LPStr)] string aPassword, [MarshalAs(UnmanagedType.LPStr)] string aArchivoAdicional);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEntregEnDiscoXML([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, int aFormato, string aFormatoAmigable);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fTimbraXML(string aRutaXML, string aCodConcepto, StringBuilder aUUID, string aRutaDDA, string aRutaResultado, string aPass, string aRutaFormato);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscarDocumento(string aCodConcepto, string aSerie, string aFolio);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosPrimerEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosSiguienteEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGWServicios.dll")]
        public static extern int fAltaCteProv(ref int aIdCliente, ref tCteProv astCliente);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaCteProv(String aCodCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaIdCteProv(int aIdCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fEditaCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoCteProv(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoCteProv(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fLlenaRegistroCteProv(ref tCteProv astCtePro, int aEsAlta);

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fBorraCteProv(String aCodCteProv);

        [DllImport("MGWServicios.dll")]
        public static extern int fActualizaCteProv(string aCodigoCteProv, ref tCteProv astCtePro);

        [DllImport("MGWServicios.dll")]
        public static extern int fInformacionCliente(string aCodigo, ref int aPermiteCredito,
                                                      ref double aLimiteCredito, ref int aLimiteDoctosVencidos,
                                                      ref int aPermiteExcederCredito, string aFecha,
                                                      ref double aSaldo, ref double aSaldoPendiente,
                                                      ref int aDoctosVencidos);
        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosUltimoCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosAnteriorCteProv();

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaIdUnidad(int aIdUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaUnidad(String aNombreUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fInsertaUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fEditaUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fGuardaUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fBorrarUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fCancelarModificacionUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoUnidad(String aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoUnidad(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern int fAltaUnidad(ref int aIdUnidad, ref tUnidad astUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fActualizaUnidad(string aNombreUnidad, ref tUnidad astUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fEliminarUnidad(string aNombreUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fLlenaRegistroUnidad(ref tUnidad astUnidad);

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosUltimoUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosAnteriorUnidad();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaDireccion(ref int lIdDireccion, ref tDireccion ltDireccion);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fActualizaDireccion(ref tDireccion ltDireccion);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscaDireccionCteProv(string aCodCteProv, byte aTipoDireccion);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fLlenaRegistroDireccion(ref tDireccion ltdDireccion, int aEsAlta);

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoDireccion(String aCampo, String aValor);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimientoSeriesCapas(int aIdMovimiento, ref tSeriesCapas lSeries);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fAltaMovimientoSeriesCapas_Param(string aIdMovimiento, string aUnidades, string aTipoCambio, string aSeries,
                    string aPedimento, string aAgencia, string aFechaPedimento, string aNumeroLote, string aFechaFabricacion, string aFechaCaducidad);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fCalculaMovtoSerieCapa(Int32 lIdMovimiento);

        [DllImport("MGWServicios.dll")]
        public static extern int fSetDatoMovimiento(string aCampo, string aValor);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEditarMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fEditaDireccion();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fGuardaMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fGuardaDireccion();

        [DllImport("MGWServicios.dll")]
        public static extern int fSetFiltroMovimiento(Int32 aIdDocumento);

        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoMovimiento(string aCampo, StringBuilder aValr, int aLen);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fCancelaDoctoInfo(string aPass);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fCancelaDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern int fAgregarRelacionCFDI(string aCodConcepto, string aSerie, string aFolio, string aTipoRelacion, string aConceptoRelacionar, string aSerieRelaciona, string aFolioRelacionar);

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fCancelaUUID33(string aUUID, string aRFCReceptor, double aTotal, string aIdConcepto, string aPass, ref int aEstatusCancelacion);

        public static void fImprime(string Tipo, int CodigoError, string Mensaje)
        {
            Console.WriteLine($"[SDK] | {Tipo} | {CodigoError} | {Mensaje}");
        }
    }
}
