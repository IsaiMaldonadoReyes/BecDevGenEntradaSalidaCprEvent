using System;
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

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class RptInventarioPorAlmacen : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        public RptInventarioPorAlmacen()
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
            string tipoMensajeDevuelto = "";
            /*
                        if (cbxAlmacen.SelectedIndex < 0)
                        {
                            camposVacios += "\n \t❎ Almacén";
                        }*/

            if (camposVacios.Equals(""))
            {
                if (xlApp != null)
                {
                    xlLibro = xlApp.Workbooks.Add(misValue);

                    tipoMensajeDevuelto = CrearRptInventarioPorAlmacen(xlApp, xlLibro, misValue);

                    switch (tipoMensajeDevuelto)
                    {
                        case "correcto":
                            try
                            {

                                progressBar1.PerformStep();
                                xlApp.DisplayAlerts = false;
                                xlApp.Visible = false;
                                string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                xlLibro.SaveAs(mdoc + "\\InventarioPorAlmacen_" + DateTime.Now.ToString("yyyy-MM-dd_HHmm") + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


                                xlLibro.Close(true, misValue, misValue);
                                xlApp.Quit();
                                Marshal.ReleaseComObject(xlLibro);
                                Marshal.ReleaseComObject(xlApp);




                                mensaje.AppendFormat($"Archivo creado en la siguiente ruta: \n\n\n{mdoc}\\InventarioPorAlmacen_{DateTime.Now.ToString("yyyy-MM-dd_HHmm")}.xlsx");
                                MaterialMessageBox.Show(mensaje.ToString(), "✔️ Reporte creado correctamente");

                            }
                            catch (Exception ex)
                            {

                                progressBar1.Value = 0;
                                mensaje.AppendFormat("Ocurrió un error al momento de crear el reporte, por favor cierre el programa y vuelva a intentarlo nuevamente.");
                                MaterialMessageBox.Show(ex.ToString(), "❎ Ha ocurrido un error");

                            }

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

        public string CrearRptInventarioPorAlmacen(Excel.Application xlApp, Excel.Workbook xlLibro, object misValue)
        {

            string tipoMensaje = "";

            try
            {
                progressBar1.PerformStep();
                Excel.Range xlRangoS;
                Excel.Range xlRangoM;
                Excel.Worksheet xlHoja;
                Excel.XlHAlign alineacionHorizontal;
                Excel.XlVAlign alineacionVertical;
                StringBuilder mensaje = new StringBuilder("Verificar lo siguiente:\n\n");
                ColorConverter cc = new ColorConverter();

                int xlFila = 0;
                int xlColumna = 0;
                int matrizFila = 0;
                int matrizColumna = 0;
                int filasTotalesMatriz = 0;
                int columnasTotalesMatriz = 0;

                string color1 = "#FF0000";
                string color2 = "#00B050";

                xlHoja = (Excel.Worksheet)xlLibro.Worksheets.get_Item(1);
                xlHoja.Name = "Inventario por almacén";
                xlHoja.Activate();

                MostrarEncabezadoPrincipal(xlHoja);

                xlColumna = 4;
                xlFila = 5;
                alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
                alineacionVertical = Excel.XlVAlign.xlVAlignCenter;

                /** Ancho de las columnas */
                xlHoja.get_Range("A:A").EntireColumn.ColumnWidth = 15;
                xlHoja.get_Range("B:B").EntireColumn.ColumnWidth = 40;
                xlHoja.get_Range("C:C").EntireColumn.ColumnWidth = 40;
                xlHoja.get_Range("D:D").EntireColumn.ColumnWidth = 40;
                xlHoja.get_Range("E:E").EntireColumn.ColumnWidth = 40;
                xlHoja.get_Range("F:F").EntireColumn.ColumnWidth = 40;
                xlHoja.get_Range("G:G").EntireColumn.ColumnWidth = 40;

                /** Formato de las columnas */
                xlHoja.get_Range("A:A").EntireColumn.NumberFormat = "DD/MM/YYYY";
                xlHoja.get_Range("B:G").EntireColumn.NumberFormat = "@";

                setEstiloFila(xlHoja, "A" + xlFila, "G" + xlFila, "#1B223A", "", "#C8AA3C", 10, true, true, alineacionHorizontal, alineacionVertical);

                /** Nombre de las columnas */
                xlHoja.Cells[xlFila, "A"] = "CÓDIGO";
                xlHoja.Cells[xlFila, "B"] = "DESCRIPCIÓN";
                xlHoja.Cells[xlFila, "C"] = "INVENTARIO DISPONIBLE";
                xlHoja.Cells[xlFila, "D"] = "INVENTARIO EN TRÁNSITO";
                xlHoja.Cells[xlFila, "E"] = "INVENTARIO DEVOLUCIÓN";
                xlHoja.Cells[xlFila, "F"] = "INVENTARIO DAÑADO";
                xlHoja.Cells[xlFila, "G"] = "INVENTARIO FINAL";

                /** Fijar fila */
                xlHoja.Application.ActiveWindow.SplitRow = xlFila;
                xlHoja.Application.ActiveWindow.FreezePanes = true;

                tipoMensaje = "correcto";


            }
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
                errorDialog.ShowDialog();*/
                progressBar1.Value = 0;
            }
            return tipoMensaje;
        }

        public void MostrarEncabezadoPrincipal(Excel.Worksheet xlHoja)
        {
            Excel.XlHAlign alineacionHorizontal;
            Excel.XlVAlign alineacionVertical;
            string rutaActual = Environment.CurrentDirectory;

            alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
            alineacionVertical = Excel.XlVAlign.xlVAlignCenter;

            setEstiloFila(xlHoja, "A1", "G1", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A1", "G1").Merge(true);
            xlHoja.Cells[1, 1] = "FECHA CREACIÓN: " + DateTime.Now.ToString("dd-MM-yyyy");

            setEstiloFila(xlHoja, "A2", "G2", "", "", "#1E233A", 10, true, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A2", "G2").Merge(true);
            xlHoja.Cells[2, 1] = "Inventario por almacén";

            setEstiloFila(xlHoja, "A3", "G3", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A3", "G3").Merge(true);
            xlHoja.Cells[3, 1] = Convert.ToDateTime(dtpFechaInicial.Value) + " a " + Convert.ToDateTime(dtpFechaFinal.Value);
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
