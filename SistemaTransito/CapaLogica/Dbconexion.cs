using System.Configuration;
using System.Data.SqlClient;

public static class Conexion
{
    public static SqlConnection ObtenerConexion()
    {
        string cadena = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        return new SqlConnection(cadena);
    }
}
