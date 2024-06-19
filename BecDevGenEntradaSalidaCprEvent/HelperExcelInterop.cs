using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using Excel = Microsoft.Office.Interop.Excel;

namespace BecDevGenEntradaSalidaCprEvent
{
    class HelperExcelInterop
    {
        public class ModeloDinamico : System.Dynamic.DynamicObject
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            public int Count
            {
                get
                {
                    return dictionary.Count;
                }
            }

            /** Agregar propiedad nueva al Modelo dinámico.*/
            public void AddProperty(string key, object value)
            {
                dictionary[key] = value;
            }

            /** Si se intenta obtener un valor de una propiedad NO definida en la clase, esté método es llamado.*/
            public override bool TryGetMember(
                GetMemberBinder binder, out object result)
            {
                /** Convertir el nombre de la propiedad a minúsculas así los nombres de las propiedades llegan a ser case-insensitive*/
                string name = binder.Name.ToLower();

                /** Si el nombre de la propiedad no se encuentra en el diccionario, asigna el resultado del parametro al valor de la propiedad y retorna TRUE, en caso contrario FALSE.*/
                return dictionary.TryGetValue(name, out result);
            }

            /** Si se intenta asignar un valor a una propiedad que NO está definida en la clase, esté método es llamado. */
            public override bool TrySetMember(
                SetMemberBinder binder, object value)
            {
                /** Convertir el nombre de la propiedad a minúsculas así los nombres de las propiedades llegan a ser case-insensitive*/
                dictionary[binder.Name.ToLower()] = value;

                /** Siempre se puede agregar una nueva propiedad a el diccionario, así que este método siempre retorna TRUE. */
                return true;
            }
        }

        public void dibujarEncabezadoPrincipal(Excel.Worksheet xlHoja, string titulo, string filtrosSeleccionados, string xlColumnaFinal)
        {
            Excel.XlHAlign alineacionHorizontal;
            Excel.XlVAlign alineacionVertical;
            string rutaActual = Environment.CurrentDirectory;

            alineacionHorizontal = Excel.XlHAlign.xlHAlignCenter;
            alineacionVertical = Excel.XlVAlign.xlVAlignCenter;

            setEstiloFila(xlHoja, "A1", xlColumnaFinal + "1", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A1", xlColumnaFinal + "1").Merge(true);
            xlHoja.Cells[1, 1] = "Fecha creación: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

            setEstiloFila(xlHoja, "A2", xlColumnaFinal + "2", "", "", "#1E233A", 10, true, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A2", xlColumnaFinal + "2").Merge(true);
            xlHoja.Cells[2, 1] = titulo;

            setEstiloFila(xlHoja, "A3", xlColumnaFinal + "3", "", "", "#AEAAAA", 8, false, true, alineacionHorizontal, alineacionVertical);
            xlHoja.get_Range("A3", xlColumnaFinal + "3").Merge(true);
            xlHoja.Cells[3, 1] = filtrosSeleccionados;
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

        public string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        public string GetMes(int mes)
        {
            string[] nombresMeses = { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
            return mes >= 1 && mes <= 12 ? nombresMeses[mes - 1] : "";
        }
    }
}
