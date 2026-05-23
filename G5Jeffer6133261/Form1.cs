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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Server=JEFFERSONARCE77\\SQLEXPRESS;database=master;integrated security=yes;TrustServerCertificate=True;");

            // Comandos T-SQL para crear la base de datos y tablas

            string CrearDB = "CREATE DATABASE DBG5Jeffer6133261";

            string tClientes = "USE DBG5Jeffer6133261; " +
                "CREATE TABLE CLIENTES(" +
                "id_Cliente int IDENTITY(1,1), " +
                "NombreCliente varchar(40), " +
                "CONSTRAINT PK_cliente PRIMARY KEY(id_Cliente));";

            string tPedidos = "USE DBG5Jeffer6133261; " +
                "CREATE TABLE PEDIDOS(" +
                "id_Pedido int IDENTITY(1,1), " +
                "id_Cliente int not null, " +
                "CantidadPedido int, " +
                "FechaPedido varchar(70), " +
                "CONSTRAINT PK_pedido PRIMARY KEY(id_Pedido), " +
                "CONSTRAINT FK_Cliente FOREIGN KEY(id_Cliente) " +
                "REFERENCES CLIENTES(id_Cliente));";

            SqlCommand cmd = new SqlCommand(CrearDB, cnn);
            SqlCommand cmd1 = new SqlCommand(tClientes, cnn);
            SqlCommand cmd2 = new SqlCommand(tPedidos, cnn);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();   
                cmd1.ExecuteNonQuery();  
                cmd2.ExecuteNonQuery();  
                cnn.Close();

                MessageBox.Show("Base de datos creada correctamente...", "Generar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear la Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form2 formu1 = new Form2();
            formu1.Show();
            this.Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            Form3 formu1 = new Form3();
            formu1.Show();
            this.Hide();
        }
    }
}
