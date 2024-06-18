using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class uAyudaVentas : UserControl
    {
        private string _animacion;

        public string animacion
        {
            get => _animacion;
            set
            {
                _animacion = value;
                ActualizarImagen(); // Llama a este método cada vez que se establece la propiedad
            }
        }
        public uAyudaVentas()
        {
            InitializeComponent();
        }

        private void ActualizarImagen()
        {
            if (!string.IsNullOrEmpty(_animacion))
            {

                string rutaProyecto = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string filePath = Path.Combine(rutaProyecto, "animaciones\\" + animacion);
                if (System.IO.File.Exists(filePath))
                {
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void uAyudaVentas_Load(object sender, EventArgs e)
        {
            ActualizarImagen();
        }
    }
}
