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
    public partial class WriterForm : Form
    {
       
        Writer writer;
        public WriterForm(Writer writer)
        {
            InitializeComponent();
            this.writer=writer ;
        }

        private void WriterForm_Load(object sender, EventArgs e)
        {

        }

        private void WriterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void οΛΑΤΑΒΙΒΛΙΑToolStripMenuItem_Click(object sender, EventArgs e)
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

            foreach (Book item in writer.books)
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
               
                top_l[i].MouseEnter += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Hand;
                };
                top_l[i].MouseLeave += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Default;
                };
               

                bottom_l[i].Text = item.Price.ToString() + "$";
                bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                bottom_l[i].Location = new Point(0, 220);
                bottom_l[i].Show();
                bottom_l[i].ForeColor = Color.Red;

              
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

        private void εΞΟΔΟΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void τΟΠΡΟΦΙΛΜΟΥToolStripMenuItem_Click(object sender, EventArgs e)
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
            List<Label> sales = new List<Label>();
            sales.Clear();
            foreach (Book item in writer.books)
            {
                int currentIndex = i;
                //ftiaxe panel
                p.Add(new Panel());
                top_l.Add(new Label());
                bottom_l.Add(new Label());
                sales.Add(new Label());
                pic.Add(new PictureBox());
                p[i].Width = 565;
                p[i].Height = 240;
                p[i].BorderStyle = BorderStyle.FixedSingle;
                p[i].Show();

                p[i].MouseEnter += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Hand;
                };
                p[i].MouseLeave += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Default;
                };


                pic[i].Width = 150;
                pic[i].Height = p[i].Height;
                pic[i].ImageLocation = "images\\" + item.Image;
                pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pic[i].Show();
                pic[i].Enabled = false;

                top_l[i].Text = item.Title;
                top_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                top_l[i].Location = new Point(pic[i].Width+10, 10);
                top_l[i].AutoSize = true;
               // top_l[i].MaximumSize = new Size(140, 0); ;
                top_l[i].Show();

                top_l[i].MouseEnter += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Hand;
                };
                top_l[i].MouseLeave += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Default;
                };


                bottom_l[i].Text ="Τιμή:" + item.Price.ToString() + "$";
                bottom_l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                bottom_l[i].Location = new Point(pic[i].Width + 10, top_l[i].Height+45);
                bottom_l[i].Show();
                bottom_l[i].ForeColor = Color.Red;

                sales[i].Text = "Πωλήσεις: " + writer.lista[i];
                sales[i].Font = new Font("Arial", 12, FontStyle.Bold);
                sales[i].Location = new Point(bottom_l[i].Location.X, bottom_l[i].Location.Y + bottom_l[i].Height+10);
                sales[i].AutoSize=true;
                sales[i].Show();

                bottom_l[i].MouseEnter += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Hand;
                };
                bottom_l[i].MouseLeave += (mousesender, eventArgs) =>
                {
                    Cursor = Cursors.Default;
                };

                p[i].Controls.Add(bottom_l[i]);
                p[i].Controls.Add(pic[i]);
                p[i].Controls.Add(top_l[i]);

                p[i].Height += 10;
                flowLayoutPanel1.Controls.Add(p[i]);
                writer.comment_text.Clear();
                writer.by.Clear();
                writer.see_reviews(item.Id);
               


                int j = 0;
                List<Panel> pa = new List<Panel>();
                pa.Clear();
                List<Label> comm = new List<Label>();
                comm.Clear();
                List<Label> com_by = new List<Label>();
                com_by.Clear();
                foreach (string it in writer.comment_text)
                {
                    //int currentIndex = i;
                    //ftiaxe panel
                    pa.Add(new Panel());
                    comm.Add(new Label());
                    com_by.Add(new Label());
                    pa[j].Width = p[i].Width;
                    pa[j].Height = 44;
                    if (j>0)
                    {
                        pa[j].Location = new Point(0, pa[j-1].Location.Y+pa[j-1].Height+10);
                    }
                    else
                    {
                        pa[j].Location = new Point(0, 254);
                    }
                    pa[j].BackColor = Color.Pink;
                    pa[j].BorderStyle = BorderStyle.FixedSingle;
                    pa[j].Show();


                    comm[j].Text = it;
                    comm[j].Font = new Font("Arial", 10, FontStyle.Bold);
                    comm[j].Location = new Point(0, 0);
                    comm[j].AutoSize = true;
                    comm[j].MaximumSize = new Size(0, 140); ;
                    comm[j].Show();

                    com_by[j].Text = "-" + writer.by[j];
                    com_by[j].Location = new Point(400, 30);
                    com_by[j].Font = new Font("Arial", 8, FontStyle.Bold);
                    com_by[j].AutoSize = true;
                    com_by[j].MaximumSize = new Size(0, 0); ;
                    com_by[j].Show();


                    pa[j].Controls.Add(com_by[j]);
                    pa[j].Controls.Add(comm[j]);
                    p[i].Controls.Add(pa[j]);
                    p[i].Controls.Add(sales[i]);

                    p[i].Height += 54;
                    j++;
                }
                i++;
            }
        }

        private void εΡΩΤΗΣΕΙΣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Panel> p = new List<Panel>();
            List<Label> l = new List<Label>();
            List<TextBox> t = new List<TextBox>();
            List<Button> b = new List<Button>();
             int i = 0;
            writer.see_questions();
            foreach (string item in writer.question)
            {
                int currentIndex = i;

                p.Add(new Panel());
                p[i].Width = this.Width;
                p[i].Height = 100;
                p[i].BorderStyle = BorderStyle.FixedSingle;
                 t.Add(new TextBox());
                 l.Add(new Label());
                b.Add(new Button());
                

                l[i].Text = "Ερώτηση: " + item;
                l[i].Font = new Font("Arial", 12, FontStyle.Bold);
                l[i].Location = new Point(0, 0);
                l[i].AutoSize = true;

                t[i].Location = new Point(0, l[i].Height+30);
                t[i].Text ="Γραψτε την απάντησή σας εδώ" ;
                t[i].Width = 180;
                t[i].Click += (txtsender, args) => {
                    if (t[currentIndex].Text.Equals( "Γραψτε την απάντησή σας εδώ"))
                    {
                        t[currentIndex].Clear();
                    }
                     };
                //t[i].Show();

                b[i].Text = "Αποστολή απάντησης";
                b[i].AutoSize = true;
                b[i].Location = new Point(t[i].Location.X+t[i].Width+10, l[i].Height + 30);
                b[i].Click += (buttonsender, eventArgs) => {
                    if (!t[currentIndex].Text.Equals("Γραψτε την απάντησή σας εδώ"))
                    {
                        writer.answer_questions(t[currentIndex].Text, writer.cId[currentIndex]);
                        p[currentIndex].Hide();
                    }
                     };

                p[i].Controls.Add(t[i]);
                  p[i].Controls.Add(l[i]);
                p[i].Controls.Add(b[i]);
                flowLayoutPanel1.Controls.Add(p[i]);
                i++;
            }
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
