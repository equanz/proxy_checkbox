# ssh\configファイルのパス
filename="/c/Users/User/.ssh/config"
# プロキシ設定用
com="	ProxyCommand"
scom="#	ProxyCommand"

# 指定文字列が無いか検索
grep -q $scom $filename
# 指定文字列が一度以上検出
if [ "$?" -eq 0 ]
then
  # Off -> On
  # 要はシャープを消す
  sed -i -e "s/$scom/$com/g" $filename
  echo "Proxy On"
  break
else
  # On -> Off
  # 要はシャープを付ける
  sed -i -e "s/$com/$scom/g" $filename
  echo "Proxy Off"
  break
fi
