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
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.MTModuloRoles = new MetroFramework.Controls.MetroTile();
            this.MTModuloUnidades = new MetroFramework.Controls.MetroTile();
            this.MTModuloUsuario = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(23, 91);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(254, 43);
            this.metroTile1.TabIndex = 12;
            this.metroTile1.Text = "Módulo Empresas";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click_1);
            // 
            // MTModuloRoles
            // 
            this.MTModuloRoles.ActiveControl = null;
            this.MTModuloRoles.Location = new System.Drawing.Point(23, 189);
            this.MTModuloRoles.Name = "MTModuloRoles";
            this.MTModuloRoles.Size = new System.Drawing.Size(254, 43);
            this.MTModuloRoles.TabIndex = 11;
            this.MTModuloRoles.Text = "Modulo Roles";
            this.MTModuloRoles.UseSelectable = true;
            // 
            // MTModuloUnidades
            // 
            this.MTModuloUnidades.ActiveControl = null;
            this.MTModuloUnidades.Location = new System.Drawing.Point(23, 140);
            this.MTModuloUnidades.Name = "MTModuloUnidades";
            this.MTModuloUnidades.Size = new System.Drawing.Size(254, 43);
            this.MTModuloUnidades.TabIndex = 10;
            this.MTModuloUnidades.Text = "Modulo Unidades";
            this.MTModuloUnidades.UseSelectable = true;
            // 
            // MTModuloUsuario
            // 
            this.MTModuloUsuario.ActiveControl = null;
            this.MTModuloUsuario.Location = new System.Drawing.Point(23, 238);
            this.MTModuloUsuario.Name = "MTModuloUsuario";
            this.MTModuloUsuario.Size = new System.Drawing.Size(254, 43);
            this.MTModuloUsuario.TabIndex = 9;
            this.MTModuloUsuario.Text = "Modulo Usuario";
            this.MTModuloUsuario.UseSelectable = true;
            // 
            // MenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 425);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.MTModuloRoles);
            this.Controls.Add(this.MTModuloUnidades);
            this.Controls.Add(this.MTModuloUsuario);
            this.Name = "MenuAdministrador";
            this.Text = "Bienvenido Administrador";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile MTModuloRoles;
        private MetroFramework.Controls.MetroTile MTModuloUnidades;
        private MetroFramework.Controls.MetroTile MTModuloUsuario;
    }
}