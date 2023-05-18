using MaterialSkin.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BecDevGenEntradaSalidaCprEvent.SDK;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class FormPagoLiquidacion : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        string CurrentDirectory = ConfigurationManager.AppSettings["CurrentDirectory"].ToString();
        string Usuario = ConfigurationManager.AppSettings["Usuario"].ToString();
        string Password = ConfigurationManager.AppSettings["Password"].ToString();
        string Empresa = ConfigurationManager.AppSettings["Empresa"].ToString();
        StringBuilder InterpreteSDK = new StringBuilder(255);

        public FormPagoLiquidacion()
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
            var liquidacion = ObtenerInformacionFactura(Documento.IdDocumento);

            Ruta.Text = $"Ruta: {liquidacion.codigo_cliente}";
            Operador.Text = $"Operador: {liquidacion.codigo_operador}";
            lblSalidaFecha.Text = $"Fecha: {liquidacion.fecha_creacion:yyyy-MM-dd}";
            CargarDGV(Documento.IdDocumento);
        }

        private bec_event_documento_encabezado ObtenerInformacionFactura(int idDocumento)
        {
            using (adConexionDB adConnect = new adConexionDB())
            {
                var salida = (from remision in adConnect.bec_event_documento_encabezado
                              where remision.tipo == "factura" && remision.id == idDocumento
                              select remision).FirstOrDefault<bec_event_documento_encabezado>();

                return salida;
            }
        }


        public void CargarDGV(int idDocumento)
        {
            dgvSalidaListaProducto.Rows.Clear();
            dgvSalidaListaProducto.Refresh();
            using (adConexionDB adConnect = new adConexionDB())
            {
                var listaDGV = (from abonos in adConnect.bec_event_documento_abono
                                join documentos in adConnect.admDocumentos on abonos.id_contpaq_documento equals documentos.CIDDOCUMENTO
                                where abonos.id_documento_origen == idDocumento
                                select new
                                {
                                    abonos,
                                    documentos
                                }).ToList();

                foreach (var objLista in listaDGV)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dgvSalidaListaProducto);
                    newRow.Cells[0].Value = objLista.abonos.id;
                    newRow.Cells[1].Value = Convert.ToDateTime(objLista.abonos.fecha_creacion).ToString("dd-MM-yyyy hh:mm");
                    newRow.Cells[2].Value = objLista.documentos.CSERIEDOCUMENTO + " " + objLista.documentos.CFOLIO;
                    newRow.Cells[3].Value = Convert.ToDouble(objLista.abonos.monto).ToString("C2");
                    dgvSalidaListaProducto.Rows.Add(newRow);
                }

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

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeConfiguracion = new StringBuilder("Verifique lo siguiente:\n\n");
            int controlErrorSDK = 0;
            int idDocumentoPago = 0;
            double folioPago = 0;
            string seriePago = "";
            string mensajeError = "";

            if (string.IsNullOrWhiteSpace(txtMontoAbono.Text))
            {
                mensajeConfiguracion.AppendLine("\n \t❎ Determinar la cantidad del producto");
            }
            else if (!double.TryParse(txtMontoAbono.Text, out double cantidad) || cantidad <= 0)
            {
                mensajeConfiguracion.AppendLine("\n \t❎ La cantidad debe de ser mayor a 0");
            }

            if (mensajeConfiguracion.Length > 28) // Si hay errores
            {
                mensajeConfiguracion.Insert(0, "Es necesario ingresar los campos solicitados para poder agregar el abono, por favor:\n\n");
                MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
                return;
            }

            double montoPago = Convert.ToDouble(txtMontoAbono.Text);

            using (adConexionDB dbConnect = new adConexionDB())
            {
                var objFactura = (from salidas in dbConnect.bec_event_documento_encabezado
                                  join factura in dbConnect.admDocumentos on salidas.id_contpaq_documento equals factura.CIDDOCUMENTO
                                  where
                                  salidas.estado == "terminada"
                                  && salidas.tipo == "factura"
                                  && salidas.id == Documento.IdDocumento
                                  orderby salidas.fecha_creacion descending
                                  select new
                                  {
                                      salidas.id,
                                      salidas.codigo_cliente,
                                      salidas.serie_contpaq_documento,
                                      salidas.folio_contpaq_documento,
                                      factura.CTOTAL,
                                      factura.CPENDIENTE
                                  }).FirstOrDefault();

                if (montoPago > objFactura.CPENDIENTE)
                {
                    MaterialMessageBox.Show("El monto no puede ser mayor a la cantidad pendiente del documento", "⚠︎ Información incorrecta");
                    return;
                }

                controlErrorSDK = SDK.SetCurrentDirectory(CurrentDirectory);
                if (controlErrorSDK != 0)
                {
                    SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                    //MaterialMessageBox.Show(InterpreteSDK.ToString(), "⚠︎ Error en la creación del SetCurrentDirectory");
                }
                controlErrorSDK = SDK.fInicioSesionSDK(Usuario, Password);
                SDK.fInicioSesionSDKCONTPAQi("SUPERVISOR", "");
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
                    var documentoPago = (from documento in dbConnect.bec_event_cliente_documento
                                         where documento.codigo_cliente == objFactura.codigo_cliente
                                         select documento).FirstOrDefault<bec_event_cliente_documento>();

                    controlErrorSDK = SDK.fSiguienteFolio(documentoPago.codigo_pago, InterpreteSDK, ref folioPago);

                    if (controlErrorSDK != 0)
                    {
                        SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                        mensajeError += $"\n \t Error al crear el siguiente folio de remisión - {InterpreteSDK}";
                    }
                    else
                    {
                        seriePago = InterpreteSDK.ToString();

                        tDocumento tPago = new tDocumento
                        {
                            aCodConcepto = documentoPago.codigo_pago,
                            aCodigoCteProv = objFactura.codigo_cliente,
                            aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                            aSerie = seriePago,
                            aFolio = folioPago,
                            aImporte = montoPago
                        };

                        controlErrorSDK = SDK.fAltaDocumento(ref idDocumentoPago, ref tPago);

                        if (controlErrorSDK != 0)
                        {
                            SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                        }
                        else
                        {
                            controlErrorSDK = SDK.fSaldarDocumento_Param(documentoPago.codigo_factura, objFactura.serie_contpaq_documento, Convert.ToDouble(objFactura.folio_contpaq_documento), documentoPago.codigo_pago, seriePago, folioPago, montoPago, 1, DateTime.Now.ToString("MM/dd/yyyy"));
                            if (controlErrorSDK != 0)
                            {
                                SDK.fError(controlErrorSDK, InterpreteSDK, 255);
                                SDK.fBuscarIdDocumento(idDocumentoPago);
                                SDK.fBorraDocumento();
                            }
                            else
                            {
                                var documentoAbono = new bec_event_documento_abono()
                                {
                                    fecha_creacion = DateTime.Now,
                                    id_documento_origen = Documento.IdDocumento,
                                    monto = montoPago,
                                    id_contpaq_documento = idDocumentoPago,
                                    procesado = true
                                };
                                dbConnect.bec_event_documento_abono.Add(documentoAbono);
                                dbConnect.SaveChanges();

                                MaterialMessageBox.Show("Se ha registrado el abono al documento correctamente ", "✔️ Abono creado correctamente.                                             ");

                                CargarDGV(Documento.IdDocumento);
                            }
                        }
                    }

                    SDK.fCierraEmpresa();
                    SDK.fTerminaSDK();
                }
            }

        }

        private void txtMontoAbono_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
