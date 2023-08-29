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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalidaNuevoFormulario = new System.Windows.Forms.Button();
            this.lblUsuarioLogeado = new MaterialSkin.Controls.MaterialLabel();
            this.dgvSalidaListadoSalidas = new System.Windows.Forms.DataGridView();
            this.id_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.entrada_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.liquidar_accion = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRptInventarioPorAlmacen = new MaterialSkin.Controls.MaterialButton();
            this.btnRptInventarioPorRuta = new MaterialSkin.Controls.MaterialButton();
            this.btnRptHistoricoMovimientosGeneral = new MaterialSkin.Controls.MaterialButton();
            this.btnRptHistoricoMovimientosPorRuta = new MaterialSkin.Controls.MaterialButton();
            this.btnRptResumenMovimientosGlobalDelDia = new MaterialSkin.Controls.MaterialButton();
            this.btnRptResumenMovimientosDetalladoPorRuta = new MaterialSkin.Controls.MaterialButton();
            btnSalidaActualizar = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListadoSalidas)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            btnSalidaActualizar.Location = new System.Drawing.Point(-5, 0);
            btnSalidaActualizar.Margin = new System.Windows.Forms.Padding(0);
            btnSalidaActualizar.Name = "btnSalidaActualizar";
            btnSalidaActualizar.Size = new System.Drawing.Size(200, 76);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(776, 497);
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
            this.materialCard1.Location = new System.Drawing.Point(4, 4);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.materialCard1.Size = new System.Drawing.Size(768, 489);
            this.materialCard1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuarioLogeado, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSalidaListadoSalidas, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 457);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.Controls.Add(btnSalidaActualizar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSalidaNuevoFormulario, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(337, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(395, 76);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnSalidaNuevoFormulario
            // 
            this.btnSalidaNuevoFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnSalidaNuevoFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidaNuevoFormulario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaNuevoFormulario.ForeColor = System.Drawing.Color.White;
            this.btnSalidaNuevoFormulario.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaNuevoFormulario.Image")));
            this.btnSalidaNuevoFormulario.Location = new System.Drawing.Point(195, 0);
            this.btnSalidaNuevoFormulario.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalidaNuevoFormulario.Name = "btnSalidaNuevoFormulario";
            this.btnSalidaNuevoFormulario.Size = new System.Drawing.Size(200, 76);
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
            this.lblUsuarioLogeado.Location = new System.Drawing.Point(7, 29);
            this.lblUsuarioLogeado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsuarioLogeado.Name = "lblUsuarioLogeado";
            this.lblUsuarioLogeado.Size = new System.Drawing.Size(325, 29);
            this.lblUsuarioLogeado.TabIndex = 3;
            this.lblUsuarioLogeado.Text = "Usuario Logeado";
            this.lblUsuarioLogeado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSalidaListadoSalidas
            // 
            this.dgvSalidaListadoSalidas.AllowUserToAddRows = false;
            this.dgvSalidaListadoSalidas.AllowUserToResizeRows = false;
            dataGridViewCellStyle82.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle82.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalidaListadoSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle82;
            this.dgvSalidaListadoSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidaListadoSalidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalidaListadoSalidas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvSalidaListadoSalidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalidaListadoSalidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSalidaListadoSalidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle83.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle83.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle83.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle83.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle83.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidaListadoSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle83;
            this.dgvSalidaListadoSalidas.ColumnHeadersHeight = 45;
            this.dgvSalidaListadoSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_salida,
            this.salida_fecha,
            this.salida_cliente,
            this.salida_documento,
            this.salida_accion,
            this.entrada_accion,
            this.liquidar_accion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvSalidaListadoSalidas, 2);
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle87.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle87.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle87.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle87.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle87.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidaListadoSalidas.DefaultCellStyle = dataGridViewCellStyle87;
            this.dgvSalidaListadoSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidaListadoSalidas.EnableHeadersVisualStyles = false;
            this.dgvSalidaListadoSalidas.GridColor = System.Drawing.Color.LightGray;
            this.dgvSalidaListadoSalidas.Location = new System.Drawing.Point(6, 86);
            this.dgvSalidaListadoSalidas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSalidaListadoSalidas.Name = "dgvSalidaListadoSalidas";
            this.dgvSalidaListadoSalidas.RowHeadersVisible = false;
            this.dgvSalidaListadoSalidas.RowHeadersWidth = 51;
            this.dgvSalidaListadoSalidas.RowTemplate.Height = 60;
            this.dgvSalidaListadoSalidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidaListadoSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSalidaListadoSalidas.Size = new System.Drawing.Size(726, 365);
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
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle84.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle84.NullValue")));
            dataGridViewCellStyle84.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle84.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.salida_accion.DefaultCellStyle = dataGridViewCellStyle84;
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
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle85.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle85.NullValue")));
            dataGridViewCellStyle85.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle85.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.entrada_accion.DefaultCellStyle = dataGridViewCellStyle85;
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
            dataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle86.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle86.NullValue")));
            dataGridViewCellStyle86.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle86.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.liquidar_accion.DefaultCellStyle = dataGridViewCellStyle86;
            this.liquidar_accion.FillWeight = 10F;
            this.liquidar_accion.HeaderText = "Liquidación";
            this.liquidar_accion.Image = ((System.Drawing.Image)(resources.GetObject("liquidar_accion.Image")));
            this.liquidar_accion.MinimumWidth = 30;
            this.liquidar_accion.Name = "liquidar_accion";
            this.liquidar_accion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.liquidar_accion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.liquidar_accion.ToolTipText = "Liquidar productos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 459F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(738, 457);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(8, 65);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.Padding = new System.Drawing.Point(10, 5);
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(784, 527);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle88.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle88.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle88.NullValue")));
            dataGridViewCellStyle88.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle88.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle88;
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
            dataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle89.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle89.NullValue")));
            dataGridViewCellStyle89.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle89.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle89;
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
            dataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle90.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle90.NullValue")));
            dataGridViewCellStyle90.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle90.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            this.dataGridViewImageColumn3.DefaultCellStyle = dataGridViewCellStyle90;
            this.dataGridViewImageColumn3.FillWeight = 10F;
            this.dataGridViewImageColumn3.HeaderText = "Liquidar";
            this.dataGridViewImageColumn3.MinimumWidth = 30;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.ToolTipText = "Liquidar productos";
            this.dataGridViewImageColumn3.Width = 96;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.materialCard3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(776, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reportes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.tableLayoutPanel5);
            this.materialCard3.Depth = 0;
            this.materialCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(0, 0);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(776, 497);
            this.materialCard3.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnRptInventarioPorAlmacen, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnRptInventarioPorRuta, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnRptHistoricoMovimientosGeneral, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnRptHistoricoMovimientosPorRuta, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnRptResumenMovimientosGlobalDelDia, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.btnRptResumenMovimientosDetalladoPorRuta, 1, 5);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 9;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(748, 469);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnRptInventarioPorAlmacen
            // 
            this.btnRptInventarioPorAlmacen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptInventarioPorAlmacen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptInventarioPorAlmacen.Depth = 0;
            this.btnRptInventarioPorAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptInventarioPorAlmacen.HighEmphasis = true;
            this.btnRptInventarioPorAlmacen.Icon = null;
            this.btnRptInventarioPorAlmacen.Location = new System.Drawing.Point(203, 6);
            this.btnRptInventarioPorAlmacen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptInventarioPorAlmacen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptInventarioPorAlmacen.Name = "btnRptInventarioPorAlmacen";
            this.btnRptInventarioPorAlmacen.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptInventarioPorAlmacen.Size = new System.Drawing.Size(342, 48);
            this.btnRptInventarioPorAlmacen.TabIndex = 0;
            this.btnRptInventarioPorAlmacen.Text = "Inventario por almacén";
            this.btnRptInventarioPorAlmacen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptInventarioPorAlmacen.UseAccentColor = false;
            this.btnRptInventarioPorAlmacen.UseVisualStyleBackColor = true;
            this.btnRptInventarioPorAlmacen.Click += new System.EventHandler(this.btnRptInventarioPorAlmacen_Click);
            // 
            // btnRptInventarioPorRuta
            // 
            this.btnRptInventarioPorRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptInventarioPorRuta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptInventarioPorRuta.Depth = 0;
            this.btnRptInventarioPorRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptInventarioPorRuta.HighEmphasis = true;
            this.btnRptInventarioPorRuta.Icon = null;
            this.btnRptInventarioPorRuta.Location = new System.Drawing.Point(203, 66);
            this.btnRptInventarioPorRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptInventarioPorRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptInventarioPorRuta.Name = "btnRptInventarioPorRuta";
            this.btnRptInventarioPorRuta.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptInventarioPorRuta.Size = new System.Drawing.Size(342, 48);
            this.btnRptInventarioPorRuta.TabIndex = 1;
            this.btnRptInventarioPorRuta.Text = "Inventario por ruta";
            this.btnRptInventarioPorRuta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptInventarioPorRuta.UseAccentColor = false;
            this.btnRptInventarioPorRuta.UseVisualStyleBackColor = true;
            this.btnRptInventarioPorRuta.Click += new System.EventHandler(this.btnRptInventarioPorRuta_Click);
            // 
            // btnRptHistoricoMovimientosGeneral
            // 
            this.btnRptHistoricoMovimientosGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptHistoricoMovimientosGeneral.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptHistoricoMovimientosGeneral.Depth = 0;
            this.btnRptHistoricoMovimientosGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptHistoricoMovimientosGeneral.HighEmphasis = true;
            this.btnRptHistoricoMovimientosGeneral.Icon = null;
            this.btnRptHistoricoMovimientosGeneral.Location = new System.Drawing.Point(203, 126);
            this.btnRptHistoricoMovimientosGeneral.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptHistoricoMovimientosGeneral.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptHistoricoMovimientosGeneral.Name = "btnRptHistoricoMovimientosGeneral";
            this.btnRptHistoricoMovimientosGeneral.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptHistoricoMovimientosGeneral.Size = new System.Drawing.Size(342, 48);
            this.btnRptHistoricoMovimientosGeneral.TabIndex = 2;
            this.btnRptHistoricoMovimientosGeneral.Text = "Histórico de movimientos general";
            this.btnRptHistoricoMovimientosGeneral.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptHistoricoMovimientosGeneral.UseAccentColor = false;
            this.btnRptHistoricoMovimientosGeneral.UseVisualStyleBackColor = true;
            this.btnRptHistoricoMovimientosGeneral.Click += new System.EventHandler(this.btnRptHistoricoMovimientosGeneral_Click);
            // 
            // btnRptHistoricoMovimientosPorRuta
            // 
            this.btnRptHistoricoMovimientosPorRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptHistoricoMovimientosPorRuta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptHistoricoMovimientosPorRuta.Depth = 0;
            this.btnRptHistoricoMovimientosPorRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptHistoricoMovimientosPorRuta.HighEmphasis = true;
            this.btnRptHistoricoMovimientosPorRuta.Icon = null;
            this.btnRptHistoricoMovimientosPorRuta.Location = new System.Drawing.Point(203, 186);
            this.btnRptHistoricoMovimientosPorRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptHistoricoMovimientosPorRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptHistoricoMovimientosPorRuta.Name = "btnRptHistoricoMovimientosPorRuta";
            this.btnRptHistoricoMovimientosPorRuta.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptHistoricoMovimientosPorRuta.Size = new System.Drawing.Size(342, 48);
            this.btnRptHistoricoMovimientosPorRuta.TabIndex = 3;
            this.btnRptHistoricoMovimientosPorRuta.Text = "Histórico de movimientos por ruta";
            this.btnRptHistoricoMovimientosPorRuta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptHistoricoMovimientosPorRuta.UseAccentColor = false;
            this.btnRptHistoricoMovimientosPorRuta.UseVisualStyleBackColor = true;
            this.btnRptHistoricoMovimientosPorRuta.Click += new System.EventHandler(this.btnRptHistoricoMovimientosPorRuta_Click);
            // 
            // btnRptResumenMovimientosGlobalDelDia
            // 
            this.btnRptResumenMovimientosGlobalDelDia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptResumenMovimientosGlobalDelDia.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptResumenMovimientosGlobalDelDia.Depth = 0;
            this.btnRptResumenMovimientosGlobalDelDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptResumenMovimientosGlobalDelDia.HighEmphasis = true;
            this.btnRptResumenMovimientosGlobalDelDia.Icon = null;
            this.btnRptResumenMovimientosGlobalDelDia.Location = new System.Drawing.Point(203, 246);
            this.btnRptResumenMovimientosGlobalDelDia.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptResumenMovimientosGlobalDelDia.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptResumenMovimientosGlobalDelDia.Name = "btnRptResumenMovimientosGlobalDelDia";
            this.btnRptResumenMovimientosGlobalDelDia.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptResumenMovimientosGlobalDelDia.Size = new System.Drawing.Size(342, 48);
            this.btnRptResumenMovimientosGlobalDelDia.TabIndex = 4;
            this.btnRptResumenMovimientosGlobalDelDia.Text = "Resumen de movimientos global del día";
            this.btnRptResumenMovimientosGlobalDelDia.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptResumenMovimientosGlobalDelDia.UseAccentColor = false;
            this.btnRptResumenMovimientosGlobalDelDia.UseVisualStyleBackColor = true;
            this.btnRptResumenMovimientosGlobalDelDia.Click += new System.EventHandler(this.btnRptResumenMovimientosGlobalDelDia_Click);
            // 
            // btnRptResumenMovimientosDetalladoPorRuta
            // 
            this.btnRptResumenMovimientosDetalladoPorRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRptResumenMovimientosDetalladoPorRuta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRptResumenMovimientosDetalladoPorRuta.Depth = 0;
            this.btnRptResumenMovimientosDetalladoPorRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRptResumenMovimientosDetalladoPorRuta.HighEmphasis = true;
            this.btnRptResumenMovimientosDetalladoPorRuta.Icon = null;
            this.btnRptResumenMovimientosDetalladoPorRuta.Location = new System.Drawing.Point(203, 306);
            this.btnRptResumenMovimientosDetalladoPorRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRptResumenMovimientosDetalladoPorRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRptResumenMovimientosDetalladoPorRuta.Name = "btnRptResumenMovimientosDetalladoPorRuta";
            this.btnRptResumenMovimientosDetalladoPorRuta.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRptResumenMovimientosDetalladoPorRuta.Size = new System.Drawing.Size(342, 48);
            this.btnRptResumenMovimientosDetalladoPorRuta.TabIndex = 6;
            this.btnRptResumenMovimientosDetalladoPorRuta.Text = "Resumen de movimientos detallado por ruta";
            this.btnRptResumenMovimientosDetalladoPorRuta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRptResumenMovimientosDetalladoPorRuta.UseAccentColor = false;
            this.btnRptResumenMovimientosDetalladoPorRuta.UseVisualStyleBackColor = true;
            this.btnRptResumenMovimientosDetalladoPorRuta.Click += new System.EventHandler(this.btnRptResumenMovimientosDetalladoPorRuta_Click);
            // 
            // ListadoSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ListadoSalidas";
            this.Padding = new System.Windows.Forms.Padding(8, 65, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Express | Listado de salidas pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoSalidas_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tabPage1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaListadoSalidas)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.materialCard3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn salida_documento;
        private System.Windows.Forms.DataGridViewImageColumn salida_accion;
        private System.Windows.Forms.DataGridViewImageColumn entrada_accion;
        private System.Windows.Forms.DataGridViewImageColumn liquidar_accion;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MaterialSkin.Controls.MaterialButton btnRptInventarioPorAlmacen;
        private MaterialSkin.Controls.MaterialButton btnRptInventarioPorRuta;
        private MaterialSkin.Controls.MaterialButton btnRptHistoricoMovimientosGeneral;
        private MaterialSkin.Controls.MaterialButton btnRptHistoricoMovimientosPorRuta;
        private MaterialSkin.Controls.MaterialButton btnRptResumenMovimientosGlobalDelDia;
        private MaterialSkin.Controls.MaterialButton btnRptResumenMovimientosDetalladoPorRuta;
    }
}