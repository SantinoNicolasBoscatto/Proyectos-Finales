
namespace AppCodigoDeArticulos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DgvProductos = new System.Windows.Forms.DataGridView();
            this.ProductosPictureBox = new System.Windows.Forms.PictureBox();
            this.EliminarBoton = new System.Windows.Forms.Button();
            this.ModificarBoton = new System.Windows.Forms.Button();
            this.AgregarBoton = new System.Windows.Forms.Button();
            this.CampoComboBox = new System.Windows.Forms.ComboBox();
            this.CriterioComboBox = new System.Windows.Forms.ComboBox();
            this.TextoFiltradoBox = new System.Windows.Forms.TextBox();
            this.CampoLabel = new System.Windows.Forms.Label();
            this.CriterioLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaCompletaBoton = new System.Windows.Forms.Button();
            this.BuscarFiltradoBoton = new System.Windows.Forms.Button();
            this.LimpiarBoton = new System.Windows.Forms.Button();
            this.BotonCategori = new System.Windows.Forms.Button();
            this.BotonMarca = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.AgregarMarcaCategoria = new System.Windows.Forms.TextBox();
            this.CategoriaLabel = new System.Windows.Forms.Label();
            this.MarcaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvProductos
            // 
            this.DgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvProductos.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.DgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvProductos.Location = new System.Drawing.Point(10, 9);
            this.DgvProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgvProductos.MultiSelect = false;
            this.DgvProductos.Name = "DgvProductos";
            this.DgvProductos.RowHeadersWidth = 51;
            this.DgvProductos.RowTemplate.Height = 24;
            this.DgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProductos.Size = new System.Drawing.Size(762, 349);
            this.DgvProductos.TabIndex = 0;
            this.DgvProductos.SelectionChanged += new System.EventHandler(this.DgvProductos_SelectionChanged);
            // 
            // ProductosPictureBox
            // 
            this.ProductosPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ProductosPictureBox.Location = new System.Drawing.Point(813, 7);
            this.ProductosPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProductosPictureBox.Name = "ProductosPictureBox";
            this.ProductosPictureBox.Size = new System.Drawing.Size(304, 258);
            this.ProductosPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductosPictureBox.TabIndex = 1;
            this.ProductosPictureBox.TabStop = false;
            this.ProductosPictureBox.Click += new System.EventHandler(this.ProductosPictureBox_Click);
            this.ProductosPictureBox.MouseEnter += new System.EventHandler(this.ProductosPictureBox_MouseEnter);
            this.ProductosPictureBox.MouseLeave += new System.EventHandler(this.ProductosPictureBox_MouseLeave);
            // 
            // EliminarBoton
            // 
            this.EliminarBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.EliminarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.EliminarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.EliminarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EliminarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarBoton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EliminarBoton.Location = new System.Drawing.Point(403, 368);
            this.EliminarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EliminarBoton.Name = "EliminarBoton";
            this.EliminarBoton.Size = new System.Drawing.Size(105, 65);
            this.EliminarBoton.TabIndex = 2;
            this.EliminarBoton.Text = "Eliminar Producto";
            this.EliminarBoton.UseVisualStyleBackColor = false;
            this.EliminarBoton.Click += new System.EventHandler(this.EliminarBoton_Click);
            // 
            // ModificarBoton
            // 
            this.ModificarBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ModificarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.ModificarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.ModificarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModificarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarBoton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ModificarBoton.Location = new System.Drawing.Point(274, 368);
            this.ModificarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModificarBoton.Name = "ModificarBoton";
            this.ModificarBoton.Size = new System.Drawing.Size(105, 65);
            this.ModificarBoton.TabIndex = 3;
            this.ModificarBoton.Text = "Modificar Producto";
            this.ModificarBoton.UseVisualStyleBackColor = false;
            this.ModificarBoton.Click += new System.EventHandler(this.ModificarBoton_Click);
            // 
            // AgregarBoton
            // 
            this.AgregarBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AgregarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.AgregarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.AgregarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarBoton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AgregarBoton.Location = new System.Drawing.Point(145, 368);
            this.AgregarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AgregarBoton.Name = "AgregarBoton";
            this.AgregarBoton.Size = new System.Drawing.Size(105, 65);
            this.AgregarBoton.TabIndex = 4;
            this.AgregarBoton.Text = "Agregar Producto";
            this.AgregarBoton.UseVisualStyleBackColor = false;
            this.AgregarBoton.Click += new System.EventHandler(this.AgregarBoton_Click);
            // 
            // CampoComboBox
            // 
            this.CampoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CampoComboBox.FormattingEnabled = true;
            this.CampoComboBox.Location = new System.Drawing.Point(780, 313);
            this.CampoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CampoComboBox.Name = "CampoComboBox";
            this.CampoComboBox.Size = new System.Drawing.Size(119, 24);
            this.CampoComboBox.TabIndex = 5;
            this.CampoComboBox.SelectedIndexChanged += new System.EventHandler(this.CampoComboBox_SelectedIndexChanged);
            // 
            // CriterioComboBox
            // 
            this.CriterioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriterioComboBox.FormattingEnabled = true;
            this.CriterioComboBox.Location = new System.Drawing.Point(904, 313);
            this.CriterioComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CriterioComboBox.Name = "CriterioComboBox";
            this.CriterioComboBox.Size = new System.Drawing.Size(119, 24);
            this.CriterioComboBox.TabIndex = 6;
            this.CriterioComboBox.Click += new System.EventHandler(this.CriterioComboBox_Click);
            // 
            // TextoFiltradoBox
            // 
            this.TextoFiltradoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextoFiltradoBox.Location = new System.Drawing.Point(1030, 313);
            this.TextoFiltradoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextoFiltradoBox.Name = "TextoFiltradoBox";
            this.TextoFiltradoBox.Size = new System.Drawing.Size(119, 24);
            this.TextoFiltradoBox.TabIndex = 7;
            this.TextoFiltradoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextoFiltradoBox_KeyPress);
            // 
            // CampoLabel
            // 
            this.CampoLabel.AutoSize = true;
            this.CampoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoLabel.Location = new System.Drawing.Point(804, 293);
            this.CampoLabel.Name = "CampoLabel";
            this.CampoLabel.Size = new System.Drawing.Size(62, 18);
            this.CampoLabel.TabIndex = 8;
            this.CampoLabel.Text = "Campo";
            // 
            // CriterioLabel
            // 
            this.CriterioLabel.AutoSize = true;
            this.CriterioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CriterioLabel.Location = new System.Drawing.Point(930, 292);
            this.CriterioLabel.Name = "CriterioLabel";
            this.CriterioLabel.Size = new System.Drawing.Size(64, 18);
            this.CriterioLabel.TabIndex = 9;
            this.CriterioLabel.Text = "Criterio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1065, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtro";
            // 
            // ListaCompletaBoton
            // 
            this.ListaCompletaBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ListaCompletaBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.ListaCompletaBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.ListaCompletaBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListaCompletaBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaCompletaBoton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListaCompletaBoton.Location = new System.Drawing.Point(16, 368);
            this.ListaCompletaBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListaCompletaBoton.Name = "ListaCompletaBoton";
            this.ListaCompletaBoton.Size = new System.Drawing.Size(105, 65);
            this.ListaCompletaBoton.TabIndex = 11;
            this.ListaCompletaBoton.Text = "Listado  Completo";
            this.ListaCompletaBoton.UseVisualStyleBackColor = false;
            this.ListaCompletaBoton.Click += new System.EventHandler(this.ListaCompletaBoton_Click);
            // 
            // BuscarFiltradoBoton
            // 
            this.BuscarFiltradoBoton.BackColor = System.Drawing.Color.Aquamarine;
            this.BuscarFiltradoBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BuscarFiltradoBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.BuscarFiltradoBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuscarFiltradoBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarFiltradoBoton.Location = new System.Drawing.Point(798, 368);
            this.BuscarFiltradoBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BuscarFiltradoBoton.Name = "BuscarFiltradoBoton";
            this.BuscarFiltradoBoton.Size = new System.Drawing.Size(77, 62);
            this.BuscarFiltradoBoton.TabIndex = 12;
            this.BuscarFiltradoBoton.Text = "Buscar";
            this.BuscarFiltradoBoton.UseVisualStyleBackColor = false;
            this.BuscarFiltradoBoton.Click += new System.EventHandler(this.BuscarFiltradoBoton_Click);
            // 
            // LimpiarBoton
            // 
            this.LimpiarBoton.BackColor = System.Drawing.Color.Aquamarine;
            this.LimpiarBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LimpiarBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.LimpiarBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LimpiarBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarBoton.Location = new System.Drawing.Point(1051, 368);
            this.LimpiarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LimpiarBoton.Name = "LimpiarBoton";
            this.LimpiarBoton.Size = new System.Drawing.Size(79, 62);
            this.LimpiarBoton.TabIndex = 13;
            this.LimpiarBoton.Text = "Limpiar Filtros";
            this.LimpiarBoton.UseVisualStyleBackColor = false;
            this.LimpiarBoton.Visible = false;
            this.LimpiarBoton.Click += new System.EventHandler(this.LimpiarBoton_Click);
            // 
            // BotonCategori
            // 
            this.BotonCategori.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BotonCategori.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.BotonCategori.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.BotonCategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonCategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCategori.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BotonCategori.Location = new System.Drawing.Point(532, 368);
            this.BotonCategori.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BotonCategori.Name = "BotonCategori";
            this.BotonCategori.Size = new System.Drawing.Size(105, 65);
            this.BotonCategori.TabIndex = 14;
            this.BotonCategori.Text = "Agregar Categoria";
            this.BotonCategori.UseVisualStyleBackColor = false;
            this.BotonCategori.Click += new System.EventHandler(this.BotonCategori_Click);
            // 
            // BotonMarca
            // 
            this.BotonMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BotonMarca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.BotonMarca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.BotonMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonMarca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BotonMarca.Location = new System.Drawing.Point(661, 368);
            this.BotonMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BotonMarca.Name = "BotonMarca";
            this.BotonMarca.Size = new System.Drawing.Size(105, 65);
            this.BotonMarca.TabIndex = 15;
            this.BotonMarca.Text = "Agregar Marca";
            this.BotonMarca.UseVisualStyleBackColor = false;
            this.BotonMarca.Click += new System.EventHandler(this.BotonMarca_Click);
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.Color.SteelBlue;
            this.Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Agregar.Location = new System.Drawing.Point(847, 398);
            this.Agregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(95, 36);
            this.Agregar.TabIndex = 16;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Visible = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Cancelar.Location = new System.Drawing.Point(979, 398);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(96, 36);
            this.Cancelar.TabIndex = 17;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Visible = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // AgregarMarcaCategoria
            // 
            this.AgregarMarcaCategoria.Location = new System.Drawing.Point(881, 342);
            this.AgregarMarcaCategoria.Name = "AgregarMarcaCategoria";
            this.AgregarMarcaCategoria.Size = new System.Drawing.Size(164, 22);
            this.AgregarMarcaCategoria.TabIndex = 18;
            this.AgregarMarcaCategoria.Visible = false;
            // 
            // CategoriaLabel
            // 
            this.CategoriaLabel.AutoSize = true;
            this.CategoriaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoriaLabel.Location = new System.Drawing.Point(1001, 16);
            this.CategoriaLabel.Name = "CategoriaLabel";
            this.CategoriaLabel.Size = new System.Drawing.Size(158, 18);
            this.CategoriaLabel.TabIndex = 19;
            this.CategoriaLabel.Text = "Categoria a Agregar";
            this.CategoriaLabel.Visible = false;
            // 
            // MarcaLabel
            // 
            this.MarcaLabel.AutoSize = true;
            this.MarcaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarcaLabel.Location = new System.Drawing.Point(1027, -2);
            this.MarcaLabel.Name = "MarcaLabel";
            this.MarcaLabel.Size = new System.Drawing.Size(132, 18);
            this.MarcaLabel.TabIndex = 20;
            this.MarcaLabel.Text = "Marca a Agregar";
            this.MarcaLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1156, 453);
            this.Controls.Add(this.MarcaLabel);
            this.Controls.Add(this.CategoriaLabel);
            this.Controls.Add(this.AgregarMarcaCategoria);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.BotonMarca);
            this.Controls.Add(this.BotonCategori);
            this.Controls.Add(this.LimpiarBoton);
            this.Controls.Add(this.BuscarFiltradoBoton);
            this.Controls.Add(this.ListaCompletaBoton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CriterioLabel);
            this.Controls.Add(this.CampoLabel);
            this.Controls.Add(this.TextoFiltradoBox);
            this.Controls.Add(this.CriterioComboBox);
            this.Controls.Add(this.CampoComboBox);
            this.Controls.Add(this.AgregarBoton);
            this.Controls.Add(this.ModificarBoton);
            this.Controls.Add(this.EliminarBoton);
            this.Controls.Add(this.ProductosPictureBox);
            this.Controls.Add(this.DgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor De Articulos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ProductosPictureBox;
        private System.Windows.Forms.Button EliminarBoton;
        private System.Windows.Forms.Button ModificarBoton;
        private System.Windows.Forms.Button AgregarBoton;
        private System.Windows.Forms.DataGridView DgvProductos;
        private System.Windows.Forms.ComboBox CampoComboBox;
        private System.Windows.Forms.ComboBox CriterioComboBox;
        private System.Windows.Forms.TextBox TextoFiltradoBox;
        private System.Windows.Forms.Label CampoLabel;
        private System.Windows.Forms.Label CriterioLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ListaCompletaBoton;
        private System.Windows.Forms.Button BuscarFiltradoBoton;
        private System.Windows.Forms.Button LimpiarBoton;
        private System.Windows.Forms.Button BotonCategori;
        private System.Windows.Forms.Button BotonMarca;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.TextBox AgregarMarcaCategoria;
        private System.Windows.Forms.Label CategoriaLabel;
        private System.Windows.Forms.Label MarcaLabel;
        //private System.Windows.Forms.Label label2;
    }
}

