namespace SysLibreria
{
    partial class frmCompraxFecha
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
            this.pnlPadre = new System.Windows.Forms.Panel();
            this.btnFecha = new FontAwesome.Sharp.IconButton();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // pnlPadre
            // 
            this.pnlPadre.Location = new System.Drawing.Point(12, 162);
            this.pnlPadre.Name = "pnlPadre";
            this.pnlPadre.Size = new System.Drawing.Size(1636, 846);
            this.pnlPadre.TabIndex = 3;
            // 
            // btnFecha
            // 
            this.btnFecha.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnFecha.IconColor = System.Drawing.Color.White;
            this.btnFecha.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFecha.IconSize = 100;
            this.btnFecha.Location = new System.Drawing.Point(886, 33);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(175, 120);
            this.btnFecha.TabIndex = 7;
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(587, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(276, 57);
            this.dtpFecha.TabIndex = 6;
            // 
            // frmCompraxFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1660, 1015);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.pnlPadre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCompraxFecha";
            this.Text = "frmReportexFecha";
            this.Load += new System.EventHandler(this.frmReportexFecha_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlPadre;
        private FontAwesome.Sharp.IconButton btnFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}