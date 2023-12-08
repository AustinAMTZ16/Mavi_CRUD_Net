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
    public class UsuarioController
    {
        private string connectionString = "Data Source=(localdb)\\LocalHome;Initial Catalog=Contactos;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;Application Name=MyApp;Current Language=Spanish";

        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = nuevoUsuario.Nickname;
                    command.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = nuevoUsuario.CorreoElectronico;
                    command.Parameters.Add("@ClaveUsuario", SqlDbType.VarChar).Value = nuevoUsuario.ClaveUsuario;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al agregar el usuario: " + ex.Message);
                    }
                }
            }
        }

        public int VerificarUsuario(Usuario verificarUsuario)
        {
            int idUsuario = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("VerificarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = verificarUsuario.Nickname;
                    command.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = verificarUsuario.CorreoElectronico;
                    command.Parameters.Add("@ClaveUsuario", SqlDbType.VarChar).Value = verificarUsuario.ClaveUsuario;


                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            idUsuario = reader.GetInt32(0); // Asumiendo que el ID del usuario es la primera columna devuelta por el SP
                        }

                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al verificar el usuario: " + ex.Message);
                    }

                }
            }

            return idUsuario;
        }

















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
        public int agregarContacto(string contacto, int IdUsuario)
        {
            int result = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Contacto (NumeroTelefono, IdUsuario) VALUES (@contacto, @IdUsuario)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contacto", contacto);
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

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
