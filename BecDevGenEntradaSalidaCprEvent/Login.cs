using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BecDevGenEntradaSalidaCprEvent
{
    public partial class Login : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StringBuilder mensajeConfiguracion = new StringBuilder("Verifique lo siguiente:\n\n");
            string camposVacios = "";
            string loginUsuario = txtLoginUsuario.Text;
            string loginPassword = txtLoginPassword.Text;
            bool loginCorrecto = false;

            if (loginUsuario.Equals(""))
            {
                camposVacios += "\n \t❎ Usuario";
            }
            if (loginPassword.Equals(""))
            {
                camposVacios += "\n \t❎ Contraseña";
            }

            if (camposVacios.Equals(""))
            {
                using (adConexionDB dbConnect = new adConexionDB())
                {
                    var loginAgente = (from agente in dbConnect.admAgentes
                                       where agente.CCODIGOAGENTE == loginUsuario
                                       select agente).FirstOrDefault<admAgentes>();

                    if (loginAgente == null)
                    {
                        mensajeConfiguracion.AppendFormat("\n \t❎ Usuario y/o contraseña incorrecta \t \t \t \t \t \t \t ");
                    }
                    else if (loginPassword == loginAgente.CTEXTOEXTRA1)
                    {

                        var almacenCliente = (from concepto in dbConnect.admConceptos
                                              join almacen in dbConnect.admAlmacenes on concepto.CIDALMASUM equals almacen.CIDALMACEN
                                              join cliente in dbConnect.bec_event_cliente_documento on concepto.CCODIGOCONCEPTO equals cliente.codigo_documento
                                              where concepto.CIDDOCUMENTODE == 3
                                              && cliente.codigo_agente == loginAgente.CCODIGOAGENTE
                                              group almacen by new { almacen.CIDALMACEN, almacen.CNOMBREALMACEN, almacen.CCODIGOALMACEN } into agrupador
                                              select new
                                              {
                                                  CIDALMACEN = agrupador.Key.CIDALMACEN,
                                                  CNOMBREALMACEN = agrupador.Key.CNOMBREALMACEN,
                                                  CCODIGOALMACEN = agrupador.Key.CCODIGOALMACEN,
                                              }).FirstOrDefault();

                        loginCorrecto = true;
                        LoginUsuario.IdUsuarioLogeado = loginAgente.CIDAGENTE;
                        LoginUsuario.CodigoUsuarioLogeado = loginAgente.CCODIGOAGENTE;
                        LoginUsuario.TipoUsuarioLogeado = loginAgente.CTEXTOEXTRA2;

                        if (!loginAgente.CTEXTOEXTRA2.Equals("administracion"))
                        {
                            LoginUsuario.AlmacenUsuarioLogeado = almacenCliente.CCODIGOALMACEN;
                            LoginUsuario.IdAlmacenUsuarioLogeado = almacenCliente.CIDALMACEN;
                        }

                    }
                    else
                    {
                        mensajeConfiguracion.AppendFormat("\n \t❎ Usuario y/o contraseña incorrecta \t \t \t \t \t \t \t ");
                    }
                }
            }
            else
            {
                mensajeConfiguracion.AppendFormat("Es necesario ingresar los campos solicitados para poder ingresar al sistema, por favor: \n\n" + camposVacios + "\n\n ");
            }

            if (loginCorrecto)
            {
                txtLoginUsuario.Text = "";
                txtLoginPassword.Text = "";

                this.Hide();
                if (LoginUsuario.TipoUsuarioLogeado.Equals("administracion"))
                {
                    ListadoLiquidaciones formPrincipal = new ListadoLiquidaciones();
                    formPrincipal.ShowDialog();
                    Close();
                }
                else if (LoginUsuario.TipoUsuarioLogeado.Equals("almacen"))
                {
                    ListadoSalidas formPrincipal = new ListadoSalidas();
                    //Ambiente.frmL = formPrincipal;
                    formPrincipal.ShowDialog();
                    Close();
                    //Dispose();
                }

            }
            else
            {
                MaterialMessageBox.Show(mensajeConfiguracion.ToString(), "⚠︎ Información incorrecta");
            }
        }

        private void txtLoginUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
