using System;
using System.Windows.Forms;

namespace NumberPlateReader
{
    /// <summary>
    /// 一連番号入力フォームのクラスです。
    /// </summary>
    public partial class Frm番号 : Form
    {
        /// <summary>
        /// デフォルト コンストラクタです。
        /// </summary>
        public Frm番号()
        {
            InitializeComponent();

            //結果表示ラベルをクリアします。
            Label結果.Text = "";
        }

        /// <summary>
        /// このフォームで選択された文字を返します。
        /// </summary>
        public string 結果 { get; set; }

        /// <summary>
        /// 文字ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelChar_Click(object sender, EventArgs e)
        {
            //クリックしたラベルの文字を変数にセットします。
            string c = ((Label)sender).Text;

            //結果表示に1文字追加します。
            Label結果.Text += c;

            //結果表示が3文字に達した場合
            if (Label結果.Text.Length == 4)
            {
                //番号にハイフンを付与します。
                Label結果.Text = Label結果.Text.Substring(0, 2) + "-" + Label結果.Text.Substring(2, 2);

                //結果プロパティに表示されている内容をセットします。
                結果 = Label結果.Text;

                //このフォームの戻り値をセットし、フォームを隠します。
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        /// <summary>
        /// 「決定」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label決定_Click(object sender, EventArgs e)
        {
            //表示されている内容をプロパティにセットします。
            結果 = Label結果.Text;

            //このフォームの戻り値をセットし、フォームを隠します。
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// 「戻る」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label戻る_Click(object sender, EventArgs e)
        {
            //プロパティをクリアします。
            結果 = "";

            //このフォームの戻り値をセットし、フォームを隠します。
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
    }
}
