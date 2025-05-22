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
    public partial class BookForm : Form
    {

        ContactForm a = new ContactForm();
        ForUs b = new ForUs();
        Book book;
        ReaderForm f;
        Reader r;
        List<string> comment_text = new List<string>();
        List<string> by = new List<string>();
        public BookForm(Book book,ReaderForm f,Reader r)
        {
            InitializeComponent();
            this.book = book;
            this.f = f;
            this.r = r;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            label1.Text = book.Title;
            label4.Text=book.Writer;
            UpdateLabel();
            label2.Text = book.Summary;
            label3.Text = book.Price.ToString() + "$";
            pictureBox1.ImageLocation = "images\\" + book.Image;
            Update_comments();
        }

        private void εΠΙΚΟΙΝΩΝΙΑToolStripMenuItem_Click(object sender, EventArgs e)
        {

            a.Hide();
            a.Show();

        }

        private void γΙΑΜΑΣToolStripMenuItem_Click(object sender, EventArgs e)
        {

            b.Hide();
            b.Show();

        }

        private void sTARTPAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            f.Show();
        }

        private void εΞΟΔΟΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Equals("Γράψτε ένα σχόλιο"))
            {
                richTextBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.review(book,r.First_lastname,richTextBox1.Text);
            Update_comments();
            richTextBox1.Clear();
            richTextBox1.Text = "Γράψτε ένα σχόλιο";
        }

        private void Update_comments()
        {
            comment_text.Clear();
            by.Clear();
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;"; 
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT writen_by,comment FROM Comments_book WHERE book_id='{book.Id}';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader()) 
                                                                              
                        {

                            while (reader.Read()) 
                            {
                                by.Add(reader.GetString(reader.GetOrdinal("writen_by"))) ; 
                                comment_text.Add(reader.GetString(reader.GetOrdinal("comment"))) ;
                            }

                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");  
                }

            }
           
            flowLayoutPanel1.Controls.Clear();
            int i = 0;
            List<Panel> p = new List<Panel>();
            p.Clear();
            List<Label> top_l = new List<Label>();
            top_l.Clear();
            List<Label> bottom_l = new List<Label>();
            bottom_l.Clear();
            foreach (string item in comment_text)
            {
                int currentIndex = i;
                //ftiaxe panel
                p.Add(new Panel());
                top_l.Add(new Label());
                bottom_l.Add(new Label());
                p[i].Width = 533;
                p[i].Height = 44;
                 p[i].BackColor = Color.Pink;
                p[i].BorderStyle = BorderStyle.FixedSingle;
                p[i].Show();


                top_l[i].Text = item;
                top_l[i].Font = new Font("Arial", 10, FontStyle.Bold);
                top_l[i].Location = new Point(0, 0);
                top_l[i].AutoSize = true;
                top_l[i].MaximumSize = new Size(0, 140); ;
                top_l[i].Show();

                bottom_l[i].Text ="-"+by[i];
                bottom_l[i].Location = new Point(400,30);
                bottom_l[i].Font = new Font("Arial", 8, FontStyle.Bold);
                bottom_l[i].AutoSize = true;
                bottom_l[i].MaximumSize = new Size(0, 0); ;
                bottom_l[i].Show();


                p[i].Controls.Add(bottom_l[i]);
                p[i].Controls.Add(top_l[i]);
                flowLayoutPanel1.Controls.Add(p[i]);

                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(f.cart_books.Contains(book) )
            {
                MessageBox.Show("Το βιβλιο είναι ήδη στο καλάθι");
            }
            else
            {
                f.cart_books.Add(book);
                f.UpdateLabel();
                label5.Text = f.cart_books.Count.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UpdateLabel();
            new CartForm(f).Show();

        }
        private void UpdateLabel()
        {
            label5.Text = f.cart_books.Count.ToString();
           
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
