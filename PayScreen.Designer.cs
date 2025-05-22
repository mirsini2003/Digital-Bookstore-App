namespace ergasia_logismikou
{
    partial class PayScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.card_network_label = new System.Windows.Forms.Label();
            this.order_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.cvv_label = new System.Windows.Forms.Label();
            this.card_num_label = new System.Windows.Forms.Label();
            this.hol_name_label = new System.Windows.Forms.Label();
            this.cvv_textbox = new System.Windows.Forms.TextBox();
            this.card_num_textbox = new System.Windows.Forms.TextBox();
            this.hol_name_textbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.card_radio = new System.Windows.Forms.RadioButton();
            this.cash_radio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 303);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ποσό πληρωμής: ";
            // 
            // card_network_label
            // 
            this.card_network_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_network_label.AutoSize = true;
            this.card_network_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.card_network_label.Location = new System.Drawing.Point(337, 190);
            this.card_network_label.Name = "card_network_label";
            this.card_network_label.Size = new System.Drawing.Size(49, 18);
            this.card_network_label.TabIndex = 22;
            this.card_network_label.Text = "Other:";
            this.card_network_label.Visible = false;
            // 
            // order_button
            // 
            this.order_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.order_button.Location = new System.Drawing.Point(552, 238);
            this.order_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order_button.Name = "order_button";
            this.order_button.Size = new System.Drawing.Size(113, 41);
            this.order_button.TabIndex = 21;
            this.order_button.Text = "Πληρωμή";
            this.order_button.UseVisualStyleBackColor = true;
            this.order_button.Click += new System.EventHandler(this.order_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancel_button.Location = new System.Drawing.Point(552, 293);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(113, 42);
            this.cancel_button.TabIndex = 20;
            this.cancel_button.Text = "Έξοδος";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // cvv_label
            // 
            this.cvv_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cvv_label.AutoSize = true;
            this.cvv_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cvv_label.Location = new System.Drawing.Point(104, 215);
            this.cvv_label.Name = "cvv_label";
            this.cvv_label.Size = new System.Drawing.Size(41, 18);
            this.cvv_label.TabIndex = 19;
            this.cvv_label.Text = "CVV:";
            // 
            // card_num_label
            // 
            this.card_num_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_num_label.AutoSize = true;
            this.card_num_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.card_num_label.Location = new System.Drawing.Point(33, 190);
            this.card_num_label.Name = "card_num_label";
            this.card_num_label.Size = new System.Drawing.Size(121, 18);
            this.card_num_label.TabIndex = 18;
            this.card_num_label.Text = "Αριθμός κάρτας:";
            // 
            // hol_name_label
            // 
            this.hol_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hol_name_label.AutoSize = true;
            this.hol_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.hol_name_label.Location = new System.Drawing.Point(33, 164);
            this.hol_name_label.Name = "hol_name_label";
            this.hol_name_label.Size = new System.Drawing.Size(118, 18);
            this.hol_name_label.TabIndex = 17;
            this.hol_name_label.Text = "Ονομα κατόχου:";
            // 
            // cvv_textbox
            // 
            this.cvv_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cvv_textbox.Location = new System.Drawing.Point(155, 210);
            this.cvv_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cvv_textbox.Name = "cvv_textbox";
            this.cvv_textbox.Size = new System.Drawing.Size(48, 22);
            this.cvv_textbox.TabIndex = 16;
            this.cvv_textbox.TextChanged += new System.EventHandler(this.cvv_textbox_TextChanged);
            // 
            // card_num_textbox
            // 
            this.card_num_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.card_num_textbox.Location = new System.Drawing.Point(155, 185);
            this.card_num_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card_num_textbox.Name = "card_num_textbox";
            this.card_num_textbox.Size = new System.Drawing.Size(179, 22);
            this.card_num_textbox.TabIndex = 15;
            this.card_num_textbox.TextChanged += new System.EventHandler(this.card_num_textbox_TextChanged);
            // 
            // hol_name_textbox
            // 
            this.hol_name_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hol_name_textbox.Location = new System.Drawing.Point(155, 159);
            this.hol_name_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hol_name_textbox.Name = "hol_name_textbox";
            this.hol_name_textbox.Size = new System.Drawing.Size(179, 22);
            this.hol_name_textbox.TabIndex = 14;
            this.hol_name_textbox.TextChanged += new System.EventHandler(this.hol_name_textbox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.card_radio);
            this.groupBox1.Controls.Add(this.cash_radio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.groupBox1.Location = new System.Drawing.Point(86, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(526, 69);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Επιλέξτε τρόπο πληρωμής";
            // 
            // card_radio
            // 
            this.card_radio.AutoSize = true;
            this.card_radio.Location = new System.Drawing.Point(36, 32);
            this.card_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card_radio.Name = "card_radio";
            this.card_radio.Size = new System.Drawing.Size(78, 22);
            this.card_radio.TabIndex = 1;
            this.card_radio.TabStop = true;
            this.card_radio.Tag = "unchecked";
            this.card_radio.Text = "Κάρτα";
            this.card_radio.UseVisualStyleBackColor = true;
            this.card_radio.CheckedChanged += new System.EventHandler(this.card_radio_CheckedChanged);
            // 
            // cash_radio
            // 
            this.cash_radio.AutoSize = true;
            this.cash_radio.Location = new System.Drawing.Point(404, 32);
            this.cash_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cash_radio.Name = "cash_radio";
            this.cash_radio.Size = new System.Drawing.Size(97, 22);
            this.cash_radio.TabIndex = 0;
            this.cash_radio.TabStop = true;
            this.cash_radio.Tag = "unchecked";
            this.cash_radio.Text = "Μετρητά";
            this.cash_radio.UseVisualStyleBackColor = true;
            this.cash_radio.CheckedChanged += new System.EventHandler(this.cash_radio_CheckedChanged);
            // 
            // PayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.card_network_label);
            this.Controls.Add(this.order_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.cvv_label);
            this.Controls.Add(this.card_num_label);
            this.Controls.Add(this.hol_name_label);
            this.Controls.Add(this.cvv_textbox);
            this.Controls.Add(this.card_num_textbox);
            this.Controls.Add(this.hol_name_textbox);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PayScreen";
            this.Text = "PayScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label card_network_label;
        private System.Windows.Forms.Button order_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label cvv_label;
        private System.Windows.Forms.Label card_num_label;
        private System.Windows.Forms.Label hol_name_label;
        private System.Windows.Forms.TextBox cvv_textbox;
        private System.Windows.Forms.TextBox card_num_textbox;
        private System.Windows.Forms.TextBox hol_name_textbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton card_radio;
        private System.Windows.Forms.RadioButton cash_radio;
    }
}