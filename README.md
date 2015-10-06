# proxy_checkbox
インターネットオプションの接続タブ、LANの設定ボタン内にあるプロキシサーバーの使用に関するチェックボックスを外す、付けるをトグル式で行おうというもの。
基本的に既にプロキシサーバーのIPは設定済みで使用するか使用しないかを変更するような利用を想定しています。  
  
# 仕組み
レジストリを書き換えるよ！(以上  
\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet SettingsのProxyEnableをトグル式で0,1変更します。
