using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace CRUDReservaciones6133261
{
    public partial class Reservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaSalida.Text = "";
            txtPersonas.Text = "";
            ddlEstado.SelectedIndex = 0;
            ddlTipoHabitacion.SelectedIndex = 0;
            txtMontoTotal.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Campos limpiados')", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Reservaciones WHERE Id = " + txtId.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtNombre.Text = ds.Tables[0].Rows[0]["NombreCliente"].ToString();
                    txtApellido.Text = ds.Tables[0].Rows[0]["ApellidoCliente"].ToString();
                    txtDocumento.Text = ds.Tables[0].Rows[0]["Documento"].ToString();
                    txtTelefono.Text = ds.Tables[0].Rows[0]["Telefono"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Correo"].ToString();
                    ddlTipoHabitacion.SelectedValue = ds.Tables[0].Rows[0]["TipoHabitacion"].ToString();
                    txtFechaIngreso.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaEntrada"]).ToString("yyyy-MM-dd");
                    txtFechaSalida.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaSalida"]).ToString("yyyy-MM-dd");
                    txtPersonas.Text = ds.Tables[0].Rows[0]["NumeroPersonas"].ToString();
                    ddlEstado.SelectedValue = ds.Tables[0].Rows[0]["Estado"].ToString();
                    txtMontoTotal.Text = ds.Tables[0].Rows[0]["MontoTotal"].ToString();
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Buscado')", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlTipoHabitacion.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seleccione un tipo de habitacion')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Reservaciones (NombreCliente, ApellidoCliente, Documento, Telefono, Correo, FechaEntrada, FechaSalida, NumeroPersonas, TipoHabitacion, Estado, MontoTotal) VALUES ('" + txtNombre.Text.Replace("'", "''") + "', '" + txtApellido.Text.Replace("'", "''") + "', '" + txtDocumento.Text.Replace("'", "''") + "', '" + txtTelefono.Text.Replace("'", "''") + "', '" + txtEmail.Text.Replace("'", "''") + "', #" + txtFechaIngreso.Text + "#, #" + txtFechaSalida.Text + "#, " + txtPersonas.Text + ", '" + ddlTipoHabitacion.SelectedValue + "', '" + ddlEstado.SelectedValue + "', " + txtMontoTotal.Text + ")", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Guardados')", true);
            btnShow_Click(sender, e);
            btnNew_Click(sender, e);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("UPDATE Reservaciones SET NombreCliente='" + txtNombre.Text.Replace("'", "''") + "', ApellidoCliente='" + txtApellido.Text.Replace("'", "''") + "', Documento='" + txtDocumento.Text.Replace("'", "''") + "', Telefono='" + txtTelefono.Text.Replace("'", "''") + "', Correo='" + txtEmail.Text.Replace("'", "''") + "', FechaEntrada=#" + txtFechaIngreso.Text + "#, FechaSalida=#" + txtFechaSalida.Text + "#, NumeroPersonas=" + txtPersonas.Text + ", TipoHabitacion='" + ddlTipoHabitacion.SelectedValue + "', Estado='" + ddlEstado.SelectedValue + "', MontoTotal=" + txtMontoTotal.Text + " WHERE Id=" + txtId.Text, con); 
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Actualizados')", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("DELETE FROM Reservaciones WHERE Id = " + txtId.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Eliminados')", true);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Reservaciones ORDER BY Id DESC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvReservaciones.DataSource = ds.Tables[0];
                gvReservaciones.DataBind();
            }
        }

        //metodos para calculo del monto segun el tipo de habitacion, personas, etc. YA QUE NO INGRESABA MONTO TOTAL, PROFE SI LO HICE YO :(
        protected void ddlTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoHabitacion.SelectedValue;

            if (tipo == "Individual")
                txtMontoTotal.Text = "50";
            else if (tipo == "Doble")
                txtMontoTotal.Text = "85";
            else if (tipo == "Suite")
                txtMontoTotal.Text = "120";
            else
                txtMontoTotal.Text = "";
        }


    }
}