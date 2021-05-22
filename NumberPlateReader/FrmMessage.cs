using System;
using System.Windows.Forms;

namespace NumberPlateReader
{
    /// <summary>
    /// メッセージフォームのクラスです。
    /// </summary>
    public partial class FrmMessage : Form
    {
        /// <summary>
        /// デフォルト コンストラクタです。
        /// </summary>
        public FrmMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 「はい」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Labelはい_Click(object sender, EventArgs e)
        {
            //このフォームの戻り値をセットし、フォームを隠します。
            this.DialogResult = DialogResult.Yes;
            this.Hide();
        }

        /// <summary>
        /// 「いいえ」ラベルのクリックイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Labelいいえ_Click(object sender, EventArgs e)
        {
            //このフォームの戻り値をセットし、フォームを隠します。
            this.DialogResult = DialogResult.No;
            this.Hide();
        }
    }
}
