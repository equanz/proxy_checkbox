# Proxy Checkbox
## Summary
`win_proxy_checkbox/`  
インターネットオプションの接続タブ、LANの設定ボタン内にあるプロキシサーバーの使用に関するチェックボックスを外す、付けるをトグル式で行います。  
基本的に既にプロキシサーバーのIPは設定済みで使用するか使用しないかを変更するような利用を想定しています。

`linux_proxy_change/`   
bashによるプロキシ設定の切り替えを行います。  
* 現在、aptのプロキシ設定変更のみ行うことが出来ます

## Mechanism
`win_proxy_checkbox/`  
Windowsレジストリキーの
```
\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings
ProxyEnable
```
をトグル式で0,1と変更しています。

`linux_proxy_change/`  
プロキシ設定のあるファイルとプロキシ設定のないファイルを用意します。そして、
```
$ mv /etc/apt/apt.conf.d/00proxy /etc/apt/apt/conf.d/00proxy~~
$ mv /etc/apt/apt.conf.d/00proxy~ /etc/apt/apt.conf.d/00proxy
$ mv /etc/apt/apt/conf.d/00proxy~~ /etc/apt/apt.conf.d/00proxy~
```
という一連の動作でプロキシ設定のあるファイルとプロキシ設定の無いファイルを入れ替えます。  
これをbash対話式シェルスクリプト化しています。

## License
[MIT License](./LICENSE.txt)で提供します。
