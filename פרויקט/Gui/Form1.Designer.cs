namespace פרויקט
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCity = new System.Windows.Forms.Button();
            this.btnKategory = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnM = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnReSa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(218, 34);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(421, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "מכולת \"זול ובגדול\"";
            // 
            // btnCity
            // 
            this.btnCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCity.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCity.Location = new System.Drawing.Point(601, 164);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(157, 33);
            this.btnCity.TabIndex = 1;
            this.btnCity.Text = "הוספת עיר";
            this.btnCity.UseVisualStyleBackColor = false;
            this.btnCity.Visible = false;
            this.btnCity.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKategory
            // 
            this.btnKategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKategory.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKategory.Location = new System.Drawing.Point(579, 203);
            this.btnKategory.Name = "btnKategory";
            this.btnKategory.Size = new System.Drawing.Size(179, 32);
            this.btnKategory.TabIndex = 2;
            this.btnKategory.Text = "הוספת קטגוריה";
            this.btnKategory.UseVisualStyleBackColor = false;
            this.btnKategory.Visible = false;
            this.btnKategory.Click += new System.EventHandler(this.btnKategory_Click_1);
            // 
            // btnCompany
            // 
            this.btnCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCompany.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.Location = new System.Drawing.Point(586, 250);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(134, 33);
            this.btnCompany.TabIndex = 3;
            this.btnCompany.Text = "הוספת חברה";
            this.btnCompany.UseVisualStyleBackColor = false;
            this.btnCompany.Visible = false;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCustomer.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.Location = new System.Drawing.Point(586, 289);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(134, 47);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "הוספת לקוח";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Visible = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnM
            // 
            this.btnM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnM.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM.Location = new System.Drawing.Point(586, 342);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(134, 37);
            this.btnM.TabIndex = 5;
            this.btnM.Text = "הוספת מוצר";
            this.btnM.UseVisualStyleBackColor = false;
            this.btnM.Visible = false;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // btnS
            // 
            this.btnS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnS.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(588, 385);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(142, 40);
            this.btnS.TabIndex = 6;
            this.btnS.Text = "הוספת ספק";
            this.btnS.UseVisualStyleBackColor = false;
            this.btnS.Visible = false;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnReSa
            // 
            this.btnReSa.BackColor = System.Drawing.Color.White;
            this.btnReSa.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSa.Location = new System.Drawing.Point(329, 144);
            this.btnReSa.Name = "btnReSa";
            this.btnReSa.Size = new System.Drawing.Size(131, 40);
            this.btnReSa.TabIndex = 7;
            this.btnReSa.Text = "רכישה מספק";
            this.btnReSa.UseVisualStyleBackColor = false;
            this.btnReSa.Click += new System.EventHandler(this.btnReSa_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(312, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "קניה עבור לקוח";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(622, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "להוספה";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 430);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnCompany);
            this.Controls.Add(this.btnKategory);
            this.Controls.Add(this.btnCity);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReSa);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.Button btnKategory;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnM;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnReSa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

