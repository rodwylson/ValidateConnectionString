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

namespace ValidateConnectionString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
           var dataSource = txtDataSource.Text;            
           var initialCatalog = txtDataBase.Text;
           var user = txtUser.Text;
           var pass = txtPass.Text;
            var teste = "";
            string connectionString = $"Password={pass}" +
                                      $";Persist Security Info=True" +
                                      $";User ID={user}" +
                                      $";Initial Catalog={initialCatalog}" +
                                      $";Data Source={dataSource}" +
                                      $";application name=SML portal";
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    lblMsgStatus.Text = "CONECTADO";
                    lblMsgStatus.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMsgStatus.Text = "Error";
                    txtMsg.Text = $"Error: \n {ex.Message}";
                    lblMsgStatus.Visible = true;
                }
               
              /*  //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT TOP 2 * FROM Dogs1", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }*/
            }


        }
    }
}
