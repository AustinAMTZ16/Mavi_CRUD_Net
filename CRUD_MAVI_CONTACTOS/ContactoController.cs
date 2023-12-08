using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace CRUD_MAVI_CONTACTOS
{
    public class ContactoController
    {
        private string connectionString = "Data Source=(localdb)\\LocalHome;Initial Catalog=Contactos;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;Application Name=MyApp;Current Language=Spanish";
        public DataTable ObtenerContactosPorUsuario(int idUsuario)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacto WHERE IdUsuario = @IdUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al obtener los contactos: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }
        public int agregarContacto(Contacto contacto)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Contacto (NumeroTelefono, IdUsuario) VALUES (@contacto, @IdUsuario)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contacto", contacto.NumeroTelefono);
                    command.Parameters.AddWithValue("@IdUsuario", contacto.IdUsuario);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        result = 1;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al obtener los contactos: " + ex.Message);
                    }
                }
            }
            return result;
        }
        public int eliminarContacto(int idContacto)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "delete from Contacto where IdContacto = @idContacto";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idContacto", idContacto);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        result = 1;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al obtener los contactos: " + ex.Message);
                    }
                }
            }
            return result;
        }

    }
}
