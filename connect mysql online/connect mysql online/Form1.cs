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
            this.connection();
        }

        private void connect_click(object sender, EventArgs e)
        {
            insert();

            query();

            conn.Close();
        }



        private void connection() {
            try
            {
                connString = "SERVER=lifeafterpurchase.com;PORT=3306;DATABASE=twoleos_testing;UID=twoleos_testing;PASSWORD=twoleos_testing;";

                conn = new MySqlConnection();

                conn.ConnectionString = connString;
             
                Console.WriteLine("Successfully Connected To Server");
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             

        }
        private void insert() {

            conn.Open();

                string query = "INSERT INTO users (username) VALUES ('tom')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

            conn.Close();
             
          
        }
        private void delete() { }
        private void update() { }
        private void query() {

            conn.Open();

                string query = "SELECT * FROM users";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.Write("| id = " + dataReader["id"]);
                    Console.Write("| username = " + dataReader["username"]);
                    Console.Write("| password = " + dataReader["password"]);
                    Console.Write("| created at = " + dataReader["created_at"]);
                    Console.WriteLine("");
                }


            conn.Close();

        }


    }
}
