using MaterialSkin;
using MaterialSkin.Controls;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class ListadoLiquidaciones : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        StiVariablesCollection variable = new StiVariablesCollection();

        public List<admClientes> clientes;
        public List<admAgentes> agentes;
        public List<admAlmacenes> almacenes;
        public List<admConceptos> remisiones;
        public List<admConceptos> entradas;
        public List<admConceptos> salidas;
        public List<admConceptos> facturas;
        public List<admConceptos> pagos;

        string CurrentDirectory = ConfigurationManager.AppSettings["CurrentDirectory"].ToString();
        string Usuario = ConfigurationManager.AppSettings["Usuario"].ToString();
        string Password = ConfigurationManager.AppSettings["Password"].ToString();
        string Empresa = ConfigurationManager.AppSettings["Empresa"].ToString();
        StringBuilder InterpreteSDK = new StringBuilder(255);

        public class MyMaterialLabel : MaterialSkin.Controls.MaterialLabel
        {
            private Font _font;

            public override Font Font
            {
                get { return _font; }
                set
                {
                    _font = new Font(value.FontFamily, 16f, value.Style);
                    base.Font = _font;
                }
            }
        }

        public ListadoLiquidaciones()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo700,
                MaterialSkin.Primary.Indigo100,
                MaterialSkin.Accent.Indigo700,
                MaterialSkin.TextShade.WHITE);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsuarioLogeado.Text = LoginUsuario.CodigoUsuarioLogeado + " | " + LoginUsuario.TipoUsuarioLogeado;
            CargarListado();

            CargarClientes(cbxRuta);
            CargarAlmacenes(cbxAlmacenDefectuoso);

            CargarConceptosRemision(cbxDocumentoRemision, 3);
            CargarConceptosFactura(cbxDocumentoFactura, 4);
            CargarConceptosEntrada(cbxDocumentoEntrada, 32);
            CargarConceptosSalida(cbxDocumentoSalida, 33);
            CargarConceptosPago(cbxDocumentoPago, 12);
            CargarAgentes(cbxAgente);

            CargarDGV();

            int errorSdk = 0;

            errorSdk = SDK.SetCurrentDirectory(CurrentDirectory);
            if (errorSdk != 0)
            {
                SDK.fError(errorSdk, InterpreteSDK, 255);
            }
            errorSdk = SDK.fInicioSesionSDK(Usuario, Password);

            SDK.fInicioSesionSDKCONTPAQi(Usuario, Password);
            if (errorSdk != 0)
            {
                SDK.fError(errorSdk, InterpreteSDK, 255);
            }
            errorSdk = SDK.fSetNombrePAQ("CONTPAQ I Comercial");
            if (errorSdk != 0)
            {
                SDK.fError(errorSdk, InterpreteSDK, 255);
            }
        }

        public void CargarAgentes(ComboBox combo)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                agentes = (from cliente in ObjCompac.admAgentes
                           where !cliente.CTEXTOEXTRA1.Equals("")
                           orderby cliente.CCODIGOAGENTE ascending
                           select cliente).ToList();
                foreach (var objLista in agentes)
                {
                    combo.Items.Add(objLista.CCODIGOAGENTE);
                }
            }
        }

        public void CargarClientes(ComboBox combo)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                clientes = (from cliente in ObjCompac.admClientes
                            where cliente.CTIPOCLIENTE == 1 || cliente.CTIPOCLIENTE == 2
                            orderby cliente.CCODIGOCLIENTE ascending
                            select cliente).ToList();
                foreach (var objLista in clientes)
                {
                    combo.Items.Add(objLista.CCODIGOCLIENTE + " | " + objLista.CRAZONSOCIAL);
                }
            }
        }

        public void CargarAlmacenes(ComboBox combo)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                almacenes = (from almacen in ObjCompac.admAlmacenes
                             orderby almacen.CCODIGOALMACEN ascending
                             select almacen).ToList();

                foreach (var objLista in almacenes)
                {
                    combo.Items.Add(objLista.CCODIGOALMACEN + " | " + objLista.CNOMBREALMACEN);
                }
            }
        }

        public void CargarConceptosRemision(ComboBox combo, int idDocumentoDe)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                remisiones = (from concepto in ObjCompac.admConceptos
                              where concepto.CIDDOCUMENTODE == idDocumentoDe
                              orderby concepto.CNOMBRECONCEPTO ascending
                              select concepto).ToList();

                foreach (var objLista in remisiones)
                {
                    combo.Items.Add(objLista.CCODIGOCONCEPTO + " | " + objLista.CNOMBRECONCEPTO);
                }
            }
        }
        public void CargarConceptosFactura(ComboBox combo, int idDocumentoDe)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                facturas = (from concepto in ObjCompac.admConceptos
                            where concepto.CIDDOCUMENTODE == idDocumentoDe
                            orderby concepto.CNOMBRECONCEPTO ascending
                            select concepto).ToList();

                foreach (var objLista in facturas)
                {
                    combo.Items.Add(objLista.CCODIGOCONCEPTO + " | " + objLista.CNOMBRECONCEPTO);
                }
            }
        }

        public void CargarConceptosEntrada(ComboBox combo, int idDocumentoDe)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                entradas = (from concepto in ObjCompac.admConceptos
                            where concepto.CIDDOCUMENTODE == idDocumentoDe
                            orderby concepto.CNOMBRECONCEPTO ascending
                            select concepto).ToList();

                foreach (var objLista in entradas)
                {
                    combo.Items.Add(objLista.CCODIGOCONCEPTO + " | " + objLista.CNOMBRECONCEPTO);
                }
            }
        }

        public void CargarConceptosSalida(ComboBox combo, int idDocumentoDe)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                salidas = (from concepto in ObjCompac.admConceptos
                           where concepto.CIDDOCUMENTODE == idDocumentoDe
                           orderby concepto.CNOMBRECONCEPTO ascending
                           select concepto).ToList();

                foreach (var objLista in salidas)
                {
                    combo.Items.Add(objLista.CCODIGOCONCEPTO + " | " + objLista.CNOMBRECONCEPTO);
                }
            }
        }

        public void CargarConceptosPago(ComboBox combo, int idDocumentoDe)
        {
            using (adConexionDB ObjCompac = new adConexionDB())
            {
                pagos = (from concepto in ObjCompac.admConceptos
                         where concepto.CIDDOCUMENTODE == idDocumentoDe
                         orderby concepto.CNOMBRECONCEPTO ascending
                         select concepto).ToList();

                foreach (var objLista in pagos)
                {
                    combo.Items.Add(objLista.CCODIGOCONCEPTO + " | " + objLista.CNOMBRECONCEPTO);
                }
            }
        }

        public void CargarListado()
        {
            dgvListado.Rows.Clear();
            dgvListado.Refresh();

            using (adConexionDB dbConnect = new adConexionDB())
            {
                var listaDVG = (from salidas in dbConnect.bec_event_documento_encabezado
                                join factura in dbConnect.admDocumentos on salidas.id_contpaq_documento equals factura.CIDDOCUMENTO
                                where
                                //salidas.id_creador == LoginUsuario.IdUsuarioLogeado
                                salidas.estado == "terminada"
                                && salidas.tipo == "factura"
                                //&& salidas.id_contpaq_documento != null
                                //&& factura.CPENDIENTE > 0
                                orderby salidas.fecha_creacion descending
                                select new
                                {
                                    salidas.id,
                                    salidas.fecha_creacion,
                                    salidas.codigo_cliente,
                                    salidas.serie_contpaq_documento,
                                    salidas.folio_contpaq_documento,
                                    factura.CTOTAL,
                                    factura.CPENDIENTE
                                }).ToList();

                foreach (var objLista in listaDVG)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvListado);
                    newRow.Cells[0].Value = objLista.id;
                    newRow.Cells[1].Value = Convert.ToDateTime(objLista.fecha_creacion).ToString("dd-MM-yyyy HH:mm");
                    newRow.Cells[2].Value = objLista.codigo_cliente;
                    newRow.Cells[3].Value = objLista.serie_contpaq_documento + objLista.folio_contpaq_documento;
                    newRow.Cells[4].Value = objLista.CTOTAL.ToString("C2");
                    newRow.Cells[5].Value = objLista.CPENDIENTE.ToString("C2");
                    dgvListado.Rows.Add(newRow);
                }
            }
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex)
            {
                case 0:
                    this.Text = "Event Express | Listado de liquidaciones";
                    break;
                case 1:
                    this.Text = "Event Express | Configuración";
                    break;
            }
        }

        private void btnSalidaActualizar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void dgvSalidaListadoSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["abono_accion"].Index && e.RowIndex >= 0 && LoginUsuario.TipoUsuarioLogeado == "administracion")
            {
                int id = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["id_documento"].Value);
                Documento.IdDocumento = id;
                Documento.TipoDocumento = "factura";
                FormPagoLiquidacion formPago = new FormPagoLiquidacion();
                formPago.ShowDialog();

                CargarListado();
            }
        }

        private void dgvSalidaListadoSalidas_SizeChanged(object sender, EventArgs e)
        {
            dgvListado.Columns[1].Width = (int)(dgvListado.Width * 0.1);
            dgvListado.Columns[2].Width = (int)(dgvListado.Width * 0.2);
            dgvListado.Columns[3].Width = (int)(dgvListado.Width * 0.1);
            dgvListado.Columns[4].Width = (int)(dgvListado.Width * 0.1);
            dgvListado.Columns[5].Width = (int)(dgvListado.Width * 0.1);
            dgvListado.Columns[6].Width = 100;

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaProyecto = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            StiReport report = new StiReport();
            report.Load(rutaProyecto + "\\ReporteSalidas.mrt");
            report.Design();
        }

        public void addVar(String varName, Object varData)
        {
            var varValue = new StiVariable();
            varValue.ValueObject = varData;
            varValue.Name = varName;
            varValue.Alias = varName;
            variable.Add(varValue);
        }

        public void CargarDGV()
        {
            dgvDocumentos.Rows.Clear();
            dgvDocumentos.Refresh();

            using (adConexionDB ObjCompac = new adConexionDB())
            {
                var configuracion = (from configuracionCuenta in ObjCompac.bec_event_cliente_documento
                                     select configuracionCuenta).ToList();

                foreach (var objLista in configuracion)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvDocumentos);
                    newRow.Cells[0].Value = objLista.id;
                    newRow.Cells[1].Value = objLista.codigo_cliente;
                    newRow.Cells[2].Value = objLista.codigo_documento;
                    newRow.Cells[3].Value = objLista.codigo_entrada;
                    newRow.Cells[4].Value = objLista.codigo_salida;
                    newRow.Cells[5].Value = objLista.codigo_factura;
                    newRow.Cells[6].Value = objLista.codigo_almacen_defectuoso;
                    dgvDocumentos.Rows.Add(newRow);
                }
            }
        }

        private void btnGuardarDocumento_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeConfiguracion = new StringBuilder("Verifique lo siguiente:\n\n");

            if (cbxDocumentoRemision.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el concepto de remisión");
            }
            if (cbxDocumentoSalida.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el concepto de salida");
            }
            if (cbxDocumentoEntrada.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el concepto de entrada");
            }
            if (cbxDocumentoFactura.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el concepto de factura");
            }
            if (cbxDocumentoPago.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el concepto de pago");
            }
            if (cbxRuta.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar la ruta");
            }
            if (cbxAlmacenDefectuoso.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el almacén ");
            }
            if (cbxAgente.SelectedIndex < 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Seleccionar el agente ");
            }

            if (mensajeConfiguracion.Length > 28) // Si hay errores
            {
                mensajeConfiguracion.Insert(0, "Es necesario ingresar los campos solicitados para poder agregar la configuación, por favor:\n\n");
                MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
                return;
            }

            using (adConexionDB ObjCompac = new adConexionDB())
            {
                string remision = remisiones[cbxDocumentoRemision.SelectedIndex].CCODIGOCONCEPTO;
                string salida = salidas[cbxDocumentoSalida.SelectedIndex].CCODIGOCONCEPTO;
                string entrada = entradas[cbxDocumentoEntrada.SelectedIndex].CCODIGOCONCEPTO;
                string factura = facturas[cbxDocumentoFactura.SelectedIndex].CCODIGOCONCEPTO;
                string pago = pagos[cbxDocumentoPago.SelectedIndex].CCODIGOCONCEPTO;
                string ruta = clientes[cbxRuta.SelectedIndex].CCODIGOCLIENTE;
                string almacen = almacenes[cbxAlmacenDefectuoso.SelectedIndex].CCODIGOALMACEN;
                string agente = agentes[cbxAgente.SelectedIndex].CCODIGOAGENTE;

                var existeAfiliacion = (from cliente in ObjCompac.bec_event_cliente_documento
                                        where cliente.codigo_cliente == ruta
                                        select cliente).FirstOrDefault<bec_event_cliente_documento>();

                if (existeAfiliacion != null)
                {
                    mensajeConfiguracion.AppendLine("\n \t❎ Existe una ruta anteriormente registrada");
                    MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
                    return;
                }
                else
                {
                    var afiliacion = new bec_event_cliente_documento()
                    {
                        codigo_documento = remision,
                        codigo_salida = salida,
                        codigo_entrada = entrada,
                        codigo_factura = factura,
                        codigo_pago = pago,
                        codigo_almacen_defectuoso = almacen,
                        codigo_cliente = ruta,
                        codigo_agente = agente
                    };
                    ObjCompac.bec_event_cliente_documento.Add(afiliacion);
                    ObjCompac.SaveChanges();

                    MaterialMessageBox.Show("Se ha registrado la configuración correctamente", "✔️ Configuración creada correctamente.                                             ");
                }
                CargarDGV();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowToDelete = dgvDocumentos.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            if (rowToDelete >= 0)
            {
                if (!Convert.ToString(dgvDocumentos.Rows[rowToDelete].Cells[0].Value).Equals(""))
                {
                    int idMovimiento = Convert.ToInt32(dgvDocumentos.Rows[rowToDelete].Cells[0].Value);
                    using (adConexionDB adConnect = new adConexionDB())
                    {
                        bec_event_cliente_documento relacionCuenta = new bec_event_cliente_documento() { id = idMovimiento };
                        adConnect.bec_event_cliente_documento.Attach(relacionCuenta);
                        adConnect.bec_event_cliente_documento.Remove(relacionCuenta);
                        adConnect.SaveChanges();

                        CargarDGV();
                    }
                }
            }
        }

        private void dgvDocumentos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvDocumentos.HitTest(e.X, e.Y);

                if (hti.RowIndex != -1)
                {
                    dgvDocumentos.ClearSelection();
                    dgvDocumentos.Rows[hti.RowIndex].Selected = true;
                    dgvDocumentos.CurrentCell = dgvDocumentos.Rows[hti.RowIndex].Cells[1];
                }
            }
        }

        private void btnRptInventarioPorAlmacen_Click(object sender, EventArgs e)
        {
            RptInventarioPorAlmacen rptInventarioPorAlmacen = new RptInventarioPorAlmacen();
            rptInventarioPorAlmacen.ShowDialog();
        }

        private void btnRptInventarioPorRuta_Click(object sender, EventArgs e)
        {
            RptInventarioPorRuta rptInventarioPorRuta = new RptInventarioPorRuta();
            rptInventarioPorRuta.ShowDialog();
        }

        private void btnRptHistoricoMovimientosGeneral_Click(object sender, EventArgs e)
        {
            RptHistoricoMovimientosGeneral rptHistoricoMovimientosGeneral = new RptHistoricoMovimientosGeneral();
            rptHistoricoMovimientosGeneral.ShowDialog();
        }

        private void btnRptHistoricoMovimientosPorRuta_Click(object sender, EventArgs e)
        {
            RptHistoricoMovimientosPorRuta rptHistoricoMovimientosPorRuta = new RptHistoricoMovimientosPorRuta();
            rptHistoricoMovimientosPorRuta.ShowDialog();
        }

        private void btnRptResumenMovimientosGlobalDelDia_Click(object sender, EventArgs e)
        {
            RptResumenMovimientosGlobalDelDia rptResumenMovimientosGlobalDelDia = new RptResumenMovimientosGlobalDelDia();
            rptResumenMovimientosGlobalDelDia.ShowDialog();
        }

        private void btnRptResumenMovimientosDetalladoPorRuta_Click(object sender, EventArgs e)
        {
            RptResumenMovimientosDetalladoPorRuta rptResumenMovimientosDetalladoPorRuta = new RptResumenMovimientosDetalladoPorRuta();
            rptResumenMovimientosDetalladoPorRuta.ShowDialog();
        }

        private void ListadoLiquidaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SDK.fTerminaSDK();
            }
            catch (Exception ex)
            {
            }
        }

        private void modificarReporteVentasTMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaProyecto = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            StiReport report = new StiReport();
            report.Load(rutaProyecto + "\\ReporteInventarioEnRuta.mrt");
            report.Design();
        }
    }
}
