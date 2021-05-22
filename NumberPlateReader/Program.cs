using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace NumberPlateReader
{
    /// <summary>
    /// このシステムのスタートアップおよび静的クラスと静的メンバです。
    /// </summary>
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //メイン画面を起動します。
            Application.Run(new FrmMain());
        }

        /// <summary>
        /// このアセンブリが存在するディレクトリのフルパスを返します。
        /// </summary>
        /// <returns>このアセンブリが存在するディレクトリのフルパス</returns>
        public static string MyDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// 画像ファイルを格納するディレクトリのフルパスを返します。
        /// </summary>
        /// <returns></returns>
        public static string ImageDir()
        {
            return MyDir() + @"\jpeg";
        }
    }
}
