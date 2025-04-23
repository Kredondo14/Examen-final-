using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TuProyecto
{
    public partial class Plantas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarPlantas();
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdCategoria, Nombre FROM Categoria", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ddlCategoria.DataSource = dr;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
            }
            ddlCategoria.Items.Insert(0, new ListItem("-- Selecciona --", "-1"));
        }

        private void CargarPlantas()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerPlantas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPlantas.DataSource = dt;
                gvPlantas.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCategoria = int.Parse(ddlCategoria.SelectedValue);
            if (idCategoria == -1) return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (string.IsNullOrEmpty(hfIdPlanta.Value))
                {
                    cmd.CommandText = "InsertarPlanta";
                }
                else
                {
                    cmd.CommandText = "ActualizarPlanta";
                    cmd.Parameters.AddWithValue("@IdPlanta", int.Parse(hfIdPlanta.Value));
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                con.Open();
                cmd.ExecuteNonQuery();

                lblMensaje.Text = "Datos guardados correctamente.";
                LimpiarFormulario();
                CargarPlantas();
            }
        }

        protected void gvPlantas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idPlanta = (int)gvPlantas.DataKeys[e.NewEditIndex].Value;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Planta WHERE IdPlanta = @Id", con);
                cmd.Parameters.AddWithValue("@Id", idPlanta);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    hfIdPlanta.Value = dr["IdPlanta"].ToString();
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtDescripcion.Text = dr["Descripcion"].ToString();
                    ddlCategoria.SelectedValue = dr["IdCategoria"].ToString();
                }
            }
        }

        protected void gvPlantas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPlanta = (int)gvPlantas.DataKeys[e.RowIndex].Value;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("EliminarPlanta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPlanta", idPlanta);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            lblMensaje.Text = "Planta eliminada.";
            CargarPlantas();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            hfIdPlanta.Value = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            ddlCategoria.SelectedIndex = 0;
        }
    }
}
