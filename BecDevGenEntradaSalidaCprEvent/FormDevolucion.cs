using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BecDevGenEntradaSalidaCprEvent.SDK;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class FormDevolucion : MaterialForm
    {
        public class InformacionFactura
        {
            public DateTime fecha_creacion { get; set; }
            public string serie_contpaq_documento { get; set; }
            public int folio_contpaq_documento { get; set; }
            public string codigo_creador { get; set; }
            public string codigo_cliente { get; set; }
            public string CNOMBREAGENTE { get; set; }
            public string CNOMBREAGENTECREADOR { get; set; }
        }

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        string CurrentDirectory = ConfigurationManager.AppSettings["CurrentDirectory"].ToString();
        string Usuario = ConfigurationManager.AppSettings["Usuario"].ToString();
        string Password = ConfigurationManager.AppSettings["Password"].ToString();
        string Empresa = ConfigurationManager.AppSettings["Empresa"].ToString();
        StringBuilder InterpreteSDK = new StringBuilder(255);

        public FormDevolucion()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo700,
                MaterialSkin.Primary.Indigo100,
                MaterialSkin.Accent.Indigo700,
                MaterialSkin.TextShade.WHITE);
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            CargarDGVProductos(Documento.IdDocumento);

            var salida = ObtenerInformacionFactura(Documento.IdDocumento);

            lblDevolucionFecha.Text = $"Fecha: {Convert.ToDateTime(salida.fecha_creacion):yyyy-MM-dd}";
            lblDevolucionDocumento.Text = $"Documento: {salida.serie_contpaq_documento}{salida.folio_contpaq_documento}";
            lblDevolucionAgente.Text = $"Agente: {salida.CNOMBREAGENTECREADOR}";
            lblDevolucionCliente.Text = $"Ruta: {salida.codigo_cliente}";
            lblDevolucionOperador.Text = $"Operador: {salida.CNOMBREAGENTE}";
        }

        private InformacionFactura ObtenerInformacionFactura(int idDocumento)
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                var salida = (from remision in adConnect.bec_event_documento_encabezado
                              join operador in adConnect.admAgentes on remision.id_operador equals operador.CIDAGENTE
                              join creador in adConnect.admAgentes on remision.id_creador equals creador.CIDAGENTE
                              where remision.tipo == "remision"
                              && remision.id == idDocumento
                              select new InformacionFactura
                              {
                                  fecha_creacion = (DateTime)remision.fecha_creacion,
                                  serie_contpaq_documento = remision.serie_contpaq_documento,
                                  folio_contpaq_documento = (int)remision.folio_contpaq_documento,
                                  codigo_creador = remision.codigo_creador,
                                  codigo_cliente = remision.codigo_cliente,
                                  CNOMBREAGENTE = operador.CNOMBREAGENTE,
                                  CNOMBREAGENTECREADOR = creador.CNOMBREAGENTE
                              }).FirstOrDefault();


                return salida;
            }
        }

        public void CargarDGVProductos(int idDocumento)
        {
            dgvDevolucionListaProducto.Rows.Clear();
            dgvDevolucionListaProducto.Refresh();
            using (adConexionDB adConnect = new adConexionDB())
            {
                var listaDGVProductos = (from listaMovimientos in adConnect.bec_event_documento_movimiento
                                         join producto in adConnect.admProductos on listaMovimientos.codigo_producto equals producto.CCODIGOPRODUCTO
                                         where listaMovimientos.id_documento_encabezado == idDocumento
                                         select new { listaMovimientos.id, listaMovimientos.codigo_producto, listaMovimientos.cantidad_producto, producto.CNOMBREPRODUCTO }).ToList();

                foreach (var objLista in listaDGVProductos)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvDevolucionListaProducto);
                    newRow.Cells[0].Value = objLista.id;
                    newRow.Cells[1].Value = objLista.codigo_producto + " | " + objLista.CNOMBREPRODUCTO;
                    newRow.Cells[2].Value = objLista.cantidad_producto;
                    dgvDevolucionListaProducto.Rows.Add(newRow);
                }
            }
        }

        private void DgvDevolucionListaProducto_Devolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDevolucionListaProducto.CurrentCell.ColumnIndex == 3) // Validar solo para la columna 3
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true; // Cancelar la tecla presionada
                    return;
                }

                string input = (dgvDevolucionListaProducto.EditingControl as DataGridViewTextBoxEditingControl).Text + e.KeyChar;

                if (decimal.TryParse(input, out decimal inputValue))
                {
                    DataGridViewRow currentRow = dgvDevolucionListaProducto.CurrentRow;
                    decimal cell2Value = Convert.ToDecimal(currentRow.Cells[2].Value);

                    DataGridViewRow almacenDefectuoso = dgvDevolucionListaProducto.CurrentRow;
                    decimal valorAlmacenDefectuoso = Convert.ToDecimal(almacenDefectuoso.Cells[4].Value ?? 0);

                    decimal valorActual = cell2Value - valorAlmacenDefectuoso;

                    if (inputValue > 0 && inputValue > valorActual)
                    {
                        e.Handled = true; // Cancelar la tecla presionada
                        MaterialMessageBox.Show("El valor introducido no puede ser mayor que la cantidad de salida.", "⚠︎ Información incorrecta                                 ");
                    }
                }
            }

            if (dgvDevolucionListaProducto.CurrentCell.ColumnIndex == 4) // Validar solo para la columna 3
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true; // Cancelar la tecla presionada
                    return;
                }

                string input = (dgvDevolucionListaProducto.EditingControl as DataGridViewTextBoxEditingControl).Text + e.KeyChar;

                if (decimal.TryParse(input, out decimal inputValue))
                {
                    DataGridViewRow currentRow = dgvDevolucionListaProducto.CurrentRow;
                    decimal cell2Value = Convert.ToDecimal(currentRow.Cells[2].Value);

                    DataGridViewRow almacenDevolucion = dgvDevolucionListaProducto.CurrentRow;
                    decimal valorAlmacenDevolucion = Convert.ToDecimal(almacenDevolucion.Cells[3].Value ?? 0);

                    decimal valorActual = cell2Value - valorAlmacenDevolucion;

                    if (inputValue > 0 && inputValue > valorActual)
                    {
                        e.Handled = true; // Cancelar la tecla presionada
                        MessageBox.Show("El valor introducido no puede ser mayor que la cantidad de salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DgvDevolucionListaProducto_ProductoDefecto_KeyPress(object sender, KeyPressEventArgs e)
        {

            MessageBox.Show(dgvDevolucionListaProducto.CurrentCell.ColumnIndex.ToString() + " Prodcuto");

            if (dgvDevolucionListaProducto.CurrentCell.ColumnIndex == 4) // Validar solo para la columna 3
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true; // Cancelar la tecla presionada
                    return;
                }

                string input = (dgvDevolucionListaProducto.EditingControl as DataGridViewTextBoxEditingControl).Text + e.KeyChar;

                if (decimal.TryParse(input, out decimal inputValue))
                {
                    DataGridViewRow currentRow = dgvDevolucionListaProducto.CurrentRow;
                    decimal cell2Value = Convert.ToDecimal(currentRow.Cells[2].Value);

                    DataGridViewRow almacenDevolucion = dgvDevolucionListaProducto.CurrentRow;
                    decimal valorAlmacenDevolucion = Convert.ToDecimal(almacenDevolucion.Cells[3].Value ?? 0);

                    decimal valorActual = cell2Value - valorAlmacenDevolucion;

                    if (inputValue > 0 && inputValue > valorActual)
                    {
                        e.Handled = true; // Cancelar la tecla presionada
                        MessageBox.Show("El valor introducido no puede ser mayor que la cantidad de salida." + inputValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDevolucionCompletar_Click(object sender, EventArgs e)
        {
            double devolucionCantidad = 0;
            double devolucionCantidadDefectuoso = 0;
            double TiempoUnix = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            int controlErrorSDK = 0;

            int idMovimientoRemision = 0;
            int idRemisionOrigen = Documento.IdDocumento;
            int idSalida = 0;
            int idEntrada = 0;
            int idFactura = 0;

            int idDocumentoSalida = 0;
            int idMovimientoSalida = 0;
            double folioSalida = 0;
            string serieSalida = "";

            int idDocumentoEntrada = 0;
            int idMovimientoEntrada = 0;
            double folioEntrada = 0;
            string serieEntrada = "";

            int idDocumentoFactura = 0;
            int idMovimientoFactura = 0;
            double folioFactura = 0;
            string serieFactura = "";

            string mensajeError = "";
            StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:\n\n");
            StringBuilder InterpreteSDK = new StringBuilder(255);

            using (adConexionDB adConnect = new adConexionDB())
            {
                var documentoRemision = (from remision in adConnect.bec_event_documento_encabezado
                                         where remision.id == idRemisionOrigen
                                         && remision.tipo == "remision"
                                         select remision).FirstOrDefault<bec_event_documento_encabezado>();

                var documentoSalida = new bec_event_documento_encabezado()
                {
                    fecha_creacion = DateTime.Now,
                    id_creador = LoginUsuario.IdUsuarioLogeado,
                    codigo_creador = LoginUsuario.CodigoUsuarioLogeado,
                    id_cliente = documentoRemision.id_cliente,
                    codigo_cliente = documentoRemision.codigo_cliente,
                    tipo = "salida",
                    unix = TiempoUnix,
                    procesado = false,
                    estado = "pendiente",
                    id_documento_origen = Documento.IdDocumento,
                    id_operador = documentoRemision.id_operador,
                    codigo_operador = documentoRemision.codigo_operador
                };
                adConnect.bec_event_documento_encabezado.Add(documentoSalida);

                var documentoEntrada = new bec_event_documento_encabezado()
                {
                    fecha_creacion = DateTime.Now,
                    id_creador = LoginUsuario.IdUsuarioLogeado,
                    codigo_creador = LoginUsuario.CodigoUsuarioLogeado,
                    id_cliente = documentoRemision.id_cliente,
                    codigo_cliente = documentoRemision.codigo_cliente,
                    tipo = "entrada",
                    unix = TiempoUnix,
                    procesado = false,
                    estado = "pendiente",
                    id_documento_origen = Documento.IdDocumento,
                    id_operador = documentoRemision.id_operador,
                    codigo_operador = documentoRemision.codigo_operador
                };
                adConnect.bec_event_documento_encabezado.Add(documentoEntrada);

                var documentoFactura = new bec_event_documento_encabezado()
                {
                    fecha_creacion = DateTime.Now,
                    id_creador = LoginUsuario.IdUsuarioLogeado,
                    codigo_creador = LoginUsuario.CodigoUsuarioLogeado,
                    id_cliente = documentoRemision.id_cliente,
                    codigo_cliente = documentoRemision.codigo_cliente,
                    tipo = "factura",
                    unix = TiempoUnix,
                    procesado = false,
                    estado = "pendiente",
                    id_documento_origen = Documento.IdDocumento,
                    id_operador = documentoRemision.id_operador,
                    codigo_operador = documentoRemision.codigo_operador
                };
                adConnect.bec_event_documento_encabezado.Add(documentoFactura);
                adConnect.SaveChanges();

                idSalida = documentoSalida.id;
                idEntrada = documentoEntrada.id;
                idFactura = documentoFactura.id;

                foreach (DataGridViewRow row in dgvDevolucionListaProducto.Rows)
                {
                    devolucionCantidad = Convert.ToDouble(row.Cells[3].Value ?? 0);
                    devolucionCantidadDefectuoso = Convert.ToDouble(row.Cells[4].Value ?? 0);

                    idMovimientoRemision = Convert.ToInt32(row.Cells[0].Value);
                    var movimientoRemision = (from remisionMov in adConnect.bec_event_documento_movimiento
                                              where remisionMov.id == idMovimientoRemision
                                              select remisionMov).FirstOrDefault<bec_event_documento_movimiento>();

                    if ((devolucionCantidad + devolucionCantidadDefectuoso) > 0)
                    {
                        var movimientoDevolucionSalida = new bec_event_documento_movimiento()
                        {
                            id_documento_encabezado = idSalida,
                            codigo_producto = movimientoRemision.codigo_producto,
                            cantidad_producto = Convert.ToDouble(devolucionCantidad + devolucionCantidadDefectuoso),
                            tipo = "salida",
                            unix = TiempoUnix,
                            procesado = false,
                        };
                        adConnect.bec_event_documento_movimiento.Add(movimientoDevolucionSalida);

                        var movimientoDevolucionEntrada = new bec_event_documento_movimiento()
                        {
                            id_documento_encabezado = idEntrada,
                            codigo_producto = movimientoRemision.codigo_producto,
                            cantidad_producto = Convert.ToDouble(devolucionCantidad),
                            cantidad_producto_defectuoso = Convert.ToDouble(devolucionCantidadDefectuoso),
                            tipo = "entrada",
                            unix = TiempoUnix,
                            procesado = false,
                        };
                        adConnect.bec_event_documento_movimiento.Add(movimientoDevolucionEntrada);
                    }

                    var movimientoDevolucionFactura = new bec_event_documento_movimiento()
                    {
                        id_documento_encabezado = idFactura,
                        codigo_producto = movimientoRemision.codigo_producto,
                        cantidad_producto = Convert.ToDouble(movimientoRemision.cantidad_producto) - (devolucionCantidad + devolucionCantidadDefectuoso),
                        tipo = "factura",
                        unix = TiempoUnix,
                        procesado = false,
                    };
                    adConnect.bec_event_documento_movimiento.Add(movimientoDevolucionFactura);
                }
                adConnect.SaveChanges();

                controlErrorSDK = SDK.SetCurrentDirectory(CurrentDirectory);
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                }
                controlErrorSDK = SDK.fInicioSesionSDK(Usuario, Password);
                //SDK.fInicioSesionSDKCONTPAQi("SUPERVISOR", "");
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                }
                controlErrorSDK = SDK.fSetNombrePAQ("CONTPAQ I Comercial");
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                }
                controlErrorSDK = SDK.fAbreEmpresa(Empresa);

                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                }
                else
                {
                    var existenSalidas = (from entSalida in adConnect.bec_event_documento_movimiento
                                          where entSalida.id_documento_encabezado == idSalida
                                          && entSalida.tipo == "salida"
                                          //&& entSalida.cantidad_producto >= 0
                                          select entSalida).ToList();

                    var existenEntradas = (from entradaSal in adConnect.bec_event_documento_movimiento
                                           where entradaSal.id_documento_encabezado == idEntrada
                                           && entradaSal.tipo == "entrada"
                                           //&& entradaSal.cantidad_producto >= 0
                                           select entradaSal).ToList();

                    var existenFacturas = (from entSalFac in adConnect.bec_event_documento_movimiento
                                           where entSalFac.id_documento_encabezado == idFactura
                                           && entSalFac.tipo == "factura"
                                           //&& entSalFac.cantidad_producto >= 0
                                           select entSalFac).ToList();

                    var conceptosPorCliente = (from documento in adConnect.bec_event_cliente_documento
                                               where documento.codigo_cliente == documentoRemision.codigo_cliente
                                               select documento).FirstOrDefault<bec_event_cliente_documento>();
                    if (existenSalidas.Count() > 0)
                    {
                        controlErrorSDK = SDK.fSiguienteFolio(conceptosPorCliente.codigo_salida, InterpreteSDK, ref folioSalida);

                        if (controlErrorSDK != 0)
                        {
                            SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                            mensajeError += $"\n \t Error al crear el folio de salida (devolución) folio: {folioSalida}  - {InterpreteSDK}";
                        }
                        else
                        {
                            serieSalida = documentoRemision.codigo_cliente;

                            SDK.tDocumento tDocSalida = new SDK.tDocumento
                            {
                                aCodConcepto = conceptosPorCliente.codigo_salida,
                                aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                                aSerie = serieSalida,
                                aFolio = folioSalida,
                            };

                            controlErrorSDK = SDK.fAltaDocumento(ref idDocumentoSalida, ref tDocSalida);

                            if (controlErrorSDK != 0)
                            {
                                SDK.fBuscarIdDocumento(idDocumentoSalida);
                                SDK.fBorraDocumento();
                                SDK.fError(controlErrorSDK, InterpreteSDK, 255);

                                mensajeError += $" Error en la creación del documento de salida (devolución) - folio: {folioSalida} - {InterpreteSDK} \n";
                            }
                            else
                            {
                                foreach (var objMovimientoSalida in existenSalidas)
                                {

                                    var almacenXSalida = (from mov in adConnect.admMovimientos
                                                          join pro in adConnect.admProductos on mov.CIDPRODUCTO equals pro.CIDPRODUCTO
                                                          join alm in adConnect.admAlmacenes on mov.CIDALMACEN equals alm.CIDALMACEN
                                                          join remision in adConnect.bec_event_documento_movimiento on mov.CIDMOVTOOWNER equals remision.id_movimiento_contpaq
                                                          where pro.CCODIGOPRODUCTO == objMovimientoSalida.codigo_producto
                                                          && remision.tipo == "remision"
                                                          select new { alm.CCODIGOALMACEN, mov.CUNIDADESCAPTURADAS }).FirstOrDefault();

                                    SDK.fBuscarIdDocumento(idDocumentoSalida);

                                    SDK.tMovimiento tMovSalida = new SDK.tMovimiento
                                    {
                                        aCodAlmacen = almacenXSalida.CCODIGOALMACEN,
                                        aCodProdSer = objMovimientoSalida.codigo_producto,
                                        aUnidades = Convert.ToDouble(objMovimientoSalida.cantidad_producto),
                                    };

                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumentoSalida, ref idMovimientoSalida, ref tMovSalida);

                                    if (controlErrorSDK != 0)
                                    {
                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieSalida}{folioSalida} de salida del producto: {objMovimientoSalida.codigo_producto} - {InterpreteSDK} \n";
                                    }
                                    else
                                    {
                                        objMovimientoSalida.procesado = true;
                                        objMovimientoSalida.id_movimiento_contpaq = idMovimientoSalida;
                                        adConnect.Entry(objMovimientoSalida).State = System.Data.Entity.EntityState.Modified;
                                        adConnect.SaveChanges();
                                    }
                                }

                                string updateEncabezadoSalida = $" UPDATE bec_event_documento_encabezado SET procesado = 1, id_contpaq_documento = {idDocumentoSalida}, folio_contpaq_documento = {folioSalida}, serie_contpaq_documento = '{serieSalida}' WHERE id = {idSalida}";
                                adConnect.Database.ExecuteSqlCommand(updateEncabezadoSalida);

                                if (mensajeError.Equals(""))
                                {
                                    controlErrorSDK = SDK.fSiguienteFolio(conceptosPorCliente.codigo_entrada, InterpreteSDK, ref folioEntrada);

                                    if (controlErrorSDK != 0)
                                    {
                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                        mensajeError += $"\n \t Error al crear el folio de entrada (devolución) - {InterpreteSDK}";
                                    }
                                    else
                                    {
                                        serieEntrada = documentoRemision.codigo_cliente;

                                        SDK.tDocumento tDocEntrada = new SDK.tDocumento
                                        {
                                            aCodConcepto = conceptosPorCliente.codigo_entrada,
                                            aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                                            aSerie = serieEntrada,
                                            aFolio = folioEntrada,
                                        };

                                        controlErrorSDK = SDK.fAltaDocumento(ref idDocumentoEntrada, ref tDocEntrada);

                                        if (controlErrorSDK != 0)
                                        {
                                            SDK.fBuscarIdDocumento(idDocumentoEntrada);
                                            SDK.fBorraDocumento();
                                            SDK.fError(controlErrorSDK, InterpreteSDK, 255);

                                            mensajeError += $" Error en la creación del documento de entrada (devolución) - {InterpreteSDK} \n";
                                        }
                                        else
                                        {
                                            foreach (var objMovimientoEntrada in existenEntradas)
                                            {
                                                SDK.fBuscarIdDocumento(idDocumentoEntrada);

                                                if (objMovimientoEntrada.cantidad_producto_defectuoso > 0)
                                                {
                                                    SDK.tMovimiento tMovEntrada = new SDK.tMovimiento
                                                    {
                                                        aCodAlmacen = conceptosPorCliente.codigo_almacen_defectuoso,
                                                        aCodProdSer = objMovimientoEntrada.codigo_producto,
                                                        aUnidades = Convert.ToDouble(objMovimientoEntrada.cantidad_producto_defectuoso),
                                                    };
                                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumentoEntrada, ref idMovimientoEntrada, ref tMovEntrada);

                                                    if (controlErrorSDK != 0)
                                                    {
                                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieEntrada}{folioEntrada} de entrada del producto: {objMovimientoEntrada.codigo_producto} - {InterpreteSDK} \n";
                                                    }
                                                    else
                                                    {
                                                        objMovimientoEntrada.procesado = true;
                                                        objMovimientoEntrada.id_movimiento_contpaq = idMovimientoEntrada;
                                                        adConnect.Entry(objMovimientoEntrada).State = System.Data.Entity.EntityState.Modified;
                                                        adConnect.SaveChanges();
                                                    }
                                                }
                                                if (objMovimientoEntrada.cantidad_producto > 0)
                                                {
                                                    var almacenXEntrada = (from mov in adConnect.admMovimientos
                                                                           join pro in adConnect.admProductos on mov.CIDPRODUCTO equals pro.CIDPRODUCTO
                                                                           join alm in adConnect.admAlmacenes on mov.CIDALMACEN equals alm.CIDALMACEN
                                                                           join remision in adConnect.bec_event_documento_movimiento on mov.CIDMOVIMIENTO equals remision.id_movimiento_contpaq
                                                                           where pro.CCODIGOPRODUCTO == objMovimientoEntrada.codigo_producto
                                                                           && remision.tipo == "remision"
                                                                           select new { alm.CCODIGOALMACEN, mov.CUNIDADESCAPTURADAS }).FirstOrDefault();

                                                    SDK.tMovimiento tMovEntrada = new SDK.tMovimiento
                                                    {
                                                        aCodAlmacen = almacenXEntrada.CCODIGOALMACEN,
                                                        aCodProdSer = objMovimientoEntrada.codigo_producto,
                                                        aUnidades = Convert.ToDouble(objMovimientoEntrada.cantidad_producto),
                                                    };

                                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumentoEntrada, ref idMovimientoEntrada, ref tMovEntrada);

                                                    if (controlErrorSDK != 0)
                                                    {
                                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieEntrada}{folioEntrada} de entrada del producto: {objMovimientoEntrada.codigo_producto} - {InterpreteSDK} \n";
                                                    }
                                                    else
                                                    {
                                                        objMovimientoEntrada.procesado = true;
                                                        objMovimientoEntrada.id_movimiento_contpaq = idMovimientoEntrada;
                                                        adConnect.Entry(objMovimientoEntrada).State = System.Data.Entity.EntityState.Modified;
                                                        adConnect.SaveChanges();
                                                    }
                                                }
                                            }

                                            string updateEncabezadoEntrada = $" UPDATE bec_event_documento_encabezado SET procesado = 1, id_contpaq_documento = {idDocumentoEntrada}, folio_contpaq_documento = {folioEntrada}, serie_contpaq_documento = '{serieEntrada}' WHERE id = {idEntrada}";
                                            adConnect.Database.ExecuteSqlCommand(updateEncabezadoEntrada);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (mensajeError.Equals(""))
                    {
                        controlErrorSDK = SDK.fSiguienteFolio(conceptosPorCliente.codigo_factura, InterpreteSDK, ref folioFactura);

                        if (controlErrorSDK != 0)
                        {
                            SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                            mensajeError += $" Error en la creación del documento de factura (devolucion) - {InterpreteSDK} \n";
                        }
                        else
                        {
                            serieFactura = InterpreteSDK.ToString();

                            SDK.tDocumento tDocFactura = new SDK.tDocumento
                            {
                                aCodConcepto = conceptosPorCliente.codigo_factura,
                                aCodigoCteProv = documentoRemision.codigo_cliente,
                                aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                                aSerie = serieFactura,
                                aFolio = folioFactura,
                            };

                            controlErrorSDK = SDK.fAltaDocumento(ref idDocumentoFactura, ref tDocFactura);

                            if (controlErrorSDK != 0)
                            {
                                SDK.fBuscarIdDocumento(idDocumentoFactura);
                                SDK.fBorraDocumento();
                                SDK.fError(controlErrorSDK, InterpreteSDK, 255);

                                mensajeError += $" Error en la creación del documento de factura - {InterpreteSDK} \n";
                            }
                            else
                            {
                                var almacenXDocumento = (from clie in adConnect.admConceptos
                                                         join alm in adConnect.admAlmacenes on clie.CIDALMASUM equals alm.CIDALMACEN
                                                         where clie.CCODIGOCONCEPTO == conceptosPorCliente.codigo_factura
                                                         select new { alm.CCODIGOALMACEN, clie.CNOMBRECONCEPTO }).FirstOrDefault();

                                foreach (var objMovimientoFactura in existenFacturas)
                                {
                                    SDK.fBuscarIdDocumento(idDocumentoFactura);

                                    SDK.tMovimiento tMov = new SDK.tMovimiento
                                    {
                                        aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                        aCodProdSer = objMovimientoFactura.codigo_producto,
                                        aUnidades = Convert.ToDouble(objMovimientoFactura.cantidad_producto),
                                    };

                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumentoFactura, ref idMovimientoFactura, ref tMov);
                                    if (controlErrorSDK != 0)
                                    {
                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieFactura}{folioFactura} de factura del producto: {objMovimientoFactura.codigo_producto} - {InterpreteSDK} \n";
                                    }
                                    else
                                    {
                                        objMovimientoFactura.id_movimiento_contpaq = idMovimientoFactura;
                                        objMovimientoFactura.procesado = true;
                                        adConnect.Entry(objMovimientoFactura).State = System.Data.Entity.EntityState.Modified;
                                        adConnect.SaveChanges();
                                    }
                                }

                                if (mensajeError.Equals(""))
                                {
                                    foreach (var objMovimientoFactura in existenFacturas)
                                    {
                                        var movimientoRemision = (from movRem in adConnect.bec_event_documento_movimiento
                                                                  where movRem.codigo_producto == objMovimientoFactura.codigo_producto
                                                                  && movRem.id_documento_encabezado == idRemisionOrigen
                                                                  select movRem).FirstOrDefault<bec_event_documento_movimiento>();

                                        string actualizarUnidadesPendientesMovimiento = $" UPDATE admMovimientos SET CUNIDADESPENDIENTES = 0 WHERE CIDMOVIMIENTO = {movimientoRemision.id_movimiento_contpaq}";
                                        adConnect.Database.ExecuteSqlCommand(actualizarUnidadesPendientesMovimiento);
                                    }

                                    string actualizarUnidadesPendientesDocumento = $@" UPDATE admDocumentos 
                                                                                    SET CUNIDADESPENDIENTES = ( SELECT SUM(CUNIDADESPENDIENTES) FROM admMovimientos WHERE CIDDOCUMENTO = {documentoRemision.id_contpaq_documento} )
                                                                                    WHERE CIDDOCUMENTO = {documentoRemision.id_contpaq_documento}";
                                    adConnect.Database.ExecuteSqlCommand(actualizarUnidadesPendientesDocumento);

                                    string updateEncabezadoFactura = $" UPDATE bec_event_documento_encabezado SET procesado = 1, id_contpaq_documento = {idDocumentoFactura}, folio_contpaq_documento = {folioFactura}, serie_contpaq_documento = '{serieFactura}', estado = 'terminada' WHERE id = {idFactura}";
                                    adConnect.Database.ExecuteSqlCommand(updateEncabezadoFactura);

                                    string updateEncabezadoRemision = $" UPDATE bec_event_documento_encabezado SET estado = 'terminada' WHERE id = {idRemisionOrigen}";
                                    adConnect.Database.ExecuteSqlCommand(updateEncabezadoRemision);

                                    mensaje.AppendFormat($"Liquidación completada correctamente. \n\n");
                                    MaterialMessageBox.Show(mensaje.ToString(), "✔️ Liquidación creada correctamente.                                             ");

                                    ListadoSalidas formPrincipal = new ListadoSalidas();
                                    formPrincipal.CargarListado();
                                    this.Close();
                                }
                            }
                        }
                    }

                    if (!mensajeError.Equals(""))
                    {
                        mensaje.AppendFormat($"Verifique el siguiente error: {mensajeError} \n\n");
                        MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ Proceso erroneo");
                    }

                    SDK.fCierraEmpresa();
                    SDK.fTerminaSDK();
                }

            }
        }

        private void dgvDevolucionListaProducto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(DgvDevolucionListaProducto_Devolucion_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(DgvDevolucionListaProducto_Devolucion_KeyPress);
        }
    }
}
