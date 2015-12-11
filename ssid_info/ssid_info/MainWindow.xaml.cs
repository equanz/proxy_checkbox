using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ssid_info
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool isconnecting()
        {
            string url = "http://www.google.co.jp/";

            //try前にnullで作成
            System.Net.HttpWebRequest requ = null;
            System.Net.HttpWebResponse resp = null;
            try
            {
                //"url"で指定したURLでリクエストを作成します
                requ = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                requ.Method = "HEAD";
                //設定したリクエストで受信
                resp = (System.Net.HttpWebResponse)requ.GetResponse();
                Console.WriteLine(resp.StatusCode);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (resp != null)
                {
                    resp.Close();
                }
            }
        }
        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            if (isconnecting())
            {
                ssidbox.Text = "〇現在インターネットに接続されています";
            }
            else
            {
                ssidbox.Text = "×現在インターネットには接続されていません";
            }
        }
    }
}
