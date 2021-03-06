using UnityEngine;
using System.Collections;
using UnityEditor;

public class BatchBuild {

     // ビルド対象のシーン
    private static string[] scene = {"Assets/Scene/Sample.unity"};
    // keystore Path
    private static string keystorePath = "batch_build/Android/test.keystore";
    // keystoreのパスワードはUnityEditorで設定できるが保持されないのでここに記述
    private static string keystorePass = "k9yRMKR6e7933b6";
    private static string keyaliasPass = "k9yRMKR6e7933b6";

//    private static string[] GetScenes() {
//        ArrayList levels = new ArrayList();

//        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
//            if (scene.enabled) {
//                levels.Add(scene.path);
//            }
//        }
//        return (string[]) levels.ToArray(typeof(string));
//    }

    // リリースビルド
    public static void ReleaseBuild() {
//        if ( BuildiOS(true) == false ) EditorApplication.Exit(1);
        if ( BuildAndroid(true) == false ) EditorApplication.Exit(1);
        EditorApplication.Exit(0);
    }

    // 開発用ビルド
    public static void DevelopmentBuild() {
        Debug.Log("DevelopmentBuild");
//        if ( BuildiOS(false) == false ) EditorApplication.Exit(1);
        if ( BuildAndroid(false) == false ) EditorApplication.Exit(1);
        EditorApplication.Exit(0);
    }

    // iOSビルド
//    private static bool BuildiOS(bool release) {
//        Debug.Log("Start Build( iOS )");

//        BuildOptions opt = BuildOptions.SymlinkLibraries;
//        // 開発用ビルドの場合のオプション設定
//        if ( release == false ) {
//            opt |= BuildOptions.Development | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
//        }

        // ビルド
        // シーン、出力ファイル（フォルダ）、ターゲット、オプションを指定
//        string errorMsg =
//            BuildPipeline.BuildPlayer(scene, "ios", BuildTarget.iPhone, opt);

        // errorMsgがない場合は成功
//        if ( string.IsNullOrEmpty(errorMsg) ) {
//            Debug.Log("Build( iOS ) Success.");
//            return true;
//        }
//        Debug.Log("Build( iOS ) ERROR!");
//        Debug.LogError(errorMsg);
//        return false;
//    }

    // Androidビルド
    private static bool BuildAndroid(bool release) {
        Debug.Log("Start Build( Android )");

        BuildOptions opt = BuildOptions.None;
        // 開発用ビルドの場合のオプション設定
        if ( release == false ) {
            opt |= BuildOptions.Development | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
        }
        // keystoreファイルのの場所を設定
        string keystoreName =
            System.IO.Directory.GetCurrentDirectory() + "/" + keystorePath;
        // set keystoreName
        PlayerSettings.Android.keystoreName = keystoreName;
        // パスワードの再設定
        PlayerSettings.Android.keystorePass = keystorePass;
        // パスワードの再設定
        PlayerSettings.Android.keyaliasPass = keyaliasPass;

        // ビルド
        // シーン、出力ファイル（フォルダ）、ターゲット、オプションを指定
        string errorMsg =
            BuildPipeline.BuildPlayer(scene, "test.apk", BuildTarget.Android, opt);
        // errorMsgがない場合は成功
        if ( string.IsNullOrEmpty(errorMsg) ) {
            Debug.Log("Build( Android ) Success.");
            return true;
        }
        Debug.Log("Build( Android ) ERROR!");
        Debug.LogError(errorMsg);
        return false;
    }
}