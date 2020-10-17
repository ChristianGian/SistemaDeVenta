namespace CapaPresentacion
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.pboxLogo = new System.Windows.Forms.PictureBox();
            this.panelBarraSuperior = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUserDatos = new System.Windows.Forms.Label();
            this.pboxUser = new System.Windows.Forms.PictureBox();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelMenuMas = new System.Windows.Forms.Panel();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblMas = new System.Windows.Forms.Label();
            this.panelMenuMantenimiento = new System.Windows.Forms.Panel();
            this.btnTrabajadores = new System.Windows.Forms.Button();
            this.lblMantenimiento = new System.Windows.Forms.Label();
            this.panelMenuConsultas = new System.Windows.Forms.Panel();
            this.btnConsultaVenta = new System.Windows.Forms.Button();
            this.btnConsultaCompra = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.panelMenuAlmacen = new System.Windows.Forms.Panel();
            this.btnPresentaciones = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnArticulos = new System.Windows.Forms.Button();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.panelMenuCompras = new System.Windows.Forms.Panel();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnIngresos = new System.Windows.Forms.Button();
            this.lblCompras = new System.Windows.Forms.Label();
            this.panelMenuVentas = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.lblVentas = new System.Windows.Forms.Label();
            this.panelFormHijo = new System.Windows.Forms.Panel();
            this.pboxLogoCentral = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).BeginInit();
            this.panelBarraSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxUser)).BeginInit();
            this.panelSideMenu.SuspendLayout();
            this.panelMenuMas.SuspendLayout();
            this.panelMenuMantenimiento.SuspendLayout();
            this.panelMenuConsultas.SuspendLayout();
            this.panelMenuAlmacen.SuspendLayout();
            this.panelMenuCompras.SuspendLayout();
            this.panelMenuVentas.SuspendLayout();
            this.panelFormHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogoCentral)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxLogo
            // 
            this.pboxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.pboxLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pboxLogo.Image = global::CapaPresentacion.Properties.Resources.F_logo_white;
            this.pboxLogo.Location = new System.Drawing.Point(0, 0);
            this.pboxLogo.Name = "pboxLogo";
            this.pboxLogo.Size = new System.Drawing.Size(200, 54);
            this.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxLogo.TabIndex = 0;
            this.pboxLogo.TabStop = false;
            this.pboxLogo.Click += new System.EventHandler(this.PboxLogo_Click);
            // 
            // panelBarraSuperior
            // 
            this.panelBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.panelBarraSuperior.Controls.Add(this.pboxLogo);
            this.panelBarraSuperior.Controls.Add(this.lblFecha);
            this.panelBarraSuperior.Controls.Add(this.label7);
            this.panelBarraSuperior.Controls.Add(this.lblEmail);
            this.panelBarraSuperior.Controls.Add(this.lblUserDatos);
            this.panelBarraSuperior.Controls.Add(this.pboxUser);
            this.panelBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelBarraSuperior.Name = "panelBarraSuperior";
            this.panelBarraSuperior.Size = new System.Drawing.Size(1184, 54);
            this.panelBarraSuperior.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.lblFecha.Location = new System.Drawing.Point(387, 21);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(151, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "lunes 00 del enero de 0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(208, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sistema de Ventas .";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(958, 24);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(171, 23);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "nombre@email.com";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserDatos
            // 
            this.lblUserDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserDatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDatos.ForeColor = System.Drawing.Color.White;
            this.lblUserDatos.Location = new System.Drawing.Point(958, 7);
            this.lblUserDatos.Name = "lblUserDatos";
            this.lblUserDatos.Size = new System.Drawing.Size(171, 23);
            this.lblUserDatos.TabIndex = 1;
            this.lblUserDatos.Text = "Nombre Apellido";
            this.lblUserDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboxUser
            // 
            this.pboxUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxUser.Image = ((System.Drawing.Image)(resources.GetObject("pboxUser.Image")));
            this.pboxUser.Location = new System.Drawing.Point(1134, 6);
            this.pboxUser.Name = "pboxUser";
            this.pboxUser.Size = new System.Drawing.Size(42, 42);
            this.pboxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxUser.TabIndex = 0;
            this.pboxUser.TabStop = false;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.panelSideMenu.Controls.Add(this.panelMenuMas);
            this.panelSideMenu.Controls.Add(this.panelMenuMantenimiento);
            this.panelSideMenu.Controls.Add(this.panelMenuConsultas);
            this.panelSideMenu.Controls.Add(this.panelMenuAlmacen);
            this.panelSideMenu.Controls.Add(this.panelMenuCompras);
            this.panelSideMenu.Controls.Add(this.panelMenuVentas);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 54);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 607);
            this.panelSideMenu.TabIndex = 4;
            // 
            // panelMenuMas
            // 
            this.panelMenuMas.Controls.Add(this.btnAyuda);
            this.panelMenuMas.Controls.Add(this.btnBackup);
            this.panelMenuMas.Controls.Add(this.lblMas);
            this.panelMenuMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuMas.Location = new System.Drawing.Point(0, 665);
            this.panelMenuMas.Name = "panelMenuMas";
            this.panelMenuMas.Size = new System.Drawing.Size(183, 125);
            this.panelMenuMas.TabIndex = 6;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnAyuda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.White;
            this.btnAyuda.Image = global::CapaPresentacion.Properties.Resources.SideAyuda;
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.Location = new System.Drawing.Point(0, 76);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAyuda.Size = new System.Drawing.Size(183, 40);
            this.btnAyuda.TabIndex = 2;
            this.btnAyuda.Text = "   Ayuda";
            this.btnAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Image = global::CapaPresentacion.Properties.Resources.SideBackup;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(0, 36);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(183, 40);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "   Backup";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblMas
            // 
            this.lblMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMas.ForeColor = System.Drawing.Color.White;
            this.lblMas.Location = new System.Drawing.Point(0, 0);
            this.lblMas.Name = "lblMas";
            this.lblMas.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblMas.Size = new System.Drawing.Size(183, 36);
            this.lblMas.TabIndex = 0;
            this.lblMas.Text = "MÁS";
            // 
            // panelMenuMantenimiento
            // 
            this.panelMenuMantenimiento.Controls.Add(this.btnTrabajadores);
            this.panelMenuMantenimiento.Controls.Add(this.lblMantenimiento);
            this.panelMenuMantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuMantenimiento.Location = new System.Drawing.Point(0, 580);
            this.panelMenuMantenimiento.Name = "panelMenuMantenimiento";
            this.panelMenuMantenimiento.Size = new System.Drawing.Size(183, 85);
            this.panelMenuMantenimiento.TabIndex = 5;
            // 
            // btnTrabajadores
            // 
            this.btnTrabajadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrabajadores.FlatAppearance.BorderSize = 0;
            this.btnTrabajadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnTrabajadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnTrabajadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrabajadores.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrabajadores.ForeColor = System.Drawing.Color.White;
            this.btnTrabajadores.Image = global::CapaPresentacion.Properties.Resources.SideTrabajadores;
            this.btnTrabajadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrabajadores.Location = new System.Drawing.Point(0, 36);
            this.btnTrabajadores.Name = "btnTrabajadores";
            this.btnTrabajadores.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTrabajadores.Size = new System.Drawing.Size(183, 40);
            this.btnTrabajadores.TabIndex = 1;
            this.btnTrabajadores.Text = "   Trabajadores";
            this.btnTrabajadores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrabajadores.UseVisualStyleBackColor = true;
            this.btnTrabajadores.Click += new System.EventHandler(this.BtnTrabajadores_Click);
            // 
            // lblMantenimiento
            // 
            this.lblMantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMantenimiento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMantenimiento.ForeColor = System.Drawing.Color.White;
            this.lblMantenimiento.Location = new System.Drawing.Point(0, 0);
            this.lblMantenimiento.Name = "lblMantenimiento";
            this.lblMantenimiento.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblMantenimiento.Size = new System.Drawing.Size(183, 36);
            this.lblMantenimiento.TabIndex = 0;
            this.lblMantenimiento.Text = "MANTENIMIENTO";
            // 
            // panelMenuConsultas
            // 
            this.panelMenuConsultas.Controls.Add(this.btnConsultaVenta);
            this.panelMenuConsultas.Controls.Add(this.btnConsultaCompra);
            this.panelMenuConsultas.Controls.Add(this.btnStock);
            this.panelMenuConsultas.Controls.Add(this.lblConsultas);
            this.panelMenuConsultas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuConsultas.Location = new System.Drawing.Point(0, 415);
            this.panelMenuConsultas.Name = "panelMenuConsultas";
            this.panelMenuConsultas.Size = new System.Drawing.Size(183, 165);
            this.panelMenuConsultas.TabIndex = 4;
            // 
            // btnConsultaVenta
            // 
            this.btnConsultaVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaVenta.FlatAppearance.BorderSize = 0;
            this.btnConsultaVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnConsultaVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnConsultaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaVenta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaVenta.ForeColor = System.Drawing.Color.White;
            this.btnConsultaVenta.Image = global::CapaPresentacion.Properties.Resources.SideConsultaVenta;
            this.btnConsultaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaVenta.Location = new System.Drawing.Point(0, 116);
            this.btnConsultaVenta.Name = "btnConsultaVenta";
            this.btnConsultaVenta.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaVenta.Size = new System.Drawing.Size(183, 40);
            this.btnConsultaVenta.TabIndex = 3;
            this.btnConsultaVenta.Text = "   Ventas";
            this.btnConsultaVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultaVenta.UseVisualStyleBackColor = true;
            this.btnConsultaVenta.Click += new System.EventHandler(this.btnConsultaVenta_Click);
            // 
            // btnConsultaCompra
            // 
            this.btnConsultaCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaCompra.FlatAppearance.BorderSize = 0;
            this.btnConsultaCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnConsultaCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnConsultaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaCompra.ForeColor = System.Drawing.Color.White;
            this.btnConsultaCompra.Image = global::CapaPresentacion.Properties.Resources.SideConsultaCompra;
            this.btnConsultaCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaCompra.Location = new System.Drawing.Point(0, 76);
            this.btnConsultaCompra.Name = "btnConsultaCompra";
            this.btnConsultaCompra.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaCompra.Size = new System.Drawing.Size(183, 40);
            this.btnConsultaCompra.TabIndex = 2;
            this.btnConsultaCompra.Text = "   Compras";
            this.btnConsultaCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultaCompra.UseVisualStyleBackColor = true;
            this.btnConsultaCompra.Click += new System.EventHandler(this.btnConsultaCompra_Click);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Image = global::CapaPresentacion.Properties.Resources.SideStock;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(0, 36);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(183, 40);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "   Stock";
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.BtnStock_Click);
            // 
            // lblConsultas
            // 
            this.lblConsultas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConsultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultas.ForeColor = System.Drawing.Color.White;
            this.lblConsultas.Location = new System.Drawing.Point(0, 0);
            this.lblConsultas.Name = "lblConsultas";
            this.lblConsultas.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblConsultas.Size = new System.Drawing.Size(183, 36);
            this.lblConsultas.TabIndex = 0;
            this.lblConsultas.Text = "CONSULTAS";
            // 
            // panelMenuAlmacen
            // 
            this.panelMenuAlmacen.Controls.Add(this.btnPresentaciones);
            this.panelMenuAlmacen.Controls.Add(this.btnCategorias);
            this.panelMenuAlmacen.Controls.Add(this.btnArticulos);
            this.panelMenuAlmacen.Controls.Add(this.lblAlmacen);
            this.panelMenuAlmacen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuAlmacen.Location = new System.Drawing.Point(0, 250);
            this.panelMenuAlmacen.Name = "panelMenuAlmacen";
            this.panelMenuAlmacen.Size = new System.Drawing.Size(183, 165);
            this.panelMenuAlmacen.TabIndex = 3;
            // 
            // btnPresentaciones
            // 
            this.btnPresentaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPresentaciones.FlatAppearance.BorderSize = 0;
            this.btnPresentaciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnPresentaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnPresentaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresentaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresentaciones.ForeColor = System.Drawing.Color.White;
            this.btnPresentaciones.Image = global::CapaPresentacion.Properties.Resources.SidePresentaciones;
            this.btnPresentaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresentaciones.Location = new System.Drawing.Point(0, 116);
            this.btnPresentaciones.Name = "btnPresentaciones";
            this.btnPresentaciones.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPresentaciones.Size = new System.Drawing.Size(183, 40);
            this.btnPresentaciones.TabIndex = 3;
            this.btnPresentaciones.Text = "   Presentaciones";
            this.btnPresentaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPresentaciones.UseVisualStyleBackColor = true;
            this.btnPresentaciones.Click += new System.EventHandler(this.BtnPresentaciones_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Image = global::CapaPresentacion.Properties.Resources.SideCategoria;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 76);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(183, 40);
            this.btnCategorias.TabIndex = 2;
            this.btnCategorias.Text = "   Categorías";
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.BtnCategorias_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticulos.FlatAppearance.BorderSize = 0;
            this.btnArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ForeColor = System.Drawing.Color.White;
            this.btnArticulos.Image = global::CapaPresentacion.Properties.Resources.SideArticulos;
            this.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.Location = new System.Drawing.Point(0, 36);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnArticulos.Size = new System.Drawing.Size(183, 40);
            this.btnArticulos.TabIndex = 1;
            this.btnArticulos.Text = "   Artículos";
            this.btnArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArticulos.UseVisualStyleBackColor = true;
            this.btnArticulos.Click += new System.EventHandler(this.BtnArticulos_Click);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAlmacen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(0, 0);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblAlmacen.Size = new System.Drawing.Size(183, 36);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "ALMACÉN";
            // 
            // panelMenuCompras
            // 
            this.panelMenuCompras.Controls.Add(this.btnProveedores);
            this.panelMenuCompras.Controls.Add(this.btnIngresos);
            this.panelMenuCompras.Controls.Add(this.lblCompras);
            this.panelMenuCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuCompras.Location = new System.Drawing.Point(0, 125);
            this.panelMenuCompras.Name = "panelMenuCompras";
            this.panelMenuCompras.Size = new System.Drawing.Size(183, 125);
            this.panelMenuCompras.TabIndex = 2;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Image = global::CapaPresentacion.Properties.Resources.SideProveedor;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(0, 76);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProveedores.Size = new System.Drawing.Size(183, 40);
            this.btnProveedores.TabIndex = 2;
            this.btnProveedores.Text = "   Proveedores";
            this.btnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresos.FlatAppearance.BorderSize = 0;
            this.btnIngresos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnIngresos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.ForeColor = System.Drawing.Color.White;
            this.btnIngresos.Image = global::CapaPresentacion.Properties.Resources.SideIngresos;
            this.btnIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresos.Location = new System.Drawing.Point(0, 36);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnIngresos.Size = new System.Drawing.Size(183, 40);
            this.btnIngresos.TabIndex = 1;
            this.btnIngresos.Text = "   Ingresos";
            this.btnIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresos.UseVisualStyleBackColor = true;
            this.btnIngresos.Click += new System.EventHandler(this.btnIngresos_Click);
            // 
            // lblCompras
            // 
            this.lblCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompras.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompras.ForeColor = System.Drawing.Color.White;
            this.lblCompras.Location = new System.Drawing.Point(0, 0);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblCompras.Size = new System.Drawing.Size(183, 36);
            this.lblCompras.TabIndex = 0;
            this.lblCompras.Text = "COMPRAS";
            // 
            // panelMenuVentas
            // 
            this.panelMenuVentas.Controls.Add(this.btnClientes);
            this.panelMenuVentas.Controls.Add(this.btnVentas);
            this.panelMenuVentas.Controls.Add(this.lblVentas);
            this.panelMenuVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuVentas.Location = new System.Drawing.Point(0, 0);
            this.panelMenuVentas.Name = "panelMenuVentas";
            this.panelMenuVentas.Size = new System.Drawing.Size(183, 125);
            this.panelMenuVentas.TabIndex = 1;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(22)))));
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = global::CapaPresentacion.Properties.Resources.SideClientes;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 76);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(183, 40);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "   Clientes";
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(45)))), ((int)(((byte)(210)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.Image = global::CapaPresentacion.Properties.Resources.SideVentas;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 36);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(183, 40);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "   Ventas";
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // lblVentas
            // 
            this.lblVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.ForeColor = System.Drawing.Color.White;
            this.lblVentas.Location = new System.Drawing.Point(0, 0);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblVentas.Size = new System.Drawing.Size(183, 36);
            this.lblVentas.TabIndex = 0;
            this.lblVentas.Text = "VENTAS";
            // 
            // panelFormHijo
            // 
            this.panelFormHijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.panelFormHijo.Controls.Add(this.pboxLogoCentral);
            this.panelFormHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormHijo.Location = new System.Drawing.Point(200, 54);
            this.panelFormHijo.Name = "panelFormHijo";
            this.panelFormHijo.Size = new System.Drawing.Size(984, 607);
            this.panelFormHijo.TabIndex = 5;
            // 
            // pboxLogoCentral
            // 
            this.pboxLogoCentral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pboxLogoCentral.Image = global::CapaPresentacion.Properties.Resources.F_logo_white;
            this.pboxLogoCentral.Location = new System.Drawing.Point(475, 286);
            this.pboxLogoCentral.Name = "pboxLogoCentral";
            this.pboxLogoCentral.Size = new System.Drawing.Size(54, 54);
            this.pboxLogoCentral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxLogoCentral.TabIndex = 3;
            this.pboxLogoCentral.TabStop = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelFormHijo);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelBarraSuperior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).EndInit();
            this.panelBarraSuperior.ResumeLayout(false);
            this.panelBarraSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxUser)).EndInit();
            this.panelSideMenu.ResumeLayout(false);
            this.panelMenuMas.ResumeLayout(false);
            this.panelMenuMantenimiento.ResumeLayout(false);
            this.panelMenuConsultas.ResumeLayout(false);
            this.panelMenuAlmacen.ResumeLayout(false);
            this.panelMenuCompras.ResumeLayout(false);
            this.panelMenuVentas.ResumeLayout(false);
            this.panelFormHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogoCentral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pboxLogo;
        private System.Windows.Forms.Panel panelBarraSuperior;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUserDatos;
        private System.Windows.Forms.PictureBox pboxUser;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelMenuMas;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblMas;
        private System.Windows.Forms.Panel panelMenuMantenimiento;
        private System.Windows.Forms.Button btnTrabajadores;
        private System.Windows.Forms.Label lblMantenimiento;
        private System.Windows.Forms.Panel panelMenuConsultas;
        private System.Windows.Forms.Button btnConsultaVenta;
        private System.Windows.Forms.Button btnConsultaCompra;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.Panel panelMenuAlmacen;
        private System.Windows.Forms.Button btnPresentaciones;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Panel panelMenuCompras;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Panel panelMenuVentas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Panel panelFormHijo;
        private System.Windows.Forms.PictureBox pboxLogoCentral;
    }
}