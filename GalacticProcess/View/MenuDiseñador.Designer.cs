namespace GalacticProcess.View
{
    partial class MenuDiseñador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuDiseñador));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnModuloTareas = new MetroFramework.Controls.MetroTile();
            this.BtnFlujoTrabajo = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.metroPanel1.TabIndex = 14;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.BtnFlujoTrabajo);
            this.panel1.Controls.Add(this.BtnModuloTareas);
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
            // BtnModuloTareas
            // 
            this.BtnModuloTareas.ActiveControl = null;
            this.BtnModuloTareas.Location = new System.Drawing.Point(19, 31);
            this.BtnModuloTareas.Name = "BtnModuloTareas";
            this.BtnModuloTareas.Size = new System.Drawing.Size(254, 43);
            this.BtnModuloTareas.TabIndex = 20;
            this.BtnModuloTareas.Text = "Modulo Tareas";
            this.BtnModuloTareas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnModuloTareas.UseSelectable = true;
            this.BtnModuloTareas.Click += new System.EventHandler(this.BtnModuloTareas_Click);
            // 
            // BtnFlujoTrabajo
            // 
            this.BtnFlujoTrabajo.ActiveControl = null;
            this.BtnFlujoTrabajo.Location = new System.Drawing.Point(19, 80);
            this.BtnFlujoTrabajo.Name = "BtnFlujoTrabajo";
            this.BtnFlujoTrabajo.Size = new System.Drawing.Size(254, 43);
            this.BtnFlujoTrabajo.TabIndex = 20;
            this.BtnFlujoTrabajo.Text = "Flujo De Trabajo";
            this.BtnFlujoTrabajo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnFlujoTrabajo.UseSelectable = true;
            this.BtnFlujoTrabajo.Click += new System.EventHandler(this.BtnFlujoTrabajo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuDiseñador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 383);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MenuDiseñador";
            this.Text = "Menu Diseñador De Procesos";
            this.metroPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile BtnModuloTareas;
        private MetroFramework.Controls.MetroTile BtnFlujoTrabajo;
    }
}