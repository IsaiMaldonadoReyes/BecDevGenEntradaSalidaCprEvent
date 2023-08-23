namespace BecDevGenEntradaSalidaCprEvent
{
    partial class FormDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevolucion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDevolucionFecha = new MaterialSkin.Controls.MaterialLabel();
            this.lblDevolucionDocumento = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDevolucionCompletar = new System.Windows.Forms.Button();
            this.lblDevolucionCliente = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider4 = new MaterialSkin.Controls.MaterialDivider();
            this.lblDevolucionAgente = new MaterialSkin.Controls.MaterialLabel();
            this.dgvDevolucionListaProducto = new System.Windows.Forms.DataGridView();
            this.id_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_cantidad_devolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_cantidad_extra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDevolucionOperador = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucionListaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.tableLayoutPanel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(13, 86);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.materialCard1.Size = new System.Drawing.Size(1254, 653);
            this.materialCard1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDevolucionListaProducto, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1228, 625);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblDevolucionFecha, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDevolucionDocumento, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.materialDivider1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.materialDivider2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.materialDivider3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblDevolucionCliente, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.materialDivider4, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblDevolucionOperador, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblDevolucionAgente, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(392, 617);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // lblDevolucionFecha
            // 
            this.lblDevolucionFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevolucionFecha.AutoSize = true;
            this.lblDevolucionFecha.Depth = 0;
            this.lblDevolucionFecha.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDevolucionFecha.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblDevolucionFecha.Location = new System.Drawing.Point(3, 22);
            this.lblDevolucionFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDevolucionFecha.Name = "lblDevolucionFecha";
            this.lblDevolucionFecha.Size = new System.Drawing.Size(386, 29);
            this.lblDevolucionFecha.TabIndex = 0;
            this.lblDevolucionFecha.Text = "Fecha";
            this.lblDevolucionFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDevolucionDocumento
            // 
            this.lblDevolucionDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevolucionDocumento.AutoSize = true;
            this.lblDevolucionDocumento.Depth = 0;
            this.lblDevolucionDocumento.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDevolucionDocumento.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblDevolucionDocumento.Location = new System.Drawing.Point(3, 108);
            this.lblDevolucionDocumento.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDevolucionDocumento.Name = "lblDevolucionDocumento";
            this.lblDevolucionDocumento.Size = new System.Drawing.Size(386, 29);
            this.lblDevolucionDocumento.TabIndex = 2;
            this.lblDevolucionDocumento.Text = "Documento";
            this.lblDevolucionDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider1.Location = new System.Drawing.Point(4, 78);
            this.materialDivider1.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(384, 4);
            this.materialDivider1.TabIndex = 6;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider2.Location = new System.Drawing.Point(4, 164);
            this.materialDivider2.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(384, 4);
            this.materialDivider2.TabIndex = 7;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider3.Location = new System.Drawing.Point(4, 250);
            this.materialDivider3.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(384, 4);
            this.materialDivider3.TabIndex = 8;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Controls.Add(this.btnDevolucionCompletar, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 535);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 78);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // btnDevolucionCompletar
            // 
            this.btnDevolucionCompletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            this.btnDevolucionCompletar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDevolucionCompletar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolucionCompletar.ForeColor = System.Drawing.Color.White;
            this.btnDevolucionCompletar.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucionCompletar.Image")));
            this.btnDevolucionCompletar.Location = new System.Drawing.Point(0, 0);
            this.btnDevolucionCompletar.Margin = new System.Windows.Forms.Padding(0);
            this.btnDevolucionCompletar.Name = "btnDevolucionCompletar";
            this.btnDevolucionCompletar.Size = new System.Drawing.Size(384, 78);
            this.btnDevolucionCompletar.TabIndex = 9;
            this.btnDevolucionCompletar.Text = "COMPLETAR DEVOLUCIÓN";
            this.btnDevolucionCompletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevolucionCompletar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDevolucionCompletar.UseVisualStyleBackColor = false;
            this.btnDevolucionCompletar.Click += new System.EventHandler(this.btnDevolucionCompletar_Click);
            // 
            // lblDevolucionCliente
            // 
            this.lblDevolucionCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevolucionCliente.AutoSize = true;
            this.lblDevolucionCliente.Depth = 0;
            this.lblDevolucionCliente.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDevolucionCliente.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblDevolucionCliente.Location = new System.Drawing.Point(3, 280);
            this.lblDevolucionCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDevolucionCliente.Name = "lblDevolucionCliente";
            this.lblDevolucionCliente.Size = new System.Drawing.Size(386, 29);
            this.lblDevolucionCliente.TabIndex = 4;
            this.lblDevolucionCliente.Text = "Ruta";
            this.lblDevolucionCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialDivider4
            // 
            this.materialDivider4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider4.Depth = 0;
            this.materialDivider4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDivider4.Location = new System.Drawing.Point(4, 336);
            this.materialDivider4.Margin = new System.Windows.Forms.Padding(4);
            this.materialDivider4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider4.Name = "materialDivider4";
            this.materialDivider4.Size = new System.Drawing.Size(384, 4);
            this.materialDivider4.TabIndex = 9;
            this.materialDivider4.Text = "materialDivider4";
            // 
            // lblDevolucionAgente
            // 
            this.lblDevolucionAgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevolucionAgente.AutoSize = true;
            this.lblDevolucionAgente.Depth = 0;
            this.lblDevolucionAgente.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDevolucionAgente.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblDevolucionAgente.Location = new System.Drawing.Point(3, 194);
            this.lblDevolucionAgente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDevolucionAgente.Name = "lblDevolucionAgente";
            this.lblDevolucionAgente.Size = new System.Drawing.Size(386, 29);
            this.lblDevolucionAgente.TabIndex = 1;
            this.lblDevolucionAgente.Text = "Agente";
            this.lblDevolucionAgente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDevolucionListaProducto
            // 
            this.dgvDevolucionListaProducto.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDevolucionListaProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevolucionListaProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevolucionListaProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDevolucionListaProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvDevolucionListaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevolucionListaProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDevolucionListaProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(62)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevolucionListaProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDevolucionListaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevolucionListaProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_salida,
            this.producto_codigo,
            this.producto_cantidad,
            this.producto_cantidad_devolucion,
            this.producto_cantidad_extra});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(141)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevolucionListaProducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDevolucionListaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevolucionListaProducto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDevolucionListaProducto.EnableHeadersVisualStyles = false;
            this.dgvDevolucionListaProducto.Location = new System.Drawing.Point(403, 2);
            this.dgvDevolucionListaProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDevolucionListaProducto.Name = "dgvDevolucionListaProducto";
            this.dgvDevolucionListaProducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDevolucionListaProducto.RowHeadersVisible = false;
            this.dgvDevolucionListaProducto.RowHeadersWidth = 51;
            this.dgvDevolucionListaProducto.RowTemplate.Height = 60;
            this.dgvDevolucionListaProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevolucionListaProducto.Size = new System.Drawing.Size(822, 621);
            this.dgvDevolucionListaProducto.StandardTab = true;
            this.dgvDevolucionListaProducto.TabIndex = 5;
            this.dgvDevolucionListaProducto.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDevolucionListaProducto_EditingControlShowing);
            // 
            // id_salida
            // 
            this.id_salida.HeaderText = "ID";
            this.id_salida.MinimumWidth = 6;
            this.id_salida.Name = "id_salida";
            this.id_salida.ReadOnly = true;
            this.id_salida.Visible = false;
            // 
            // producto_codigo
            // 
            this.producto_codigo.HeaderText = "Producto";
            this.producto_codigo.MinimumWidth = 6;
            this.producto_codigo.Name = "producto_codigo";
            this.producto_codigo.ReadOnly = true;
            // 
            // producto_cantidad
            // 
            this.producto_cantidad.HeaderText = "Cantidad salida";
            this.producto_cantidad.MinimumWidth = 6;
            this.producto_cantidad.Name = "producto_cantidad";
            this.producto_cantidad.ReadOnly = true;
            // 
            // producto_cantidad_devolucion
            // 
            this.producto_cantidad_devolucion.HeaderText = "Devolución";
            this.producto_cantidad_devolucion.MinimumWidth = 6;
            this.producto_cantidad_devolucion.Name = "producto_cantidad_devolucion";
            // 
            // producto_cantidad_extra
            // 
            this.producto_cantidad_extra.HeaderText = "Producto dañado";
            this.producto_cantidad_extra.MinimumWidth = 6;
            this.producto_cantidad_extra.Name = "producto_cantidad_extra";
            // 
            // lblDevolucionOperador
            // 
            this.lblDevolucionOperador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDevolucionOperador.AutoSize = true;
            this.lblDevolucionOperador.Depth = 0;
            this.lblDevolucionOperador.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDevolucionOperador.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblDevolucionOperador.Location = new System.Drawing.Point(4, 366);
            this.lblDevolucionOperador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDevolucionOperador.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDevolucionOperador.Name = "lblDevolucionOperador";
            this.lblDevolucionOperador.Size = new System.Drawing.Size(384, 29);
            this.lblDevolucionOperador.TabIndex = 10;
            this.lblDevolucionOperador.Text = "Operador";
            this.lblDevolucionOperador.Visible = false;
            // 
            // FormDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 751);
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDevolucion";
            this.Padding = new System.Windows.Forms.Padding(13, 86, 13, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Devolución de producto al almacén ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDevolucion_Load);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucionListaProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel lblDevolucionFecha;
        private MaterialSkin.Controls.MaterialLabel lblDevolucionAgente;
        private MaterialSkin.Controls.MaterialLabel lblDevolucionDocumento;
        private MaterialSkin.Controls.MaterialLabel lblDevolucionCliente;
        private System.Windows.Forms.DataGridView dgvDevolucionListaProducto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private System.Windows.Forms.Button btnDevolucionCompletar;
        private MaterialSkin.Controls.MaterialDivider materialDivider4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_cantidad_devolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_cantidad_extra;
        private MaterialSkin.Controls.MaterialLabel lblDevolucionOperador;
    }
}