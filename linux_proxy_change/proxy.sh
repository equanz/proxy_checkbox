#! /bin/bash

proxy_change () {
    # ファイル置き換えで対応(ファイルを読み込んで変更したほうがいいと思う人生だった)
    sudo mv /etc/apt/apt.conf.d/00proxy /etc/apt/apt.conf.d/00proxy~~
    sudo mv /etc/apt/apt.conf.d/00proxy~ /etc/apt/apt.conf.d/00proxy
    sudo mv /etc/apt/apt.conf.d/00proxy~~ /etc/apt/apt.conf.d/00proxy~
}

grep -q "#" /etc/apt/apt.conf.d/00proxy
if [ "$?" -eq 0 ]
then
    echo "現在プロキシは Off です。"
    echo "プロキシを On  にしますか。"
    echo "Y/n"
    while true; do
	read INPUT
	if [ "$INPUT" = "Y" -o "$INPUT" = "y" -o "$INPUT" = "yes" -o "$INPUT" = "Yes" ]; then
	    proxy_change
	    echo "プロキシ On"
	    break
	elif [ "$INPUT" = "N" -o "$INPUT" = "n" -o "$INPUT" = "no" -o "$INPUT" = "no" ]; then
	    echo "プロキシ Off"
	    break
	else
	    echo "Y/n を入力してください。"
	fi
    done
else
    echo "現在プロキシは On  です。"
    echo "プロキシを Off にしますか。"
    echo "Y/n"
    while true; do
	read INPUT
	if [ "$INPUT" = "Y" -o "$INPUT" = "y" -o "$INPUT" = "yes" -o "$INPUT" = "Yes" ]; then
	    echo "プロキシ Off"
	    proxy_change
	    break
	elif [ "$INPUT" = "N" -o "$INPUT" = "n" -o "$INPUT" = "no" -o "$INPUT" = "no" ]; then
	    echo "プロキシ On"
	    break
	else
	    echo "Y/n を入力してください。"
	fi
    done
fi

sleep 5s

