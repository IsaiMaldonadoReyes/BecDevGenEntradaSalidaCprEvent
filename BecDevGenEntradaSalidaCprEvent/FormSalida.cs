using MaterialSkin.Controls;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Web;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static BecDevGenEntradaSalidaCprEvent.SDK;
using TextBox = System.Windows.Controls.TextBox;
using Excel = Microsoft.Office.Interop.Excel;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class FormSalida : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        string CurrentDirectory = ConfigurationManager.AppSettings["CurrentDirectory"].ToString();
        string Usuario = ConfigurationManager.AppSettings["Usuario"].ToString();
        string Password = ConfigurationManager.AppSettings["Password"].ToString();
        string Empresa = ConfigurationManager.AppSettings["Empresa"].ToString();

        string Server = ConfigurationManager.AppSettings["server"].ToString();
        string Instance = ConfigurationManager.AppSettings["instance"].ToString();
        string User = ConfigurationManager.AppSettings["user"].ToString();
        string PasswordDB = ConfigurationManager.AppSettings["passwordDB"].ToString();
        string Database = ConfigurationManager.AppSettings["database"].ToString();
        string LocalDirectory = ConfigurationManager.AppSettings["LocalDirectory"].ToString();

        StringBuilder InterpreteSDK = new StringBuilder(255);
        StiVariablesCollection variable = new StiVariablesCollection();

        private List<InformacionClientesConfigurados> clientes;
        private List<admAgentes> agentes;
        private List<admProductos> productos;

        public class InformacionClientesConfigurados
        {
            public int CIDCLIENTEPROVEEDOR { get; set; }

            public string CCODIGOCLIENTE { get; set; }
        }

        public FormSalida()
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

        private void FormSalida_Load(object sender, EventArgs e)
        {
            btnSalidaBorrar.Enabled = false;
            btnSalidaCompletar.Enabled = false;

            cbxSalidaProducto.Enabled = false;
            btnSalidaAgregarProducto.Enabled = false;
            cbxSalidaCliente.Enabled = false;
            txtSalidaCantidadProducto.Enabled = false;
            cbxOperador.Visible = false;
            lblOperador.Visible = false;


            Documento.AccionDocumento = "crear";

            if (Documento.IdDocumento != 0)
            {
                var salida = ObtenerFechaCreacion(Documento.IdDocumento);

                lblSalidaFecha.Text = $"Fecha: {(Documento.IdDocumento == 0 ? DateTime.Now : salida.fecha_creacion):yyyy-MM-dd}";
                lblRuta.Text = $"Ruta: {salida.codigo_cliente}";
                //lblOperador.Text = $"Operador: {salida.codigo_operador}";

                cbxSalidaCliente.Visible = false;
                cbxSalidaProducto.Enabled = true;

                txtSalidaCantidadProducto.Enabled = true;
                btnSalidaAgregarProducto.Enabled = true;
                btnSalidaCompletar.Enabled = true;
                //lblProducto.Visible = false;
                //lblCantidad.Visible = false;

                btnSalidaBorrar.Text = "Reimprimir ticket";
                btnSalidaBorrar.Enabled = true;

                CargarDGVProductos(Documento.IdDocumento);
            }
            cbxSalidaCliente.Enabled = (Documento.IdDocumento == 0);
            this.Text = (Documento.IdDocumento == 0 ? "Event Express | Nueva salida" : "Event Express | Editar salida");
            CargarClientes();
            //CargarOperadores();
            CargarProductos();
        }

        private bec_event_documento_encabezado ObtenerFechaCreacion(int idDocumento)
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                var salida = (from remision in adConnect.bec_event_documento_encabezado
                              where remision.tipo == "remision" && remision.id == idDocumento
                              select remision).FirstOrDefault<bec_event_documento_encabezado>();

                return salida;
            }
        }

        public void CargarOperadores()
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                agentes = (from agente in adConnect.admAgentes
                           where agente.CTIPOAGENTE == 2
                           orderby agente.CCODIGOAGENTE
                           select agente).ToList();

                foreach (var objLista in agentes)
                {
                    cbxOperador.Items.Add(objLista.CCODIGOAGENTE + " | " + objLista.CNOMBREAGENTE);
                }
            }
        }

        public void CargarClientes()
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                string codigoLogeado = LoginUsuario.CodigoUsuarioLogeado;
                clientes = (from cliente in adConnect.admClientes
                            join conf in adConnect.bec_event_cliente_documento on cliente.CCODIGOCLIENTE equals conf.codigo_cliente
                            where cliente.CIDALMACEN > 0 && cliente.CTIPOCLIENTE == 1
                            && cliente.CESTATUS == 1
                            && conf.codigo_agente == codigoLogeado
                            orderby cliente.CCODIGOCLIENTE
                            select new InformacionClientesConfigurados
                            {
                                CCODIGOCLIENTE = cliente.CCODIGOCLIENTE,
                                CIDCLIENTEPROVEEDOR = cliente.CIDCLIENTEPROVEEDOR
                            }).ToList();

                foreach (var objLista in clientes)
                {
                    cbxSalidaCliente.Items.Add(objLista.CCODIGOCLIENTE);
                }
            }
        }
        public void CargarProductos()
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                productos = (from producto in adConnect.admProductos
                             where producto.CIDPRODUCTO > 0 && producto.CSTATUSPRODUCTO == 1
                             orderby producto.CCODIGOPRODUCTO
                             select producto).ToList();
                foreach (var objLista in productos)
                {
                    cbxSalidaProducto.Items.Add(objLista.CCODALTERN + " | " + objLista.CCODIGOPRODUCTO + " | " + objLista.CNOMBREPRODUCTO);
                }
            }
        }

        public void CargarDGVProductos(int idDocumento)
        {
            dgvSalidaListaProducto.Rows.Clear();
            dgvSalidaListaProducto.Refresh();
            using (adConexionDB adConnect = new adConexionDB())
            {
                var listaDGVProductos = (from listaMovimientos in adConnect.bec_event_documento_movimiento
                                         join producto in adConnect.admProductos on listaMovimientos.codigo_producto equals producto.CCODIGOPRODUCTO
                                         where listaMovimientos.id_documento_encabezado == idDocumento && producto.CIDPRODUCTO > 0
                                         select new { listaMovimientos.id, listaMovimientos.codigo_producto, listaMovimientos.cantidad_producto, producto.CNOMBREPRODUCTO }).ToList();

                foreach (var objLista in listaDGVProductos)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvSalidaListaProducto);
                    newRow.Cells[0].Value = objLista.id;
                    newRow.Cells[1].Value = objLista.codigo_producto + " | " + objLista.CNOMBREPRODUCTO;
                    newRow.Cells[2].Value = objLista.cantidad_producto;
                    dgvSalidaListaProducto.Rows.Add(newRow);
                }
                if (Documento.TipoDocumento == "create")
                {
                    btnSalidaCompletar.Enabled = (listaDGVProductos.Count() > 0);
                }
            }
        }

        private void btnSalidaAgregarProducto_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeConfiguracion = new StringBuilder("Verifique lo siguiente:\n\n");
            double TiempoUnix = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            string codigoProducto = "";

            if (cbxSalidaProducto.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el producto");
            }
            if (string.IsNullOrWhiteSpace(txtSalidaCantidadProducto.Text))
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Determinar la cantidad del producto");
            }
            else if (!double.TryParse(txtSalidaCantidadProducto.Text, out double cantidad) || cantidad <= 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ La cantidad debe de ser mayor a 0");
            }

            if (mensajeConfiguracion.Length > 28) // Si hay errores
            {
                mensajeConfiguracion.Insert(0, "Es necesario ingresar los campos solicitados para poder agregar el producto, por favor:\n\n");
                MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
                cbxSalidaProducto.SelectedIndex = -1;
                return;
            }


            codigoProducto = productos[cbxSalidaProducto.SelectedIndex].CCODIGOPRODUCTO;
            using (adConexionDB adConnect = new adConexionDB())
            {
                var existeSalidaDisponibleProducto = (from productoDisponible in adConnect.bec_event_documento_movimiento
                                                      where productoDisponible.tipo == "remision"
                                                      && productoDisponible.codigo_producto == codigoProducto
                                                      && productoDisponible.id_documento_encabezado == Documento.IdDocumento
                                                      select productoDisponible).FirstOrDefault<bec_event_documento_movimiento>();
                if (existeSalidaDisponibleProducto != null)
                {
                    //mensajeConfiguracion.AppendLine("\n \t❎ Existe un producto anteriormente registrado");
                    //MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
                    //cbxSalidaProducto.SelectedIndex = -1;
                    //return;
                    double cantidadAnterior = (double)existeSalidaDisponibleProducto.cantidad_producto;
                    existeSalidaDisponibleProducto.cantidad_producto = cantidadAnterior + Convert.ToDouble(txtSalidaCantidadProducto.Text);
                    adConnect.Entry(existeSalidaDisponibleProducto).State = System.Data.Entity.EntityState.Modified;

                    var historiaMovimiento = new bec_event_historia_movimiento()
                    {
                        id_documento_encabezado = Documento.IdDocumento,
                        id_documento_movimiento = existeSalidaDisponibleProducto.id,
                        cantidad = Convert.ToDouble(txtSalidaCantidadProducto.Text),
                        codigo_producto = codigoProducto,
                        fecha = DateTime.Now
                    };
                    adConnect.bec_event_historia_movimiento.Add(historiaMovimiento);
                }
                else
                {
                    var documentoMovimiento = new bec_event_documento_movimiento()
                    {
                        id_documento_encabezado = Documento.IdDocumento,
                        codigo_producto = codigoProducto,
                        cantidad_producto = Convert.ToDouble(txtSalidaCantidadProducto.Text),
                        tipo = "remision",
                        unix = TiempoUnix,
                        procesado = false,
                    };
                    adConnect.bec_event_documento_movimiento.Add(documentoMovimiento);
                }
                adConnect.SaveChanges();

                txtSalidaCantidadProducto.Text = "";
                cbxSalidaProducto.Text = "";
                cbxSalidaProducto.Focus();
                CargarDGVProductos(Documento.IdDocumento);
                btnSalidaCompletar.Enabled = true;
            }
        }

        private void txtSalidaCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;  // evitar que se escriba en el control
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.IndexOf('.') > -1)
            {
                e.Handled = true;  // evitar que se escriba en el control
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.IndexOf('.') == -1)
            {
                int pointIndex = (sender as TextBox).Text.IndexOf('.');
                if (pointIndex > -1)
                {
                    e.Handled = true; // evitar que se escriba en el control
                }
            }
        }

        private void btnSalidaCompletar_Click(object sender, EventArgs e)
        {
            Documento.AccionDocumento = "completar";

            StringBuilder MensajeErrorVentana = new StringBuilder("Verifique lo siguiente:\n\n");
            int controlErrorSDK = 0;
            int idDocumento = 0;
            int idMovimiento = 0;
            double folioDocumento = 0;
            string mensajeError = "";
            string serieDocumento = "";

            using (adConexionDB adConnect = new adConexionDB())
            {
                var salidaPendiente = (from salida in adConnect.bec_event_documento_encabezado
                                       where salida.id == Documento.IdDocumento
                                       && salida.estado == "pendiente"
                                       //&& salida.id_contpaq_documento == null
                                       select salida).FirstOrDefault<bec_event_documento_encabezado>();
                controlErrorSDK = SDK.SetCurrentDirectory(CurrentDirectory);
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                    //MaterialMessageBox.Show(InterpreteSDK.ToString(), "⚠︎ Error en la creación del SetCurrentDirectory");
                }
                controlErrorSDK = SDK.fInicioSesionSDK(Usuario, Password);
                //                SDK.fInicioSesionSDKCONTPAQi("SUPERVISOR", "");
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                    //MaterialMessageBox.Show(InterpreteSDK.ToString(), "⚠︎ Error en la creación del fInicioSesionSDK");
                }
                controlErrorSDK = SDK.fSetNombrePAQ("CONTPAQ I Comercial");
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                    //MaterialMessageBox.Show(InterpreteSDK.ToString(), "⚠︎ Error en la creación del fSetNombrePAQ");
                }
                controlErrorSDK = SDK.fAbreEmpresa(Empresa);

                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                    //MaterialMessageBox.Show(InterpreteSDK.ToString(), "⚠︎ Error en la creación del fAbreEmpresa");
                }
                else
                {

                    var documentoSalida = (from documento in adConnect.bec_event_cliente_documento
                                           where documento.codigo_cliente == salidaPendiente.codigo_cliente
                                           select documento).FirstOrDefault<bec_event_cliente_documento>();

                    if (salidaPendiente.id_contpaq_documento == null)
                    {
                        controlErrorSDK = SDK.fSiguienteFolio(documentoSalida.codigo_documento, InterpreteSDK, ref folioDocumento);

                        if (controlErrorSDK != 0)
                        {
                            SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                            mensajeError += $"\n \t Error al crear el siguiente folio de remisión - {InterpreteSDK}";
                        }
                        else
                        {
                            serieDocumento = InterpreteSDK.ToString();

                            SDK.tDocumento tDoc = new SDK.tDocumento
                            {
                                aCodConcepto = documentoSalida.codigo_documento,
                                aCodigoCteProv = documentoSalida.codigo_cliente,
                                aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                                aSerie = serieDocumento,
                                aFolio = folioDocumento,
                                //aCodigoAgente = agentes[cbxOperador.SelectedIndex].CCODIGOAGENTE,
                            };

                            controlErrorSDK = SDK.fAltaDocumento(ref idDocumento, ref tDoc);

                            if (controlErrorSDK != 0)
                            {
                                SDK.fBuscarIdDocumento(idDocumento);
                                SDK.fBorraDocumento();
                                SDK.fError(controlErrorSDK, InterpreteSDK, 255);

                                mensajeError += $"\n \t Error en la creación del documento - {InterpreteSDK} ";
                            }
                            else
                            {
                                var almacenXDocumento = (from clie in adConnect.admConceptos
                                                         join alm in adConnect.admAlmacenes on clie.CIDALMASUM equals alm.CIDALMACEN
                                                         where clie.CCODIGOCONCEPTO == documentoSalida.codigo_documento
                                                         select new { alm.CCODIGOALMACEN, clie.CNOMBRECONCEPTO }).FirstOrDefault();

                                var movimientosSalida = (from movimientos in adConnect.bec_event_documento_movimiento
                                                         where movimientos.id_documento_encabezado == salidaPendiente.id
                                                         select movimientos).ToList();

                                foreach (var objMovimiento in movimientosSalida)
                                {
                                    SDK.fBuscarIdDocumento(idDocumento);

                                    SDK.tMovimiento tMov = new SDK.tMovimiento
                                    {
                                        aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                        aCodProdSer = objMovimiento.codigo_producto,
                                        aUnidades = Convert.ToDouble(objMovimiento.cantidad_producto),
                                    };

                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumento, ref idMovimiento, ref tMov);

                                    if (controlErrorSDK != 0)
                                    {
                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieDocumento}{folioDocumento}, código del producto: {objMovimiento.codigo_producto} - {InterpreteSDK} \n";

                                        objMovimiento.procesado = false;
                                        adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                        adConnect.SaveChanges();
                                    }
                                    else
                                    {
                                        objMovimiento.procesado = true;
                                        objMovimiento.id_movimiento_contpaq = idMovimiento;
                                        adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                        adConnect.SaveChanges();

                                        string actualizarMovimientosHistoria = $"UPDATE bec_event_historia_movimiento SET procesado = 1,  id_movimiento_contpaq = {idMovimiento} WHERE id_documento_movimiento = {objMovimiento.id} ";
                                        adConnect.Database.ExecuteSqlCommand(actualizarMovimientosHistoria);

                                    }
                                }

                                if (!mensajeError.Equals(""))
                                {
                                    SDK.fBuscarIdDocumento(idDocumento);
                                    SDK.fBorraDocumento();

                                    MensajeErrorVentana.Append(mensajeError);
                                    MaterialMessageBox.Show(MensajeErrorVentana.ToString(), "⚠︎ Error en la creación del documento");
                                }
                            }
                        }

                        if (mensajeError.Equals(""))
                        {
                            salidaPendiente.procesado = true;
                            salidaPendiente.id_contpaq_documento = idDocumento;
                            salidaPendiente.serie_contpaq_documento = serieDocumento;
                            salidaPendiente.folio_contpaq_documento = folioDocumento;
                            adConnect.Entry(salidaPendiente).State = System.Data.Entity.EntityState.Modified;
                            adConnect.SaveChanges();

                            GenerarTicketSalida(Documento.IdDocumento);

                            MensajeErrorVentana.Append($"\n \t Salida completada correctamente.                                                                         ");
                            MaterialMessageBox.Show(MensajeErrorVentana.ToString(), "✔️ Información guardada correctamente");

                            ListadoSalidas formPrincipal = new ListadoSalidas();
                            formPrincipal.CargarListado();
                            this.Close();
                        }
                    }
                    else
                    {
                        var almacenXDocumento = (from clie in adConnect.admConceptos
                                                 join alm in adConnect.admAlmacenes on clie.CIDALMASUM equals alm.CIDALMACEN
                                                 where clie.CCODIGOCONCEPTO == documentoSalida.codigo_documento
                                                 select new { alm.CCODIGOALMACEN, clie.CNOMBRECONCEPTO }).FirstOrDefault();


                        var movimientosSalida = (from movimientos in adConnect.bec_event_documento_movimiento
                                                 where movimientos.id_documento_encabezado == Documento.IdDocumento
                                                 && movimientos.id_movimiento_contpaq == null
                                                 select movimientos).ToList();


                        foreach (var objMovimiento in movimientosSalida)
                        {
                            idDocumento = (int)salidaPendiente.id_contpaq_documento;

                            SDK.fBuscarIdDocumento(idDocumento);

                            SDK.tMovimiento tMov = new SDK.tMovimiento
                            {
                                aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                aCodProdSer = objMovimiento.codigo_producto,
                                aUnidades = Convert.ToDouble(objMovimiento.cantidad_producto),
                            };

                            controlErrorSDK = SDK.fAltaMovimiento(idDocumento, ref idMovimiento, ref tMov);

                            if (controlErrorSDK != 0)
                            {
                                SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieDocumento}{folioDocumento}, código del producto: {objMovimiento.codigo_producto} - {InterpreteSDK} \n";
                            }
                            else
                            {
                                objMovimiento.procesado = true;
                                objMovimiento.id_movimiento_contpaq = idMovimiento;
                                adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                adConnect.SaveChanges();
                            }
                        }

                        var movimientosSalidaHistoria = (from movimientos in adConnect.bec_event_historia_movimiento
                                                         where movimientos.id_documento_encabezado == salidaPendiente.id
                                                         && movimientos.id_movimiento_contpaq == null
                                                         select movimientos).ToList();


                        foreach (var objMovimiento in movimientosSalidaHistoria)
                        {
                            idDocumento = (int)salidaPendiente.id_contpaq_documento;

                            var movimientosOrigen = (from movimientos in adConnect.bec_event_documento_movimiento
                                                     where movimientos.id == objMovimiento.id_documento_movimiento
                                                     select movimientos).FirstOrDefault();
                            SDK.fBuscarIdDocumento(idDocumento);
                            if (movimientosOrigen != null)
                            {
                                if (movimientosOrigen.id_movimiento_contpaq == null)
                                {
                                    SDK.tMovimiento tMov = new SDK.tMovimiento
                                    {
                                        aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                        aCodProdSer = objMovimiento.codigo_producto,
                                        aUnidades = Convert.ToDouble(objMovimiento.cantidad),
                                    };

                                    controlErrorSDK = SDK.fAltaMovimiento(idDocumento, ref idMovimiento, ref tMov);

                                    if (controlErrorSDK != 0)
                                    {
                                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                        mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieDocumento}{folioDocumento}, código del producto: {objMovimiento.codigo_producto} - {InterpreteSDK} \n";
                                    }
                                    else
                                    {
                                        movimientosOrigen.id_movimiento_contpaq = idMovimiento;
                                        movimientosOrigen.procesado = true;
                                        adConnect.Entry(movimientosOrigen).State = System.Data.Entity.EntityState.Modified;

                                        objMovimiento.procesado = true;
                                        objMovimiento.id_movimiento_contpaq = idMovimiento;
                                        adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                        adConnect.SaveChanges();
                                    }
                                }
                                else
                                {

                                    SDK.fBuscarIdMovimiento(Convert.ToInt32(movimientosOrigen.id_movimiento_contpaq));
                                    SDK.fEditarMovimiento();
                                    SDK.fSetDatoMovimiento("CUNIDADESCAPTURADAS", movimientosOrigen.cantidad_producto.ToString());
                                    SDK.fGuardaMovimiento();

                                    objMovimiento.procesado = true;
                                    objMovimiento.id_movimiento_contpaq = movimientosOrigen.id_movimiento_contpaq;
                                    adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                    adConnect.SaveChanges();
                                }
                            }
                            else
                            {

                                SDK.tMovimiento tMov = new SDK.tMovimiento
                                {
                                    aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                    aCodProdSer = objMovimiento.codigo_producto,
                                    aUnidades = Convert.ToDouble(objMovimiento.cantidad),
                                };

                                controlErrorSDK = SDK.fAltaMovimiento(idDocumento, ref idMovimiento, ref tMov);

                                if (controlErrorSDK != 0)
                                {
                                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                    mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieDocumento}{folioDocumento}, código del producto: {objMovimiento.codigo_producto} - {InterpreteSDK} \n";
                                }
                                else
                                {
                                    objMovimiento.procesado = true;
                                    objMovimiento.id_movimiento_contpaq = idMovimiento;
                                    adConnect.Entry(objMovimiento).State = System.Data.Entity.EntityState.Modified;
                                    adConnect.SaveChanges();
                                }
                            }
                        }

                        if (mensajeError.Equals(""))
                        {
                            GenerarTicketSalida(Documento.IdDocumento);

                            MensajeErrorVentana.Append($"\n \t Salida actualizada correctamente.                                                                         ");
                            MaterialMessageBox.Show(MensajeErrorVentana.ToString(), "✔️ Información guardada correctamente");

                            ListadoSalidas formPrincipal = new ListadoSalidas();
                            formPrincipal.CargarListado();
                            this.Close();
                        }
                        else
                        {
                            MensajeErrorVentana.Append($"\n \t {mensajeError}");
                            MaterialMessageBox.Show(MensajeErrorVentana.ToString(), "❎ Información incorrecta");
                        }
                    }
                }

                SDK.fCierraEmpresa();
                SDK.fTerminaSDK();
            }

        }

        private void GenerarTicketSalida(int idSalida)
        {
            try
            {
                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                SDK.SetCurrentDirectory(LocalDirectory);

                StiReport mrt = new StiReport();
                Stimulsoft.Base.StiLicense.Key = @"6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkpNBNlI/1rz4ZIh+PJP5PlDY/b4HIU9O1e2oNddG4xhdP1Uw" +
                                                "vn4GQ7LiDcUOP1HTGjvHLwklwbkdorFBx+rO4KOY1ssR9fpR9mxDlbjXy/XECx7yyvN9bNY9qLh7Wd0Vk8HMilx7u7" +
                                                "0tHOhY5Kfgr8G/6n4fwsw0ZuOfWUiMdHqJV5PDGBFByN12Jkebffil+ybmVpVjtCoEJeDXikMKUNE6YMul5UxoYqvO" +
                                                "05nCRTmFQzrXq+CZiA/U6S+r3KjsNNnVFr651oRgr1kinasjsgqlTpkKwK324TFhOowTNtMGy83nFn2/8wl3ZSkTcZ" +
                                                "FgSUPpcGZiQ4eVbzqx38FXTy2hwjsJ4/m6gPvpCV0ph3C9lhAr2A0AnRTpCIjHFy5CpHPC31u/trfvm3r41sKKfxiH" +
                                                "TmjKyp+M2ke67s6b1DC0jEsUaNOm00YzFl+YAnDDdbsvBQQUnF9mSNxpsxfQcqV3sufAAf80H5DvKJ5oo+3p3BWGnH" +
                                                "X3Ix+cK/Ymh6cj/89F+Q5mPxOhizMVgl7RLS";

                mrt.Load(LocalDirectory + "ReporteSalidas.mrt");
                mrt.ReportName = "ReporteSalidas.mrt";

                addVar("vIdAlmacen", idSalida.ToString());
                mrt.Dictionary.Variables = variable;

                var sqlDB = new StiSqlDatabase("Zeus", "", $"Data Source={Server}\\{Instance} ;Initial Catalog={Database};Integrated Security=False;Persist Security Info=True;User ID={User};Password={PasswordDB}");

                mrt.Dictionary.Databases.Clear();

                mrt.Dictionary.Databases.Add(sqlDB);
                mrt.Dictionary.Synchronize();
                mrt.RenderWithWpf();
                mrt.ExportDocument(StiExportFormat.Pdf, $"{mdoc}\\{idSalida}.pdf");

                string pdfPath = Path.Combine(Application.StartupPath, $"{mdoc}\\{idSalida}.pdf");
                Process.Start(pdfPath);
            }
            catch (IOException)
            {
                MaterialMessageBox.Show($"El formato de PDF se encuentra abierto, por favor cierrelo y vuelva a intentarlo.                                                                                            ", "⚠︎ Error al abrir el PDF6");
            }
        }

        private void btnSalidaBorrar_Click(object sender, EventArgs e)
        {
            Documento.AccionDocumento = "completar";
            ListadoSalidas formPrincipal = new ListadoSalidas();

            if (Documento.TipoDocumento != "create")
            {
                GenerarTicketSalida(Documento.IdDocumento);
                formPrincipal.CargarListado();
                this.Close();

                return;
            }

            StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:");
            mensaje.AppendFormat("\n\n¿Desea eliminar el documento de salida?                                                                                        \n\n\n💡 Nota: está acción no se puede deshacer, al eliminarlo ya no podrá acceder a la información.");

            if (MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ ¡CUIDADO! Leer atentamente entes de continuar", MessageBoxButtons.YesNo, true, FlexibleMaterialForm.ButtonsPosition.Center) != DialogResult.Yes)
            {
                return;
            }

            LiquidarSalida(Documento.IdDocumento);

            MaterialMessageBox.Show($"La salida ha sido eliminada correctamente.                                                                                            ", "✔️ Información eliminada correctamente");

            formPrincipal.CargarListado();
            this.Close();
        }

        private void cbxSalidaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder mensajeConfiguracion = new StringBuilder("Verifique lo siguiente:\n\n");
            double TiempoUnix = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            int idCliente = 0;
            string codigoCliente = "";

            if (cbxSalidaCliente.SelectedIndex < 0) return;

            idCliente = clientes[cbxSalidaCliente.SelectedIndex].CIDCLIENTEPROVEEDOR;
            codigoCliente = clientes[cbxSalidaCliente.SelectedIndex].CCODIGOCLIENTE;
            using (adConexionDB adConnect = new adConexionDB())
            {


                var existeSalidaDisponibleCliente = (from clienteExiste in adConnect.bec_event_cliente_documento
                                                     where clienteExiste.codigo_cliente == codigoCliente
                                                     select clienteExiste).FirstOrDefault<bec_event_cliente_documento>();


                if (existeSalidaDisponibleCliente == null)
                {
                    MaterialMessageBox.Show("\n \t❎ No se encuentra configurada la ruta seleccionada                                                                                            ", "⚠︎ Información incorrecta");
                    cbxSalidaCliente.SelectedIndex = -1;
                    cbxSalidaCliente.Text = "";
                    return;
                }


                /*
                var existeSalidaDisponibleCliente = (from clienteDisponible in adConnect.bec_event_documento_encabezado
                                                     where clienteDisponible.estado == "pendiente"
                                                     && clienteDisponible.tipo == "remision"
                                                     && clienteDisponible.id_cliente == idCliente
                                                     select clienteDisponible).FirstOrDefault<bec_event_documento_encabezado>();
                */
                /*
                if (existeSalidaDisponibleCliente != null)
                {
                    MaterialMessageBox.Show("\n \t❎ Existe una salida pendiente con el cliente seleccionado", "⚠︎ Información incorrecta");
                    cbxSalidaCliente.SelectedIndex = -1;
                    cbxSalidaCliente.Text = "";
                    return;
                }
                */

                var documentoEncabezado = new bec_event_documento_encabezado()
                {
                    fecha_creacion = DateTime.Now,
                    id_cliente = clientes[cbxSalidaCliente.SelectedIndex].CIDCLIENTEPROVEEDOR,
                    codigo_cliente = clientes[cbxSalidaCliente.SelectedIndex].CCODIGOCLIENTE,
                    id_creador = LoginUsuario.IdUsuarioLogeado,
                    codigo_creador = LoginUsuario.CodigoUsuarioLogeado,
                    tipo = "remision",
                    unix = TiempoUnix,
                    procesado = false,
                    estado = "pendiente"
                };
                adConnect.bec_event_documento_encabezado.Add(documentoEncabezado);
                adConnect.SaveChanges();

                Documento.IdDocumento = documentoEncabezado.id;

                cbxSalidaCliente.Enabled = false;

                txtSalidaCantidadProducto.Enabled = true;
                cbxSalidaProducto.Enabled = true;
                btnSalidaAgregarProducto.Enabled = true;
                //cbxOperador.Enabled = true;

                btnSalidaBorrar.Enabled = true;

                cbxSalidaProducto.Focus();
            }
        }

        private void dgvSalidaListaProducto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvSalidaListaProducto.HitTest(e.X, e.Y);

                if (hti.RowIndex != -1)
                {
                    dgvSalidaListaProducto.ClearSelection();
                    dgvSalidaListaProducto.Rows[hti.RowIndex].Selected = true;
                    dgvSalidaListaProducto.CurrentCell = dgvSalidaListaProducto.Rows[hti.RowIndex].Cells[1];
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Documento.TipoDocumento.Equals("create"))
            {
                int rowToDelete = dgvSalidaListaProducto.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                if (rowToDelete >= 0)
                {
                    if (!Convert.ToString(dgvSalidaListaProducto.Rows[rowToDelete].Cells[0].Value).Equals(""))
                    {
                        int idMovimiento = Convert.ToInt32(dgvSalidaListaProducto.Rows[rowToDelete].Cells[0].Value);
                        using (adConexionDB adConnect = new adConexionDB())
                        {
                            bec_event_documento_movimiento relacionCuenta = new bec_event_documento_movimiento() { id = idMovimiento };
                            adConnect.bec_event_documento_movimiento.Attach(relacionCuenta);
                            adConnect.bec_event_documento_movimiento.Remove(relacionCuenta);
                            adConnect.SaveChanges();

                            CargarDGVProductos(Documento.IdDocumento);

                            var existenMovivimientos = (from salida in adConnect.bec_event_documento_movimiento
                                                        where salida.id_documento_encabezado == Documento.IdDocumento
                                                        select salida).ToList();

                            if (existenMovivimientos == null)
                            {
                                btnSalidaCompletar.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                MaterialMessageBox.Show("\n \t❎ No se puede eliminar un producto de una salida pendiente", "⚠︎ Acción negada");
            }
        }

        private void cbxSalidaCliente_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
        }

        private void cbxOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idOperador = 0;

            if (cbxOperador.SelectedIndex >= 0)
            {
                using (adConexionDB adConnect = new adConexionDB())
                {
                    idOperador = agentes[cbxOperador.SelectedIndex].CIDAGENTE;

                    var remisionDocumento = (from remision in adConnect.bec_event_documento_encabezado
                                             where remision.estado == "pendiente"
                                             && remision.tipo == "remision"
                                             && remision.id == Documento.IdDocumento
                                             select remision).FirstOrDefault<bec_event_documento_encabezado>();

                    remisionDocumento.id_operador = idOperador;
                    remisionDocumento.codigo_operador = agentes[cbxOperador.SelectedIndex].CCODIGOAGENTE;
                    adConnect.Entry(remisionDocumento).State = System.Data.Entity.EntityState.Modified;
                    adConnect.SaveChanges();

                    cbxSalidaProducto.Focus();

                }
            }
        }
        private void cbxSalidaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                /*
                string codigoBarras = cbxSalidaProducto.Text.Trim();

                if (productos.Any(objProducto => objProducto.CCODALTERN == codigoBarras))
                {
                    int indice = cbxSalidaProducto.FindStringExact(codigoBarras);
                    cbxSalidaProducto.SelectedIndex = indice;
                }
                else
                {
                    MaterialMessageBox.Show($"Código de producto {codigoBarras} no encontrado", "⚠︎ Producto no encontrado");
                    cbxSalidaProducto.SelectedIndex = -1;
                    cbxSalidaProducto.Text = "";
                }*/

                string codigoBarras = cbxSalidaProducto.Text.Trim();

                int indice = productos.FindIndex(objProducto => objProducto.CCODALTERN == codigoBarras);


                //MessageBox.Show(indice.ToString());

                //string mensaje = string.Join(Environment.NewLine, productos);
                //MessageBox.Show(mensaje, "Listado de productos");
                if (indice >= 0)
                {
                    //indice = indice - 1;

                    cbxSalidaProducto.SelectedIndex = indice;
                }
                else
                {
                    MaterialMessageBox.Show($"Código de producto {codigoBarras} no encontrado", "⚠︎ Producto no encontrado");
                    cbxSalidaProducto.SelectedIndex = -1;
                    cbxSalidaProducto.Text = "";
                }

                e.Handled = true;
            }
        }

        private void txtSalidaCantidadProducto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;  // evitar que se escriba en el control
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.IndexOf('.') > -1)
            {
                e.Handled = true;  // evitar que se escriba en el control
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.IndexOf('.') == -1)
            {
                int pointIndex = (sender as TextBox).Text.IndexOf('.');
                if (pointIndex > -1)
                {
                    e.Handled = true; // evitar que se escriba en el control
                }
            }
        }

        public void addVar(String varName, Object varData)
        {
            var varValue = new StiVariable();
            varValue.ValueObject = varData;
            varValue.Name = varName;
            varValue.Alias = varName;
            variable.Add(varValue);
        }

        private void FormSalida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Documento.TipoDocumento == "create" && !Documento.AccionDocumento.Equals("completar"))
            {
                StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:");
                mensaje.AppendFormat("\n\n¿Al salir sin haber completado la salida se perderán los avances?                                                                                            \n\n\n💡 Nota: está acción no se puede deshacer.                                          ");

                if (MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ ¡CUIDADO! Leer atentamente entes de continuar", MessageBoxButtons.YesNo, true, FlexibleMaterialForm.ButtonsPosition.Center) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else if (Documento.IdDocumento != 0)
                {
                    LiquidarSalida(Documento.IdDocumento);

                }
            }
        }

        public void LiquidarSalida(int idRemision)
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                var encabezado = adConnect.bec_event_documento_encabezado.Find(idRemision);
                encabezado.estado = "eliminado";
                adConnect.SaveChanges();
            }
        }
    }
}
