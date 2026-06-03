using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace CRUDReservaciones6133261
{
    //puse validaciones como IsNullOrEmpty para que se ingrese un dato obligatoriamente
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtEmpleadoID.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleInitial.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtPhone.Text = "";
            txtEmailAddress.Text = "";
            txtContraseña.Text = "";
            ddlEstado.SelectedIndex = 0;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Campos limpiados')", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleadoID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de empleado para buscar')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Employee WHERE EmpleadoID = " + txtEmpleadoID.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtMiddleInitial.Text = ds.Tables[0].Rows[0]["MiddleInitial"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txtEmailAddress.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    txtContraseña.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    ddlEstado.SelectedValue = ds.Tables[0].Rows[0]["Estado"].ToString();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Empleado encontrado')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Empleado no encontrado')", true);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleadoID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de empleado')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Employee (EmpleadoID, LastName, FirstName, MiddleInitial, Address, City, State, ZipCode, Phone, EmailAddress, [Password], Estado) VALUES (" + txtEmpleadoID.Text + ", '" + txtLastName.Text.Replace("'", "''") + "', '" + txtFirstName.Text.Replace("'", "''") + "', '" + txtMiddleInitial.Text.Replace("'", "''") + "', '" + txtAddress.Text.Replace("'", "''") + "', '" + txtCity.Text.Replace("'", "''") + "', '" + txtState.Text.Replace("'", "''") + "', '" + txtZipCode.Text.Replace("'", "''") + "', '" + txtPhone.Text.Replace("'", "''") + "', '" + txtEmailAddress.Text.Replace("'", "''") + "', '" + txtContraseña.Text.Replace("'", "''") + "', '" + ddlEstado.SelectedValue + ")", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Guardados')", true);
            btnShow_Click(sender, e);
            btnNew_Click(sender, e);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleadoID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Busque un empleado primero')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("UPDATE Employee SET LastName='" + txtLastName.Text.Replace("'", "''") + "', FirstName='" + txtFirstName.Text.Replace("'", "''") + "', MiddleInitial='" + txtMiddleInitial.Text.Replace("'", "''") + "', Address='" + txtAddress.Text.Replace("'", "''") + "', City='" + txtCity.Text.Replace("'", "''") + "', State='" + txtState.Text.Replace("'", "''") + "', ZipCode='" + txtZipCode.Text.Replace("'", "''") + "', Phone='" + txtPhone.Text.Replace("'", "''") + "', EmailAddress='" + txtEmailAddress.Text.Replace("'", "''") + "', [Password]='" + txtContraseña.Text.Replace("'", "''") + "', Estado='" + ddlEstado.SelectedValue + "' WHERE EmpleadoID = " + txtEmpleadoID.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Actualizados')", true);
            btnShow_Click(sender, e);
            btnNew_Click(sender, e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleadoID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Busque un empleado primero')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("DELETE FROM Employee WHERE EmpleadoID = " + txtEmpleadoID.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Eliminados')", true);
            btnShow_Click(sender, e);
            btnNew_Click(sender, e);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Employee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvEmpleados.DataSource = ds.Tables[0];
                gvEmpleados.DataBind();
            }
        }
    }
}