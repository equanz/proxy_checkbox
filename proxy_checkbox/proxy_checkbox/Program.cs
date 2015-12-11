using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.AspNet.SignalR.Client;

namespace proxy_checkbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //ネットワーク接続の確認
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //インターネット非接続の確認
                if (!Check.isconnecting())
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
                        Console.WriteLine("プロキシ On");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else if (intValue == 1)
                    {
                        //False(プロキシサーバーを使用しない)
                        regkey.SetValue("ProxyEnable", 0);
                        Console.WriteLine("プロキシ Off");
                        System.Threading.Thread.Sleep(2000);
                    }
                    regkey.Close();

                    var connection = new HubConnection("http://www.google.co.jp/");

                    connection.Closed += () =>
                    {
                        System.Threading.Thread.Sleep(5000);  //--- 5秒後にリトライ
                        try
                        {
                            connection.Start();
                        }
                        catch
                        {
                            //--- 再接続失敗
                        }
                    };

                    try
                    {
                        connection.Start();
                    }
                    catch
                    {
                        //--- 接続失敗
                    }
                    /* インターネットに再接続されるまでに時間がかかる模様
                
                    if (Check.isconnecting())
                    {
                        Console.WriteLine("o インターネット接続");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("x インターネット接続...");
                        System.Threading.Thread.Sleep(2000);
                    }
                    */
                }
                else
                {
                    Console.WriteLine("o ネットワーク接続");
                    Console.WriteLine("o インターネット接続");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("x ネットワーク接続");
                Console.WriteLine("LANの接続等を確認してください");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
