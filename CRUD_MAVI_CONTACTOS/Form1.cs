using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_MAVI_CONTACTOS
{
    public partial class Form1 : Form
    {
        private UsuarioController usuarioController;
        public Form1()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {            
            try
            {
                
                string Nickname = txtNickname.Text;
                string CorreoElectronico = txtCorreoElectronico.Text;
                string ClaveUsuario = txtClaveUsuario.Text;

                Usuario nuevoUsuario = new Usuario(Nickname, CorreoElectronico, ClaveUsuario);
                usuarioController.AgregarUsuario(nuevoUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login _ver = new login();
            _ver.Show();

            this.Hide();
        }

        private void txtNickname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNickname.MaxLength = 10;
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            //SOLO NUMEROS
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtCorreoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCorreoElectronico.MaxLength = 25;
        }

        private void txtClaveUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCorreoElectronico.MaxLength = 25;
        }
    }
}
