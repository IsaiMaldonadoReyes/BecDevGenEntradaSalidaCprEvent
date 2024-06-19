using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace BecDevGenEntradaSalidaCprEvent
{
    class RptXLInventarioPorAlmacen
    {

        HelperExcelInterop excel = new HelperExcelInterop();


        public void xlLlenarHoja(Excel.Worksheet xlHoja, string tituloReporte, string usuario, DateTime fechaInicial, DateTime fechaFinal, DataTable xlDetalle, List<admAlmacenes> cedis)
        {
            int filasTotalesMatriz = 0;
            int columnasTotalesMatriz = 0;
            int xlFilaInicio = 4;
            int xlColumnaInicio = 1;

            string cedisConcatenados = String.Join(", ", cedis.Select(temporal => $"'{temporal.CCODIGOALMACEN}'"));


            xlHoja.Activate();
            string filtrosSeleccionados = cedisConcatenados + " | " + fechaInicial.ToString("dd/MM/yyyy") + " a " + fechaFinal.ToString("dd/MM/yyyy") + " | Generado por: " + usuario;
            excel.dibujarEncabezadoPrincipal(xlHoja, tituloReporte, filtrosSeleccionados, "F");

            // Fijar fila y columna
            xlHoja.Application.ActiveWindow.SplitRow = xlFilaInicio;
            xlHoja.Application.ActiveWindow.SplitColumn = xlColumnaInicio;
            xlHoja.Application.ActiveWindow.FreezePanes = true;

            // Cambiar formato a texto si no en la celda de la formula aparecerá lo siguiente: -2146826259
            xlHoja.get_Range("A:B").EntireColumn.NumberFormat = "@";
            xlHoja.get_Range("B:B").EntireColumn.NumberFormat = "_($* ###,###,##0_);_($* (###,###,##0);_($* \"-\"??_);_(@_)";


            filasTotalesMatriz = xlDetalle.Rows.Count + 1;
            columnasTotalesMatriz = xlDetalle.Columns.Count;
            object[,] arrayDetalle = new dynamic[filasTotalesMatriz, columnasTotalesMatriz];

            for (int fila = 0; fila < xlDetalle.Rows.Count; fila++)
            {
                for (int columna = 0; columna < xlDetalle.Columns.Count; columna++)
                {
                    DataColumn col = xlDetalle.Columns[columna];

                    if (col.ColumnName != "almacenCedis" || col.ColumnName != "almacenCedis2")
                    {
                        arrayDetalle[fila + 1, columna] = xlDetalle.Rows[fila][columna].ToString().ToUpper();

                        if (xlDetalle.Rows[fila][0].ToString().StartsWith("%"))
                        {
                            xlHoja.Cells[fila + 5, "B"].NumberFormat = "0.00 %";
                        }
                    }
                }
            }

            Excel.Range range = (Excel.Range)xlHoja.Cells[xlFilaInicio, xlColumnaInicio];
            range = range.get_Resize(filasTotalesMatriz, columnasTotalesMatriz);
            range.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, arrayDetalle);

            // Agregar después de cambiar los formatos para que cargué automáticamente la Formula sin tener que dar Enter 
            range.FormulaLocal = range.Value;

            // Ancho de las columnas
            xlHoja.get_Range("A:" + excel.GetExcelColumnName(columnasTotalesMatriz)).EntireColumn.AutoFit();
        }



        public DataTable xlObtenerResumen(string cadenaDeConexion, DateTime fechaInicial, DateTime fechaFinal, List<admAlmacenes> cedis)
        {
            return xlObtenerResumen(cadenaDeConexion, fechaInicial, fechaFinal, cedis, null, null);
        }

        public DataTable xlObtenerResumen(string cadenaDeConexion, DateTime fechaInicial, DateTime fechaFinal, admAlmacenes almacen, List<bec_event_cliente_documento> rutas)
        {
            return xlObtenerResumen(cadenaDeConexion, fechaInicial, fechaFinal, null, almacen, rutas);
        }


        public DataTable xlObtenerResumen(string cadenaDeConexion, DateTime fechaInicial, DateTime fechaFinal, List<admAlmacenes> cedis, admAlmacenes almacen, List<bec_event_cliente_documento> rutas)
        {
            DataTable xlDetalle = new DataTable();
            string cedisConcatenados = "";
            string rutasConcatenadas = "";

            if (!IsListNullOrEmpty(cedis))
            {
                cedisConcatenados = String.Join(", ", cedis.Select(temporal => $"'{temporal.CCODIGOALMACEN}'"));
            }

            if (!IsListNullOrEmpty(rutas))
            {
                cedisConcatenados = almacen.CCODIGOALMACEN;
                rutasConcatenadas = String.Join(", ", rutas.Select(temporal => $"'{temporal.codigo_cliente}'"));
            }

            string fechaInicio = fechaInicial.ToString("yyyy-MM-dd");
            string fechaFin = fechaFinal.ToString("yyyy-MM-dd");

            string query = "";

            query = $@"
				DECLARE @fechaInicio DATETIME;
				DECLARE @fechaFin DATETIME;

				SET @fechaInicio = '{fechaInicio}';
				SET @fechaFin = '{fechaFin}';

				;WITH salidas AS (
				SELECT 
					producto.CCODIGOPRODUCTO AS sku
					, producto.CNOMBREPRODUCTO AS producto
					, SUM(salidaDevolucion.cantidad_movimiento) AS salidas
					, almacenSalida.CCODIGOALMACEN AS almacenCedis
					, almacenSalida.CNOMBREALMACEN AS almacenCedis2
				FROM bec_event_salida_devolucion AS salidaDevolucion

				INNER JOIN bec_event_cliente_documento AS almacenConfig 
					ON salidaDevolucion.ruta_almacen = almacenConfig.codigo_cliente
				INNER JOIN admConceptos AS concepto 
					ON almacenConfig.codigo_salida = concepto.CCODIGOCONCEPTO
				INNER JOIN admAlmacenes AS almacenSalida 
					ON concepto.CIDALMASUM = almacenSalida.CIDALMACEN
				INNER JOIN admDocumentos AS salida
					ON salidaDevolucion.id_documento_salida = salida.CIDDOCUMENTO
				INNER JOIN admProductos AS producto
					ON salidaDevolucion.codigo_producto = producto.CCODIGOPRODUCTO

				WHERE 
					salidaDevolucion.tipo_movimiento = 'salida'
					AND salidaDevolucion.procesado_salida = 1
					AND salidaDevolucion.procesado_entrada = 1
					AND almacenSalida.CCODIGOALMACEN IN ({cedisConcatenados})
					{(string.IsNullOrEmpty(rutasConcatenadas) ? "" : $"AND salidaDevolucion.ruta_almacen IN({ rutasConcatenadas})")}
					AND salida.CFECHA BETWEEN @fechaInicio AND @fechaFin

				GROUP BY
					producto.CCODIGOPRODUCTO
					, producto.CNOMBREPRODUCTO 
					, almacenSalida.CCODIGOALMACEN 
					, almacenSalida.CNOMBREALMACEN 
				),
				devoluciones AS (	
				SELECT 
					producto.CCODIGOPRODUCTO AS sku
					, producto.CNOMBREPRODUCTO AS producto
					, SUM(salidaDevolucion.cantidad_movimiento) AS devoluciones
					, almacenSalida.CCODIGOALMACEN AS almacenCedis
					, almacenSalida.CNOMBREALMACEN AS almacenCedis2
				FROM bec_event_salida_devolucion AS salidaDevolucion

				INNER JOIN bec_event_cliente_documento AS almacenConfig 
					ON salidaDevolucion.ruta_almacen = almacenConfig.codigo_cliente
				INNER JOIN admConceptos AS concepto 
					ON almacenConfig.codigo_salida = concepto.CCODIGOCONCEPTO
				INNER JOIN admAlmacenes AS almacenSalida 
					ON concepto.CIDALMASUM = almacenSalida.CIDALMACEN
				INNER JOIN admDocumentos AS salida
					ON salidaDevolucion.id_documento_salida = salida.CIDDOCUMENTO
				INNER JOIN admProductos AS producto
					ON salidaDevolucion.codigo_producto = producto.CCODIGOPRODUCTO

				WHERE 
					salidaDevolucion.tipo_movimiento = 'devolucion'
					AND salidaDevolucion.procesado_salida = 1
					AND salidaDevolucion.procesado_entrada = 1
					AND almacenSalida.CCODIGOALMACEN IN ({cedisConcatenados})
					{(string.IsNullOrEmpty(rutasConcatenadas) ? "" : $"AND salidaDevolucion.ruta_almacen IN({ rutasConcatenadas})")}
					AND salida.CFECHA BETWEEN @fechaInicio AND @fechaFin

				GROUP BY
					producto.CCODIGOPRODUCTO
					, producto.CNOMBREPRODUCTO 
					, almacenSalida.CCODIGOALMACEN 
					, almacenSalida.CNOMBREALMACEN 
				),

				liquidacion AS (	
				SELECT 
					producto.CCODIGOPRODUCTO AS sku
					, producto.CNOMBREPRODUCTO AS producto
					, SUM(salidaDevolucion.cantidad_movimiento) AS liquidacion
					, almacenSalida.CCODIGOALMACEN AS almacenCedis
					, almacenSalida.CNOMBREALMACEN AS almacenCedis2
				FROM bec_event_salida_devolucion AS salidaDevolucion

				INNER JOIN bec_event_cliente_documento AS almacenConfig 
					ON salidaDevolucion.ruta_almacen = almacenConfig.codigo_cliente
				INNER JOIN admConceptos AS concepto 
					ON almacenConfig.codigo_salida = concepto.CCODIGOCONCEPTO
				INNER JOIN admAlmacenes AS almacenSalida 
					ON concepto.CIDALMASUM = almacenSalida.CIDALMACEN
				INNER JOIN admDocumentos AS salida
					ON salidaDevolucion.id_documento_salida = salida.CIDDOCUMENTO
				INNER JOIN admProductos AS producto
					ON salidaDevolucion.codigo_producto = producto.CCODIGOPRODUCTO

				WHERE 
					salidaDevolucion.tipo_movimiento = 'venta'
					AND salidaDevolucion.procesado_salida = 1
					AND almacenSalida.CCODIGOALMACEN IN ({cedisConcatenados})
					{(string.IsNullOrEmpty(rutasConcatenadas) ? "" : $"AND salidaDevolucion.ruta_almacen IN({ rutasConcatenadas})")}
					AND salida.CFECHA BETWEEN @fechaInicio AND @fechaFin

				GROUP BY
					producto.CCODIGOPRODUCTO
					, producto.CNOMBREPRODUCTO 
					, almacenSalida.CCODIGOALMACEN 
					, almacenSalida.CNOMBREALMACEN 
				)

				SELECT 
					COALESCE(salidas.sku, devoluciones.sku, liquidacion.sku) AS sku,
					COALESCE(salidas.producto, devoluciones.producto, liquidacion.producto) AS producto,
					COALESCE(salidas.salidas, 0) AS salidas,
					COALESCE(devoluciones.devoluciones, 0) AS devoluciones,
					COALESCE(salidas.salidas, 0) - COALESCE(devoluciones.devoluciones, 0) AS vtaTeorica, 
					COALESCE(liquidacion.liquidacion, 0) AS liquidaciones,
					(COALESCE(salidas.salidas, 0) - COALESCE(devoluciones.devoluciones, 0)) - COALESCE(liquidacion.liquidacion, 0) AS diferencia,
					COALESCE(salidas.almacenCedis, devoluciones.almacenCedis, liquidacion.almacenCedis) AS almacenCedis,
					COALESCE(salidas.almacenCedis2, devoluciones.almacenCedis2, liquidacion.almacenCedis2) AS almacenCedis2
				FROM salidas
				FULL OUTER JOIN devoluciones
					ON salidas.sku = devoluciones.sku
					AND salidas.almacenCedis = devoluciones.almacenCedis
					AND salidas.almacenCedis2 = devoluciones.almacenCedis2

				FULL OUTER JOIN liquidacion
					ON salidas.sku = liquidacion.sku
					AND salidas.almacenCedis = liquidacion.almacenCedis
					AND salidas.almacenCedis2 = liquidacion.almacenCedis2
					OR devoluciones.sku = liquidacion.sku
					AND devoluciones.almacenCedis = liquidacion.almacenCedis
					AND devoluciones.almacenCedis2 = liquidacion.almacenCedis2;
					";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(xlDetalle);
                        conexion.Close();
                    }
                }
            }

            return xlDetalle;
        }

        // Método para verificar si una lista es nula o está vacía
        public static bool IsListNullOrEmpty<T>(List<T> lista)
        {
            return lista == null || lista.Count == 0;
        }

    }
}
