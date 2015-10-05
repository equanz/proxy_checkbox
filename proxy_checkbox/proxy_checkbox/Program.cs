using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace proxy_checkbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //キーを開く
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            //キーを読み込み、TrueかFalseを判定
            int intValue = (int)regkey.GetValue("ProxyEnable");
            //整数（32ビット）を書き込む
            if (intValue == 0)
            {
                //True(プロキシサーバーを使用する)
                regkey.SetValue("ProxyEnable", 1);
                Console.WriteLine("プロキシサーバーを使用するチェックボックスを付けました。\n");
                System.Threading.Thread.Sleep(2000);
            }
            else if(intValue==1)
            {
                //False(プロキシサーバーを使用しない)
                regkey.SetValue("ProxyEnable", 0);
                Console.WriteLine("プロキシサーバーを使用するチェックボックスを外しました。\n");
                System.Threading.Thread.Sleep(2000);
            }
            regkey.Close();
        }
    }
}
