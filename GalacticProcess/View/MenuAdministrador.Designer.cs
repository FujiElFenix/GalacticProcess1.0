namespace GalacticProcess.View
{
    partial class MenuAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdministrador));
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MTModuloUsuario = new MetroFramework.Controls.MetroTile();
            this.MTModuloRoles = new MetroFramework.Controls.MetroTile();
            this.MTModuloUnidades = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.metroPanel1.Controls.Add(this.panel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(604, 303);
            this.metroPanel1.TabIndex = 13;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.metroTile1);
            this.panel1.Controls.Add(this.MTModuloRoles);
            this.panel1.Controls.Add(this.MTModuloUnidades);
            this.panel1.Controls.Add(this.MTModuloUsuario);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 291);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(343, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 221);
            this.panel2.TabIndex = 21;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(23, 45);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(254, 43);
            this.metroTile1.TabIndex = 20;
            this.metroTile1.Text = "Módulo Empresas";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click_2);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MTModuloUsuario
            // 
            this.MTModuloUsuario.ActiveControl = null;
            this.MTModuloUsuario.Location = new System.Drawing.Point(23, 192);
            this.MTModuloUsuario.Name = "MTModuloUsuario";
            this.MTModuloUsuario.Size = new System.Drawing.Size(254, 43);
            this.MTModuloUsuario.TabIndex = 17;
            this.MTModuloUsuario.Text = "Modulo Usuario";
            this.MTModuloUsuario.UseSelectable = true;
            this.MTModuloUsuario.Click += new System.EventHandler(this.MTModuloUsuario_Click);
            // 
            // MTModuloRoles
            // 
            this.MTModuloRoles.ActiveControl = null;
            this.MTModuloRoles.Location = new System.Drawing.Point(23, 143);
            this.MTModuloRoles.Name = "MTModuloRoles";
            this.MTModuloRoles.Size = new System.Drawing.Size(254, 43);
            this.MTModuloRoles.TabIndex = 19;
            this.MTModuloRoles.Text = "Modulo Roles";
            this.MTModuloRoles.UseSelectable = true;
            this.MTModuloRoles.Click += new System.EventHandler(this.MTModuloRoles_Click);
            // 
            // MTModuloUnidades
            // 
            this.MTModuloUnidades.ActiveControl = null;
            this.MTModuloUnidades.Location = new System.Drawing.Point(23, 94);
            this.MTModuloUnidades.Name = "MTModuloUnidades";
            this.MTModuloUnidades.Size = new System.Drawing.Size(254, 43);
            this.MTModuloUnidades.TabIndex = 18;
            this.MTModuloUnidades.Text = "Modulo Unidades";
            this.MTModuloUnidades.UseSelectable = true;
            this.MTModuloUnidades.Click += new System.EventHandler(this.MTModuloUnidades_Click);
            // 
            // MenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 383);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MenuAdministrador";
            this.Text = "Bienvenido Administrador";
            this.metroPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile MTModuloRoles;
        private MetroFramework.Controls.MetroTile MTModuloUnidades;
        private MetroFramework.Controls.MetroTile MTModuloUsuario;
    }
}