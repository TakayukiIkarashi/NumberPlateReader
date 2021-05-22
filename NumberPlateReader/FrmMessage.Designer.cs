namespace NumberPlateReader
{
    partial class FrmMessage
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
            this.LabelMessage = new System.Windows.Forms.Label();
            this.Labelいいえ = new System.Windows.Forms.Label();
            this.Labelはい = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelMessage
            // 
            this.LabelMessage.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelMessage.Location = new System.Drawing.Point(40, 50);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(550, 150);
            this.LabelMessage.TabIndex = 0;
            this.LabelMessage.Text = "終了します。よろしいですか？";
            // 
            // Labelいいえ
            // 
            this.Labelいいえ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(157)))));
            this.Labelいいえ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Labelいいえ.Font = new System.Drawing.Font("メイリオ", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Labelいいえ.Location = new System.Drawing.Point(456, 231);
            this.Labelいいえ.Name = "Labelいいえ";
            this.Labelいいえ.Size = new System.Drawing.Size(166, 74);
            this.Labelいいえ.TabIndex = 2;
            this.Labelいいえ.Text = "いいえ";
            this.Labelいいえ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Labelいいえ.Click += new System.EventHandler(this.Labelいいえ_Click);
            // 
            // Labelはい
            // 
            this.Labelはい.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(157)))));
            this.Labelはい.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Labelはい.Font = new System.Drawing.Font("メイリオ", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Labelはい.Location = new System.Drawing.Point(284, 231);
            this.Labelはい.Name = "Labelはい";
            this.Labelはい.Size = new System.Drawing.Size(166, 74);
            this.Labelはい.TabIndex = 1;
            this.Labelはい.Text = "はい";
            this.Labelはい.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Labelはい.Click += new System.EventHandler(this.Labelはい_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(43F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(634, 314);
            this.ControlBox = false;
            this.Controls.Add(this.Labelはい);
            this.Controls.Add(this.Labelいいえ);
            this.Controls.Add(this.LabelMessage);
            this.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(21, 24, 21, 24);
            this.Name = "FrmMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label LabelMessage;
        public System.Windows.Forms.Label Labelいいえ;
        public System.Windows.Forms.Label Labelはい;
    }
}