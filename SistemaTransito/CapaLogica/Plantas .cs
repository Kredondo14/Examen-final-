using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TuProyecto
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categoria", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                gvCategorias.DataSource = dr;
                gvCategorias.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (string.IsNullOrEmpty(hfIdCategoria.Value))
                {
                    cmd.CommandText = "InsertarCategoria";
                }
                else
                {
                    cmd.CommandText = "ActualizarCategoria";
                    cmd.Parameters.AddWithValue("@IdCategoria", int.Parse(hfIdCategoria.Value));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();

                lblMensaje.Text = "Categoría guardada correctamente.";
                LimpiarFormulario();
                CargarCategorias();
            }
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idCategoria = (int)gvCategorias.DataKeys[e.NewEditIndex].Value;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categoria WHERE IdCategoria = @Id", con);
                cmd.Parameters.AddWithValue("@Id", idCategoria);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    hfIdCategoria.Value = dr["IdCategoria"].ToString();
                    txtNombre.Text = dr["Nombre"].ToString();
                }
            }
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idCategoria = (int)gvCategorias.DataKeys[e.RowIndex].Value;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("EliminarCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMensaje.Text = "Categoría eliminada.";
            CargarCategorias();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hfIdCategoria.Value = "";
            txtNombre.Text = "";
        }
    }
}


