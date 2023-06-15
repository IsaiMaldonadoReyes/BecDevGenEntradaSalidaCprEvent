﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

using PresentationControls;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class RptResumenMovimientosGlobalDelDia : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        List<admAlmacenes> almacenes;

        public class Inventario
        {
            public string cedis { get; set; }
            public string codigoProducto { get; set; }
            public string nombreProducto { get; set; }
            public double cantidad { get; set; }
            public double averiado { get; set; }
        }

        public RptResumenMovimientosGlobalDelDia()
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

        private void RptResumenMovimientosGlobalDelDia_Load(object sender, EventArgs e)
        {
            cargarAlmacenes();
        }

        private void btnEjecutarReporte_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 4;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            progressBar1.PerformStep();

            DateTime fechaFinal = Convert.ToDateTime(dtpFechaFinal.Value);
            DateTime fechaInicial = Convert.ToDateTime(dtpFechaInicial.Value);
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlLibro;
            object misValue = Missing.Value;
            StringBuilder mensaje = new StringBuilder("Verifica lo siguiente:\n\n");
            string camposVacios = "";
            string nombreReporte = "ResumenMovimientosGlobalDelDia";
            string tipoMensajeDevuelto = "";
            List<admAlmacenes> almacenesSeleccionados = new List<admAlmacenes>();
            string tipoMovimiento = cbxTipoMovimiento.SelectedItem.ToString();

            for (var i = 0; i < cbxAlmacenes.CheckBoxItems.Count; i++)
            {
                CheckBoxComboBoxItem item = cbxAlmacenes.CheckBoxItems[i];

                if (item.Checked)
                {
                    admAlmacenes almacen = new admAlmacenes();

                    almacen.CIDALMACEN = this.almacenes[i].CIDALMACEN;
                    almacen.CNOMBREALMACEN = this.almacenes[i].CNOMBREALMACEN;

                    almacenesSeleccionados.Add(almacen);
                }
            }


            if (almacenesSeleccionados.Count < 0)
            {
                camposVacios += "\n \t❎ Almacenes";
            }
            if (cbxTipoMovimiento.SelectedIndex < 0)
            {
                camposVacios += "\n \t❎ Tipo de movimiento";
            }

            if (camposVacios.Equals(""))
            {
                if (xlApp != null)
                {
                    xlLibro = xlApp.Workbooks.Add(misValue);

                    tipoMensajeDevuelto = crearRpt(xlApp, xlLibro, misValue, almacenesSeleccionados, fechaInicial, fechaFinal, tipoMovimiento);

                    switch (tipoMensajeDevuelto)
                    {
                        case "correcto":
                            try
                            {
                                progressBar1.PerformStep();
                                xlApp.DisplayAlerts = false;
                                xlApp.Visible = false;
                                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                xlLibro.SaveAs(mdoc + "\\" + nombreReporte + DateTime.Now.ToString("yyyy-MM-dd_HHmm") + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                                xlLibro.Close(true, misValue, misValue);
                                xlApp.Quit();
                                Marshal.ReleaseComObject(xlLibro);
                                Marshal.ReleaseComObject(xlApp);

                                mensaje.AppendFormat($"Archivo creado en la siguiente ruta: \n\n\n{mdoc}\\{nombreReporte}_{DateTime.Now.ToString("yyyy-MM-dd_HHmm")}.xlsx");
                                MaterialMessageBox.Show(mensaje.ToString(), "✔️ Reporte creado correctamente");

                            }
                            catch (Exception ex)
                            {

                                progressBar1.Value = 0;
                                mensaje.AppendFormat("Ocurrió un error al momento de crear el reporte, por favor cierre el programa y vuelva a intentarlo nuevamente.");
                                MaterialMessageBox.Show(ex.ToString(), "❎ Ha ocurrido un error");

                            }

                            break;

                        case "error":

                            progressBar1.Value = 0;
                            mensaje.AppendFormat("No se encontraron registros con coincidencia de los filtros seleccionados.                            \nPor favor verificque que existan registros con estos atributos y vuelva a intentarlo.");
                            MaterialMessageBox.Show(mensaje.ToString(), "❎ Ha ocurrido un error");

                            break;
                    }
                }
                else
                {
                    mensaje.AppendFormat("Para ejecutar el reporte es necesario utilizar Microsoft Excel. \nPor favor, asegúrese de que la aplicación se encuentré instalada o se esté ejecutando correctamente.\n\n");
                    MaterialMessageBox.Show(mensaje.ToString(), "❎ Microsoft Excel no responde");
                    progressBar1.Value = 0;
                }
            }
            else
            {
                mensaje.AppendFormat("Es necesario completar los siguientes campos para poder ejecutar el reporte, por favor:  \n\n" + camposVacios + "\n\n\n 💡 Nota: los campos marcados con un (*) son requeridos para ejecutar el proceso.");
                MaterialMessageBox.Show(mensaje.ToString(), "⚠︎ Información incompleta");
                progressBar1.Value = 0;
            }

        }

        public string crearRpt(Excel.Application xlApp, Excel.Workbook xlLibro, object misValue, List<admAlmacenes> almacenesSeleccionados, DateTime fechaInicial, DateTime fechaFinal, string tipoMovimiento)
        {

            string tipoMensaje = "";

            //try
            //{
            progressBar1.PerformStep();
            Excel.Range xlRangoS;
            Excel.Range xlRangoM;
            Excel.Worksheet xlHoja;
            Excel.XlHAlign alineacionHorizontal;
            Excel.XlVAlign alineacionVertical;
            StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:\n\n");
            ColorConverter cc = new ColorConverter();
            List<Inventario> detalle = new List<Inventario>();


            int xlFila = 0;
            int xlColumna = 0;
            int matrizFila = 0;
            int matrizColumna = 0;
            int filasTotalesMatriz = 0;
            int columnasTotalesMatriz = 0;

            string color1 = "#FF0000";
            string color2 = "#00B050";

            xlHoja = (Excel.Worksheet)xlLibro.Worksheets.get_Item(1);
            xlHoja.Name = tipoMovimiento.Equals("Salidas") ? "Salidas" : "Devoluciones";
            xlHoja.Activate();

            mostrarEncabezadoPrincipal(xlHoja);

            xlColumna = 5;
            xlFila = 5;
            alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
            alineacionVertical = Excel.XlVAlign.xlVAlignCenter;



            /** Formato de las columnas */
            xlHoja.get_Range("A:C").EntireColumn.NumberFormat = "@";
            xlHoja.get_Range("D:E").EntireColumn.NumberFormat = "0.00";

            setEstiloFila(xlHoja, "A" + xlFila, "E" + xlFila, "#1B223A", "", "#C8AA3C", 10, true, true, alineacionHorizontal, alineacionVertical);

            /** Nombre de las columnas */
            xlHoja.Cells[xlFila, "A"] = "CEDIS";
            xlHoja.Cells[xlFila, "B"] = "CÓDIGO";
            xlHoja.Cells[xlFila, "C"] = "NOMBRE";
            xlHoja.Cells[xlFila, "D"] = "CANTIDAD";
            xlHoja.Cells[xlFila, "E"] = "DAÑADO";

            /** Fijar fila */
            xlHoja.Application.ActiveWindow.SplitRow = xlFila;
            xlHoja.Application.ActiveWindow.FreezePanes = true;

            detalle = obtenerDetalle(almacenesSeleccionados, fechaInicial, fechaFinal, tipoMovimiento);

            if (detalle.Count > 0)
            {
                xlFila = 6;
                matrizFila = 0;
                matrizColumna = 0;
                columnasTotalesMatriz = 9;
                filasTotalesMatriz = detalle.Count * 2; // Poner operación aquí porque si se pone directa no respeta la cantidad de la operación

                object[,] arrayDetalle = new dynamic[filasTotalesMatriz, columnasTotalesMatriz];

                for (var i = 0; i < detalle.Count; i++)
                {
                    Inventario inventario = detalle[i];

                    arrayDetalle[i, 0] = inventario.cedis;
                    arrayDetalle[i, 1] = inventario.codigoProducto;
                    arrayDetalle[i, 2] = inventario.nombreProducto;
                    arrayDetalle[i, 3] = inventario.cantidad;
                    arrayDetalle[i, 4] = inventario.averiado;

                    xlFila++;
                }



                /*
                 *  Dibujar registros a tráves de la matriz en el excel.
                */
                // Obtener un rango de Excel inicial para empezar a dibujar la matriz
                Excel.Range range = (Excel.Range)xlHoja.Cells[6, 1];
                range = range.get_Resize(filasTotalesMatriz, columnasTotalesMatriz);

                // Asignar el 2-d array a el rango de Excel
                range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, arrayDetalle);
                // Propiedad para que acepte los nombres de las formulas en Español. (Excepción) No sirve cuando se agregan los valores de forma directa al Excel, es decir sin matriz.
                //range.FormulaLocal = range.Value;

                matrizFila = xlFila;
                xlFila = xlFila + 2;

                xlHoja.get_Range("A" + xlFila, "C" + xlFila).Merge(true);
                xlHoja.Cells[xlFila, "A"] = "TOTAL: ";
                xlHoja.Cells[xlFila, "D"].FormulaLocal = string.Format("=SUMA(D6:" + "D" + matrizFila);
                xlHoja.Cells[xlFila, "E"].FormulaLocal = string.Format("=SUMA(E6:" + "E" + matrizFila);

                /** Ancho de las columnas */
                xlHoja.get_Range("A:H").EntireColumn.AutoFit();

                tipoMensaje = "correcto";
            }
            else
            {
                tipoMensaje = "error";
            }
            //}
            /*
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                //int line = (new StackTrace(ex, true)).GetFrame(-1).GetFileLineNumber();

                /*Error errorDialog = new Error();
                errorDialog.linea = line;
                errorDialog.ShowDialog();
                progressBar1.Value = 0;
            }*/
            return tipoMensaje;
        }

        public void mostrarEncabezadoPrincipal(Excel.Worksheet xlHoja)
        {
            Excel.XlHAlign alineacionHorizontal;
            Excel.XlVAlign alineacionVertical;
            string rutaActual = Environment.CurrentDirectory;

            alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
            alineacionVertical = Excel.XlVAlign.xlVAlignCenter;

            setEstiloFila(xlHoja, "A1", "G1", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A1", "G1").Merge(true);
            xlHoja.Cells[1, 1] = "FECHA CREACIÓN: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

            setEstiloFila(xlHoja, "A2", "G2", "", "", "#1E233A", 10, true, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A2", "G2").Merge(true);
            xlHoja.Cells[2, 1] = "Resumen de movimientos global del día";

            setEstiloFila(xlHoja, "A3", "G3", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A3", "G3").Merge(true);
            xlHoja.Cells[3, 1] = Convert.ToDateTime(dtpFechaInicial.Value).ToString("dd/MM/yyyy") + " a " + Convert.ToDateTime(dtpFechaFinal.Value).ToString("dd/MM/yyyy");

        }

        public void setEstiloFila(Excel.Worksheet xlHoja, string rangoInicio, string rangoFin, string bgColor, string borderColor, string fontColor, int fontSize, bool isBold, bool isWrapText, Excel.XlHAlign textAlignH, Excel.XlVAlign textAlignV)
        {

            Excel.Range range = xlHoja.get_Range(rangoInicio, rangoFin);

            ColorConverter cc = new ColorConverter();

            /** background-color */
            if (bgColor != "")
            {
                range.Interior.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString(bgColor));
            }

            /** border-color */
            if (borderColor != "")
            {
                range.Borders.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString(borderColor));
                range.Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            }

            /** font-color */
            if (fontColor != "")
            {
                range.Font.Color = ColorTranslator.ToOle((Color)cc.ConvertFromString(fontColor));
            }

            range.Font.Size = fontSize;

            range.Font.Bold = isBold;

            range.WrapText = isWrapText;

            range.HorizontalAlignment = textAlignH;

            range.VerticalAlignment = textAlignV;
        }

        public List<Inventario> obtenerDetalle(List<admAlmacenes> almacenesSeleccionados, DateTime fechaInicial, DateTime fechaFinal, string tipoMovimiento)
        {

            using (adConexionDB conexion = new adConexionDB())
            {
                string fechaInicio = fechaInicial.ToString("yyyy-MM-dd");
                string fechaFin = fechaFinal.ToString("yyyy-MM-dd");
                string query = "";
                string queryWhere = "";
                int[] idAlmacenesSeleccionados = new int[almacenesSeleccionados.Count];
                

                for (var i = 0; i < almacenesSeleccionados.Count; i++)
                {
                    admAlmacenes almacen = almacenesSeleccionados[i];

                    idAlmacenesSeleccionados[i] = almacen.CIDALMACEN;
                }

                string[] numberStrings = Array.ConvertAll(idAlmacenesSeleccionados, x => x.ToString());

                string numbersAsString = string.Join(", ", numberStrings);

                if (tipoMovimiento.Equals("Devoluciones"))
                {
                    queryWhere += $@"
                    AND becMovimiento.procesado = 1
	                AND becEncabezado.tipo = 'entrada'
                    ";
                } else if (tipoMovimiento.Equals("Salidas"))
                {
                    queryWhere += $@"
                    AND becEncabezado.tipo = 'remision'
	                AND becEncabezado.estado = 'pendiente'
                    ";
                }

                query += $@"
                DECLARE @fechaInicio DATETIME;
                DECLARE @fechaFin DATETIME;

                SET @fechaInicio = '{fechaInicio}';
                SET @fechaFin = '{fechaFin}';

                SELECT  almacen.CCODIGOALMACEN			AS cedis
                        , producto.CCODIGOPRODUCTO		AS codigoProducto
	                    , producto.CNOMBREPRODUCTO		AS nombreProducto
	                    , ISNULL(SUM (becMovimiento.cantidad_producto), 0) AS cantidad
	                    , ISNULL(SUM (becMovimiento.cantidad_producto_defectuoso), 0) AS averiado
                FROM    admConceptos AS concepto
                        INNER JOIN admAlmacenes AS almacen ON concepto.CIDALMASUM = almacen.CIDALMACEN
                        INNER JOIN bec_event_cliente_documento AS becClienteDocumento ON concepto.CCODIGOCONCEPTO = becClienteDocumento.codigo_documento
                        INNER JOIN bec_event_documento_encabezado AS becEncabezado ON becClienteDocumento.codigo_cliente = becEncabezado.codigo_cliente
                        INNER JOIN bec_event_documento_movimiento AS becMovimiento ON becEncabezado.id = becMovimiento.id_documento_encabezado
                        INNER JOIN admProductos as producto ON becMovimiento.codigo_producto = producto.CCODIGOPRODUCTO
                WHERE   concepto.CIDDOCUMENTODE = 3
	                    AND producto.CTIPOPRODUCTO = 1
	                    {queryWhere}
	                    AND almacen.CIDALMACEN IN ({numbersAsString})
	                    AND CONVERT(date, becEncabezado.fecha_creacion) BETWEEN @fechaInicio AND @fechaFin
                GROUP BY 
	                    almacen.CCODIGOALMACEN
	                    , producto.CCODIGOPRODUCTO
	                    , producto.CNOMBREPRODUCTO
	
                ORDER BY 
                        producto.CCODIGOPRODUCTO
                ";

                List<Inventario> inventarioDetalle = conexion.Database.SqlQuery<Inventario>(query).ToList();

                return inventarioDetalle;
            }
        }

        public void cargarAlmacenes()
        {
            using (adConexionDB conexion = new adConexionDB())
            {
                var query = (from concepto in conexion.admConceptos
                             join almacen in conexion.admAlmacenes on concepto.CIDALMASUM equals almacen.CIDALMACEN
                             join cliente in conexion.bec_event_cliente_documento on concepto.CCODIGOCONCEPTO equals cliente.codigo_documento
                             where concepto.CIDDOCUMENTODE == 3
                             group almacen by new { almacen.CIDALMACEN, almacen.CNOMBREALMACEN } into agrupador
                             select new
                             {
                                 CIDALMACEN = agrupador.Key.CIDALMACEN,
                                 CNOMBREALMACEN = agrupador.Key.CNOMBREALMACEN,
                             }).ToList();


                almacenes = query.Select(almacen => new admAlmacenes
                {
                    CIDALMACEN = almacen.CIDALMACEN,
                    CNOMBREALMACEN = almacen.CNOMBREALMACEN
                }).ToList();


                foreach (admAlmacenes almacen in almacenes)
                {
                    cbxAlmacenes.Items.Add(almacen.CIDALMACEN + " | " + almacen.CNOMBREALMACEN);
                }
            }
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFinal.Value < dtpFechaInicial.Value)
            {
                StringBuilder mensaje = new StringBuilder("Verifica lo siguiente:\n\n");
                mensaje.AppendFormat("Seleccione una fecha MAYOR a la fecha inicial, por favor. ");
                MaterialMessageBox.Show(mensaje.ToString(), "❎ Rango de fechas incorrecto");
            }
        }
    }
}
