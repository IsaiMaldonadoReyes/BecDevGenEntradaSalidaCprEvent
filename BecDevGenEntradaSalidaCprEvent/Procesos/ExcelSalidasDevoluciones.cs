using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecDevGenEntradaSalidaCprEvent.Procesos
{
    public static class ExcelSalidasDevoluciones
    {

        public static string ProcesarExcelSalidasDevoluciones(string rutaArchivo, bool tipoCarga, adConexionDB dbConnect, double unix)
        {
            int col = 0;
            int row = 0;
            int filaExcel = 2;
            string errorCampos = "";

            try
            {
                using (var stream = File.Open(rutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelReader;

                    excelReader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };


                    var dataSet = excelReader.AsDataSet(conf);
                    var dataTable = dataSet.Tables["Formato para salidas de almacén"];

                    if (!tipoCarga)
                    {
                        if (dataSet.Tables["Formato para salidas de almacén"] == null)
                        {
                            errorCampos += "\n La hoja de su archivo no corresponde al formato para importar las salidas de auto venta, por favor asegurese de que sea el formato.";
                            return errorCampos;
                        }
                        dataTable = dataSet.Tables["Formato para salidas de almacén"];
                    }
                    else
                    {
                        if (dataSet.Tables["Formato para devolución"] == null)
                        {
                            errorCampos += "\n La hoja de su archivo no corresponde al formato para importar los movimientos de devolución, por favor asegurese de que sea el formato.";
                            return errorCampos;
                        }
                        dataTable = dataSet.Tables["Formato para devolución"];
                    }

                    if (errorCampos.Equals(""))
                    {
                        bool esNumerica = false;
                        double cantidadMovimiento;


                        for (int i = row; i < dataTable.Rows.Count; i++)
                        {
                            string celdaActual = "";

                            bec_event_salida_devolucion becSalidaDev = new bec_event_salida_devolucion();
                            for (int j = col; j < dataTable.Columns.Count; j++)
                            {
                                var data = dataTable.Rows[i][Int32.Parse(j.ToString())];
                                celdaActual = data.ToString() ?? "";

                                switch (j)
                                {
                                    case 0: // código producto
                                        if (celdaActual.Equals(""))
                                        {
                                            errorCampos += $"\n Celda: {GetExcelColumnNameIniZero(j)}{filaExcel} se encuentra vacía";
                                        }
                                        else
                                        {
                                            var existeProducto = (from producto in dbConnect.admProductos
                                                                  where producto.CCODIGOPRODUCTO == celdaActual
                                                                  select producto).FirstOrDefault<admProductos>();

                                            if (existeProducto == null)
                                            {
                                                errorCampos += $" \n El producto ingresado en la celda {GetExcelColumnNameIniZero(j)}{filaExcel} no existe";
                                            }
                                            else
                                            {
                                                becSalidaDev.codigo_producto = celdaActual;
                                            }
                                        }
                                        break;
                                    case 2:
                                        if (celdaActual.Equals(""))
                                        {
                                            errorCampos += $"\n Celda: {GetExcelColumnNameIniZero(j)}{filaExcel} se encuentra vacía";
                                        }
                                        else
                                        {
                                            esNumerica = double.TryParse(celdaActual, out cantidadMovimiento);

                                            if (esNumerica)
                                            {
                                                becSalidaDev.cantidad_movimiento = Convert.ToDouble(celdaActual);
                                            }
                                            else
                                            {
                                                errorCampos += $" \n La cantidad ingresada en la celda {GetExcelColumnNameIniZero(j)}{filaExcel} no es de tipo numérico";
                                            }
                                        }

                                        break;
                                    case 3:
                                        if (celdaActual.Equals(""))
                                        {
                                            errorCampos += $"\n Celda: {GetExcelColumnNameIniZero(j)}{filaExcel} se encuentra vacía";
                                        }
                                        else
                                        {
                                            var existeAlmacen = (from almacen in dbConnect.admAlmacenes
                                                                 join clienteDoc in dbConnect.bec_event_cliente_documento
                                                                 on almacen.CCODIGOALMACEN equals clienteDoc.codigo_cliente
                                                                 where almacen.CCODIGOALMACEN == celdaActual
                                                                 select almacen).FirstOrDefault<admAlmacenes>();

                                            if (existeAlmacen == null)
                                            {
                                                errorCampos += $" \n El almacén ingresado en la celda {GetExcelColumnNameIniZero(j)}{filaExcel} no existe o no se encuentra configurado";
                                            }
                                            else
                                            {

                                                becSalidaDev.ruta_almacen = celdaActual;
                                            }
                                        }
                                        break;

                                    case 4:
                                        if (celdaActual.Equals(""))
                                        {
                                            errorCampos += $"\n Celda: {GetExcelColumnNameIniZero(j)}{filaExcel} se encuentra vacía";
                                        }
                                        else
                                        {
                                            becSalidaDev.folio_definido = celdaActual;
                                        }
                                        break;
                                }
                            }

                            becSalidaDev.procesado_salida = false;
                            becSalidaDev.procesado_entrada = false;
                            becSalidaDev.unix = unix;
                            becSalidaDev.tipo_movimiento = tipoCarga ? "devolucion" : "salida";
                            becSalidaDev.id_agente = LoginUsuario.IdUsuarioLogeado;


                            dbConnect.bec_event_salida_devolucion.Add(becSalidaDev);

                            try
                            {
                                dbConnect.SaveChanges();
                            }
                            catch (DbUpdateException dbE)
                            { }
                            catch (DbEntityValidationException dbEx)
                            {
                                foreach (var validationErrors in dbEx.EntityValidationErrors)
                                {
                                    foreach (var validationError in validationErrors.ValidationErrors)
                                    { }
                                }
                            }


                            filaExcel++;
                        }

                        if (!errorCampos.Equals(""))
                        {
                            string query = $"DELETE FROM bec_event_salida_devolucion WHERE unix = {unix}";
                            dbConnect.Database.ExecuteSqlCommand(query);

                            return errorCampos;
                        }
                    }
                }
            }
            catch (IOException)
            {
                errorCampos += "\n El formato de Excel se encuentra abierto, por favor cierrelo y vuelva a intentarlo.";
            }
            return errorCampos;
        }

        public static string ProcesarSalidasDevoluciones(bool tipoCarga, adConexionDB dbConnect, double unix, string Empresa, StringBuilder InterpreteSDK)
        {
            int errorSdk = 0;
            int idDocumento = 0;
            int idMovimiento = 0;

            int idDocumentoEntrada = 0;
            int idMovimientoEntrada = 0;

            double folioDoc = 0;
            double folioDocEntrada = 0;

            string serieDoc = "";
            string serieDocEntrada = "";
            string mensajeResultado = "";

            string almacenSalida = "";
            string almacenEntrada = "";

            errorSdk = SDK.fAbreEmpresa(Empresa);

            if (errorSdk != 0)
            {
                SDK.fError(errorSdk, InterpreteSDK, 255);
            }
            else
            {
                var documentosPendientes = (from pendientes in dbConnect.bec_event_salida_devolucion
                                            where pendientes.unix == unix
                                            orderby pendientes.tipo_movimiento descending
                                            group pendientes
                                            by new
                                            {
                                                pendientes.tipo_movimiento,
                                                pendientes.ruta_almacen,
                                                pendientes.folio_definido,
                                                pendientes.unix,
                                                pendientes.id_agente
                                            } into g
                                            select g.Key).ToList();

                foreach (var objPen in documentosPendientes)
                {
                    folioDoc = 0;
                    serieDoc = "";
                    folioDocEntrada = 0;
                    serieDocEntrada = "";

                    var conceptosPorCliente = (from documento in dbConnect.bec_event_cliente_documento
                                               where documento.codigo_cliente == objPen.ruta_almacen
                                               select documento).FirstOrDefault<bec_event_cliente_documento>();

                    if (tipoCarga) // devoluciones
                    {
                        almacenEntrada = (from concepto in dbConnect.admConceptos
                                          join almace in dbConnect.admAlmacenes on concepto.CIDALMASUM equals almace.CIDALMACEN
                                          where concepto.CCODIGOCONCEPTO == conceptosPorCliente.codigo_salida
                                          select almace.CCODIGOALMACEN).FirstOrDefault();

                        almacenSalida = objPen.ruta_almacen;
                    }
                    else // auto venta (entregas)
                    {
                        almacenEntrada = objPen.ruta_almacen;

                        almacenSalida = (from concepto in dbConnect.admConceptos
                                         join almace in dbConnect.admAlmacenes on concepto.CIDALMASUM equals almace.CIDALMACEN
                                         where concepto.CCODIGOCONCEPTO == conceptosPorCliente.codigo_salida
                                         select almace.CCODIGOALMACEN).FirstOrDefault();
                    }

                    var agenteDoc = (from agente in dbConnect.admAgentes
                                     where agente.CIDAGENTE == objPen.id_agente
                                     select agente).FirstOrDefault<admAgentes>();

                    errorSdk = SDK.fSiguienteFolio(conceptosPorCliente.codigo_salida, InterpreteSDK, ref folioDoc);

                    if (errorSdk != 0)
                    {
                        SDK.fError(errorSdk, InterpreteSDK, 255);
                        mensajeResultado += $" \n Error al crear el siguiente folio: {InterpreteSDK}";
                    }
                    else
                    {
                        serieDoc = InterpreteSDK.ToString();
                        SDK.tDocumento tDoc = new SDK.tDocumento
                        {
                            aCodConcepto = conceptosPorCliente.codigo_salida,
                            aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                            aSerie = serieDoc,
                            aFolio = folioDoc
                        };

                        if (agenteDoc != null)
                        {
                            tDoc.aCodigoAgente = agenteDoc.CCODIGOAGENTE;
                        }

                        errorSdk = SDK.fAltaDocumento(ref idDocumento, ref tDoc);

                        if (errorSdk != 0)
                        {
                            SDK.fError(errorSdk, InterpreteSDK, 255);
                            mensajeResultado += $"\n Error al crear el documento de la ruta {objPen.ruta_almacen}: {InterpreteSDK}";

                            SDK.fBuscarIdDocumento(idDocumento);
                            SDK.fBorraDocumento();
                        }
                        else
                        {

                            SDK.fBuscarIdDocumento(idDocumento);
                            SDK.fEditarDocumento();
                            SDK.fSetDatoDocumento("CREFERENCIA", objPen.folio_definido);
                            SDK.fGuardaDocumento();

                            var movimientosDocumento = (from movimientos in dbConnect.bec_event_salida_devolucion
                                                        where movimientos.tipo_movimiento == objPen.tipo_movimiento
                                                        && movimientos.ruta_almacen == objPen.ruta_almacen
                                                        && movimientos.unix == objPen.unix
                                                        && movimientos.id_agente == objPen.id_agente
                                                        && movimientos.procesado_salida == false
                                                        select movimientos).ToList();

                            if (tipoCarga) // devoluciones
                            {
                                mensajeResultado += $"\n Entrada: {serieDoc} {folioDoc}, ruta {objPen.ruta_almacen} ";
                            }
                            else
                            {
                                mensajeResultado += $"\n Salida: {serieDoc} {folioDoc}, ruta {objPen.ruta_almacen} ";
                            }

                            foreach (var objMovs in movimientosDocumento)
                            {
                                idMovimiento = 0;


                                SDK.tMovimiento tMov = new SDK.tMovimiento
                                {
                                    aCodAlmacen = almacenSalida,
                                    aCodProdSer = objMovs.codigo_producto,
                                    aUnidades = Convert.ToDouble(objMovs.cantidad_movimiento)
                                };

                                errorSdk = SDK.fAltaMovimiento(idDocumento, ref idMovimiento, ref tMov);

                                if (errorSdk != 0)
                                {
                                    SDK.fError(errorSdk, InterpreteSDK, 255);
                                    mensajeResultado += $"\n Ocurrio al cargar el producto: {objMovs.codigo_producto}, de la ruta {objMovs.ruta_almacen}: {InterpreteSDK} ";
                                }
                                else
                                {
                                    objMovs.procesado_salida = true;
                                    objMovs.id_documento_salida = idDocumento;
                                    objMovs.id_movimiento_salida = idMovimiento;
                                    objMovs.serie_salida = serieDoc;
                                    objMovs.folio_salida = folioDoc;
                                    dbConnect.Entry(objMovs).State = System.Data.Entity.EntityState.Modified;

                                    try
                                    {
                                        dbConnect.SaveChanges();
                                    }
                                    catch (DbUpdateException dbE)
                                    { }
                                    catch (DbEntityValidationException dbEx)
                                    {
                                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                                        {
                                            foreach (var validationError in validationErrors.ValidationErrors)
                                            { }
                                        }
                                    }
                                }

                            }
                        }
                    }

                    errorSdk = SDK.fSiguienteFolio(conceptosPorCliente.codigo_entrada, InterpreteSDK, ref folioDocEntrada);

                    if (errorSdk != 0)
                    {
                        SDK.fError(errorSdk, InterpreteSDK, 255);
                        mensajeResultado += $" \n Error al crear el siguiente folio: {InterpreteSDK}";
                    }
                    else
                    {
                        serieDocEntrada = InterpreteSDK.ToString();
                        SDK.tDocumento tDoc = new SDK.tDocumento
                        {
                            aCodConcepto = conceptosPorCliente.codigo_entrada,
                            aFecha = DateTime.Now.ToString("MM/dd/yyyy"),
                            aSerie = serieDocEntrada,
                            aFolio = folioDocEntrada
                        };

                        if (agenteDoc != null)
                        {
                            tDoc.aCodigoAgente = agenteDoc.CCODIGOAGENTE;
                        }

                        errorSdk = SDK.fAltaDocumento(ref idDocumentoEntrada, ref tDoc);

                        if (errorSdk != 0)
                        {
                            SDK.fError(errorSdk, InterpreteSDK, 255);
                            mensajeResultado += $"\n Error al crear el documento de la ruta {objPen.ruta_almacen}: {InterpreteSDK}";

                            SDK.fBuscarIdDocumento(idDocumentoEntrada);
                            SDK.fBorraDocumento();
                        }
                        else
                        {

                            SDK.fBuscarIdDocumento(idDocumentoEntrada);
                            SDK.fEditarDocumento();
                            SDK.fSetDatoDocumento("CREFERENCIA", objPen.folio_definido);
                            SDK.fGuardaDocumento();

                            var movimientosDocumento = (from movimientos in dbConnect.bec_event_salida_devolucion
                                                        where movimientos.tipo_movimiento == objPen.tipo_movimiento
                                                        && movimientos.ruta_almacen == objPen.ruta_almacen
                                                        && movimientos.unix == objPen.unix
                                                        && movimientos.id_agente == objPen.id_agente
                                                        && movimientos.procesado_salida == true
                                                        && movimientos.procesado_entrada == false
                                                        select movimientos).ToList();

                            if (!tipoCarga) // devoluciones
                            {
                                mensajeResultado += $"\n Entrada: {serieDocEntrada} {folioDocEntrada}, ruta {objPen.ruta_almacen} ";
                            }
                            else
                            {
                                mensajeResultado += $"\n Salida: {serieDocEntrada} {folioDocEntrada}, ruta {objPen.ruta_almacen} ";
                            }
                            foreach (var objMovs in movimientosDocumento)
                            {
                                idMovimientoEntrada = 0;


                                SDK.tMovimiento tMov = new SDK.tMovimiento
                                {
                                    aCodAlmacen = almacenEntrada,
                                    aCodProdSer = objMovs.codigo_producto,
                                    aUnidades = Convert.ToDouble(objMovs.cantidad_movimiento)
                                };

                                errorSdk = SDK.fAltaMovimiento(idDocumentoEntrada, ref idMovimientoEntrada, ref tMov);

                                if (errorSdk != 0)
                                {
                                    SDK.fError(errorSdk, InterpreteSDK, 255);
                                    mensajeResultado += $"\n Ocurrio al cargar el producto: {objMovs.codigo_producto}, de la ruta {objMovs.ruta_almacen}: {InterpreteSDK} ";
                                }
                                else
                                {
                                    objMovs.procesado_entrada = true;
                                    objMovs.id_documento_entrada = idDocumentoEntrada;
                                    objMovs.id_movimiento_entrada = idMovimientoEntrada;
                                    objMovs.serie_entrada = serieDocEntrada;
                                    objMovs.folio_entrada = folioDocEntrada;
                                    dbConnect.Entry(objMovs).State = System.Data.Entity.EntityState.Modified;

                                    try
                                    {
                                        dbConnect.SaveChanges();
                                    }
                                    catch (DbUpdateException dbE)
                                    { }
                                    catch (DbEntityValidationException dbEx)
                                    {
                                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                                        {
                                            foreach (var validationError in validationErrors.ValidationErrors)
                                            { }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return mensajeResultado;
        }

        private static string GetExcelColumnNameIniZero(int columnNumber)
        {
            string columnName = "";

            columnNumber++;

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }
    }
}
