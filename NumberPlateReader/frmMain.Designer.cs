namespace NumberPlateReader
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnCapture = new System.Windows.Forms.Button();
            this.BtnRetry = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label番号 = new System.Windows.Forms.Label();
            this.Labelかな = new System.Windows.Forms.Label();
            this.Label分類番号 = new System.Windows.Forms.Label();
            this.Label標板地 = new System.Windows.Forms.Label();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.ChkDebug = new System.Windows.Forms.CheckBox();
            this.Label説明 = new System.Windows.Forms.Label();
            this.Btn終了 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCapture
            // 
            this.BtnCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(157)))));
            this.BtnCapture.Font = new System.Drawing.Font("Meiryo UI", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCapture.Location = new System.Drawing.Point(725, 30);
            this.BtnCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCapture.Name = "BtnCapture";
            this.BtnCapture.Size = new System.Drawing.Size(250, 150);
            this.BtnCapture.TabIndex = 1;
            this.BtnCapture.Text = "画像\r\n読み込み";
            this.BtnCapture.UseVisualStyleBackColor = false;
            this.BtnCapture.Click += new System.EventHandler(this.BtnCapture_Click);
            // 
            // BtnRetry
            // 
            this.BtnRetry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.BtnRetry.Font = new System.Drawing.Font("Meiryo UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnRetry.Location = new System.Drawing.Point(725, 186);
            this.BtnRetry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRetry.Name = "BtnRetry";
            this.BtnRetry.Size = new System.Drawing.Size(250, 74);
            this.BtnRetry.TabIndex = 2;
            this.BtnRetry.Text = "やりなおし";
            this.BtnRetry.UseVisualStyleBackColor = false;
            this.BtnRetry.Click += new System.EventHandler(this.BtnRetry_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Black;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(30, 30);
            this.picImage.Margin = new System.Windows.Forms.Padding(20);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(640, 320);
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // BtnOK
            // 
            this.BtnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(154)))), ((int)(((byte)(208)))));
            this.BtnOK.Font = new System.Drawing.Font("Meiryo UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnOK.Location = new System.Drawing.Point(725, 547);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(250, 150);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "読み込みOK";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Label番号);
            this.panel1.Controls.Add(this.Labelかな);
            this.panel1.Controls.Add(this.Label分類番号);
            this.panel1.Controls.Add(this.Label標板地);
            this.panel1.Controls.Add(this.TxtResult);
            this.panel1.Location = new System.Drawing.Point(30, 380);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 320);
            this.panel1.TabIndex = 0;
            // 
            // Label番号
            // 
            this.Label番号.Font = new System.Drawing.Font("Impact", 117F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label番号.Location = new System.Drawing.Point(160, 140);
            this.Label番号.Name = "Label番号";
            this.Label番号.Size = new System.Drawing.Size(475, 175);
            this.Label番号.TabIndex = 3;
            this.Label番号.Text = "88-88";
            this.Label番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label番号.Click += new System.EventHandler(this.Label番号_Click);
            // 
            // Labelかな
            // 
            this.Labelかな.Font = new System.Drawing.Font("Meiryo UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Labelかな.Location = new System.Drawing.Point(20, 175);
            this.Labelかな.Name = "Labelかな";
            this.Labelかな.Size = new System.Drawing.Size(125, 125);
            this.Labelかな.TabIndex = 2;
            this.Labelかな.Text = "さ";
            this.Labelかな.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Labelかな.Click += new System.EventHandler(this.Labelかな_Click);
            // 
            // Label分類番号
            // 
            this.Label分類番号.Font = new System.Drawing.Font("Impact", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label分類番号.Location = new System.Drawing.Point(350, 0);
            this.Label分類番号.Name = "Label分類番号";
            this.Label分類番号.Size = new System.Drawing.Size(275, 125);
            this.Label分類番号.TabIndex = 1;
            this.Label分類番号.Text = "888";
            this.Label分類番号.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label分類番号.Click += new System.EventHandler(this.Label分類番号_Click);
            // 
            // Label標板地
            // 
            this.Label標板地.Font = new System.Drawing.Font("Meiryo UI", 51F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label標板地.Location = new System.Drawing.Point(20, 20);
            this.Label標板地.Name = "Label標板地";
            this.Label標板地.Size = new System.Drawing.Size(330, 100);
            this.Label標板地.TabIndex = 0;
            this.Label標板地.Text = "尾張小牧";
            this.Label標板地.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(-2, -2);
            this.TxtResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtResult.Multiline = true;
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtResult.Size = new System.Drawing.Size(640, 320);
            this.TxtResult.TabIndex = 4;
            this.TxtResult.Visible = false;
            // 
            // ChkDebug
            // 
            this.ChkDebug.AutoSize = true;
            this.ChkDebug.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChkDebug.Location = new System.Drawing.Point(834, 264);
            this.ChkDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkDebug.Name = "ChkDebug";
            this.ChkDebug.Size = new System.Drawing.Size(141, 28);
            this.ChkDebug.TabIndex = 6;
            this.ChkDebug.Text = "デバッグモード";
            this.ChkDebug.UseVisualStyleBackColor = true;
            this.ChkDebug.CheckedChanged += new System.EventHandler(this.ChkDebug_CheckedChanged);
            // 
            // Label説明
            // 
            this.Label説明.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label説明.Location = new System.Drawing.Point(725, 380);
            this.Label説明.Name = "Label説明";
            this.Label説明.Size = new System.Drawing.Size(250, 138);
            this.Label説明.TabIndex = 7;
            this.Label説明.Text = "ナンバープレートを台の上に置き、右上の「画像読み込み」ボタンを押してください。";
            // 
            // Btn終了
            // 
            this.Btn終了.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn終了.Location = new System.Drawing.Point(0, 0);
            this.Btn終了.Name = "Btn終了";
            this.Btn終了.Size = new System.Drawing.Size(75, 30);
            this.Btn終了.TabIndex = 8;
            this.Btn終了.Text = "終了";
            this.Btn終了.UseVisualStyleBackColor = true;
            this.Btn終了.Click += new System.EventHandler(this.Btn終了_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.CancelButton = this.Btn終了;
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.ControlBox = false;
            this.Controls.Add(this.Btn終了);
            this.Controls.Add(this.Label説明);
            this.Controls.Add(this.ChkDebug);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCapture);
            this.Controls.Add(this.BtnRetry);
            this.Controls.Add(this.picImage);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCapture;
        private System.Windows.Forms.Button BtnRetry;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Label番号;
        private System.Windows.Forms.Label Labelかな;
        private System.Windows.Forms.Label Label分類番号;
        private System.Windows.Forms.Label Label標板地;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.CheckBox ChkDebug;
        private System.Windows.Forms.Label Label説明;
        private System.Windows.Forms.Button Btn終了;
    }
}

