namespace BecDevGenEntradaSalidaCprEvent
{
    partial class ListadoSalidas
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
            System.Windows.Forms.Button btnSalidaActualizar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoSalidas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSalidaListadoSalidas = new System.Windows.Forms.DataGridView();
            this.id_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.entrada_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.liquidar_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalidaNuevoFormulario = new System.Windows.Forms.Button();
            this.lblUsuarioLogeado = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            btnSalidaActualizar = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListadoSalidas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalidaActualizar
            // 
            btnSalidaActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            btnSalidaActualizar.CausesValidation = false;
            btnSalidaActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSalidaActualizar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSalidaActualizar.ForeColor = System.Drawing.Color.White;
            btnSalidaActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaActualizar.Image")));
            btnSalidaActualizar.Location = new System.Drawing.Point(-7, 0);
            btnSalidaActualizar.Margin = new System.Windows.Forms.Padding(0);
            btnSalidaActualizar.Name = "btnSalidaActualizar";
            btnSalidaActualizar.Size = new System.Drawing.Size(267, 94);
            btnSalidaActualizar.TabIndex = 5;
            btnSalidaActualizar.Text = "ACTUALIZAR";
            btnSalidaActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSalidaActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            btnSalidaActualizar.UseVisualStyleBackColor = false;
            btnSalidaActualizar.Click += new System.EventHandler(this.btnSalidaActualizar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.materialCard1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(1037, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Salida de productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            this.materialCard1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.tableLayoutPanel1);
            this.materialCard1.Controls.Add(this.tableLayoutPanel2);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(5, 5);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(20);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(20);
            this.materialCard1.Size = new System.Drawing.Size(1027, 605);
            this.materialCard1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel1.Controls.Add(this.dgvSalidaListadoSalidas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuarioLogeado, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(987, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvSalidaListadoSalidas
            // 
            this.dgvSalidaListadoSalidas.AllowUserToAddRows = false;
            this.dgvSalidaListadoSalidas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalidaListadoSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalidaListadoSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidaListadoSalidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalidaListadoSalidas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvSalidaListadoSalidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalidaListadoSalidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSalidaListadoSalidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidaListadoSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalidaListadoSalidas.ColumnHeadersHeight = 45;
            this.dgvSalidaListadoSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_salida,
            this.salida_fecha,
            this.salida_cliente,
            this.salida_operador,
            this.salida_documento,
            this.salida_accion,
            this.entrada_accion,
            this.liquidar_accion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvSalidaListadoSalidas, 2);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidaListadoSalidas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSalidaListadoSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidaListadoSalidas.EnableHeadersVisualStyles = false;
            this.dgvSalidaListadoSalidas.GridColor = System.Drawing.Color.LightGray;
            this.dgvSalidaListadoSalidas.Location = new System.Drawing.Point(8, 105);
            this.dgvSalidaListadoSalidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSalidaListadoSalidas.Name = "dgvSalidaListadoSalidas";
            this.dgvSalidaListadoSalidas.RowHeadersVisible = false;
            this.dgvSalidaListadoSalidas.RowHeadersWidth = 51;
            this.dgvSalidaListadoSalidas.RowTemplate.Height = 60;
            this.dgvSalidaListadoSalidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidaListadoSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSalidaListadoSalidas.Size = new System.Drawing.Size(971, 453);
            this.dgvSalidaListadoSalidas.TabIndex = 0;
            this.dgvSalidaListadoSalidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalidaListadoSalidas_CellContentClick);
            this.dgvSalidaListadoSalidas.SizeChanged += new System.EventHandler(this.dgvSalidaListadoSalidas_SizeChanged);
            // 
            // id_salida
            // 
            this.id_salida.FillWeight = 20.30457F;
            this.id_salida.HeaderText = "ID";
            this.id_salida.MinimumWidth = 6;
            this.id_salida.Name = "id_salida";
            this.id_salida.ReadOnly = true;
            this.id_salida.Visible = false;
            // 
            // salida_fecha
            // 
            this.salida_fecha.FillWeight = 10F;
            this.salida_fecha.HeaderText = "Fecha";
            this.salida_fecha.MinimumWidth = 100;
            this.salida_fecha.Name = "salida_fecha";
            this.salida_fecha.ReadOnly = true;
            // 
            // salida_cliente
            // 
            this.salida_cliente.FillWeight = 20F;
            this.salida_cliente.HeaderText = "Ruta";
            this.salida_cliente.MinimumWidth = 100;
            this.salida_cliente.Name = "salida_cliente";
            this.salida_cliente.ReadOnly = true;
            // 
            // salida_operador
            // 
            this.salida_operador.FillWeight = 30F;
            this.salida_operador.HeaderText = "Operador";
            this.salida_operador.MinimumWidth = 300;
            this.salida_operador.Name = "salida_operador";
            this.salida_operador.ReadOnly = true;
            // 
            // salida_documento
            // 
            this.salida_documento.FillWeight = 10F;
            this.salida_documento.HeaderText = "Documento salida";
            this.salida_documento.MinimumWidth = 100;
            this.salida_documento.Name = "salida_documento";
            this.salida_documento.ReadOnly = true;
            this.salida_documento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // salida_accion
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.salida_accion.DefaultCellStyle = dataGridViewCellStyle3;
            this.salida_accion.FillWeight = 10F;
            this.salida_accion.HeaderText = "Salida";
            this.salida_accion.Image = ((System.Drawing.Image)(resources.GetObject("salida_accion.Image")));
            this.salida_accion.MinimumWidth = 30;
            this.salida_accion.Name = "salida_accion";
            this.salida_accion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.salida_accion.ToolTipText = "Visualizar detalle de la salida del almacén";
            // 
            // entrada_accion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.entrada_accion.DefaultCellStyle = dataGridViewCellStyle4;
            this.entrada_accion.FillWeight = 10F;
            this.entrada_accion.HeaderText = "Devolución";
            this.entrada_accion.Image = ((System.Drawing.Image)(resources.GetObject("entrada_accion.Image")));
            this.entrada_accion.MinimumWidth = 30;
            this.entrada_accion.Name = "entrada_accion";
            this.entrada_accion.ReadOnly = true;
            this.entrada_accion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.entrada_accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.entrada_accion.ToolTipText = "Crear devolución sobre salida";
            // 
            // liquidar_accion
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.liquidar_accion.DefaultCellStyle = dataGridViewCellStyle5;
            this.liquidar_accion.FillWeight = 10F;
            this.liquidar_accion.HeaderText = "Liquidación";
            this.liquidar_accion.Image = ((System.Drawing.Image)(resources.GetObject("liquidar_accion.Image")));
            this.liquidar_accion.MinimumWidth = 30;
            this.liquidar_accion.Name = "liquidar_accion";
            this.liquidar_accion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.liquidar_accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.liquidar_accion.ToolTipText = "Liquidar productos";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel3.Controls.Add(btnSalidaActualizar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSalidaNuevoFormulario, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(452, 7);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(527, 94);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnSalidaNuevoFormulario
            // 
            this.btnSalidaNuevoFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnSalidaNuevoFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidaNuevoFormulario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaNuevoFormulario.ForeColor = System.Drawing.Color.White;
            this.btnSalidaNuevoFormulario.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaNuevoFormulario.Image")));
            this.btnSalidaNuevoFormulario.Location = new System.Drawing.Point(260, 0);
            this.btnSalidaNuevoFormulario.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalidaNuevoFormulario.Name = "btnSalidaNuevoFormulario";
            this.btnSalidaNuevoFormulario.Size = new System.Drawing.Size(267, 94);
            this.btnSalidaNuevoFormulario.TabIndex = 5;
            this.btnSalidaNuevoFormulario.Text = "NUEVA SALIDA";
            this.btnSalidaNuevoFormulario.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalidaNuevoFormulario.UseVisualStyleBackColor = false;
            this.btnSalidaNuevoFormulario.Click += new System.EventHandler(this.btnNuevaSalida_Click);
            // 
            // lblUsuarioLogeado
            // 
            this.lblUsuarioLogeado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioLogeado.AutoSize = true;
            this.lblUsuarioLogeado.Depth = 0;
            this.lblUsuarioLogeado.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUsuarioLogeado.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblUsuarioLogeado.Location = new System.Drawing.Point(9, 39);
            this.lblUsuarioLogeado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioLogeado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsuarioLogeado.Name = "lblUsuarioLogeado";
            this.lblUsuarioLogeado.Size = new System.Drawing.Size(436, 29);
            this.lblUsuarioLogeado.TabIndex = 3;
            this.lblUsuarioLogeado.Text = "Usuario Logeado";
            this.lblUsuarioLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 565F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(987, 565);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(11, 80);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.Padding = new System.Drawing.Point(10, 5);
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1045, 648);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewImageColumn1.FillWeight = 111.3851F;
            this.dataGridViewImageColumn1.HeaderText = "Salida";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.ToolTipText = "Visualizar detalle de la salida del almacén";
            this.dataGridViewImageColumn1.Width = 107;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewImageColumn2.FillWeight = 111.3851F;
            this.dataGridViewImageColumn2.HeaderText = "Devolución";
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.ToolTipText = "Crear devolución sobre salida";
            this.dataGridViewImageColumn2.Width = 107;
            // 
            // dataGridViewImageColumn3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle9.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle9.NullValue")));
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.dataGridViewImageColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewImageColumn3.FillWeight = 10F;
            this.dataGridViewImageColumn3.HeaderText = "Liquidar";
            this.dataGridViewImageColumn3.MinimumWidth = 30;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.ToolTipText = "Liquidar productos";
            this.dataGridViewImageColumn3.Width = 96;
            // 
            // ListadoSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListadoSalidas";
            this.Padding = new System.Windows.Forms.Padding(11, 80, 11, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Express | Listado de salidas pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoSalidas_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tabPage1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListadoSalidas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvSalidaListadoSalidas;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private MaterialSkin.Controls.MaterialLabel lblUsuarioLogeado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSalidaNuevoFormulario;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn salida_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn salida_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn salida_operador;
        private System.Windows.Forms.DataGridViewTextBoxColumn salida_documento;
        private System.Windows.Forms.DataGridViewImageColumn salida_accion;
        private System.Windows.Forms.DataGridViewImageColumn entrada_accion;
        private System.Windows.Forms.DataGridViewImageColumn liquidar_accion;
    }
}