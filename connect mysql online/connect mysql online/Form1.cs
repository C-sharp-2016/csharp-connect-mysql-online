using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace connect_mysql_online
{
    public partial class Form1 : Form
    {

        MySqlConnection conn;
        string connString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connect_click(object sender, EventArgs e)
        { 
            try
            {
                connString = "SERVER=lifeafterpurchase.com;PORT=3306;DATABASE=twoleos_testing;UID=twoleos_testing;PASSWORD=twoleos_testing;";

                conn = new MySqlConnection();

                conn.ConnectionString = connString;
                conn.Open(); 
                MessageBox.Show("Connection Success!");



                string query = "SELECT * FROM users";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                {
                    Console.Write("| id = " + dataReader["id"]);
                    Console.Write("| username = " + dataReader["username"]);
                    Console.Write("| password = " + dataReader["password"]);
                    Console.Write("| created at = " + dataReader["created_at"]);
                    Console.WriteLine("");
                }






            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
