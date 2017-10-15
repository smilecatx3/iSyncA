using System;
using System.Windows.Forms;

namespace iSyncA
{
    public partial class iSyncAForm : Form
    {
        #region 程式碼主要進入點
        [STAThread]
        static void Main()
        {
            //Console.OutputEncoding = Encoding.Unicode;
            //Console.BufferHeight = 8000;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new iSyncAForm());
        }
        #endregion
    }
}
