using System.Data.SqlClient;
using System.Data;

public static void InsertarPlanta(Planta p)
{
    using (SqlConnection con = Conexion.ObtenerConexion())
    {
        SqlCommand cmd = new SqlCommand("InsertarPlanta", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
        cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
        cmd.Parameters.AddWithValue("@FechaRegistro", p.FechaRegistro);
        cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
        con.Open();
        cmd.ExecuteNonQuery();
    }
}
