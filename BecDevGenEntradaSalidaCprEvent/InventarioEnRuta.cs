using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class InventarioEnRuta : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        List<admAlmacenes> almacenes;
        List<bec_event_cliente_documento> rutasDocumento;
        RptXLInventarioPorAlmacen xlInventarioPorAlmacen = new RptXLInventarioPorAlmacen();

        public InventarioEnRuta()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo700,
                MaterialSkin.Primary.Indigo100,
                MaterialSkin.Accent.Indigo700,
                MaterialSkin.TextShade.WHITE);
        }

        private void InventarioEnRuta_Load(object sender, EventArgs e)
        {
            cbxCedisFinal.Enabled = false;

            cargarAlmacenes(cbxCedisInicial);
        }

        public void cargarAlmacenes(ComboBox combo)
        {
            using (adConexionDB conexion = new adConexionDB())
            {
                var query = (from concepto in conexion.admConceptos
                             join almacen in conexion.admAlmacenes on concepto.CIDALMASUM equals almacen.CIDALMACEN
                             join cliente in conexion.bec_event_cliente_documento on concepto.CCODIGOCONCEPTO equals cliente.codigo_documento
                             where concepto.CIDDOCUMENTODE == 3
                             group almacen by new { almacen.CIDALMACEN, almacen.CNOMBREALMACEN, almacen.CCODIGOALMACEN } into agrupador
                             select new
                             {
                                 agrupador.Key.CIDALMACEN,
                                 agrupador.Key.CNOMBREALMACEN,
                                 agrupador.Key.CCODIGOALMACEN,
                             }).ToList();


                almacenes = query.Select(almacen => new admAlmacenes
                {
                    CIDALMACEN = almacen.CIDALMACEN,
                    CNOMBREALMACEN = almacen.CNOMBREALMACEN,
                    CCODIGOALMACEN = almacen.CCODIGOALMACEN,
                }).ToList();

                foreach (admAlmacenes almacen in almacenes)
                {
                    combo.Items.Add(almacen.CIDALMACEN + " | " + almacen.CNOMBREALMACEN);
                }
            }
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            cbxCedisInicial.Items.Clear();
            cbxCedisFinal.Items.Clear();

            cbxRutaInicial.Items.Clear();
            cbxRutaFinal.Items.Clear();

            cbxCedisInicial.Text = string.Empty;
            cbxCedisFinal.Text = string.Empty;

            cbxRutaInicial.Text = string.Empty;
            cbxRutaFinal.Text = string.Empty;


            if (chkCedis.Checked)
            {
                cargarAlmacenes(cbxCedisFinal);
                cbxCedisFinal.Enabled = true;

                cbxRutaInicial.Enabled = false;
                cbxRutaFinal.Enabled = false;
            }
            else
            {
                cbxCedisFinal.Enabled = false;

                cbxRutaInicial.Enabled = true;
                cbxRutaFinal.Enabled = true;
            }

            cargarAlmacenes(cbxCedisInicial);
        }

        public string ValidarFiltros()
        {
            string filtrosFaltantes = "";

            if (cbxCedisInicial.SelectedIndex < 0)
            {
                filtrosFaltantes += "\n \t⦿ Rango inicial de Cedis";
            }

            if (chkCedis.Checked)
            {
                if (cbxCedisFinal.SelectedIndex < 0)
                {
                    filtrosFaltantes += "\n \t⦿ Rango final de Cedis";
                }
            }
            else
            {
                if (cbxRutaInicial.SelectedIndex < 0)
                {
                    filtrosFaltantes += "\n \t⦿ Rango incial de Ruta";
                }

                if (cbxRutaFinal.SelectedIndex < 0)
                {
                    filtrosFaltantes += "\n \t⦿ Rango final de Ruta";
                }
            }

            return filtrosFaltantes;
        }

        public void xlCrearHojas(Excel.Workbook xlLibro)
        {
            StringBuilder mensaje = new StringBuilder("Verifica lo siguiente:\n\n");
            string cadenaDeConexion = "";
            DataTable sqlDetalle = new DataTable();
            Excel.Worksheet xlHoja = new Excel.Worksheet();

            DateTime fechaFinal = Convert.ToDateTime(dtpFinal.Value);
            DateTime fechaInicial = Convert.ToDateTime(dtpInicial.Value);

            using (adConexionDB conexion = new adConexionDB())
            {
                //cadenaDeConexion = conexion.Database.Connection.ConnectionString = conexion.Database.Connection.ConnectionString.Replace(conexion.Database.Connection.Database, empresaAlias);

                cadenaDeConexion = conexion.Database.Connection.ConnectionString;

                var cedisInicio = almacenes[cbxCedisInicial.SelectedIndex].CCODIGOALMACEN;
                var cedisFinal = chkCedis.Checked == true ? almacenes[cbxCedisFinal.SelectedIndex].CCODIGOALMACEN : almacenes[cbxCedisInicial.SelectedIndex].CCODIGOALMACEN;

                int indexInicio = almacenes.FindIndex(a => a.CCODIGOALMACEN == cedisInicio);
                int indexFinal = almacenes.FindIndex(a => a.CCODIGOALMACEN == cedisFinal);


                if (indexInicio > indexFinal)
                {
                    var temp = indexInicio;
                    indexInicio = indexFinal;
                    indexFinal = temp;
                }

                // Filtrar los almacenes entre los índices obtenidos (inclusive)
                var almacenesEntreCedis = almacenes
                    .Skip(indexInicio)
                    .Take(indexFinal - indexInicio + 1)
                    .ToArray();

                try
                {

                    foreach (admAlmacenes cedis in almacenesEntreCedis)
                    {

                        if (chkCedis.Checked)
                        {
                            sqlDetalle = xlInventarioPorAlmacen.xlObtenerResumen(cadenaDeConexion, fechaInicial, fechaFinal, cedis.CCODIGOALMACEN);
                        }
                        else
                        {
                            var rutaInicio = rutasDocumento[cbxRutaInicial.SelectedIndex].codigo_cliente;
                            var rutaFinal = rutasDocumento[cbxRutaFinal.SelectedIndex].codigo_cliente;

                            int indexInicioRuta = rutasDocumento.FindIndex(a => a.codigo_cliente == rutaInicio);
                            int indexFinalRuta = rutasDocumento.FindIndex(a => a.codigo_cliente == rutaFinal);


                            if (indexInicioRuta > indexFinalRuta)
                            {
                                var temp = indexInicioRuta;
                                indexInicioRuta = indexFinalRuta;
                                indexFinalRuta = temp;
                            }
                            var rutasEntreCedis = rutasDocumento
                                .Skip(indexInicioRuta)
                                .Take(indexFinalRuta - indexInicioRuta + 1)
                                .ToArray();
                            sqlDetalle = xlInventarioPorAlmacen.xlObtenerResumen(cadenaDeConexion, fechaInicial, fechaFinal, cedis.CCODIGOALMACEN, rutasEntreCedis);
                        }

                        if (sqlDetalle != null || sqlDetalle.Rows.Count != 0)
                        {
                            xlHoja = (Excel.Worksheet)xlLibro.Worksheets.get_Item(xlLibro.Sheets.Count);
                            xlHoja.Name = cedis.CCODIGOALMACEN.ToString();
                            xlInventarioPorAlmacen.xlLlenarHoja(xlHoja, "Inventario por cedis", LoginUsuario.CodigoUsuarioLogeado, fechaInicial, fechaFinal, sqlDetalle, cedis.CNOMBREALMACEN);
                            xlHoja = (Excel.Worksheet)xlLibro.Worksheets.Add(After: xlLibro.Sheets[xlLibro.Sheets.Count]);
                            pgInventarioEnRuta.PerformStep();

                        }
                    }
                    // Eliminar última hoja creada
                    xlHoja = (Excel.Worksheet)xlLibro.Worksheets.get_Item(xlLibro.Sheets.Count);
                    xlHoja.Delete(); // Nota: la hoja no se puede eliminar es porque se encuentra activa
                }
                catch (Exception ex)
                {
                    mensaje.AppendFormat("La empresa no se encuentra configurada para el sistema CONTPAQi.\n" + ex.ToString());
                    MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ Empresa no corresponde al sistema CONTPAQi");
                }
            }
        }

        public void xlEjecutarReporte(string nombreLibro)
        {
            StringBuilder mensaje = new StringBuilder("Verifica lo siguiente:\n\n");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlLibro;
            object misValue = Missing.Value;

            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaExcel = mdoc + "\\" + nombreLibro + "_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".xlsx";

            if (xlApp != null)
            {
                //rutaExcel = DuplicarFormatoPrincipal(xlApp, misValue, nombreLibro);

                if (!rutaExcel.Equals("Ruta no encontrada"))
                {
                    //try
                    //{
                    xlLibro = xlApp.Workbooks.Add(misValue);
                    xlApp.DisplayAlerts = false;
                    xlApp.Visible = false;

                    // Desactiva alertas de confirmación antes de la eliminación de hojas ebido que al eliminar un hoja de forma manual se muestra una ventana emergente que espera una aprobación para poder eliminar

                    // si es por cedis mandar a llamar a ejecutar reporte xlCrearHojas si no llamar a xlCrearHoja


                    xlCrearHojas(xlLibro);


                    xlLibro.SaveAs(rutaExcel, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlLibro.Close(true, misValue, misValue);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlLibro);
                    Marshal.ReleaseComObject(xlApp);

                    pgInventarioEnRuta.PerformStep();
                    mensaje.AppendFormat($"Archivo creado en la siguiente ruta: \n{rutaExcel}");
                    MaterialMessageBox.Show(mensaje.ToString(), "✔️ Reporte creado correctamente");

                    pgInventarioEnRuta.Value = 0;
                    // Abrir el archivo de Excel después de guardarlo
                    System.Diagnostics.Process.Start(rutaExcel);
                    //}
                    //catch (COMException ex)
                    //{
                    //    pgInventarioEnRuta.Value = 0;
                    //    mensaje.AppendFormat("Microsoft Excel está ocupado en otro proceso. Por favor, asegúrese de no tener seleccionada una celda de edición en otro proceso");
                    //    MaterialMessageBox.Show(mensaje.ToString(), "❎ Error al interactuar con Microsoft Excel");
                    //}
                    //catch (Exception ex)
                    //{
                    //    pgInventarioEnRuta.Value = 0;
                    //    mensaje.AppendFormat("Ocurrió un error al momento de crear el reporte, por favor cierre el programa y vuelva a intentarlo nuevamente.");
                    //    MaterialMessageBox.Show(ex.ToString(), "❎ Ha ocurrido un error");
                    //}
                }
                else
                {
                    pgInventarioEnRuta.Value = 0;
                    mensaje.AppendFormat("La ruta del Formato Principal no se encontró. Por favor, asegúrese de importar la plantilla de Excel.");
                    MaterialMessageBox.Show(mensaje.ToString(), "❎ Ha ocurrido un error");
                }
            }
            else
            {
                pgInventarioEnRuta.Value = 0;
                mensaje.AppendFormat("Para ejecutar el reporte, es necesario utilizar Microsoft Excel. \nPor favor, asegúrese de que la aplicación esté instalada y se esté ejecutando correctamente.\n\n");
                MaterialMessageBox.Show(mensaje.ToString(), "❎ Microsoft Excel no responde");

            }
        }

        private void btnEjecutarInventarioEnRuta_Click(object sender, EventArgs e)
        {
            StringBuilder mensaje = new StringBuilder("Verifica lo siguiente:\n\n");
            string filtrosFaltantes = ValidarFiltros();

            if (filtrosFaltantes.Equals(""))
            {
                pgInventarioEnRuta.Visible = true;
                pgInventarioEnRuta.Minimum = 0;
                pgInventarioEnRuta.Maximum = 3;
                pgInventarioEnRuta.Value = 0;
                pgInventarioEnRuta.Step = 1;
                pgInventarioEnRuta.PerformStep();


                xlEjecutarReporte("InventarioEnRuta");
            }
            else
            {
                mensaje.AppendFormat("Es necesario seleccionar los siguientes filtros para poder ejecutar el reporte, por favor:  \n" + filtrosFaltantes + "\n\n💡 Nota: los campos marcados con un (*) son requeridos para ejecutar el proceso.");
                MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ Información incompleta");
            }
        }

        private void cbxCedisInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxRutaInicial.Items.Clear();
            cbxRutaFinal.Items.Clear();

            cbxRutaInicial.Text = string.Empty;
            cbxRutaFinal.Text = string.Empty;

            if (!chkCedis.Checked)
            {
                using (adConexionDB conexion = new adConexionDB())
                {
                    var codigoRuta = almacenes[cbxCedisInicial.SelectedIndex].CCODIGOALMACEN;


                    var query = (from concepto in conexion.admConceptos
                                 join almacen in conexion.admAlmacenes on concepto.CIDALMASUM equals almacen.CIDALMACEN
                                 join cliente in conexion.bec_event_cliente_documento on concepto.CCODIGOCONCEPTO equals cliente.codigo_documento
                                 where almacen.CCODIGOALMACEN == codigoRuta
                                 group almacen by new { cliente.codigo_cliente } into agrupador
                                 select new
                                 {
                                     agrupador.Key.codigo_cliente
                                 }).ToList();

                    rutasDocumento = query.Select(almacen => new bec_event_cliente_documento
                    {
                        codigo_cliente = almacen.codigo_cliente,
                    }).ToList();

                    foreach (bec_event_cliente_documento ruta in rutasDocumento)
                    {
                        cbxRutaInicial.Items.Add(ruta.codigo_cliente);
                        cbxRutaFinal.Items.Add(ruta.codigo_cliente);
                    }
                }
            }
        }
    }
}
