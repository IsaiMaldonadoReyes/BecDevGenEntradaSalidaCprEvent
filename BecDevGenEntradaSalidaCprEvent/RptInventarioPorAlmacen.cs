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

        List<admAlmacenes> almacenes;

        public class Inventario
        {
            public string codigoProducto { get; set; }
            public string nombreProducto { get; set; }
            public double inventarioInicial { get; set; }
            public double inventarioTransito { get; set; }
            public double inventarioDevolucion { get; set; }
            public double inventarioAveriado { get; set; }
        }

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

        private void RptInventarioPorAlmacen_Load(object sender, EventArgs e)
        {
            cargarAlmacenes(cbxAlmacen);

            if (!LoginUsuario.TipoUsuarioLogeado.Equals("almacen"))
            {
                cbxAlmacen.Show();
                lbAlmacen.Show();
            }
            else
            {
                cbxAlmacen.Hide();
                lbAlmacen.Hide();
            }
        }

        private void btnEjecutarReporte_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 3;
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
            int almacen = 0;

            if (!LoginUsuario.TipoUsuarioLogeado.Equals("almacen"))
            {
                if (cbxAlmacen.SelectedIndex < 0)
                {
                    camposVacios += "\n \t❎ Almacén";
                }
            }

            if (camposVacios.Equals(""))
            {
                almacen = LoginUsuario.TipoUsuarioLogeado.Equals("almacen") ? LoginUsuario.IdAlmacenUsuarioLogeado : almacenes[cbxAlmacen.SelectedIndex].CIDALMACEN;
                
                if (xlApp != null)
                {
                    xlLibro = xlApp.Workbooks.Add(misValue);

                    tipoMensajeDevuelto = CrearRptInventarioPorAlmacen(xlApp, xlLibro, misValue, almacen, fechaInicial, fechaFinal);

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

        public string CrearRptInventarioPorAlmacen(Excel.Application xlApp, Excel.Workbook xlLibro, object misValue, int idAlmacen, DateTime fechaInicial, DateTime fechaFinal)
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
            xlHoja.Name = "Inventario por almacén";
            xlHoja.Activate();

            MostrarEncabezadoPrincipal(xlHoja);

            xlColumna = 7;
            xlFila = 5;
            alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
            alineacionVertical = Excel.XlVAlign.xlVAlignCenter;



            /** Formato de las columnas */
            xlHoja.get_Range("A:G").EntireColumn.NumberFormat = "@";
            xlHoja.get_Range("C:G").EntireColumn.NumberFormat = "0.00";

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

            detalle = obtenerDetalle(idAlmacen, fechaInicial, fechaFinal);

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


                    arrayDetalle[i, 0] = inventario.codigoProducto;
                    arrayDetalle[i, 1] = inventario.nombreProducto;
                    arrayDetalle[i, 2] = inventario.inventarioInicial;
                    arrayDetalle[i, 3] = inventario.inventarioTransito;
                    arrayDetalle[i, 4] = inventario.inventarioDevolucion;
                    arrayDetalle[i, 5] = inventario.inventarioAveriado;
                    arrayDetalle[i, 6] = "=C" + xlFila + "-" + "D" + xlFila + "+" + "E" + xlFila;

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

                xlHoja.get_Range("A" + xlFila, "B" + xlFila).Merge(true);
                xlHoja.Cells[xlFila, "A"] = "TOTAL: ";
                xlHoja.Cells[xlFila, "C"].FormulaLocal = string.Format("=SUMA(C6:" + "C" + matrizFila);
                xlHoja.Cells[xlFila, "D"].FormulaLocal = string.Format("=SUMA(D6:" + "D" + matrizFila);
                xlHoja.Cells[xlFila, "E"].FormulaLocal = string.Format("=SUMA(E6:" + "E" + matrizFila);
                xlHoja.Cells[xlFila, "F"].FormulaLocal = string.Format("=SUMA(F6:" + "F" + matrizFila);
                xlHoja.Cells[xlFila, "G"].FormulaLocal = string.Format("=SUMA(G6:" + "G" + matrizFila);

                /** Ancho de las columnas */
                xlHoja.get_Range("A:G").EntireColumn.AutoFit();

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

        public void MostrarEncabezadoPrincipal(Excel.Worksheet xlHoja)
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
            xlHoja.Cells[2, 1] = "Inventario por almacén";

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

        public List<Inventario> obtenerDetalle(int idAlmacen, DateTime fechaInicial, DateTime fechaFinal)
        {

            using (adConexionDB conexion = new adConexionDB())
            {
                string fechaInicio = fechaInicial.ToString("yyyy-MM-dd");
                string fechaFin = fechaFinal.ToString("yyyy-MM-dd");
                string query = "";
                int mes = fechaInicial.Month - 1;
                query += $@"
                DECLARE @dia INT;
                DECLARE @mes INT;
                DECLARE @anio INT;
                DECLARE @idEjercicio INT;
                DECLARE @idAlmacen INT;
                DECLARE @fechaInicioInventario VARCHAR(8);
                DECLARE @fechaFinInventario VARCHAR(8);
                DECLARE @fechaInicio DATETIME;
                DECLARE @fechaFin DATETIME;

                SET @idAlmacen = {idAlmacen};
                SET @fechaInicio = '{fechaInicio}';
                SET @fechaFin = '{fechaFin}';
                SET @dia = DAY('{fechaInicio}');
                SET @mes = MONTH('{fechaInicio}');
                SET @anio = YEAR('{fechaInicio}');
                SET @fechaInicioInventario = CONVERT(varchar(4), @anio) + RIGHT('0' + CONVERT(varchar(2), @mes), 2) + '01';
                SET @fechaFinInventario = CONVERT(varchar(4), @anio) + RIGHT('0' + CONVERT(varchar(2), @mes), 2) + RIGHT('0' + CONVERT(varchar(2), @dia - 1), 2);
                SET @idEjercicio = (
                    SELECT  CIDEJERCICIO
                    FROM    admEjercicios
                    WHERE   CEJERCICIO = CASE WHEN @mes = 1 THEN (@anio - 1) ELSE @anio END
                );

                SELECT  producto.CCODIGOPRODUCTO AS codigoProducto
	                    , producto.CNOMBREPRODUCTO AS nombreProducto
	                    , CASE 
		                    WHEN @dia = 1 THEN ISNULL(( SELECT  SUM(cEntradasPeriodo{mes}  - cSalidasPeriodo{mes}) AS cUnidadesAcumulado
                                                        FROM    admExistenciaCosto
						                                WHERE   cIdProducto = producto.CIDPRODUCTO
							                                    AND cIdEjercicio = @idEjercicio
							                                    AND cTipoExistencia = 1
							                                    AND cIdAlmacen = almacen.CIDALMACEN), 0.0) 
                            ELSE
                                CASE 
                                    WHEN @mes = 1 THEN ISNULL(( SELECT  SUM(cEntradasIniciales - cSalidasIniciales) AS cUnidadesAcumulado
                                                                FROM    admExistenciaCosto
								                                WHERE   cIdProducto = producto.CIDPRODUCTO
										                                AND cIdEjercicio = @idEjercicio
										                                AND cTipoExistencia = 1
										                                AND cIdAlmacen = almacen.CIDALMACEN), 0.0) 
										                                + 
						                                                ISNULL((SELECT  SUM(CASE
										                                                        WHEN cAfectaExistencia = 1 THEN cUnidades
										                                                        WHEN cAfectaExistencia = 2 THEN 0 - cUnidades
										                                                        ELSE 0
										                                                    END) AS cUnidadesMovto
								                                                FROM    admMovimientos
								                                                WHERE   (cIdProducto = producto.CIDPRODUCTO)
									                                                    AND (cAfectadoInventario = 1
									                                                    OR cAfectadoInventario = 2)
									                                                    AND (cFecha >= @fechaInicioInventario
									                                                    AND cFecha <= @fechaFinInventario)
									                                                    AND cIdAlmacen = almacen.CIDALMACEN), 0.0)
                                    ELSE 
                                            ISNULL((SELECT  SUM(cEntradasPeriodo{mes} - cSalidasPeriodo{mes}) AS cUnidadesAcumulado
                                                    FROM    admExistenciaCosto
								                    WHERE   cIdProducto = producto.CIDPRODUCTO
										                    AND cIdEjercicio = @idEjercicio
										                    AND cTipoExistencia = 1
										                    AND cIdAlmacen = almacen.CIDALMACEN), 0.0) 
										    + 
						                    ISNULL((SELECT  SUM(CASE
                                                                    WHEN cAfectaExistencia = 1 THEN cUnidades
										                            WHEN cAfectaExistencia = 2 THEN 0 - cUnidades
										                            ELSE 0
										                        END) AS cUnidadesMovto
								                    FROM    admMovimientos
								                    WHERE   (cIdProducto = producto.CIDPRODUCTO)
									                        AND (cAfectadoInventario = 1
									                        OR cAfectadoInventario = 2)
									                        AND (cFecha >= @fechaInicioInventario
									                        AND cFecha <= @fechaFinInventario)
									                        AND cIdAlmacen = almacen.CIDALMACEN), 0.0)
                                    END
                                END
                        AS inventarioInicial
	                    , ISNULL((  SELECT  SUM(becMovimiento.cantidad_producto)
		                            FROM    admConceptos AS concepto
		                                    INNER JOIN admAlmacenes AS almacen ON concepto.CIDALMASUM = almacen.CIDALMACEN
		                                    INNER JOIN bec_event_cliente_documento AS becClienteDocumento ON concepto.CCODIGOCONCEPTO = becClienteDocumento.codigo_documento
		                                    INNER JOIN bec_event_documento_encabezado AS becEncabezado ON becClienteDocumento.codigo_cliente = becEncabezado.codigo_cliente
		                                    INNER JOIN bec_event_documento_movimiento AS becMovimiento ON becEncabezado.id = becMovimiento.id_documento_encabezado AND becMovimiento.codigo_producto = producto.CCODIGOPRODUCTO
		                            WHERE   becEncabezado.estado = 'pendiente' 
                                            AND becEncabezado.tipo = 'remision'
                                            AND becMovimiento.procesado = 1
		                                    AND almacen.CIDALMACEN = @idAlmacen 
		                                    AND CONVERT(date, becEncabezado.fecha_creacion) BETWEEN @fechaInicio AND @fechaFin
		                                    AND concepto.CIDDOCUMENTODE = 3
                        ), 0) AS inventarioTransito
	                    , ISNULL((  SELECT  SUM(becMovimiento.cantidad_producto)
		                            FROM    admConceptos AS concepto
		                                    INNER JOIN admAlmacenes AS almacen ON concepto.CIDALMASUM = almacen.CIDALMACEN
		                                    INNER JOIN bec_event_cliente_documento AS becClienteDocumento ON concepto.CCODIGOCONCEPTO = becClienteDocumento.codigo_documento
		                                    INNER JOIN bec_event_documento_encabezado AS becEncabezado ON becClienteDocumento.codigo_cliente = becEncabezado.codigo_cliente
		                                    INNER JOIN bec_event_documento_movimiento AS becMovimiento ON becEncabezado.id = becMovimiento.id_documento_encabezado AND becMovimiento.codigo_producto = producto.CCODIGOPRODUCTO
		                            WHERE   becEncabezado.tipo = 'entrada' 
		                                    AND becMovimiento.procesado = 1
		                                    AND almacen.CIDALMACEN = @idAlmacen 
		                                    AND CONVERT(date, becEncabezado.fecha_creacion) BETWEEN @fechaInicio AND @fechaFin
		                                    AND concepto.CIDDOCUMENTODE = 3
                        ), 0) AS inventarioDevolucion
	                    , ISNULL((  SELECT  SUM(becMovimiento.cantidad_producto_defectuoso)
		                            FROM    admConceptos AS concepto
		                                    INNER JOIN admAlmacenes AS almacen ON concepto.CIDALMASUM = almacen.CIDALMACEN
		                                    INNER JOIN bec_event_cliente_documento AS becClienteDocumento ON concepto.CCODIGOCONCEPTO = becClienteDocumento.codigo_documento
		                                    INNER JOIN bec_event_documento_encabezado AS becEncabezado ON becClienteDocumento.codigo_cliente = becEncabezado.codigo_cliente
		                                    INNER JOIN bec_event_documento_movimiento AS becMovimiento ON becEncabezado.id = becMovimiento.id_documento_encabezado AND becMovimiento.codigo_producto = producto.CCODIGOPRODUCTO
		                            WHERE   becEncabezado.tipo = 'entrada' 
		                                    AND becMovimiento.procesado = 1
		                                    AND almacen.CIDALMACEN = @idAlmacen 
		                                    AND CONVERT(date, becEncabezado.fecha_creacion) BETWEEN @fechaInicio AND @fechaFin
		                                    AND concepto.CIDDOCUMENTODE = 3
		                ), 0) AS inventarioAveriado

                FROM    admAlmacenes almacen,
                        admProductos AS producto
                WHERE   almacen.CIDALMACEN = @idAlmacen
	                    AND producto.CTIPOPRODUCTO = 1
                ORDER BY 
                        producto.CCODIGOPRODUCTO
                ";

                List<Inventario> inventarioDetalle = conexion.Database.SqlQuery<Inventario>(query).ToList();


                return inventarioDetalle;

            }
        }

        public void cargarAlmacenes(ComboBox combo)
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
                    combo.Items.Add(almacen.CIDALMACEN + " | " + almacen.CNOMBREALMACEN);
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
