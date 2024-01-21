using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

public class ExportMap : EditorWindow
{
    //关卡路径，关卡前缀，关卡数
    public static string levelNum = "1";
    public static string prefix = "map";
    public static string writePath = "/AssetsPackage/Datas/Map/";

    [MenuItem("mapEditor/ExportMap")]
    private static void ShowWindow()
    {
        var window = GetWindow <ExportMap>();
        window.titleContent = new GUIContent("ExportMap");
        window.Show();

    }

    private void OnGUI()
    {
        GUILayout.Label("选择地图根节点");
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            GUILayout.Label(Selection.activeGameObject.name);
        else
            GUILayout.Label("没有选中的地图节点，无法生成");

        GUILayout.Label("\n输出路径");
        writePath = GUILayout.TextField (writePath);
        GUILayout.Label("地图文件前缀");
        prefix = GUILayout.TextField(prefix);
        GUILayout.Label("设置关卡数（1~N）");
        levelNum = GUILayout.TextField(levelNum);

        string fileName = writePath + prefix + levelNum + ".csv";
        GUILayout.Label(fileName + "\n");

        if(GUILayout.Button("生成地图文件"))
        {
            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("正在生成地图文件....");
                ExportMapUtil.ExportMapToFile(Selection.activeGameObject, fileName);
                Debug.Log("生成地图文件成功");
            }
        }
        if(GUILayout.Button("清理地图"))
        {
            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("正在清理地图....");
                ClearMapUtil.clearMapRoot(Selection.activeGameObject);
                //使用代码来保存场景
                EditorApplication.SaveScene(EditorApplication.currentScene);
                Debug.Log("清理地图成功!!");
            }
        }
    }

    private void OnSelectionChange()
    {
        //重载该函数，实时显示选中的物体
        this.Repaint();
    }
}
