using MaterialSkin;
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
    public partial class dialogConfigAyudaVenta : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        uAyudaVentas uAyudaVentas = new uAyudaVentas();

        public dialogConfigAyudaVenta()
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

        private void dialogConfigAyudaVenta_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    this.Text = "Ver ejemplo 1 | ";
                    uAyudaVentas.animacion = "Animation1.gif";
                    uAyudaVentas.Dock = DockStyle.Fill;
                    area1.Controls.Clear();
                    area1.Controls.Add(uAyudaVentas);
                    break;
                case 1:
                    this.Text = "Ver ejemplo 2 | ";
                    uAyudaVentas.animacion = "Animation2.gif";
                    uAyudaVentas.Dock = DockStyle.Fill;
                    area2.Controls.Clear();
                    area2.Controls.Add(uAyudaVentas);
                    break;
                case 2:
                    this.Text = "Ver ejemplo 3 | ";
                    uAyudaVentas.animacion = "Animation3.gif";
                    uAyudaVentas.Dock = DockStyle.Fill;
                    area3.Controls.Clear();
                    area3.Controls.Add(uAyudaVentas);
                    break;
                case 3:
                    this.Text = "Ver ejemplo 4 | ";
                    uAyudaVentas.animacion = "Animation4.gif";
                    uAyudaVentas.Dock = DockStyle.Fill;
                    area4.Controls.Clear();
                    area4.Controls.Add(uAyudaVentas);
                    break;
            }
        }
    }
}
