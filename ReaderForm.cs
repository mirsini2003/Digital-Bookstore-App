using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_logismikou
{
    public partial class ReaderForm : Form
    {
        ToolTip t1 = new ToolTip();
        ContactForm a = new ContactForm();
        ForUs b=new ForUs();
        List<Book> books = new List<Book>();
        public List<Book> cart_books = new List<Book>();  //ta biblia pou einai mesa sto kalathi
        Reader reader;
        public ReaderForm(Reader reader)
        {
            InitializeComponent();
            //basi
            books = new Book().get_all_books();
            this.reader = reader;
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

        private void ReaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void aLLBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void οΛΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_books("all");

        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void εΠΙΣΤΗΜΟΝΙΚΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_books("science");
        }

        private void αΣΤΥΝΟΜΙΚΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_books("police");
        }

        private void τΡΟΜΟΥToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_books("horror");
        }

        private void πΟΙΗΣΗΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_books("poetry");
        }

        private void sTARTPAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Display_books(string req,string key,int i)
        {
            if (req.Equals("writer"))
            {

                List<Panel> p = new List<Panel>();
                p.Clear();
                List<Label> top_l = new List<Label>();
                top_l.Clear();
                List<Label> bottom_l = new List<Label>();
                bottom_l.Clear();
                List<PictureBox> pic = new List<PictureBox>();
                pic.Clear();

                foreach (Book item in books)
                {

                    if (item.Writer.Equals(key))
                    {
                        int currentIndex = i;
                        //ftiaxe panel
                        p.Add(new Panel());
                        top_l.Add(new Label());
                        bottom_l.Add(new Label());
                        pic.Add(new PictureBox());
                        p[i].Width = 150;
                        p[i].Height = 240;
                        p[i].BorderStyle = BorderStyle.FixedSingle;
                        p[i].Show();
                        p[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        p[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        p[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };


                        pic[i].Width = 150;
                        pic[i].Height = 180;
                        pic[i].ImageLocation = "images\\" + item.Image;
                        pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pic[i].Show();
                        pic[i].Enabled = false;

                        top_l[i].Text = item.Title;
                        top_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        top_l[i].Location = new Point(0, 180);
                        top_l[i].AutoSize = true;
                        top_l[i].MaximumSize = new Size(140, 0); ;
                        top_l[i].Show();
                        top_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        top_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        top_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //top_l[i].Enabled = false;

                        bottom_l[i].Text = item.Price.ToString() + "$";
                        bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        bottom_l[i].Location = new Point(0, 220);
                        bottom_l[i].Show();
                        bottom_l[i].ForeColor = Color.Red;
                        bottom_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        bottom_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        bottom_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //bottom_l[i].Enabled = false;

                        p[i].Controls.Add(bottom_l[i]);
                        p[i].Controls.Add(pic[i]);
                        p[i].Controls.Add(top_l[i]);


                        flowLayoutPanel1.Controls.Add(p[i]);

                        i++;
                    }
                }
            } 
            else if (req.Equals("title") )
            {
                List<Panel> p = new List<Panel>();
                p.Clear();
                List<Label> top_l = new List<Label>();
                top_l.Clear();
                List<Label> bottom_l = new List<Label>();
                bottom_l.Clear();
                List<PictureBox> pic = new List<PictureBox>();
                pic.Clear();

                foreach (Book item in books)
                {

                    if (item.Title.Equals(key))
                    {
                        int currentIndex = i;
                        //ftiaxe panel
                        p.Add(new Panel());
                        top_l.Add(new Label());
                        bottom_l.Add(new Label());
                        pic.Add(new PictureBox());
                        p[i].Width = 150;
                        p[i].Height = 240;
                        p[i].BorderStyle = BorderStyle.FixedSingle;
                        p[i].Show();
                        p[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        p[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        p[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };


                        pic[i].Width = 150;
                        pic[i].Height = 180;
                        pic[i].ImageLocation = "images\\" + item.Image;
                        pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pic[i].Show();
                        pic[i].Enabled = false;

                        top_l[i].Text = item.Title;
                        top_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        top_l[i].Location = new Point(0, 180);
                        top_l[i].AutoSize = true;
                        top_l[i].MaximumSize = new Size(140, 0); ;
                        top_l[i].Show();
                        top_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        top_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        top_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //top_l[i].Enabled = false;

                        bottom_l[i].Text = item.Price.ToString() + "$";
                        bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        bottom_l[i].Location = new Point(0, 220);
                        bottom_l[i].Show();
                        bottom_l[i].ForeColor = Color.Red;
                        bottom_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this, reader).Show();
                        };
                        bottom_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        bottom_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //bottom_l[i].Enabled = false;

                        p[i].Controls.Add(bottom_l[i]);
                        p[i].Controls.Add(pic[i]);
                        p[i].Controls.Add(top_l[i]);


                        flowLayoutPanel1.Controls.Add(p[i]);

                        i++;
                    }
                }
            }
        }


        private void Display_books(string req)
        {
            label3.Hide();
            if (req.Equals("all"))
            {
                int i = 0;
                flowLayoutPanel1.Controls.Clear();
                List<Panel> p = new List<Panel>();
                p.Clear();
                List<Label> top_l = new List<Label>();
                top_l.Clear();
                List<Label> bottom_l = new List<Label>();
                bottom_l.Clear();
                List<PictureBox> pic = new List<PictureBox>();
                pic.Clear();

                foreach (Book item in books)
                {
                    int currentIndex = i;
                    //ftiaxe panel
                    p.Add(new Panel());
                    top_l.Add(new Label());
                    bottom_l.Add(new Label());
                    pic.Add(new PictureBox());
                    p[i].Width = 150;
                    p[i].Height = 240;
                    p[i].BorderStyle = BorderStyle.FixedSingle;
                    p[i].Show();
                    p[i].Click += (buttonSender, eventArgs) =>
                    {
                        this.Hide();
                        new BookForm(item, this,reader).Show();
                    };
                    p[i].MouseEnter += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Hand;
                    };
                    p[i].MouseLeave += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Default;
                    };

                  
                    pic[i].Width = 150;
                    pic[i].Height = 180;
                    pic[i].ImageLocation = "images\\" + item.Image;
                    pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pic[i].Show();
                    pic[i].Enabled = false;

                    top_l[i].Text = item.Title;
                    top_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                    top_l[i].Location = new Point(0, 180);
                    top_l[i].AutoSize = true;
                    top_l[i].MaximumSize = new Size(140, 0); ;
                    top_l[i].Show();
                    top_l[i].Click += (buttonSender, eventArgs) =>
                    {
                        this.Hide();
                        new BookForm(item, this,reader).Show();
                    };
                    top_l[i].MouseEnter += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Hand;
                    };
                    top_l[i].MouseLeave += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Default;
                    };
                    //top_l[i].Enabled = false;

                    bottom_l[i].Text = item.Price.ToString() + "$";
                    bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                    bottom_l[i].Location = new Point(0, 220);
                    bottom_l[i].Show();
                    bottom_l[i].ForeColor = Color.Red;
                    bottom_l[i].Click += (buttonSender, eventArgs) =>
                    {
                        this.Hide();
                        new BookForm(item, this,reader).Show();
                    };
                    bottom_l[i].MouseEnter += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Hand;
                    };
                    bottom_l[i].MouseLeave += (mousesender, eventArgs) =>
                    {
                        Cursor = Cursors.Default;
                    };
                    //bottom_l[i].Enabled = false;

                    p[i].Controls.Add(bottom_l[i]);
                    p[i].Controls.Add(pic[i]);
                    p[i].Controls.Add(top_l[i]);


                    flowLayoutPanel1.Controls.Add(p[i]);

                    i++;
                }
            }
            else
            {

                int i = 0;
                flowLayoutPanel1.Controls.Clear();
                List<Panel> p = new List<Panel>();
                p.Clear();
                List<Label> top_l = new List<Label>();
                top_l.Clear();
                List<Label> bottom_l = new List<Label>();
                bottom_l.Clear();
                List<PictureBox> pic = new List<PictureBox>();
                pic.Clear();

                foreach (Book item in books)
                {
                    if (item.Genre.Equals(req))
                    {
                        int currentIndex = i;
                        //ftiaxe panel
                        p.Add(new Panel());
                        top_l.Add(new Label());
                        bottom_l.Add(new Label());
                        pic.Add(new PictureBox());
                        p[i].Width = 150;
                        p[i].Height = 240;
                        // p[i].BackColor = Color.Pink;
                        p[i].BorderStyle = BorderStyle.FixedSingle;
                        p[i].Show();
                        p[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this,reader).Show();
                        };
                        p[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        p[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };

                        pic[i].BackColor = Color.Aqua;
                        pic[i].Width = 150;
                        pic[i].Height = 180;
                        pic[i].ImageLocation = "images\\" + item.Image;
                        pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pic[i].Show();
                        pic[i].Enabled = false;

                        top_l[i].Text = item.Title;
                        top_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        top_l[i].Location = new Point(0, 180);
                        top_l[i].AutoSize = true;
                        top_l[i].MaximumSize = new Size(140, 0); ;
                        top_l[i].Show();
                        top_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this,reader).Show();
                        };
                        top_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        top_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //top_l[i].Enabled = false;

                        bottom_l[i].Text = item.Price.ToString() + "$";
                        bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        bottom_l[i].Location = new Point(0, 220);
                        bottom_l[i].Show();
                        bottom_l[i].ForeColor = Color.Red;
                        bottom_l[i].Click += (buttonSender, eventArgs) =>
                        {
                            this.Hide();
                            new BookForm(item, this,reader).Show();
                        };
                        bottom_l[i].MouseEnter += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Hand;
                        };
                        bottom_l[i].MouseLeave += (mousesender, eventArgs) =>
                        {
                            Cursor = Cursors.Default;
                        };
                        //bottom_l[i].Enabled = false;

                        p[i].Controls.Add(bottom_l[i]);
                        p[i].Controls.Add(pic[i]);
                        p[i].Controls.Add(top_l[i]);


                        flowLayoutPanel1.Controls.Add(p[i]);

                        i++;
                    }
                }
            }
        }

        private void εΞΟΔΟΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CartForm(this).Show();

        }
        public void UpdateLabel()
        {
            label1.Text = cart_books.Count.ToString();
        }

        private void εΡΩΤΗΣΕΙΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuestionForm(reader).Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           /* if (true)
            {

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
               HashSet<string> writers = new HashSet<string>();
                foreach (var item in books)
                {
                    writers.Add(item.Writer);
                }
                string res = "";
                var results = writers.Where(writer => writer.Contains(textBox1.Text));
                int i = 0;
                flowLayoutPanel1.Controls.Clear();
                label3.Show();
                if (results.Count()!=0)
                {
                    res += "Αποτελέσματα:\r\n";
                    foreach (var result in results)
                    {
                        res += result.ToString() + "\r\n";
                    } 
                        res += "Ακολουθούν τα βιβλία των παραπάνω συγγραφέων \r\n";
                }
                else
                {
                    res = "Δεν βρέθηκαν αποτελέσματα"; 
                }
                MessageBox.Show(res.ToString());
                foreach (var result in results)
                {                   
                    Display_books("writer",result.ToString(), i);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                HashSet<string> titles = new HashSet<string>();
                foreach (var item in books)
                {
                    titles.Add(item.Title);
                }
                string res = "";
                var results = titles.Where(writer => writer.Contains(textBox1.Text));
                int i = 0;
                flowLayoutPanel1.Controls.Clear();
                label3.Show();
                if (results.Count()!=0)
                {
                    res += "Αποτελέσματα:\r\n";
                    foreach (var result in results)
                    {
                        res += result.ToString() + "\r\n";
                    }
                    res += "Ακολουθούν τα βιβλία που αντιστοιχούν στα αποτελέσματα \r\n";
                }
                else
                {
                    res = "Δεν βρέθηκαν αποτελέσματα";
                }
                MessageBox.Show(res.ToString());
                foreach (var result in results)
                {
                    Display_books("title", result.ToString(), i);
                }
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            t1.SetToolTip(pictureBox2, "ΚΑΛΑΘΙ ΑΓΟΡΩΝ");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
