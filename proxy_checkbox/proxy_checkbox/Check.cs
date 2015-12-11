using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace proxy_checkbox
{
    /// <summary>
    /// 接続系の各操作を格納したclass
    /// </summary>
    /// <returns></returns>
    class Check
    {

        public static bool isconnecting()
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

        /* 非同期処理等が必要、要修正
        public static async Task reconnect()
        {
            var connection = new HubConnection("http://www.google.co.jp/");

            connection.Closed += () =>
            {
                await Task.Delay(5000);  //--- 5秒後にリトライ
                try
                {
                    await connection.Start();
                }
                catch
                {
                    //--- 再接続失敗
                }
            };

            try
            {
                await connection.Start();
            }
            catch
            {
                //--- 接続失敗
            }
        }*/
    }
}
