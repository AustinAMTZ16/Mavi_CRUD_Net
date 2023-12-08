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
    public partial class GriedViewContactoUsuario : Form
    {
        private UsuarioController usuarioController;
        private ContactoController contactoController;

        private int idUsuario;
        public GriedViewContactoUsuario(int idUsuario)
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            contactoController = new ContactoController(); 
            this.idUsuario = idUsuario;
            MostrarContactos(idUsuario);
        }
        private void MostrarContactos(int idUsuario)
        {
            try
            {
                DataTable dataTable = usuarioController.ObtenerContactosPorUsuario(idUsuario);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            try
            {
                string contacto = txtContacto.Text;
                int idusuarioSave = idUsuario;

                Contacto nuevoContacto = new Contacto(contacto, idusuarioSave);

                int respuesta = contactoController.agregarContacto(nuevoContacto);

                if (respuesta != -1) 
                {
                    MostrarContactos(idUsuario);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdContacto = int.Parse(txtIdContacto.Text);
                usuarioController.eliminarContacto(IdContacto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
