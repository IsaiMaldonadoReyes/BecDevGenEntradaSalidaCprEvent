
namespace BecDevGenEntradaSalidaCprEvent
{
    partial class RptHistoricoMovimientosPorRuta
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
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAlmacen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.btnEjecutarReporte = new MaterialSkin.Controls.MaterialButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.materialCard2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.tableLayoutPanel1);
            this.materialCard2.Depth = 0;
            this.materialCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(3, 64);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(394, 333);
            this.materialCard2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbAlmacen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxAlmacen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaInicial, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaFinal, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnEjecutarReporte, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 305);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona los filtros para poder ejecutar el reporte";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbAlmacen
            // 
            this.lbAlmacen.AutoSize = true;
            this.lbAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAlmacen.Location = new System.Drawing.Point(5, 55);
            this.lbAlmacen.Margin = new System.Windows.Forms.Padding(5);
            this.lbAlmacen.Name = "lbAlmacen";
            this.lbAlmacen.Size = new System.Drawing.Size(90, 50);
            this.lbAlmacen.TabIndex = 1;
            this.lbAlmacen.Text = "Almacén * ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha inicial *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(5, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 50);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha final *";
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(103, 53);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(260, 21);
            this.cbxAlmacen.TabIndex = 4;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(103, 113);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(260, 20);
            this.dtpFechaInicial.TabIndex = 5;
            this.dtpFechaInicial.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(103, 173);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(260, 20);
            this.dtpFechaFinal.TabIndex = 6;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // btnEjecutarReporte
            // 
            this.btnEjecutarReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.btnEjecutarReporte, 2);
            this.btnEjecutarReporte.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEjecutarReporte.Depth = 0;
            this.btnEjecutarReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEjecutarReporte.HighEmphasis = true;
            this.btnEjecutarReporte.Icon = null;
            this.btnEjecutarReporte.Location = new System.Drawing.Point(4, 271);
            this.btnEjecutarReporte.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEjecutarReporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEjecutarReporte.Name = "btnEjecutarReporte";
            this.btnEjecutarReporte.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEjecutarReporte.Size = new System.Drawing.Size(358, 28);
            this.btnEjecutarReporte.TabIndex = 8;
            this.btnEjecutarReporte.Text = "Ejecutar reporte";
            this.btnEjecutarReporte.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEjecutarReporte.UseAccentColor = false;
            this.btnEjecutarReporte.UseVisualStyleBackColor = true;
            this.btnEjecutarReporte.Click += new System.EventHandler(this.btnEjecutarReporte_Click);
            // 
            // progressBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 233);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 9);
            this.progressBar1.TabIndex = 9;
            // 
            // RptHistoricoMovimientosPorRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.materialCard2);
            this.Name = "RptHistoricoMovimientosPorRuta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Histórico de movimientos por ruta";
            this.Load += new System.EventHandler(this.RptHistoricoMovimientosPorRuta_Load);
            this.materialCard2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAlmacen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private MaterialSkin.Controls.MaterialButton btnEjecutarReporte;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}