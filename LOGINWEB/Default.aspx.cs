using System;
using System.Data.SqlClient;

namespace LOGINWEB
{
    public partial class _Default : System.Web.UI.Page
    {
        // Ajusta la cadena de conexión según tu entorno
        string connectionString = "Data Source=DARWINAMAURY;Initial Catalog=Practica;Integrated Security=True";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = username.Text.Trim();
            string contraseña = password.Text.Trim();

            // Verificar que el nombre de usuario y la contraseña no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                // Muestra un mensaje de error
                lblErrorMessage.Text = "Por favor, ingrese usuario y contraseña.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Usuario, Contraseña FROM Registro WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Credenciales válidas, redirigir a la página de bienvenida
                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        // Credenciales inválidas, mostrar mensaje de error
                        lblErrorMessage.Text = "Usuario o contraseña incorrectos.";
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de registro (o realizar alguna acción adicional)
            Response.Redirect("RegistroPage.aspx");
        }
    }
}
