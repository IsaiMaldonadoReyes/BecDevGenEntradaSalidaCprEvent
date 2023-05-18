namespace BecDevGenEntradaSalidaCprEvent
{
    partial class FormPagoLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPagoLiquidacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.txtMontoAbono = new MaterialSkin.Controls.MaterialTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.lblSalidaFecha = new MaterialSkin.Controls.MaterialLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.Ruta = new MaterialSkin.Controls.MaterialLabel();
            this.Operador = new MaterialSkin.Controls.MaterialLabel();
            this.dgvSalidaListaProducto = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("materialCard1.BackgroundImage")));
            this.materialCard1.Controls.Add(this.tableLayoutPanel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(13, 86);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.Size = new System.Drawing.Size(1307, 557);
            this.materialCard1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.50001F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSalidaListaProducto, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1281, 529);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.materialDivider1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMontoAbono, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.lblSalidaFecha, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.materialDivider2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.materialDivider3, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.Ruta, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Operador, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 10);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(467, 509);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel3.SetColumnSpan(this.materialDivider1, 2);
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider1.Location = new System.Drawing.Point(4, 78);
            this.materialDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(459, 4);
            this.materialDivider1.TabIndex = 22;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // txtMontoAbono
            // 
            this.txtMontoAbono.AnimateReadOnly = false;
            this.txtMontoAbono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoAbono.Depth = 0;
            this.txtMontoAbono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMontoAbono.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMontoAbono.LeadingIcon = null;
            this.txtMontoAbono.Location = new System.Drawing.Point(7, 302);
            this.txtMontoAbono.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtMontoAbono.MaxLength = 50;
            this.txtMontoAbono.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMontoAbono.Multiline = false;
            this.txtMontoAbono.Name = "txtMontoAbono";
            this.txtMontoAbono.Size = new System.Drawing.Size(186, 50);
            this.txtMontoAbono.TabIndex = 10;
            this.txtMontoAbono.Text = "";
            this.txtMontoAbono.TrailingIcon = null;
            this.txtMontoAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoAbono_KeyPress);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnAgregarPago, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 427);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(459, 78);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnAgregarPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarPago.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPago.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarPago.Image")));
            this.btnAgregarPago.Location = new System.Drawing.Point(96, 0);
            this.btnAgregarPago.Margin = new System.Windows.Forms.Padding(0);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(267, 78);
            this.btnAgregarPago.TabIndex = 25;
            this.btnAgregarPago.Text = "AGREGAR ABONO";
            this.btnAgregarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);
            // 
            // lblSalidaFecha
            // 
            this.lblSalidaFecha.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.lblSalidaFecha, 2);
            this.lblSalidaFecha.Depth = 0;
            this.lblSalidaFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalidaFecha.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSalidaFecha.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblSalidaFecha.ForeColor = System.Drawing.Color.Gray;
            this.lblSalidaFecha.Location = new System.Drawing.Point(7, 6);
            this.lblSalidaFecha.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblSalidaFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSalidaFecha.Name = "lblSalidaFecha";
            this.lblSalidaFecha.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblSalidaFecha.Size = new System.Drawing.Size(453, 62);
            this.lblSalidaFecha.TabIndex = 24;
            this.lblSalidaFecha.Text = "Fecha";
            this.lblSalidaFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(0, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 32);
            this.label4.TabIndex = 21;
            this.label4.Text = "Cantidad";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel3.SetColumnSpan(this.materialDivider2, 2);
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider2.Location = new System.Drawing.Point(4, 152);
            this.materialDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(459, 4);
            this.materialDivider2.TabIndex = 25;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel3.SetColumnSpan(this.materialDivider3, 2);
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider3.Location = new System.Drawing.Point(4, 226);
            this.materialDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(459, 4);
            this.materialDivider3.TabIndex = 26;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // Ruta
            // 
            this.Ruta.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.Ruta, 2);
            this.Ruta.Depth = 0;
            this.Ruta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ruta.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Ruta.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.Ruta.Location = new System.Drawing.Point(4, 86);
            this.Ruta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ruta.MouseState = MaterialSkin.MouseState.HOVER;
            this.Ruta.Name = "Ruta";
            this.Ruta.Size = new System.Drawing.Size(459, 62);
            this.Ruta.TabIndex = 27;
            this.Ruta.Text = "Ruta";
            this.Ruta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Operador
            // 
            this.Operador.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.Operador, 2);
            this.Operador.Depth = 0;
            this.Operador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Operador.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Operador.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.Operador.Location = new System.Drawing.Point(4, 160);
            this.Operador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Operador.MouseState = MaterialSkin.MouseState.HOVER;
            this.Operador.Name = "Operador";
            this.Operador.Size = new System.Drawing.Size(459, 62);
            this.Operador.TabIndex = 28;
            this.Operador.Text = "Operador";
            this.Operador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSalidaListaProducto
            // 
            this.dgvSalidaListaProducto.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSalidaListaProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalidaListaProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidaListaProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalidaListaProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvSalidaListaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalidaListaProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSalidaListaProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidaListaProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalidaListaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalidaListaProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.documento,
            this.cantidad});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidaListaProducto.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSalidaListaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidaListaProducto.EnableHeadersVisualStyles = false;
            this.dgvSalidaListaProducto.Location = new System.Drawing.Point(485, 8);
            this.dgvSalidaListaProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSalidaListaProducto.Name = "dgvSalidaListaProducto";
            this.dgvSalidaListaProducto.RowHeadersVisible = false;
            this.dgvSalidaListaProducto.RowHeadersWidth = 51;
            this.dgvSalidaListaProducto.RowTemplate.Height = 60;
            this.dgvSalidaListaProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalidaListaProducto.Size = new System.Drawing.Size(786, 513);
            this.dgvSalidaListaProducto.TabIndex = 6;
            // 
            // id
            // 
            this.id.FillWeight = 7.614213F;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 100;
            this.fecha.Name = "fecha";
            // 
            // documento
            // 
            this.documento.FillWeight = 158.8086F;
            this.documento.HeaderText = "Documento";
            this.documento.MinimumWidth = 100;
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.FillWeight = 133.5773F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 100;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // FormPagoLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 655);
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPagoLiquidacion";
            this.Padding = new System.Windows.Forms.Padding(13, 86, 13, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liquidaciones | Nuevo abono";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSalida_Load);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListaProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvSalidaListaProducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialLabel lblSalidaFecha;
        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private MaterialSkin.Controls.MaterialTextBox txtMontoAbono;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private MaterialSkin.Controls.MaterialLabel Ruta;
        private MaterialSkin.Controls.MaterialLabel Operador;
    }
}