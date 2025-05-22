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
    public partial class CartForm : Form
    {
       public ReaderForm readerForm;
        Book b;
        int j = 0;
        int sum = 0;
        public List<Label> posotita = new List<Label>();
        Button buy = new Button();
        Label l = new Label();
        public CartForm(ReaderForm readerForm)
        {
            InitializeComponent();
            this.readerForm = readerForm;

        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            if (readerForm.cart_books.Count!=0)
            {
                label2.Hide();
            }
            List<PictureBox> pic=new List<PictureBox>();
            List<Label> titlos = new List<Label>();
            List<Button> increase = new List<Button>();
            List<Button> decrease = new List<Button>();
            int i = 0;

            foreach (Book item in readerForm.cart_books)
            {
                int currentIndex = i;
                pic.Add(new PictureBox());
                titlos.Add(new Label());
                increase.Add(new Button());
                decrease.Add(new Button());
                posotita.Add(new Label());
                //picture
                pic[i].Width = 86;
                pic[i].Height = 118;
                if(i==0)
                {
                    pic[i].Location = new Point(18, 94);

                }
                else
                {
                    pic[i].Location = new Point(18, 94+i*128); 
                }
                pic[i].ImageLocation = "images\\" + item.Image;
                pic[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pic[i].Show();
                pic[i].Enabled = false;
                this.Controls.Add(pic[i]);

                //titlos
                titlos[i].Text = item.Title;
                titlos[i].Font = new Font("Arial", 12, FontStyle.Bold);
                titlos[i].Location = new Point(18+86+10,pic[i].Location.Y );
                titlos[i].AutoSize = true;
               // titlos[i].MaximumSize = new Size(140, 0); ;
                titlos[i].Show();
                this.Controls.Add(titlos[i]);

                increase[i].Location = new Point(146,pic[i].Location.Y+118-24);
                increase[i].Text = "+";
                increase[i].Width=43;
                increase[i].Height =24;
                increase[i].Show();
                this.Controls.Add(increase[i]);


                decrease[i].Location = new Point(146+2*43+20, pic[i].Location.Y + 118 - 24);
                decrease[i].Text = "-";
                decrease[i].Width = 43;
                decrease[i].Height = 24;
                decrease[i].Show();
                this.Controls.Add(decrease[i]);

                posotita[i].Text = "1";
                posotita[i].Font = new Font("Arial", 12, FontStyle.Bold);
                posotita[i].AutoSize = true;
                posotita[i].Location = new Point(146 + 43 + 25, pic[i].Location.Y + 118 - 24);
                posotita[i].Show();
                this.Controls.Add(posotita[i]);
                
                increase[i].Click += (EventArgs, Sender) => {
                    j = int.Parse(posotita[currentIndex].Text);
                    j++;
                    posotita[currentIndex].Text = j.ToString();
                    sum += int.Parse(readerForm.cart_books[currentIndex].Price.ToString());
            l.Text = "Σύνολο: "+sum.ToString()+"$" ;
                };

                decrease[i].Click += (EventArgs, Sender) => {
                    j = int.Parse(posotita[currentIndex].Text);
                    if(j>0)
                    {
                        j--;
                        posotita[currentIndex].Text = j.ToString();
                        sum -= int.Parse(readerForm.cart_books[currentIndex].Price.ToString());
                l.Text = "Σύνολο: "+sum.ToString()+"$" ;
                    }

                  
                };
                i++;
                sum += int.Parse(item.Price.ToString());
            }
            if (i!=0)
            {
                l.Location = new Point(100, posotita[i - 1].Location.Y + posotita[i - 1].Height + 20);
                l.Text = "Σύνολο: " + sum.ToString() + "$";
                l.Font = new Font("Arial", 12, FontStyle.Bold);
                l.AutoSize = true;
                l.Show();
                this.Controls.Add(l);
                buy.Text = "Αγορά";
                buy.AutoSize = true;
                buy.Click += (EventArgs, Sender) => { new PayScreen(this, sum).Show(); };
                buy.Location = new Point(l.Location.X + l.Width + 30, posotita[i - 1].Location.Y + posotita[i - 1].Height + 20);
                buy.Show();
                this.Controls.Add(buy);
            }
           
        }
        public void PurchaceDone() { readerForm.cart_books.Clear();
            this.Close();
        }

        private void CartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (readerForm.cart_books.Count>0)
            {
                for (int i = 0; i < posotita.Count; i++)
                {
                    if (posotita[i].Text.Equals("0"))
                    {
                        readerForm.cart_books.RemoveAt(i);
                    }
                }
            }
            readerForm.UpdateLabel();
        }
    }
}
