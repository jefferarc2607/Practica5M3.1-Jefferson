using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G5Jeffer6133261
{
    public partial class Form2 : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string scn;

        public Form2()
        {
            InitializeComponent();

            conexion cn = new conexion();
            cn.conce();
            scn = cn.cadena;  
            conn = new SqlConnection(scn);
        }

        private void btnIngresarC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string sql = "INSERT INTO CLIENTES (NombreCliente) VALUES (@nombre)";
                insert1 = new SqlCommand(sql, conn);
                insert1.Parameters.AddWithValue("@nombre", txtCliente.Text);
                insert1.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Cliente ingresado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCliente.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarC_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
        }

        private void btnVolverC_Click(object sender, EventArgs e)
        {
            Form1 formu1 = new Form1();
            formu1.Show();
            this.Hide();
        }
    }
}
