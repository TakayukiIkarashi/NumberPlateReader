using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NumberPlateReader
{
    /// <summary>
    /// メインフォームのクラスです。
    /// </summary>
    public partial class FrmMain : Form
    {
        #region camcapkun
        public int iCamFlg;
        public const int WM_APP = 32768;
        public const int WM_GACAP_CAPSTART = 32769;
        public const int WM_GACAP_FILESAVE = 32770;
        public const int WM_GACAP_CAPSTOP = 32771;
        public const int WM_GACAP_NEWHANDLE = 32776;
        public const int WM_GACAP_NEWSIZE = 32777;
        public const int WM_camcapkun_ALLEND = 32778;
        public const int WM_camcapkun_CAMCHANGE = 32788;
        public const int WM_camcapkun_TESSERACT = 65536;
        public const int WM_camcapkun_HEALTH = 36864;
        public int iFlgWinHandle;
        public int iFlgWinSize;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string WindowName);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 36864)
            {
                this.iCamFlg = 1;
            }
            base.WndProc(ref m);
        }
        #endregion

        /// <summary>
        /// デフォルト コンストラクタです。
        /// </summary>os
        public FrmMain()
        {
            InitializeComponent();

            //コントロールを初期化します。
            SetInitControls();

            ////フォームを最大化します。
            //this.WindowState = FormWindowState.Maximized;

            //前回までの画像ファイルが存在する場合は削除します。
            RemoveImageFile();

            //カメラを起動します。
            StartCamCap();
        }

        /// <summary>
        /// コントロールを初期化します。
        /// </summary>
        private void SetInitControls()
        {
            //読み取り結果を反映するテキストボックスを空にします。
            Label標板地.Text = "";
            Label分類番号.Text = "";
            Labelかな.Text = "";
            Label番号.Text = "";

            //読み取り結果を反映するテキストボックスの背景色を白にします。
            Label標板地.BackColor = Color.White;
            Label分類番号.BackColor = Color.White;
            Labelかな.BackColor = Color.White;
            Label番号.BackColor = Color.White;

            //説明書きを初期化します。
            Label説明.Text = "ナンバープレートを台の上に置き、右上の「画像読み込み」ボタンを押してください。";
        }

        /// <summary>
        /// 画像ファイルを保存するディレクトリを空にします。
        /// </summary>
        private void RemoveImageFile()
        {
            //画像ファイルを保存するディレクトリを空にします。
            try
            {
                foreach (string filepath in Directory.GetFiles(Program.ImageDir()))
                {
                    File.Delete(filepath);
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 「キャプチャ」ボタンのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCapture_Click(object sender, EventArgs e)
        {
            //カメラに表示されている画像をjpeg形式で保存します。
            FrmMain.SendMessage(FrmMain.FindWindow("camcapkun", "camcapkun"), 32770, 0, 0);

            //カメラの読み込みを停止します。
            FrmMain.SendMessage(FrmMain.FindWindow("camcapkun", "camcapkun"), 32778, 0, 0);

            //jpeg形式で保存したキャプチャ画像のフルパスを取得します。
            //string imgpath = GetImageFilePath();
            string imgpath = Program.MyDir() + @"\sample1.png";
            if (imgpath == "")
            {
                MessageBox.Show("イメージを取得できません");
                return;
            }

            //画像ファイルのフルパスから画像イメージをピクチャボックスに再描画します。
            picImage.Image = Image.FromFile(imgpath);

            //画像ファイルから文字列を抽出します。
            string s = TextRecognition(imgpath);

            //実行結果をそのままテキストボックスに反映します。
            TxtResult.Text = s;

            //抽出した文字列を登録番号として結果表示します。
            Reflect登録番号(s);

            //説明書きを更新します。
            Reflect説明書き();
        }

        /// <summary>
        /// カメラを起動します。
        /// </summary>
        private void StartCamCap()
        {
            //カメラの制御は、フリーソフトの「camcapkun」を利用します。
            Process.Start(new ProcessStartInfo
            {
                FileName = ".\\camcapkun.exe",
                Arguments = this.picImage.Handle.ToString() + " " + Process.GetCurrentProcess().MainWindowHandle.ToString(),
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Minimized
            });

            this.timer1.Interval = 5000;
            this.timer1.Enabled = true;
            this.iCamFlg = 1;
        }

        /// <summary>
        /// パラメータに指定された画像ファイルのフルパスから画像に含まれる文字列を抽出し、返します。
        /// </summary>
        /// <param name="imgpath">画像ファイルのフルパス</param>
        /// <returns>画像に含まれる文字列</returns>
        private string TextRecognition(string imgpath)
        {
            //GoogleCloudVisionAPIをインスタンス化します。
            GoogleCloudVisionAPI ocr = new GoogleCloudVisionAPI
            {
                //認証ファイルを指定します。
                CredentialFile = Application.StartupPath + @"\sample.json"
            };

            //画像イメージをバイト配列に変換します。
            byte[] buf = File.ReadAllBytes(imgpath);

            //画像イメージから文字列を抽出します。
            string s = "";
            ocr.GetFullText(buf, ref s);

            //抽出した結果を返します。
            return s;
        }

        /// <summary>
        /// 同一ディレクトリに存在するjpeg形式の画像ファイルから、本日付けでいちばん新しい日付のものを返します。
        /// </summary>
        /// <returns></returns>
        private string GetImageFilePath()
        {
            //比較日付として、前日日付を初期値として代入します。
            DateTime prevDT = DateTime.Now.AddDays(-1);

            //このメソッドの戻り値となる変数です。
            string result = "";

            //このアセンブリと同一ディレクトリに存在するすべてのファイルを検索します。
            foreach (string filepath in Directory.GetFiles(Program.ImageDir()))
            {
                //jpeg形式のファイルかどうかをファイルの拡張子で判別します。
                string extname = Path.GetExtension(filepath);
                if (extname.ToLower() == ".jpg")
                {
                    //jpeg形式のファイルが比較日付よりも新しい場合
                    if (prevDT <= File.GetCreationTime(filepath))
                    {
                        //戻り値となる変数の値と、比較日付を更新します。
                        result = filepath;
                        prevDT = File.GetCreationTime(filepath);
                    }
                }
            }

            //変数の内容をメソッドの戻り値として返します。
            return result;
        }

        /// <summary>
        /// パラメータに指定された登録番号をテキスト欄に反映します。
        /// </summary>
        /// <param name="登録番号"></param>
        private void Reflect登録番号(string 登録番号)
        {
            //登録番号を種類ごとに分割します。
            Split登録番号(登録番号, out string 標板地, out string 分類番号, out string かな, out string 番号);

            //分割した登録番号をテキスト欄に反映します。
            Label標板地.Text = 標板地;
            Label分類番号.Text = 分類番号;
            Labelかな.Text = かな;
            Label番号.Text = 番号;
        }

        /// <summary>
        /// 説明書きを更新します。
        /// </summary>
        private void Reflect説明書き()
        {
            string 未入力 = "";

            //未入力の項目の背景色を変えます。
            if (Label標板地.Text != "")
            {
                Label標板地.BackColor = Color.White;
            }
            else
            {
                Label標板地.BackColor = Color.Yellow;
                未入力 += "・標板地\n";
            }
            if (Label分類番号.Text != "")
            {
                Label分類番号.BackColor = Color.White;
            }
            else
            {
                Label分類番号.BackColor = Color.Yellow;
                未入力 += "・分類番号\n";
            }
            if (Labelかな.Text != "")
            {
                Labelかな.BackColor = Color.White;
            }
            else
            {
                Labelかな.BackColor = Color.Yellow;
                未入力 += "・かな\n";
            }
            if (Label番号.Text != "")
            {
                Label番号.BackColor = Color.White;
            }
            else
            {
                Label番号.BackColor = Color.Yellow;
                未入力 += "・番号\n";
            }

            //説明書きを更新します。
            Label説明.Text = "";
            if (未入力 == "")
            {
                Label説明.Text += "表示されている内容でよければ、「読み込みOK」ボタンを押してください。\n";
                Label説明.Text += "修正する場合は、該当する箇所をタッチしてください。";
            }
            else
            {
                Label説明.Text += "以下の内容を取得できませんでした。\n";
                Label説明.Text += 未入力;
                Label説明.Text += "該当する箇所をタッチしてください。";
            }
        }

        /// <summary>
        /// パラメータに指定された登録番号を分割して返します。
        /// </summary>
        /// <param name="登録番号">分解する登録番号</param>
        /// <param name="標板地">分解された登録番号のうち、標板地</param>
        /// <param name="分類番号">分解された登録番号のうち、分類番号</param>
        /// <param name="かな">分解された登録番号のうち、かな</param>
        /// <param name="番号">分解された登録番号のうち、番号</param>
        private void Split登録番号(string 登録番号, out string 標板地, out string 分類番号, out string かな, out string 番号)
        {
            //登録番号に含まれる余計な文字列を削除します。
            登録番号 = 登録番号.Replace("\n", "");
            登録番号 = 登録番号.Replace("-", "");
            登録番号 = 登録番号.Replace("TOYOTA", "");

            //メソッドの戻り値となる変数を初期化します。
            標板地 = "";
            分類番号 = "";
            かな = "";
            番号 = "";

            //分解する登録番号のうち、4:番号　3:かな　2:分類番号　1:標板地　を意味します。
            int kind = 4;

            //登録番号を示す文字列のうち、後方から解析します。
            for (int i = 登録番号.Length - 1; 0 <= i; --i)
            {
                //登録番号を示す文字列から1文字抽出します。
                string c = 登録番号.Substring(i, 1);

                //「4:番号」を解析している場合
                if (kind == 4)
                {
                    //抽出した1文字が数値に変換可能な場合
                    if (int.TryParse(c, out int n))
                    {
                        //番号はすでに4桁に達している場合
                        if (4 <= 番号.Length)
                        {
                            //「4:番号」の読み取りから「3:かな」を飛ばし、「2:分類番号」に移動し、処理を続行します。
                            --kind;
                            --kind;
                        }
                        //番号はまだ4桁に達していない場合
                        else
                        {
                            //番号として認識します。
                            番号 = c + 番号;
                        }
                    }
                    //抽出した1文字が数値に変換できない場合
                    else
                    {
                        //「3:かな」に移動します。
                        --kind;
                        continue;
                    }
                }

                //「3:かな」を解析している場合
                if (kind == 3)
                {
                    //かなではない文字列を認識した場合
                    if (0 <= "ACFHKLMPXY".IndexOf(c))
                    {
                        //「2:分類番号」に移動し、処理を続行します。
                        --kind;
                    }
                    //かなとして妥当な文字を認識した場合
                    else
                    {
                        //かなとして認識します。
                        かな = c;

                        //「2:分類番号」に移動します。
                        --kind;
                        continue;
                    }
                }

                //「2:分類番号」を解析している場合
                if (kind == 2)
                {
                    //抽出した1文字が数値に変換可能な場合
                    if (int.TryParse(c, out int n))
                    {
                        //分類番号として認識します。
                        分類番号 = c + 分類番号;
                    }
                    //抽出した1文字が数値に変換できない場合
                    else
                    {
                        //抽出した1文字が分類番号として利用されるアルファベットの場合
                        if (0 <= "ACFHKLMPXY".IndexOf(c))
                        {
                            //分類番号として認識します。
                            分類番号 = c + 分類番号;
                        }
                        //抽出した1文字が分類番号として利用されるアルファベット以外の場合
                        else
                        {
                            //「1:標板地」に移動します。
                            --kind;
                        }
                    }
                }

                //「1:標板地」を解析している場合
                if (kind == 1)
                {
                    //標板地として認識します。
                    標板地 = c + 標板地;
                }
            }

            //取得した標板地が妥当ではない場合
            if (int.TryParse(標板地, out int num))
            {
                //標板地を空にします。
                標板地 = "";
            }

            //取得した番号が4文字の場合
            if (番号.Length == 4)
            {
                //番号にハイフンを付与します。
                番号 = 番号.Substring(0, 2) + "-" + 番号.Substring(2, 2);
            }
        }

        /// <summary>
        /// 「やりなおし」ボタンのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRetry_Click(object sender, EventArgs e)
        {
            //カメラ読み込みを再開します。
            StartCamCap();

            //コントロールを初期化します。
            SetInitControls();
        }

        /// <summary>
        /// 読み取り結果にて、「かな」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Labelかな_Click(object sender, EventArgs e)
        {
            //「かな」入力フォームを表示します。
            Frmかな f = new Frmかな();
            f.ShowDialog();

            //「かな」入力フォームを「戻る」ボタンで閉じた場合は処理を抜けます。
            if (f.DialogResult == DialogResult.Cancel)
            {
                f.Close();
                return;
            }

            //「かな」入力フォームにて「かな」をクリックした場合は当該かなを表示します。
            Labelかな.Text = f.結果;

            //「かな」入力フォームを閉じます。
            f.Close();

            //説明書きを更新します。
            Reflect説明書き();
        }

        /// <summary>
        /// 読み取り結果にて、「分類番号」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label分類番号_Click(object sender, EventArgs e)
        {
            //「分類番号」入力フォームを表示します。
            Frm分類番号 f = new Frm分類番号();
            f.ShowDialog();

            //「分類番号」入力フォームを「戻る」ボタンで閉じた場合は処理を抜けます。
            if (f.DialogResult == DialogResult.Cancel)
            {
                f.Close();
                return;
            }

            //「分類番号」フォームにて文字をクリックした場合は当該文字を表示します。
            Label分類番号.Text = f.結果;

            //「分類番号」入力フォームを閉じます。
            f.Close();

            //説明書きを更新します。
            Reflect説明書き();
        }

        /// <summary>
        /// 読み取り結果にて、「番号」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label番号_Click(object sender, EventArgs e)
        {
            //「番号」入力フォームを表示します。
            Frm番号 f = new Frm番号();
            f.ShowDialog();

            //「番号」入力フォームを「戻る」ボタンで閉じた場合は処理を抜けます。
            if (f.DialogResult == DialogResult.Cancel)
            {
                f.Close();
                return;
            }

            //「番号」フォームにて文字をクリックした場合は当該文字を表示します。
            Label番号.Text = f.結果;

            //「番号」入力フォームを閉じます。
            f.Close();

            //説明書きを更新します。
            Reflect説明書き();
        }

        /// <summary>
        /// デバッグモードのチェックボックスの状態変更時イベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkDebug_CheckedChanged(object sender, EventArgs e)
        {
            //デバッグモードのチェックが入った時
            if (ChkDebug.Checked)
            {
                //結果表示テキストを前面に表示します。
                TxtResult.Visible = true;
                TxtResult.BringToFront();
            }
            //デバッグモードのチェックが外された時
            else
            {
                //結果表示テキストを非表示にします。
                TxtResult.Visible = false;
            }
        }

        /// <summary>
        /// 「終了」ボタンのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn終了_Click(object sender, EventArgs e)
        {
            //メッセージフォームを表示します。
            FrmMessage f = new FrmMessage();
            f.ShowDialog();

            //メッセージフォームを「いいえ」ボタンで閉じた場合は処理を抜けます。
            if (f.DialogResult == DialogResult.No)
            {
                f.Close();
                return;
            }

            //メッセージフォームを閉じます。
            f.Close();

            //フォームを閉じます。
            this.Close();
        }

        /// <summary>
        /// 「読み込みOK」ボタンのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            //TODO：ここに読み込んだナンバーの文字列を利用する処理を追加します。

        }
    }
}
