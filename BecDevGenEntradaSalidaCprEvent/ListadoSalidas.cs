using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class ListadoSalidas : MaterialForm
    {
        string CurrentDirectory = ConfigurationManager.AppSettings["CurrentDirectory"].ToString();
        string Usuario = ConfigurationManager.AppSettings["Usuario"].ToString();
        string Password = ConfigurationManager.AppSettings["Password"].ToString();
        string Empresa = ConfigurationManager.AppSettings["Empresa"].ToString();
        StringBuilder InterpreteSDK = new StringBuilder(255);

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
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

        public ListadoSalidas()
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
        }

        public void CargarListado()
        {
            dgvSalidaListadoSalidas.Rows.Clear();
            dgvSalidaListadoSalidas.Refresh();

            using (adConexionDB dbConnect = new adConexionDB())
            {
                var listaDVGSalidas = (from salidas in dbConnect.bec_event_documento_encabezado
                                       where salidas.id_creador == LoginUsuario.IdUsuarioLogeado
                                       && salidas.estado == "pendiente"
                                       && salidas.tipo == "remision"
                                       && salidas.id_contpaq_documento != null
                                       orderby salidas.fecha_creacion descending
                                       select salidas).ToList();

                foreach (var objLista in listaDVGSalidas)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvSalidaListadoSalidas);
                    newRow.Cells[0].Value = objLista.id;
                    newRow.Cells[1].Value = Convert.ToDateTime(objLista.fecha_creacion).ToString("dd-MM-yyyy HH:mm");
                    newRow.Cells[2].Value = objLista.codigo_cliente;
                    newRow.Cells[3].Value = objLista.serie_contpaq_documento + objLista.folio_contpaq_documento;
                    dgvSalidaListadoSalidas.Rows.Add(newRow);
                }
            }
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex)
            {
                case 0:
                    this.Text = "Event | Listado de salidas pendientes";
                    break;
                case 1:
                    this.Text = "Event | Devolución de productos";
                    break;
            }
        }

        private void btnNuevaSalida_Click(object sender, EventArgs e)
        {
            Documento.IdDocumento = 0;
            Documento.TipoDocumento = "create";
            FormSalida formSalida = new FormSalida();
            formSalida.ShowDialog();

            CargarListado();
        }

        private void btnSalidaActualizar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void dgvSalidaListadoSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isAlmacen = LoginUsuario.TipoUsuarioLogeado == "almacen";

            if (e.RowIndex >= 0 && isAlmacen)
            {
                int id = Convert.ToInt32(dgvSalidaListadoSalidas.Rows[e.RowIndex].Cells["id_salida"].Value);
                Documento.IdDocumento = id;
                Form form;

                if (e.ColumnIndex == dgvSalidaListadoSalidas.Columns["salida_accion"].Index)
                {
                    Documento.TipoDocumento = "edit";
                    form = new FormSalida();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == dgvSalidaListadoSalidas.Columns["entrada_accion"].Index)
                {
                    Documento.TipoDocumento = "devolucion";
                    form = new FormDevolucion();
                    form.ShowDialog();
                }
                else if (e.ColumnIndex == dgvSalidaListadoSalidas.Columns["liquidar_accion"].Index)
                {
                    StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:");
                    mensaje.AppendFormat("\n\n¿Desea liquidar el documento de salida?                                                                                            \n\n\n💡 Nota: está acción no se puede deshacer.                                          ");

                    if (MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ ¡CUIDADO! Leer atentamente entes de continuar", MessageBoxButtons.YesNo, true, FlexibleMaterialForm.ButtonsPosition.Center) != DialogResult.Yes)
                    {
                        return;
                    }
                    LiquidarSalida(id);
                }
                else
                {
                    return;
                }

                CargarListado();
            }
        }

        public void LiquidarSalida(int idRemisionOrigen)
        {
            double TiempoUnix = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            int controlErrorSDK = 0;
            int idFactura = 0;


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
                    estado = "terminada",
                    id_documento_origen = idRemisionOrigen,
                    id_operador = documentoRemision.id_operador,
                    codigo_operador = documentoRemision.codigo_operador
                };
                adConnect.bec_event_documento_encabezado.Add(documentoFactura);
                adConnect.SaveChanges();

                idFactura = documentoFactura.id;

                var movimientosRemision = (from remisionMov in adConnect.bec_event_documento_movimiento
                                           where remisionMov.id_documento_encabezado == idRemisionOrigen
                                           select remisionMov).ToList();


                controlErrorSDK = SDK.SetCurrentDirectory(CurrentDirectory);
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                }
                controlErrorSDK = SDK.fInicioSesionSDK(Usuario, Password);
                SDK.fInicioSesionSDKCONTPAQi("SUPERVISOR", "");
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
                    var conceptosPorCliente = (from documento in adConnect.bec_event_cliente_documento
                                               where documento.codigo_cliente == documentoRemision.codigo_cliente
                                               select documento).FirstOrDefault<bec_event_cliente_documento>();

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

                            SDK.fBuscarIdDocumento(idDocumentoFactura);
                            foreach (var objRemisionMov in movimientosRemision)
                            {
                                SDK.tMovimiento tMov = new SDK.tMovimiento
                                {
                                    aCodAlmacen = almacenXDocumento.CCODIGOALMACEN,
                                    aCodProdSer = objRemisionMov.codigo_producto,
                                    aUnidades = Convert.ToDouble(objRemisionMov.cantidad_producto),
                                };

                                controlErrorSDK = SDK.fAltaMovimiento(idDocumentoFactura, ref idMovimientoFactura, ref tMov);
                                if (controlErrorSDK != 0)
                                {
                                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                    mensajeError += $"\n \t Error en la creación del movimiento del documento: {serieFactura}{folioFactura} de factura del producto: {objRemisionMov.codigo_producto} - {InterpreteSDK} \n";
                                }
                                else
                                {
                                    var movimientoDevolucionFactura = new bec_event_documento_movimiento()
                                    {
                                        id_documento_encabezado = idFactura,
                                        codigo_producto = objRemisionMov.codigo_producto,
                                        cantidad_producto = Convert.ToDouble(objRemisionMov.cantidad_producto),
                                        tipo = "factura",
                                        unix = TiempoUnix,
                                        procesado = true,
                                        id_movimiento_contpaq = idMovimientoFactura
                                    };
                                    adConnect.bec_event_documento_movimiento.Add(movimientoDevolucionFactura);
                                    adConnect.SaveChanges();


                                }
                            }
                        }
                    }
                }

                if (!mensajeError.Equals(""))
                {
                    string qryDeleteFactura = $"DELETE FROM bec_event_documento_encabezado WHERE id = {idFactura}";
                    adConnect.Database.ExecuteSqlCommand(qryDeleteFactura);

                    mensaje.AppendFormat($"Verifique el siguiente error: {mensajeError} \n\n");
                    MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ Proceso erroneo");
                }
                else
                {
                    documentoRemision.estado = "terminada";
                    adConnect.Entry(documentoRemision).State = System.Data.Entity.EntityState.Modified;
                    adConnect.SaveChanges();

                    foreach (var objMovimientoRemision in movimientosRemision)
                    {
                        var movimientoRemision = (from movRem in adConnect.bec_event_documento_movimiento
                                                  where movRem.codigo_producto == objMovimientoRemision.codigo_producto
                                                  && movRem.id_documento_encabezado == idRemisionOrigen
                                                  select movRem).FirstOrDefault<bec_event_documento_movimiento>();

                        string actualizarUnidadesPendientesMovimiento = $" UPDATE admMovimientos SET CUNIDADESPENDIENTES = 0 WHERE CIDMOVIMIENTO = {movimientoRemision.id_movimiento_contpaq}";
                        adConnect.Database.ExecuteSqlCommand(actualizarUnidadesPendientesMovimiento);
                    }

                    string actualizarUnidadesPendientesDocumento = $@" UPDATE admDocumentos 
                                                                                    SET CUNIDADESPENDIENTES = ( SELECT SUM(CUNIDADESPENDIENTES) FROM admMovimientos WHERE CIDDOCUMENTO = {documentoRemision.id_contpaq_documento} )
                                                                                    WHERE CIDDOCUMENTO = {documentoRemision.id_contpaq_documento}";

                    mensaje.AppendFormat($"Liquidación completada correctamente. \n\n");
                    MaterialMessageBox.Show(mensaje.ToString(), "✔️ Liquidación creada correctamente.                                             ");
                    CargarListado();
                }

                SDK.fCierraEmpresa();
                SDK.fTerminaSDK();
            }
        }

        private void dgvSalidaListadoSalidas_SizeChanged(object sender, EventArgs e)
        {
            dgvSalidaListadoSalidas.Columns[1].Width = (int)(dgvSalidaListadoSalidas.Width * 0.1);
            dgvSalidaListadoSalidas.Columns[2].Width = (int)(dgvSalidaListadoSalidas.Width * 0.2);
            dgvSalidaListadoSalidas.Columns[3].Width = (int)(dgvSalidaListadoSalidas.Width * 0.1);
            dgvSalidaListadoSalidas.Columns[4].Width = 100;
            dgvSalidaListadoSalidas.Columns[5].Width = 100;
            dgvSalidaListadoSalidas.Columns[6].Width = 100;

        }

        private void ListadoSalidas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnGuardarDocumento_Click(object sender, EventArgs e)
        {
           
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
    }
}
