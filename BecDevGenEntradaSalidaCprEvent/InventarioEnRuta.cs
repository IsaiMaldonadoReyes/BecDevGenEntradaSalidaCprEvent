using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class InventarioEnRuta : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        List<admAlmacenes> almacenes;
        List<bec_event_cliente_documento> rutasDocumento;

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

        private void btnEjecutarInventarioEnRuta_Click(object sender, EventArgs e)
        {

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
