using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ergasia_logismikou
{
    public partial class LoginForm : Form
    {
        Reader usr_reader=new Reader();
        User user=new User();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string status = user.login_status(usr_Textbox.Text, pw_Textbox.Text);
            //login check
            if (status.Equals("noexist"))
            {
                MessageBox.Show($"Username {usr_Textbox.Text} doesnt exist");
            }
            else if (status.Equals("wrongpw"))
            {
                MessageBox.Show($"Wrong Password for user {usr_Textbox.Text}");
            }
            else if (status.Equals("r") || status.Equals("w"))
            {
                MessageBox.Show("Successfull Login");
                if (status.Equals("r"))
                {
                    string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        try
                        {
                            // Open the connection
                            connection.Open();

                            string query = $"SELECT username,  role, fullname ,email, gender FROM Users WHERE username = '{usr_Textbox.Text}';";

                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                using (SQLiteDataReader reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {
                                        usr_reader.Username = reader.GetString(reader.GetOrdinal("username"));
                                        usr_reader.Gender = reader.GetString(reader.GetOrdinal("gender"));
                                        usr_reader.First_lastname= reader.GetString(reader.GetOrdinal("fullname"));
                                        usr_reader.Email = reader.GetString(reader.GetOrdinal("email"));
                                    }
                                    this.Hide();
                                    new ReaderForm(usr_reader).Show();
                                }
                            }

                            connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"ERROR {ex}");

                        }

                    }
                }
                else
                {
                    String username="",gender="",first_lastname="",email="";
                    string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        try
                        {
                            // Open the connection
                            connection.Open();
                            string query = $"SELECT username,  role, fullname ,email, gender FROM Users WHERE username = '{usr_Textbox.Text}';";
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                using (SQLiteDataReader reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {
                                        username = reader.GetString(reader.GetOrdinal("username"));
                                        gender = reader.GetString(reader.GetOrdinal("gender"));
                                        first_lastname = reader.GetString(reader.GetOrdinal("fullname"));
                                        email = reader.GetString(reader.GetOrdinal("email"));
                                    }
                                    this.Hide();
                                    new WriterForm(new Writer(username,gender,first_lastname,email)).Show();
                                }
                            }

                            connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"ERROR {ex}");

                        }
                    }
                }
                
            }
            else if (status.Equals("temp"))
            {
                MessageBox.Show("4");
            }

            else if (status.Equals("error"))
            {
                MessageBox.Show("5");
            }
           
            }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usr_Textbox.Clear();
            pw_Textbox.Clear();
        }
    }
}
