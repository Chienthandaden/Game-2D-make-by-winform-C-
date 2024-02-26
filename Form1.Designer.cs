namespace dacs
{
    partial class Form1
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
            this.txtDan = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.Label();
            this.txtMau = new System.Windows.Forms.Label();
            this.ThanhMau = new System.Windows.Forms.ProgressBar();
            this.gametime = new System.Windows.Forms.Timer(this.components);
            this.txtLaser = new System.Windows.Forms.Label();
            this.txtDanno = new System.Windows.Forms.Label();
            this.notificationTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.nguoichoi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nguoichoi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDan
            // 
            this.txtDan.AutoSize = true;
            this.txtDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDan.ForeColor = System.Drawing.Color.White;
            this.txtDan.Location = new System.Drawing.Point(12, 9);
            this.txtDan.Name = "txtDan";
            this.txtDan.Size = new System.Drawing.Size(87, 29);
            this.txtDan.TabIndex = 0;
            this.txtDan.Text = "Đạn: 0";
            this.txtDan.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDiem
            // 
            this.txtDiem.AutoSize = true;
            this.txtDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiem.ForeColor = System.Drawing.Color.White;
            this.txtDiem.Location = new System.Drawing.Point(550, 12);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(102, 29);
            this.txtDiem.TabIndex = 1;
            this.txtDiem.Text = "Điểm: 0";
            // 
            // txtMau
            // 
            this.txtMau.AutoSize = true;
            this.txtMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMau.ForeColor = System.Drawing.Color.White;
            this.txtMau.Location = new System.Drawing.Point(975, 9);
            this.txtMau.Name = "txtMau";
            this.txtMau.Size = new System.Drawing.Size(69, 29);
            this.txtMau.TabIndex = 2;
            this.txtMau.Text = "Máu:";
            // 
            // ThanhMau
            // 
            this.ThanhMau.Location = new System.Drawing.Point(1050, 12);
            this.ThanhMau.Name = "ThanhMau";
            this.ThanhMau.Size = new System.Drawing.Size(210, 23);
            this.ThanhMau.TabIndex = 3;
            this.ThanhMau.Value = 100;
            // 
            // gametime
            // 
            this.gametime.Enabled = true;
            this.gametime.Interval = 20;
            this.gametime.Tick += new System.EventHandler(this.tgchinh);
            // 
            // txtLaser
            // 
            this.txtLaser.AutoSize = true;
            this.txtLaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaser.ForeColor = System.Drawing.Color.Firebrick;
            this.txtLaser.Location = new System.Drawing.Point(149, 9);
            this.txtLaser.Name = "txtLaser";
            this.txtLaser.Size = new System.Drawing.Size(106, 29);
            this.txtLaser.TabIndex = 0;
            this.txtLaser.Text = "Laser: 0";
            this.txtLaser.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDanno
            // 
            this.txtDanno.AutoSize = true;
            this.txtDanno.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanno.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtDanno.Location = new System.Drawing.Point(280, 9);
            this.txtDanno.Name = "txtDanno";
            this.txtDanno.Size = new System.Drawing.Size(137, 29);
            this.txtDanno.TabIndex = 0;
            this.txtDanno.Text = "Explode: 0";
            this.txtDanno.Click += new System.EventHandler(this.label1_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // nguoichoi
            // 
            this.nguoichoi.Image = global::dacs.Properties.Resources.up;
            this.nguoichoi.Location = new System.Drawing.Point(616, 387);
            this.nguoichoi.Name = "nguoichoi";
            this.nguoichoi.Size = new System.Drawing.Size(71, 100);
            this.nguoichoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nguoichoi.TabIndex = 4;
            this.nguoichoi.TabStop = false;
            this.nguoichoi.Click += new System.EventHandler(this.nguoichoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1284, 692);
            this.Controls.Add(this.nguoichoi);
            this.Controls.Add(this.ThanhMau);
            this.Controls.Add(this.txtMau);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.txtDanno);
            this.Controls.Add(this.txtLaser);
            this.Controls.Add(this.txtDan);
            this.Name = "Form1";
            this.Text = "Gamezombie";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisUp);
            ((System.ComponentModel.ISupportInitialize)(this.nguoichoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtDan;
        private System.Windows.Forms.Label txtDiem;
        private System.Windows.Forms.Label txtMau;
        private System.Windows.Forms.ProgressBar ThanhMau;
        private System.Windows.Forms.PictureBox nguoichoi;
        private System.Windows.Forms.Timer gametime;
        private System.Windows.Forms.Label txtLaser;
        private System.Windows.Forms.Label txtDanno;
        private System.Windows.Forms.Timer notificationTimer;
        private System.Windows.Forms.Timer gameTimer;
    }
}

