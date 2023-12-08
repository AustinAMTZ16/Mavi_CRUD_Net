using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_MAVI_CONTACTOS
{
    public partial class login : Form
    {
        private UsuarioController usuarioController;
        public login()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Form1 _ver = new Form1();
            _ver.Show();
            this.Hide();
        }

        private void btbAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                string Nickname = txtNickname.Text;
                string CorreoElectronico = txtCorreoElectronico.Text;
                string ClaveUsuario = txtClaveUsuario.Text;

                Usuario verificarUsuario = new Usuario(Nickname, CorreoElectronico, ClaveUsuario);

                //usuarioController.VerificarUsuario(verificarUsuario);


                
                //MessageBox.Show("Se verifico correctamente el usuario.");
                //GriedViewContactoUsuario _ver = new GriedViewContactoUsuario();
                //_ver.Show();
                //this.Hide();


                int idUsuarioVerificado = usuarioController.VerificarUsuario(verificarUsuario);

                if (idUsuarioVerificado != -1)
                {
                    // El usuario ha sido verificado correctamente
                    // Pasar el ID del usuario a la nueva vista
                    GriedViewContactoUsuario nuevaVista = new GriedViewContactoUsuario(idUsuarioVerificado);
                    nuevaVista.Show();
                    this.Hide();
                }
                else
                {
                    // El usuario no se encontró o no pudo ser verificado
                    MessageBox.Show("El usuario no ha sido verificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GriedViewContactoUsuario _ver = new GriedViewContactoUsuario();
            //_ver.Show();
            //this.Hide();
        }
    }
}
