using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_logismikou
{
    public partial class QuestionForm : Form
    {
        private Reader reader;
        string writer;
        public QuestionForm(Reader reader)
        {
            InitializeComponent();
            this.reader = reader;

        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT fullname FROM Users WHERE role='w' ;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader.GetString(reader.GetOrdinal("fullname")));
                            }

                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }
                UpdateQ();
            }

            

        }

        private void UpdateQ()
        {
            reader.get_answered_Questions();
            int i = 0;
            flowLayoutPanel1.Controls.Clear();
            List<Panel> p = new List<Panel>();
            p.Clear();
            List<Label> top_l = new List<Label>();
            top_l.Clear();
            List<Label> bottom_l = new List<Label>();
            bottom_l.Clear();
            foreach (string item in reader.question)
            {
                int currentIndex = i;
                //ftiaxe panel
                p.Add(new Panel());
                top_l.Add(new Label());
                bottom_l.Add(new Label());
                p[i].Width = flowLayoutPanel1.Width-15;
                p[i].Height = 150;
                p[i].BorderStyle = BorderStyle.FixedSingle;
                p[i].Show();

                top_l[i].Text ="Ερώτηση προς "+reader.to[i]+": "+reader.question[i];
                top_l[i].Font = new Font("Arial", 12);
                top_l[i].Location = new Point(0, 0);
                top_l[i].AutoSize = true;
                top_l[i].MaximumSize = new Size(p[i].Width-10, 60); 
                top_l[i].Show();

                bottom_l[i].Text ="Απάντηση: "+reader.answer[i]  ;
                bottom_l[i].Font = new Font("Arial", 12);
                bottom_l[i].AutoSize = true;
                bottom_l[i].MaximumSize = new Size(p[i].Width - 10, 60);
                bottom_l[i].Location = new Point(0, 80);
                bottom_l[i].Show();

                p[i].Controls.Add(bottom_l[i]);
                p[i].Controls.Add(top_l[i]);
                flowLayoutPanel1.Controls.Add(p[i]);

                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Assuming textBox1.Text contains the value you want to insert
                    string query = $"INSERT INTO Comments_to_writer(writen_by,writen_to,status,question) VALUES (@reader,@writer,@status,@question)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Use parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@reader", reader.First_lastname);
                        command.Parameters.AddWithValue("@writer", writer);
                        command.Parameters.AddWithValue("@status", "sent");
                        command.Parameters.AddWithValue("@question", richTextBox1.Text);

                        // Execute the query without using ExecuteReader for INSERT
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Επιτυχής Αποστολή!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Αποτυχία");
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: {ex.Message}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            writer = comboBox1.SelectedItem.ToString();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
