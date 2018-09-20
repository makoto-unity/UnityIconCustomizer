# Unity Icon Customizer
このプロジェクト内のEditorスクリプトを利用すればiOS用のアイコンを自動生成できます。
バージョン番号や、"ベータ"のリボン等を自由にカスタマイズができます。

![UnityIconCustomizer](https://github.com/makoto-unity/Pics/blob/master/UnityIconCustomizer/IconScreenShot2.png?raw=true)

# 環境
- Unity 
- iOS (Android は開発中)
- Unity Cloud Buildでも利用可能です

## 概要

アイコンを自動生成します。
元の画像がUnityのPrefabでできており、それをカメラに写した画像を RenderTexture で取得してpngで保存しています。
元がPrefabでなので、自由にカスタマイズすることが可能です。

例えば普通にビルドすると、そのバージョンがリリースなのかベータなのか分からなくなるのではないでしょうか。
そういう時は、このEditorスクリプトでBETA デファインシンボルがある時は "BETA" のリボンをつける等すれば区別がつきやすいでしょう。

## 使い方

1. プロジェクト内の IconGenSystem.prefab プレファブをカスタマイズして、Applyします。
2. IconBuilder.cs に お好みの Define symbols (BETAとか) で修正します
3. IconBuilder.GenerateIconForIOS() スクリプトを呼び出します。または Unity エディタのメニューから MyApp/GenerateIconForIOS を選択します。
4. 自動的にiOSアイコンが設定されます。
