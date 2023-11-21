using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOGINWEB
{
    public partial class Inicio : System.Web.UI.Page
    {
        private string connectionString = "Data Source=DARWINAMAURY;Initial Catalog=Practica;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        // Método para cargar datos en el GridView
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Registro";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
                finally
                {
                    connection.Close();
                }

                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // ... código para crear un registro ...
            string nombre = Nombre.Text;
            string apellidoPaterno = ApellidoP.Text;
            string apellidoMaterno = ApellidoM.Text;
            int matricula = 0;

            // Verifica si la matrícula es un número válido
            if (int.TryParse(Matricula.Text, out matricula))
            {
                string carrera = Carrera.Text;
                string usuario = User.Text;
                string contraseña = Password.Text; // Puedes almacenar la contraseña como texto plano o aplicar algún método de cifrado seguro según tus necesidades.


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Registro (Nombre, [Apellido Paterno], [Apellido Materno], [Numero de control], Carrera, Usuario, Contraseña) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Matricula, @Carrera, @Usuario, @Contraseña)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                        command.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                        command.Parameters.AddWithValue("@Matricula", matricula);
                        command.Parameters.AddWithValue("@Carrera", carrera);
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            // Muestra un mensaje indicando que el registro ha sido creado
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Nuevo registro creado correctamente.');", true);
                        }
                        catch (Exception ex)
                        {
                            // Muestra un mensaje si hay un error en la base de datos
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Error al crear el registro: " + ex.Message + "');", true);
                        }
                    }
                }
            }
            else
            {
                // Muestra un mensaje si la matrícula no es un número válido
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, ingrese una matrícula válida (números enteros).');", true);
            }

            // Limpia los TextBoxes después de la creación
            Nombre.Text = "";
            ApellidoP.Text = "";
            ApellidoM.Text = "";
            Matricula.Text = "";
            Carrera.Text = "";
            User.Text = "";
            Password.Text = "";

            // Recarga los datos en el GridView después de la creación
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Matricula.Text, out int matricula))
            {
                string connectionString = "Data Source=DARWINAMAURY;Initial Catalog=Practica;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Registro WHERE [Numero de control] = @NumeroDeControl";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroDeControl", matricula);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                // Si se encuentran resultados, muestra la información en los TextBoxes
                                while (reader.Read())
                                {
                                    Nombre.Text = reader["Nombre"].ToString();
                                    ApellidoP.Text = reader["Apellido Paterno"].ToString();
                                    ApellidoM.Text = reader["Apellido Materno"].ToString();
                                    Carrera.Text = reader["Carrera"].ToString();
                                    User.Text = reader["Usuario"].ToString();
                                    Password.Text = reader["Contraseña"].ToString();
                                    // Puedes continuar mostrando otros campos según tu estructura de base de datos
                                }
                            }
                            else
                            {
                                // Muestra un mensaje si no se encontró el registro
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encontró el registro.');", true);
                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            // Muestra un mensaje si hay un error en la base de datos
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Error al buscar el registro: " + ex.Message + "');", true);
                        }
                    }
                }
            }
            else
            {
                // Muestra un mensaje si la matrícula no es un número válido
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, ingrese una matrícula válida (números enteros).');", true);
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // ... código para actualizar un registro ...
            int matricula = 0;

            if (int.TryParse(Matricula.Text, out matricula))
            {
                // Obtén los nuevos valores de los TextBoxes
                string nombre = Nombre.Text;
                string apellidoPaterno = ApellidoP.Text;
                string apellidoMaterno = ApellidoM.Text;
                string carrera = Carrera.Text;
                string usuario = User.Text;
                string contraseña = Password.Text;

                // Establece la cadena de conexión
                string connectionString = "Data Source=DARWINAMAURY;Initial Catalog=Practica;Integrated Security=True";

                // Crea una nueva conexión SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crea la consulta SQL para actualizar el registro existente basado en la matrícula
                    string query = "UPDATE Registro SET Nombre = @Nombre, [Apellido Paterno] = @ApellidoPaterno, [Apellido Materno] = @ApellidoMaterno, Carrera = @Carrera, Usuario=@usuario, Contraseña=@contraseña WHERE [Numero de control] = @Matricula";

                    // Crea un objeto SqlCommand con la consulta SQL y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agrega los parámetros a la consulta SQL
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                        command.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                        command.Parameters.AddWithValue("@Carrera", carrera);
                        command.Parameters.AddWithValue("@Matricula", matricula);

                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);


                        try
                        {
                            // Abre la conexión
                            connection.Open();

                            // Ejecuta la consulta SQL (actualiza el registro en la base de datos)
                            int rowsAffected = command.ExecuteNonQuery();

                            // Cierra la conexión
                            connection.Close();

                            // Verifica si se actualizó el registro
                            if (rowsAffected > 0)
                            {
                                // Muestra un mensaje indicando que el registro ha sido actualizado
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro actualizado correctamente.');", true);
                                // Recarga los datos en el GridView después de la actualización
                                LoadData();
                            }
                            else
                            {
                                // Muestra un mensaje si no se encontró el registro para actualizar
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encontró el registro para actualizar.');", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Muestra un mensaje si hay un error en la base de datos
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Error al actualizar el registro: " + ex.Message + "');", true);
                            // MessageBox.Show("Error al actualizar el registro: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // Muestra un mensaje si la matrícula no es un número válido
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, ingrese una matrícula válida (números enteros) para buscar.');", true);
            }

            // Limpia los TextBox después de actualizar
            Nombre.Text = "";
            ApellidoP.Text = "";
            ApellidoM.Text = "";
            Matricula.Text = "";
            Carrera.Text = "";
            User.Text = "";
            Password.Text = "";
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Matricula.Text, out int matricula))
            {
                string connectionString = "Data Source=DARWINAMAURY;Initial Catalog=Practica;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Registro WHERE [Numero de control] = @NumeroDeControl";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NumeroDeControl", matricula);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro eliminado correctamente.');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encontró el registro para eliminar.');", true);
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Error al eliminar el registro: " + ex.Message + "');", true);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, ingrese una matrícula válida (números enteros).');", true);
            }

            Nombre.Text = "";
            ApellidoP.Text = "";
            ApellidoM.Text = "";
            Matricula.Text = "";
            Carrera.Text = "";
            User.Text = "";
            Password.Text = "";

            // Recarga los datos en el GridView después de la eliminación
            LoadData();
        }

    }
}
