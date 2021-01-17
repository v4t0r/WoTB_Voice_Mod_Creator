# WoTB_Voice_Mod_Creater
FMod Designerの使い方がわからなくても自動でプロジェクトを作成、ビルド、適応をしてくれるソフトです。<br>
※sounds.yamlを変更するためAndroid端末は適応できません。<br>
おまけとして戦闘BGMの作成と、謎の音楽プレイヤーを搭載しています。<br>
既にオンラインも実装していますが、バグがまだまだたくさんあるため利用できないようになっています。<br>
操作方法はYoutubeの動画を参照してください<br>
バグや不具合、わからないことがあればSRTTbacon#2395までご連絡を！<br>
<br>
V1.2.5変更点<br>
・配布されている音声Modのsounds.yamlがdvpl化されていなかった場合正しくインストールできない問題を修正(Thanks to meniya)<br>
・Android用にFSB単体を作成できるソフトを追加(一時フォルダのFmod_Android_Createにあります。)<br>
↑の使用方法はGithubのFmod_Android_Createを参照してください。<br>
・細かなバグを修正<br>
・一部仕様を変更<br>
V1.2.4変更点<br>
・音楽プレイヤーで出力デバイスを指定できるように操作を追加<br>
・一時フォルダの位置を変更していた場合音声をロード、セーブ、作成ができなかった問題を修正<br>
・その他軽度なバグを修正<br>
・一部仕様を変更<br>
V1.2.3変更点<br>
・ソフト内で作成したBGMModがDVPL化されていた場合BGMModとして公開できなかった問題を修正<br>
・Mod配布者自身が公開したModは編集できるように変更(削除、ファイル追加など)<br>
V1.2.2変更点<br>
・一部の環境で音声が作成されない問題を修正(Thanks to Yurina_Taki!!!)<br>
・パスに日本語が含まれている場合dvplを解除できない問題を修正<br>
・このソフトのアンインストールをソフト内でできるように(ホーム画面でShift + Escキーを押すとメッセージが出ます)<br>
・一時ファイル(キャッシュファイルを含む)のフォルダ場所を指定できるように変更(ホーム画面でShift + Dキーを押すとメッセージが出ます)<br>
・いるかわかりませんが、音楽プレイヤーでバックグラウンド再生できるように変更<br>
・謎のチャット機能を解放(V1.0から既に存在していましたが細かい調整のため非公開でした)<br>
・細かな調整<br>
V1.2.1変更点<br>
・軽度なバグを修正<br>
・一部仕様を変更<br>
・不必要なライブラリを削除<br>
V1.2変更点<br>
・致命的なバグを修正<br>
(戦闘中にクラッシュ、FEV+FSBファイルが作成されない場合があるなどを修正)<br>
・アップデートをソフト内でできるように(サーバーに接続&ログインする必要あり)<br>
V1.1変更点<br>
・WoTBのインストール場所がSteamのインストール場所と同じだった場合フォルダを取得できない問題を修正(Thanks to yurina_taki)<br>
・サーバー機能を一部開放し、ログインすればだれでもModの配布、ダウンロードを行うことができるように<br>
・サーバー容量は1TBです。不必要なファイルのアップロードはおやめください。<br>
<br>
---using Library---<br>
BASS.ASIO.1.3.1.2<br>
BASS.Native.2.4.12.2<br>
Bass.NetWrapper.2.4.12.5<br>
Costura.Fody.4.1.0<br>
FluentFTP.33.0.3<br>
Fody.6.3.0<br>
Obfuscar.2.2.28<br>
SimpleTCP.1.0.24<br>
K4os.Compression.LZ4.1.2.6<br>
Crc32.NET.1.2.0<br>
System.Buffers.4.5.1<br>
System.Memory.4.5.4<br>
System.Runtime.CompilerServices.Unsafe.5.0.0<br>
Cauldron.FMOD(V1.1から導入)
