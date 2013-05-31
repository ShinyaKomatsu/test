#-----------------------------------------------------------------------------------------------
# Unityをバッチモードで起動し、xcodeプロジェクト,apkファイルを出力する
#-----------------------------------------------------------------------------------------------
# Unityアプリパス
UNITY_APP_PATH=/Applications/Unity/Unity.app/Contents/MacOS/Unity
# 対象のUnityプロジェクトパス
UNITY_PROJECT_PATH=$WORKSPACE/test
# バッチモードで起動後に呼び出すメソッド
UNITY_BATCH_EXECUTE_METHOD=BatchBuild.DevelopmentBuild
# Unity Editor ログファイルパス
UNITY_EDITOR_LOG_PATH=~/Library/Logs/Unity/Editor.log

# 指定のUnityプロジェクトをバッチモード起動させて、指定のメソッド(UnityScript)を呼び出す
$UNITY_APP_PATH -batchmode -quit -projectPath "${UNITY_PROJECT_PATH}" -executeMethod $UNITY_BATCH_EXECUTE_METHOD

# Unityでのbuildに失敗した場合は終了
if [ $? -eq 1 ]; then
cat $UNITY_EDITOR_LOG_PATH
exit 1
fi

# Unity Editorが出力したログを表示する
cat $UNITY_EDITOR_LOG_PATH

#--------------------------------
# apkファイル名の変更
#--------------------------------
APK_FILE_PATH=$WORKSPACE/test/test.apk
NEW_APK_FILE_PATH=$WORKSPACE/test/test-$BUILD_NUMBER-$BUILD_ID.apk

# ファイル名変更
mv $APK_FILE_PATH $NEW_APK_FILE_PATH