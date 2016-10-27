#! /bin/bash

# 戻り値用
ans=""

# Yes/Noの読み込み開始
yesno () {
    echo "Y/n"
    while true; do
        read INPUT
        if [ "$INPUT" = "Y" -o "$INPUT" = "y" -o "$INPUT" = "yes" -o "$INPUT" = "Yes" ]
        then
            ans=1
            break
        elif [ "$INPUT" = "N" -o "$INPUT" = "n" -o "$INPUT" = "no" -o "$INPUT" = "no" ]
        then
            ans=0
	    break
        else
            ans=-1
	    break
        fi
    done
}

sharp_del () {
    # シャープを消す
    sudo sed -i -e "s/^#//" /etc/apt/apt.conf.d/00proxy
}
sharp_ins () {
    # シャープを付ける
    sudo sed -i -e "s/^/#/" /etc/apt/apt.conf.d/00proxy
}

# シャープがあるかの検出
grep -q "#" /etc/apt/apt.conf.d/00proxy
if [ "$?" -eq 0 ]
then
    echo "現在プロキシは Off です。"
    echo "プロキシを On  にしますか。"
    yesno
    if [ $ans -eq 1 ]
    then
        sharp_del
        echo "プロキシ On"
        break
    elif [ $ans -eq 0 ]
    then
        echo "プロキシ Off"
	break
    else
        echo "Y/n を入力してください。"
	break
    fi
else
    echo "現在プロキシは On  です。"
    echo "プロキシを Off にしますか。"
    yesno
    if [ $ans -eq 1 ]
    then
        sharp_ins
        echo "プロキシ Off"
        break
    elif [ $ans -eq 0 ]
    then
        echo "プロキシ On"
	break
    else
        echo "Y/n を入力してください。"
	break
    fi
fi

sleep 5s
