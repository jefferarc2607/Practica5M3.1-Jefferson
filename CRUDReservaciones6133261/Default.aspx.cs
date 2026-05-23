using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDReservaciones6133261
{
    public partial class Default : System.Web.UI.Page
    {
        string rutaDB = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\AcessDB\Reservaciones.accdb";

        private const decimal PRECIO_ESTANDAR = 50m;
        private const decimal PRECIO_JUNIOR = 85m;
        private const decimal PRECIO_SUITE = 150m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpiarCampos();
                MostrarTodasLasReservaciones();
                ddlTipoHabitacion.SelectedIndex = 0;
            }
        }

        private OleDbConnection ConectarDB()
        {
            return new OleDbConnection(rutaDB);
        }

        private void MostrarTodasLasReservaciones()
        {
            try
            {
                using (OleDbConnection conn = ConectarDB())
                {
                    conn.Open();
                    string query = "SELECT * FROM Reservaciones ORDER BY Id DESC";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvReservaciones.DataSource = dt;
                    gvReservaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al mostrar datos: " + ex.Message, false);
            }
        }

        private void BuscarReservacionPorId(int id)
        {
            try
            {
                using (OleDbConnection conn = ConectarDB())
                {
                    conn.Open();
                    string query = "SELECT * FROM Reservaciones WHERE Id = @Id";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["NombreCliente"].ToString();
                        txtApellido.Text = reader["ApellidoCliente"].ToString();
                        txtDocumento.Text = reader["Documento"].ToString();
                        txtTelefono.Text = reader["Telefono"].ToString();
                        txtCorreo.Text = reader["Correo"].ToString();

                        string tipo = reader["TipoHabitacion"].ToString();
                        ddlTipoHabitacion.SelectedValue = tipo;

                        txtFechaEntrada.Text = Convert.ToDateTime(reader["FechaEntrada"]).ToString("yyyy-MM-dd");
                        txtFechaSalida.Text = Convert.ToDateTime(reader["FechaSalida"]).ToString("yyyy-MM-dd");
                        txtNumeroPersonas.Text = reader["NumeroPersonas"].ToString();
                        ddlEstado.SelectedValue = reader["Estado"].ToString();
                        txtMontoTotal.Text = Convert.ToDecimal(reader["MontoTotal"]).ToString("N2");

                        lblMensaje.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("No se encontró ninguna reservación con ID: " + id, false);
                        LimpiarCampos();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al buscar: " + ex.Message, false);
            }
        }

        private decimal CalcularMontoTotal()
        {
            if (string.IsNullOrEmpty(txtFechaEntrada.Text) || string.IsNullOrEmpty(txtFechaSalida.Text))
                return 0;

            try
            {
                DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
                DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);

                if (fechaSalida <= fechaEntrada)
                    return 0;

                int noches = (fechaSalida - fechaEntrada).Days;

                decimal precioPorNoche = 0;
                string tipo = ddlTipoHabitacion.SelectedValue;

                switch (tipo)
                {
                    case "Estandar":
                        precioPorNoche = PRECIO_ESTANDAR;
                        break;
                    case "Junior":
                        precioPorNoche = PRECIO_JUNIOR;
                        break;
                    case "Suite":
                        precioPorNoche = PRECIO_SUITE;
                        break;
                    default:
                        return 0;
                }

                return noches * precioPorNoche;
            }
            catch
            {
                return 0;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            ddlTipoHabitacion.SelectedIndex = 0;
            txtFechaEntrada.Text = "";
            txtFechaSalida.Text = "";
            txtNumeroPersonas.Text = "";
            ddlEstado.SelectedIndex = 0;
            txtMontoTotal.Text = "";
            lblMensaje.Visible = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarMensaje("El nombre es obligatorio", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MostrarMensaje("El apellido es obligatorio", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MostrarMensaje("El documento es obligatorio", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MostrarMensaje("El teléfono es obligatorio", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarMensaje("El correo es obligatorio", false);
                return false;
            }
            if (string.IsNullOrEmpty(ddlTipoHabitacion.SelectedValue))
            {
                MostrarMensaje("Seleccione un tipo de habitación", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFechaEntrada.Text))
            {
                MostrarMensaje("La fecha de entrada es obligatoria", false);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFechaSalida.Text))
            {
                MostrarMensaje("La fecha de salida es obligatoria", false);
                return false;
            }

            DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
            DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);

            if (fechaSalida <= fechaEntrada)
            {
                MostrarMensaje("La fecha de salida debe ser posterior a la fecha de entrada", false);
                return false;
            }

            if (fechaEntrada < DateTime.Today)
            {
                MostrarMensaje("La fecha de entrada no puede ser anterior a hoy", false);
                return false;
            }

            return true;
        }

        private void MostrarMensaje(string mensaje, bool esExito)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "mensaje " + (esExito ? "alert-success" : "alert-danger");
            lblMensaje.Visible = true;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtId.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                int id;
                if (int.TryParse(txtId.Text, out id))
                {
                    BuscarReservacionPorId(id);
                }
                else
                {
                    MostrarMensaje("Ingrese un ID válido", false);
                }
            }
            else
            {
                MostrarMensaje("Ingrese un ID para buscar", false);
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFechaEntrada.Text) && !string.IsNullOrEmpty(txtFechaSalida.Text))
            {
                decimal monto = CalcularMontoTotal();
                txtMontoTotal.Text = monto.ToString("N2");
                MostrarMensaje("Monto calculado: US$ " + monto.ToString("N2"), true);
            }
            else
            {
                MostrarMensaje("Seleccione las fechas de entrada y salida", false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                using (OleDbConnection conn = ConectarDB())
                {
                    conn.Open();
                    string query = @"INSERT INTO Reservaciones 
                        (NombreCliente, ApellidoCliente, Documento, Telefono, Correo, TipoHabitacion, 
                         FechaEntrada, FechaSalida, NumeroPersonas, Estado, MontoTotal) 
                        VALUES (@Nombre, @Apellido, @Documento, @Telefono, @Correo, @TipoHabitacion, 
                                @FechaEntrada, @FechaSalida, @NumeroPersonas, @Estado, @MontoTotal)";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@TipoHabitacion", ddlTipoHabitacion.SelectedValue);
                    cmd.Parameters.AddWithValue("@FechaEntrada", DateTime.Parse(txtFechaEntrada.Text));
                    cmd.Parameters.AddWithValue("@FechaSalida", DateTime.Parse(txtFechaSalida.Text));
                    cmd.Parameters.AddWithValue("@NumeroPersonas", Convert.ToInt32(txtNumeroPersonas.Text));
                    cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);

                    decimal monto = CalcularMontoTotal();
                    cmd.Parameters.AddWithValue("@MontoTotal", monto);
                    txtMontoTotal.Text = monto.ToString("N2");

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MostrarMensaje("✅ Reservación guardada correctamente", true);
                        LimpiarCampos();
                        MostrarTodasLasReservaciones();
                    }
                    else
                    {
                        MostrarMensaje("Error al guardar la reservación", false);
                    }
                }
            }
            catch (OleDbException ex)
            {
                if (ex.Message.Contains("duplicado"))
                    MostrarMensaje("El documento DUI/NIT ya está registrado", false);
                else
                    MostrarMensaje("Error: " + ex.Message, false);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, false);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MostrarMensaje("Busque una reservación primero para actualizar", false);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                using (OleDbConnection conn = ConectarDB())
                {
                    conn.Open();
                    string query = @"UPDATE Reservaciones SET 
                        NombreCliente = @Nombre, ApellidoCliente = @Apellido, Documento = @Documento, 
                        Telefono = @Telefono, Correo = @Correo, TipoHabitacion = @TipoHabitacion,
                        FechaEntrada = @FechaEntrada, FechaSalida = @FechaSalida, 
                        NumeroPersonas = @NumeroPersonas, Estado = @Estado, MontoTotal = @MontoTotal 
                        WHERE Id = @Id";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@TipoHabitacion", ddlTipoHabitacion.SelectedValue);
                    cmd.Parameters.AddWithValue("@FechaEntrada", DateTime.Parse(txtFechaEntrada.Text));
                    cmd.Parameters.AddWithValue("@FechaSalida", DateTime.Parse(txtFechaSalida.Text));
                    cmd.Parameters.AddWithValue("@NumeroPersonas", Convert.ToInt32(txtNumeroPersonas.Text));
                    cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);

                    decimal monto = CalcularMontoTotal();
                    cmd.Parameters.AddWithValue("@MontoTotal", monto);
                    txtMontoTotal.Text = monto.ToString("N2");

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MostrarMensaje("✅ Reservación actualizada correctamente", true);
                        LimpiarCampos();
                        MostrarTodasLasReservaciones();
                    }
                    else
                    {
                        MostrarMensaje("No se encontró la reservación para actualizar", false);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al actualizar: " + ex.Message, false);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MostrarMensaje("Ingrese el ID de la reservación a eliminar", false);
                return;
            }

            try
            {
                using (OleDbConnection conn = ConectarDB())
                {
                    conn.Open();
                    string query = "DELETE FROM Reservaciones WHERE Id = @Id";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MostrarMensaje("✅ Reservación eliminada correctamente", true);
                        LimpiarCampos();
                        MostrarTodasLasReservaciones();
                    }
                    else
                    {
                        MostrarMensaje("No se encontró la reservación con ID: " + txtId.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar: " + ex.Message, false);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            MostrarTodasLasReservaciones();
        }

        protected void gvReservaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReservaciones.SelectedRow;
            if (row != null && row.Cells.Count > 0)
            {
                string id = row.Cells[0].Text;
                txtId.Text = id;
                BuscarReservacionPorId(Convert.ToInt32(id));
            }
        }
    }
}