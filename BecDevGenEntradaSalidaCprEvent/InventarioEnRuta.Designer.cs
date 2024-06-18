namespace BecDevGenEntradaSalidaCprEvent
{
    partial class InventarioEnRuta
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCedis = new MaterialSkin.Controls.MaterialCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxCedisInicial = new System.Windows.Forms.ComboBox();
            this.cbxCedisFinal = new System.Windows.Forms.ComboBox();
            this.cbxRutaInicial = new System.Windows.Forms.ComboBox();
            this.cbxRutaFinal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btnEjecutarInventarioEnRuta = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.tableLayoutPanel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 64);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(394, 633);
            this.materialCard1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCedis, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxCedisInicial, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxCedisFinal, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxRutaInicial, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxRutaFinal, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.dtpInicial, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtpFinal, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnEjecutarInventarioEnRuta, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 605);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona los filtros para poder ejecutar el reporte";
            // 
            // chkCedis
            // 
            this.chkCedis.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkCedis, 2);
            this.chkCedis.Depth = 0;
            this.chkCedis.Location = new System.Drawing.Point(0, 60);
            this.chkCedis.Margin = new System.Windows.Forms.Padding(0);
            this.chkCedis.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkCedis.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkCedis.Name = "chkCedis";
            this.chkCedis.ReadOnly = false;
            this.chkCedis.Ripple = true;
            this.chkCedis.Size = new System.Drawing.Size(107, 37);
            this.chkCedis.TabIndex = 1;
            this.chkCedis.Text = "Por CEDIS";
            this.chkCedis.UseVisualStyleBackColor = true;
            this.chkCedis.CheckedChanged += new System.EventHandler(this.materialCheckbox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "CEDIS inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "CEDIS final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ruta inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ruta final";
            // 
            // cbxCedisInicial
            // 
            this.cbxCedisInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxCedisInicial.FormattingEnabled = true;
            this.cbxCedisInicial.Location = new System.Drawing.Point(103, 123);
            this.cbxCedisInicial.Name = "cbxCedisInicial";
            this.cbxCedisInicial.Size = new System.Drawing.Size(260, 21);
            this.cbxCedisInicial.TabIndex = 6;
            this.cbxCedisInicial.SelectedIndexChanged += new System.EventHandler(this.cbxCedisInicial_SelectedIndexChanged);
            // 
            // cbxCedisFinal
            // 
            this.cbxCedisFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxCedisFinal.FormattingEnabled = true;
            this.cbxCedisFinal.Location = new System.Drawing.Point(103, 183);
            this.cbxCedisFinal.Name = "cbxCedisFinal";
            this.cbxCedisFinal.Size = new System.Drawing.Size(260, 21);
            this.cbxCedisFinal.TabIndex = 7;
            // 
            // cbxRutaInicial
            // 
            this.cbxRutaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRutaInicial.FormattingEnabled = true;
            this.cbxRutaInicial.Location = new System.Drawing.Point(103, 243);
            this.cbxRutaInicial.Name = "cbxRutaInicial";
            this.cbxRutaInicial.Size = new System.Drawing.Size(260, 21);
            this.cbxRutaInicial.TabIndex = 8;
            // 
            // cbxRutaFinal
            // 
            this.cbxRutaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRutaFinal.FormattingEnabled = true;
            this.cbxRutaFinal.Location = new System.Drawing.Point(103, 303);
            this.cbxRutaFinal.Name = "cbxRutaFinal";
            this.cbxRutaFinal.Size = new System.Drawing.Size(260, 21);
            this.cbxRutaFinal.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha inicial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fecha final";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(103, 363);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(260, 20);
            this.dtpInicial.TabIndex = 12;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(103, 423);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(260, 20);
            this.dtpFinal.TabIndex = 13;
            // 
            // btnEjecutarInventarioEnRuta
            // 
            this.btnEjecutarInventarioEnRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnEjecutarInventarioEnRuta, 2);
            this.btnEjecutarInventarioEnRuta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEjecutarInventarioEnRuta.Depth = 0;
            this.btnEjecutarInventarioEnRuta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEjecutarInventarioEnRuta.HighEmphasis = true;
            this.btnEjecutarInventarioEnRuta.Icon = null;
            this.btnEjecutarInventarioEnRuta.Location = new System.Drawing.Point(4, 563);
            this.btnEjecutarInventarioEnRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEjecutarInventarioEnRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEjecutarInventarioEnRuta.Name = "btnEjecutarInventarioEnRuta";
            this.btnEjecutarInventarioEnRuta.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEjecutarInventarioEnRuta.Size = new System.Drawing.Size(358, 36);
            this.btnEjecutarInventarioEnRuta.TabIndex = 14;
            this.btnEjecutarInventarioEnRuta.Text = "Ejecutar reporte";
            this.btnEjecutarInventarioEnRuta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEjecutarInventarioEnRuta.UseAccentColor = false;
            this.btnEjecutarInventarioEnRuta.UseVisualStyleBackColor = true;
            this.btnEjecutarInventarioEnRuta.Click += new System.EventHandler(this.btnEjecutarInventarioEnRuta_Click);
            // 
            // InventarioEnRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.materialCard1);
            this.Name = "InventarioEnRuta";
            this.Text = " ";
            this.Load += new System.EventHandler(this.InventarioEnRuta_Load);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialCheckbox chkCedis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxCedisInicial;
        private System.Windows.Forms.ComboBox cbxCedisFinal;
        private System.Windows.Forms.ComboBox cbxRutaInicial;
        private System.Windows.Forms.ComboBox cbxRutaFinal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private MaterialSkin.Controls.MaterialButton btnEjecutarInventarioEnRuta;
    }
}