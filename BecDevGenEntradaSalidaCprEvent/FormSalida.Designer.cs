namespace BecDevGenEntradaSalidaCprEvent
{
    partial class FormSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalida));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsSalidaListaProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtSalidaCantidadProducto = new MaterialSkin.Controls.MaterialTextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbxSalidaProducto = new System.Windows.Forms.ComboBox();
            this.cbxOperador = new System.Windows.Forms.ComboBox();
            this.cbxSalidaCliente = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalidaBorrar = new System.Windows.Forms.Button();
            this.btnSalidaCompletar = new System.Windows.Forms.Button();
            this.btnSalidaAgregarProducto = new System.Windows.Forms.Button();
            this.lblSalidaFecha = new MaterialSkin.Controls.MaterialLabel();
            this.lblRuta = new MaterialSkin.Controls.MaterialLabel();
            this.lblOperador = new MaterialSkin.Controls.MaterialLabel();
            this.dgvSalidaListaProducto = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSalidaListaProducto.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsSalidaListaProducto
            // 
            this.cmsSalidaListaProducto.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSalidaListaProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this.cmsSalidaListaProducto.Name = "cmsSalidaListaProducto";
            this.cmsSalidaListaProducto.Size = new System.Drawing.Size(118, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("materialCard1.BackgroundImage")));
            this.materialCard1.Controls.Add(this.tableLayoutPanel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(10, 70);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.materialCard1.Size = new System.Drawing.Size(1230, 814);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1210, 792);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.materialDivider1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblCantidad, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.txtSalidaCantidadProducto, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.lblProducto, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.cbxSalidaProducto, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.cbxOperador, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.cbxSalidaCliente, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.lblSalidaFecha, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblRuta, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblOperador, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 12;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(443, 776);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel3.SetColumnSpan(this.materialDivider1, 2);
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider1.Location = new System.Drawing.Point(3, 63);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(437, 4);
            this.materialDivider1.TabIndex = 22;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Gray;
            this.lblCantidad.Location = new System.Drawing.Point(0, 418);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(123, 32);
            this.lblCantidad.TabIndex = 21;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtSalidaCantidadProducto
            // 
            this.txtSalidaCantidadProducto.AnimateReadOnly = false;
            this.txtSalidaCantidadProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalidaCantidadProducto.Depth = 0;
            this.txtSalidaCantidadProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSalidaCantidadProducto.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSalidaCantidadProducto.LeadingIcon = null;
            this.txtSalidaCantidadProducto.Location = new System.Drawing.Point(5, 455);
            this.txtSalidaCantidadProducto.Margin = new System.Windows.Forms.Padding(5);
            this.txtSalidaCantidadProducto.MaxLength = 50;
            this.txtSalidaCantidadProducto.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSalidaCantidadProducto.Multiline = false;
            this.txtSalidaCantidadProducto.Name = "txtSalidaCantidadProducto";
            this.txtSalidaCantidadProducto.Size = new System.Drawing.Size(140, 50);
            this.txtSalidaCantidadProducto.TabIndex = 10;
            this.txtSalidaCantidadProducto.Text = "";
            this.txtSalidaCantidadProducto.TrailingIcon = null;
            this.txtSalidaCantidadProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalidaCantidadProducto_KeyPress_1);
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.Gray;
            this.lblProducto.Location = new System.Drawing.Point(0, 308);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(122, 32);
            this.lblProducto.TabIndex = 20;
            this.lblProducto.Text = "Producto";
            // 
            // cbxSalidaProducto
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxSalidaProducto, 2);
            this.cbxSalidaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSalidaProducto.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSalidaProducto.FormattingEnabled = true;
            this.cbxSalidaProducto.Location = new System.Drawing.Point(5, 345);
            this.cbxSalidaProducto.Margin = new System.Windows.Forms.Padding(5);
            this.cbxSalidaProducto.Name = "cbxSalidaProducto";
            this.cbxSalidaProducto.Size = new System.Drawing.Size(433, 40);
            this.cbxSalidaProducto.TabIndex = 4;
            this.cbxSalidaProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxSalidaProducto_KeyPress);
            // 
            // cbxOperador
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxOperador, 2);
            this.cbxOperador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxOperador.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOperador.FormattingEnabled = true;
            this.cbxOperador.Location = new System.Drawing.Point(5, 235);
            this.cbxOperador.Margin = new System.Windows.Forms.Padding(5);
            this.cbxOperador.Name = "cbxOperador";
            this.cbxOperador.Size = new System.Drawing.Size(433, 40);
            this.cbxOperador.TabIndex = 23;
            this.cbxOperador.SelectedIndexChanged += new System.EventHandler(this.cbxOperador_SelectedIndexChanged);
            // 
            // cbxSalidaCliente
            // 
            this.cbxSalidaCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSalidaCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel3.SetColumnSpan(this.cbxSalidaCliente, 2);
            this.cbxSalidaCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSalidaCliente.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSalidaCliente.FormattingEnabled = true;
            this.cbxSalidaCliente.Location = new System.Drawing.Point(5, 125);
            this.cbxSalidaCliente.Margin = new System.Windows.Forms.Padding(5);
            this.cbxSalidaCliente.Name = "cbxSalidaCliente";
            this.cbxSalidaCliente.Size = new System.Drawing.Size(433, 40);
            this.cbxSalidaCliente.TabIndex = 3;
            this.cbxSalidaCliente.SelectedIndexChanged += new System.EventHandler(this.cbxSalidaCliente_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.btnSalidaBorrar, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSalidaCompletar, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSalidaAgregarProducto, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 709);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(437, 64);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // btnSalidaBorrar
            // 
            this.btnSalidaBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnSalidaBorrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidaBorrar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaBorrar.ForeColor = System.Drawing.Color.White;
            this.btnSalidaBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaBorrar.Image")));
            this.btnSalidaBorrar.Location = new System.Drawing.Point(0, 0);
            this.btnSalidaBorrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalidaBorrar.Name = "btnSalidaBorrar";
            this.btnSalidaBorrar.Size = new System.Drawing.Size(145, 64);
            this.btnSalidaBorrar.TabIndex = 24;
            this.btnSalidaBorrar.Text = "ELIMINAR SALIDA";
            this.btnSalidaBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalidaBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalidaBorrar.UseVisualStyleBackColor = false;
            this.btnSalidaBorrar.Click += new System.EventHandler(this.btnSalidaBorrar_Click);
            // 
            // btnSalidaCompletar
            // 
            this.btnSalidaCompletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnSalidaCompletar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidaCompletar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaCompletar.ForeColor = System.Drawing.Color.White;
            this.btnSalidaCompletar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaCompletar.Image")));
            this.btnSalidaCompletar.Location = new System.Drawing.Point(145, 0);
            this.btnSalidaCompletar.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalidaCompletar.Name = "btnSalidaCompletar";
            this.btnSalidaCompletar.Size = new System.Drawing.Size(145, 64);
            this.btnSalidaCompletar.TabIndex = 24;
            this.btnSalidaCompletar.Text = "COMPLETAR SALIDA";
            this.btnSalidaCompletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalidaCompletar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalidaCompletar.UseVisualStyleBackColor = false;
            this.btnSalidaCompletar.Click += new System.EventHandler(this.btnSalidaCompletar_Click);
            // 
            // btnSalidaAgregarProducto
            // 
            this.btnSalidaAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnSalidaAgregarProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidaAgregarProducto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnSalidaAgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaAgregarProducto.Image")));
            this.btnSalidaAgregarProducto.Location = new System.Drawing.Point(290, 0);
            this.btnSalidaAgregarProducto.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalidaAgregarProducto.Name = "btnSalidaAgregarProducto";
            this.btnSalidaAgregarProducto.Size = new System.Drawing.Size(147, 64);
            this.btnSalidaAgregarProducto.TabIndex = 24;
            this.btnSalidaAgregarProducto.Text = "AGREGAR PRODUCTO";
            this.btnSalidaAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalidaAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalidaAgregarProducto.UseVisualStyleBackColor = false;
            this.btnSalidaAgregarProducto.Click += new System.EventHandler(this.btnSalidaAgregarProducto_Click);
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
            this.lblSalidaFecha.Location = new System.Drawing.Point(5, 5);
            this.lblSalidaFecha.Margin = new System.Windows.Forms.Padding(5);
            this.lblSalidaFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSalidaFecha.Name = "lblSalidaFecha";
            this.lblSalidaFecha.Padding = new System.Windows.Forms.Padding(5);
            this.lblSalidaFecha.Size = new System.Drawing.Size(433, 50);
            this.lblSalidaFecha.TabIndex = 24;
            this.lblSalidaFecha.Text = "Fecha";
            this.lblSalidaFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.lblRuta, 2);
            this.lblRuta.Depth = 0;
            this.lblRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRuta.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRuta.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblRuta.Location = new System.Drawing.Point(3, 70);
            this.lblRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(437, 50);
            this.lblRuta.TabIndex = 25;
            this.lblRuta.Text = "Ruta";
            this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.lblOperador, 2);
            this.lblOperador.Depth = 0;
            this.lblOperador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperador.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperador.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblOperador.Location = new System.Drawing.Point(3, 180);
            this.lblOperador.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(437, 50);
            this.lblOperador.TabIndex = 26;
            this.lblOperador.Text = "Operador";
            this.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.producto,
            this.cantidad});
            this.dgvSalidaListaProducto.ContextMenuStrip = this.cmsSalidaListaProducto;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidaListaProducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalidaListaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidaListaProducto.EnableHeadersVisualStyles = false;
            this.dgvSalidaListaProducto.Location = new System.Drawing.Point(456, 7);
            this.dgvSalidaListaProducto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSalidaListaProducto.Name = "dgvSalidaListaProducto";
            this.dgvSalidaListaProducto.RowHeadersVisible = false;
            this.dgvSalidaListaProducto.RowHeadersWidth = 51;
            this.dgvSalidaListaProducto.RowTemplate.Height = 60;
            this.dgvSalidaListaProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalidaListaProducto.Size = new System.Drawing.Size(747, 778);
            this.dgvSalidaListaProducto.TabIndex = 6;
            this.dgvSalidaListaProducto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvSalidaListaProducto_MouseDown);
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
            // producto
            // 
            this.producto.FillWeight = 158.8086F;
            this.producto.HeaderText = "Producto";
            this.producto.MinimumWidth = 500;
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.FillWeight = 133.5773F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 50;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // FormSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 894);
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSalida";
            this.Padding = new System.Windows.Forms.Padding(10, 70, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salida de producto del almacén | Nueva salida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSalida_FormClosing);
            this.Load += new System.EventHandler(this.FormSalida_Load);
            this.cmsSalidaListaProducto.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsSalidaListaProducto;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbxSalidaCliente;
        private MaterialSkin.Controls.MaterialTextBox txtSalidaCantidadProducto;
        private System.Windows.Forms.ComboBox cbxSalidaProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.ComboBox cbxOperador;
        private System.Windows.Forms.Button btnSalidaBorrar;
        private System.Windows.Forms.Button btnSalidaCompletar;
        private System.Windows.Forms.Button btnSalidaAgregarProducto;
        private MaterialSkin.Controls.MaterialLabel lblSalidaFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private MaterialSkin.Controls.MaterialLabel lblRuta;
        private MaterialSkin.Controls.MaterialLabel lblOperador;
    }
}