namespace SharpManager
{
	partial class FrmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
			this.btnInloggen = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnSluiten = new System.Windows.Forms.Button();
			this.lblGebruiker = new System.Windows.Forms.Label();
			this.lstGebruiker = new System.Windows.Forms.ComboBox();
			this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnInloggen
			// 
			this.btnInloggen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInloggen.Location = new System.Drawing.Point(162, 227);
			this.btnInloggen.Name = "btnInloggen";
			this.btnInloggen.Size = new System.Drawing.Size(100, 38);
			this.btnInloggen.TabIndex = 1;
			this.btnInloggen.Text = "&Inloggen";
			this.btnInloggen.UseVisualStyleBackColor = true;
			this.btnInloggen.Click += new System.EventHandler(this.btnInloggen_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::SharpManager.Properties.Resources.Key_Cartoon;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(250, 136);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// btnSluiten
			// 
			this.btnSluiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSluiten.Location = new System.Drawing.Point(12, 227);
			this.btnSluiten.Name = "btnSluiten";
			this.btnSluiten.Size = new System.Drawing.Size(84, 38);
			this.btnSluiten.TabIndex = 2;
			this.btnSluiten.Text = "&Sluiten";
			this.btnSluiten.UseVisualStyleBackColor = true;
			this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
			// 
			// lblGebruiker
			// 
			this.lblGebruiker.AutoSize = true;
			this.lblGebruiker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGebruiker.Location = new System.Drawing.Point(13, 168);
			this.lblGebruiker.Name = "lblGebruiker";
			this.lblGebruiker.Size = new System.Drawing.Size(83, 20);
			this.lblGebruiker.TabIndex = 3;
			this.lblGebruiker.Text = "Gebruiker:";
			// 
			// lstGebruiker
			// 
			this.lstGebruiker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lstGebruiker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstGebruiker.FormattingEnabled = true;
			this.lstGebruiker.Location = new System.Drawing.Point(102, 164);
			this.lstGebruiker.Name = "lstGebruiker";
			this.lstGebruiker.Size = new System.Drawing.Size(160, 28);
			this.lstGebruiker.TabIndex = 0;
			// 
			// visualStyler1
			// 
			this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
			this.visualStyler1.LoadVisualStyle(null, "OSX (Tiger).vssf");
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(274, 277);
			this.Controls.Add(this.lstGebruiker);
			this.Controls.Add(this.lblGebruiker);
			this.Controls.Add(this.btnSluiten);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnInloggen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Welkom bij SharpManager";
			this.Load += new System.EventHandler(this.FrmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnInloggen;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnSluiten;
		private System.Windows.Forms.Label lblGebruiker;
		private System.Windows.Forms.ComboBox lstGebruiker;
		private SkinSoft.VisualStyler.VisualStyler visualStyler1;

	}
}