
namespace פרויקט.Gui
{
    partial class frmCities
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCities));
            this.dataGridViewCity = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameCity = new System.Windows.Forms.Label();
            this.panelSaveCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnl = new System.Windows.Forms.Panel();
            this.btnHatseg = new System.Windows.Forms.Button();
            this.btnRaanen = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gpCity = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblKod = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCity)).BeginInit();
            this.panelSaveCancel.SuspendLayout();
            this.pnl.SuspendLayout();
            this.gpCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCity
            // 
            this.dataGridViewCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCity.Location = new System.Drawing.Point(240, 167);
            this.dataGridViewCity.Name = "dataGridViewCity";
            this.dataGridViewCity.ReadOnly = true;
            this.dataGridViewCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCity.Size = new System.Drawing.Size(231, 196);
            this.dataGridViewCity.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "קוד עיר";
            this.label1.Click += new System.EventHandler(this.ibiCodCity_Click);
            // 
            // lblNameCity
            // 
            this.lblNameCity.AutoSize = true;
            this.lblNameCity.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameCity.Location = new System.Drawing.Point(159, 66);
            this.lblNameCity.Name = "lblNameCity";
            this.lblNameCity.Size = new System.Drawing.Size(32, 17);
            this.lblNameCity.TabIndex = 0;
            this.lblNameCity.Text = " עיר";
            this.lblNameCity.Click += new System.EventHandler(this.lblNameCity_Click);
            // 
            // panelSaveCancel
            // 
            this.panelSaveCancel.BackColor = System.Drawing.Color.Transparent;
            this.panelSaveCancel.Controls.Add(this.btnCancel);
            this.panelSaveCancel.Controls.Add(this.btnSave);
            this.panelSaveCancel.Location = new System.Drawing.Point(517, 242);
            this.panelSaveCancel.Name = "panelSaveCancel";
            this.panelSaveCancel.Size = new System.Drawing.Size(220, 91);
            this.panelSaveCancel.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(30, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 85);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "בטל";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.btnSave.Font = new System.Drawing.Font("Blackadder ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(111, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 85);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "שמור";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Transparent;
            this.pnl.Controls.Add(this.btnHatseg);
            this.pnl.Controls.Add(this.btnRaanen);
            this.pnl.Controls.Add(this.btnUpdate);
            this.pnl.Controls.Add(this.btnAdd);
            this.pnl.Location = new System.Drawing.Point(137, 387);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(347, 51);
            this.pnl.TabIndex = 4;
            // 
            // btnHatseg
            // 
            this.btnHatseg.BackColor = System.Drawing.Color.Cyan;
            this.btnHatseg.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHatseg.Location = new System.Drawing.Point(7, 3);
            this.btnHatseg.Name = "btnHatseg";
            this.btnHatseg.Size = new System.Drawing.Size(75, 34);
            this.btnHatseg.TabIndex = 4;
            this.btnHatseg.Text = "הצג";
            this.btnHatseg.UseVisualStyleBackColor = false;
            this.btnHatseg.Click += new System.EventHandler(this.btnHatseg_Click);
            // 
            // btnRaanen
            // 
            this.btnRaanen.BackColor = System.Drawing.Color.Cyan;
            this.btnRaanen.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaanen.Location = new System.Drawing.Point(88, 3);
            this.btnRaanen.Name = "btnRaanen";
            this.btnRaanen.Size = new System.Drawing.Size(75, 34);
            this.btnRaanen.TabIndex = 3;
            this.btnRaanen.Text = "רענן";
            this.btnRaanen.UseVisualStyleBackColor = false;
            this.btnRaanen.Click += new System.EventHandler(this.btnRaanen_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Cyan;
            this.btnUpdate.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(169, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 33);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "עדכן";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cyan;
            this.btnAdd.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(250, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "הוסף";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gpCity
            // 
            this.gpCity.BackColor = System.Drawing.Color.Transparent;
            this.gpCity.Controls.Add(this.textBox1);
            this.gpCity.Controls.Add(this.lblKod);
            this.gpCity.Controls.Add(this.label1);
            this.gpCity.Controls.Add(this.lblNameCity);
            this.gpCity.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCity.Location = new System.Drawing.Point(517, 118);
            this.gpCity.Name = "gpCity";
            this.gpCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpCity.Size = new System.Drawing.Size(220, 111);
            this.gpCity.TabIndex = 5;
            this.gpCity.TabStop = false;
            this.gpCity.Text = "פרטי עיר";
            this.gpCity.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 58);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 29);
            this.textBox1.TabIndex = 4;
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.Location = new System.Drawing.Point(49, 30);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(51, 21);
            this.lblKod.TabIndex = 3;
            this.lblKod.Text = "label1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(387, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 63);
            this.label2.TabIndex = 7;
            this.label2.Text = "עיר";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(346, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "רשימת הערים";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // frmCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gpCity);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.panelSaveCancel);
            this.Controls.Add(this.dataGridViewCity);
            this.DoubleBuffered = true;
            this.Name = "frmCities";
            this.Text = "frmCities";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCity)).EndInit();
            this.panelSaveCancel.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.gpCity.ResumeLayout(false);
            this.gpCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNameCity;
        private System.Windows.Forms.Panel panelSaveCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gpCity;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Button btnRaanen;
        private System.Windows.Forms.Button btnHatseg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}