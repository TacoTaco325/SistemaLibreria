namespace SysLibreria
{
    partial class frmMortisal
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvLibro = new System.Windows.Forms.DataGridView();
            this.pnlSugerencia = new System.Windows.Forms.Panel();
            this.txtSugerencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbMortisal = new System.Windows.Forms.PictureBox();
            this.btnSugerencia = new FontAwesome.Sharp.IconButton();
            this.tmTiempo = new System.Windows.Forms.Timer(this.components);
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibro)).BeginInit();
            this.pnlSugerencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMortisal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.txtBuscar.Location = new System.Drawing.Point(944, 86);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(568, 34);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.Text = "BUSCAR";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            // 
            // dgvLibro
            // 
            this.dgvLibro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibro.Location = new System.Drawing.Point(509, 144);
            this.dgvLibro.Name = "dgvLibro";
            this.dgvLibro.Size = new System.Drawing.Size(1399, 671);
            this.dgvLibro.TabIndex = 2;
            // 
            // pnlSugerencia
            // 
            this.pnlSugerencia.Controls.Add(this.label2);
            this.pnlSugerencia.Controls.Add(this.btnSugerencia);
            this.pnlSugerencia.Controls.Add(this.txtSugerencia);
            this.pnlSugerencia.Controls.Add(this.shapeContainer2);
            this.pnlSugerencia.Location = new System.Drawing.Point(509, 821);
            this.pnlSugerencia.Name = "pnlSugerencia";
            this.pnlSugerencia.Size = new System.Drawing.Size(1409, 219);
            this.pnlSugerencia.TabIndex = 3;
            this.pnlSugerencia.Visible = false;
            // 
            // txtSugerencia
            // 
            this.txtSugerencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txtSugerencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSugerencia.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSugerencia.ForeColor = System.Drawing.Color.DimGray;
            this.txtSugerencia.Location = new System.Drawing.Point(154, 127);
            this.txtSugerencia.Name = "txtSugerencia";
            this.txtSugerencia.Size = new System.Drawing.Size(803, 34);
            this.txtSugerencia.TabIndex = 2;
            this.txtSugerencia.Text = "ESCRIBA AQUI SU SUGERENCIA";
            this.txtSugerencia.Enter += new System.EventHandler(this.txtSugerencia_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(510, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "...";
            this.label1.Visible = false;
            // 
            // ptbMortisal
            // 
            this.ptbMortisal.Image = global::SysLibreria.Properties.Resources.LectorLoad;
            this.ptbMortisal.Location = new System.Drawing.Point(0, -1);
            this.ptbMortisal.Name = "ptbMortisal";
            this.ptbMortisal.Size = new System.Drawing.Size(504, 1041);
            this.ptbMortisal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMortisal.TabIndex = 5;
            this.ptbMortisal.TabStop = false;
            // 
            // btnSugerencia
            // 
            this.btnSugerencia.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.btnSugerencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.btnSugerencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSugerencia.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSugerencia.ForeColor = System.Drawing.Color.White;
            this.btnSugerencia.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btnSugerencia.IconColor = System.Drawing.Color.White;
            this.btnSugerencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSugerencia.IconSize = 100;
            this.btnSugerencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSugerencia.Location = new System.Drawing.Point(1024, 79);
            this.btnSugerencia.Name = "btnSugerencia";
            this.btnSugerencia.Size = new System.Drawing.Size(301, 128);
            this.btnSugerencia.TabIndex = 3;
            this.btnSugerencia.Text = "ENVIAR\r\nSUGERENCIA\r\n";
            this.btnSugerencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSugerencia.UseVisualStyleBackColor = true;
            this.btnSugerencia.Click += new System.EventHandler(this.btnSugerencia_Click);
            // 
            // tmTiempo
            // 
            this.tmTiempo.Interval = 17;
            this.tmTiempo.Tick += new System.EventHandler(this.tmTiempo_Tick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1920, 1040);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1511;
            this.lineShape1.X2 = 944;
            this.lineShape1.Y1 = 122;
            this.lineShape1.Y2 = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1155, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vaya... no tenemos el libro que desea dejenos una sugerencia para una futura comp" +
    "ra";
            // 
            // lineShape2
            // 
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 956;
            this.lineShape2.X2 = 154;
            this.lineShape2.Y1 = 164;
            this.lineShape2.Y2 = 164;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(1409, 219);
            this.shapeContainer2.TabIndex = 5;
            this.shapeContainer2.TabStop = false;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(1833, 100);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 38);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmMortisal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1920, 1040);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.ptbMortisal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlSugerencia);
            this.Controls.Add(this.dgvLibro);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMortisal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMortisal";
            this.Load += new System.EventHandler(this.frmMortisal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibro)).EndInit();
            this.pnlSugerencia.ResumeLayout(false);
            this.pnlSugerencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMortisal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvLibro;
        private System.Windows.Forms.Panel pnlSugerencia;
        private System.Windows.Forms.TextBox txtSugerencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbMortisal;
        private FontAwesome.Sharp.IconButton btnSugerencia;
        private System.Windows.Forms.Timer tmTiempo;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}