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
    public partial class Form3 : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        private SqlDataAdapter dal;
        private SqlDataReader dr1;

        public Form3()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conce();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
        }

        private void llenar()
        {
            try
            {
                conn.Open();
                string sql = "SELECT id_Cliente, NombreCliente FROM CLIENTES";
                SqlCommand cmd = new SqlCommand(sql, conn);
                dr1 = cmd.ExecuteReader();

                cbCliente.Items.Clear();

                while (dr1.Read())
                {
                    cbCliente.Items.Add(dr1["id_Cliente"].ToString() + " - " + dr1["NombreCliente"].ToString());
                }

                dr1.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            llenar();
            dTime1.Value = DateTime.Now;
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numero;

            if (cbCliente.SelectedItem != null)
            {
                string selected = cbCliente.SelectedItem.ToString();
                string[] parts = selected.Split('-');
                string idCliente = parts[0].Trim();

                if (int.TryParse(idCliente, out numero))
                {
                    try
                    {
                        conn.Open();
                        string seleccion = "SELECT NombreCliente FROM CLIENTES WHERE id_Cliente = " + numero;
                        SqlCommand cmd = new SqlCommand(seleccion, conn);
                        string nombre = cmd.ExecuteScalar()?.ToString();
                        lbNombreC.Text = nombre;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnIngresarP_Click(object sender, EventArgs e)
        {
            if (cbCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                string selected = cbCliente.SelectedItem.ToString();
                string[] parts = selected.Split('-');
                int idCliente = int.Parse(parts[0].Trim());

                string sql = "INSERT INTO PEDIDOS (id_Cliente, CantidadPedido, FechaPedido) VALUES (@idCliente, @cantidad, @fecha)";
                insert1 = new SqlCommand(sql, conn);
                insert1.Parameters.AddWithValue("@idCliente", idCliente);
                insert1.Parameters.AddWithValue("@cantidad", (int)nUDcant.Value);
                insert1.Parameters.AddWithValue("@fecha", dTime1.Value.ToShortDateString());

                int resultado = insert1.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Pedido ingresado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El registro no fue agregado...", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
                btnLimpiarP_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar pedido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarP_Click(object sender, EventArgs e)
        {
            cbCliente.SelectedIndex = -1;
            nUDcant.Value = 1;
            dTime1.Value = DateTime.Now;
            lbNombreC.Text = "";
        }

        private void btnVolverP_Click(object sender, EventArgs e)
        {
            Form1 formu1 = new Form1();
            formu1.Show();
            this.Hide();
        }
    }
}
