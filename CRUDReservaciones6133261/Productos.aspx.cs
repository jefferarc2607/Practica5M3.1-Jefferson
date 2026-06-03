using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace CRUDReservaciones6133261
{
    //puse validaciones como IsNullOrEmpty para que se ingrese un dato obligatoriamente
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtSupplierID.Text = "";
            txtProduct.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtNumberInStock.Text = "";
            txtNumberOnOrder.Text = "";
            txtReorderLevel.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Campos limpiados')", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de categoría para buscar')", true);
                return;
            }

            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Product WHERE CategoryID = " + txtCategoryID.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSupplierID.Text = ds.Tables[0].Rows[0]["SupplierID"].ToString();
                    txtProduct.Text = ds.Tables[0].Rows[0]["Product"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtNumberInStock.Text = ds.Tables[0].Rows[0]["NumberInStock"].ToString();
                    txtNumberOnOrder.Text = ds.Tables[0].Rows[0]["NumberOnOrder"].ToString();
                    txtReorderLevel.Text = ds.Tables[0].Rows[0]["ReorderLevel"].ToString();
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Buscado')", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de categoría para buscar')", true);
                return;
            }
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Product (CategoryID, SupplierID, Product, Description, Price, NumberInStock, NumberOnOrder, ReorderLevel) VALUES (" + txtCategoryID.Text + ", " + txtSupplierID.Text + ", '" + txtProduct.Text + "', '" + txtDescription.Text + "', " + txtPrice.Text + ", " + txtNumberInStock.Text + ", " + txtNumberOnOrder.Text + ", " + txtReorderLevel.Text + ")", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Guardados')", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de categoría para buscar')", true);
                return;
            }
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("UPDATE Product SET SupplierID=" + txtSupplierID.Text + ", Product='" + txtProduct.Text + "', Description='" + txtDescription.Text + "', Price=" + txtPrice.Text + ", NumberInStock=" + txtNumberInStock.Text + ", NumberOnOrder=" + txtNumberOnOrder.Text + ", ReorderLevel=" + txtReorderLevel.Text + " WHERE CategoryID=" + txtCategoryID.Text, con); DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Actualizados')", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingrese un ID de categoría para buscar')", true);
                return;
            }
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("DELETE FROM Product WHERE CategoryID = " + txtCategoryID.Text, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos Eliminados')", true);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = conexion.conec())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Product", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvProductos.DataSource = ds.Tables[0];
                gvProductos.DataBind();
            }
        }
    }
}