using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class IconBuilder
{
    const string tmpIconPath = "/UnityIconCustomizer/Generated/tmpIcon.png";
    const string iconPrefabPath = "Assets/UnityIconCustomizer/Res/IconGenSystem.prefab";

    private static void SetIcons(Texture2D originalIcon)
    {
        var group = BuildTargetGroup.iOS;
        int [] iconSizes = PlayerSettings.GetIconSizesForTargetGroup(group);
        Texture2D[] texture2Ds = new Texture2D[iconSizes.Length];

        for (var i = 0; i < iconSizes.Length; i++)
        {
            texture2Ds[i] = AssetDatabase.LoadAssetAtPath<Texture2D>( "Assets" + tmpIconPath);
        }

        PlayerSettings.SetIconsForTargetGroup(group, texture2Ds);
    }

    // デモ用のビルドを作る準備
    [UnityEditor.MenuItem("MyApp/GenerateIconForIOS")]
    public static void GenerateIconForIOS()
    {
        // Icon を生成。まずは元となるPrefabを読みこんでその中身を変える
        GameObject iconGenPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(iconPrefabPath);
        GameObject iconGen = Object.Instantiate(iconGenPrefab);
        Text[] texts = iconGen.GetComponentsInChildren<Text>();
        // バージョン番号
        string verStr = "Ver." + PlayerSettings.bundleVersion + "(" + PlayerSettings.iOS.buildNumber + ")";
        Debug.Log(verStr);
        texts[1].text = verStr;

        // RenderTexture に焼き込んだ画像をTexture2Dにする
        Camera camera = iconGen.GetComponentInChildren<Camera>();
        camera.Render();
        RenderTexture original = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        Texture2D newTexture = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        newTexture.ReadPixels(new Rect(0, 0, newTexture.width, newTexture.height), 0, 0);
        newTexture.Apply();

        // いったんオリジナルアイコンとしてpngとして吐く
        byte [] bytes = newTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + tmpIconPath, bytes);
        AssetDatabase.Refresh();
        Texture2D newIconImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets" + tmpIconPath);

        // できたTexture2Dをアイコンにセットする
        SetIcons(newIconImage);

        // 後片付け
        Object.DestroyImmediate(newTexture);
        Object.DestroyImmediate(iconGen);

        AssetDatabase.Refresh();
    }

}