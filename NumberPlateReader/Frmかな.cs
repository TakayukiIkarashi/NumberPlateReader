using System;
using System.Windows.Forms;

namespace NumberPlateReader
{
    /// <summary>
    /// かな入力フォームのクラスです。
    /// </summary>
    public partial class Frmかな : Form
    {
        /// <summary>
        /// デフォルト コンストラクタです。
        /// </summary>
        public Frmかな()
        {
            InitializeComponent();
        }

        /// <summary>
        /// このフォームで選択された文字を返します。
        /// </summary>
        public string 結果 { get; set; }

        /// <summary>
        /// 「かな」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Labelかな_Click(object sender, EventArgs e)
        {
            //クリックしたラベルの文字をプロパティにセットします。
            結果 = ((Label)sender).Text;

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
