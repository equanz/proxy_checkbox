# Proxy Checkbox
## Summary
`win_proxy_checkbox/`  
インターネットオプションの接続タブ，LANの設定ボタン内にあるプロキシサーバーの使用に関するチェックボックスを外す，付けるを行います。  
基本的に既にプロキシサーバーのIPは設定済みで使用するか使用しないかを変更するような利用を想定しています。

`linux_proxy_change/`  
bashによるプロキシ設定の切り替えを行います。  
* 現在，aptのプロキシ設定変更のみ行うことが出来ます

`win_ssh_proxy_change`  
MinGWのsshプロキシ設定の切り替えを行います。
* 現在，自動切り替えのみ対応しています

## Mechanism
`win_proxy_checkbox/`  
Windowsレジストリキーの
```
\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings
ProxyEnable
```
を検出し，現在のインターネット接続状況を元に0,1と変更しています。

`linux_proxy_change/`  
プロキシ設定をコメントアウトします。  
またはコメントアウトした設定のコメントアウトを解除します。  
この一連の動作でプロキシ設定のあるファイルとプロキシ設定の無いファイルを入れ替えます。  
これをbash対話式シェルスクリプト化しています。

`win_ssh_proxy_change`  
MinGWのsshプロキシ設定を切り替えます。
設定のコメントアウトまたはその解除で切り替えを行う。

## License
[MIT License](./LICENSE.txt)で提供します。
