using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImportMap : EditorWindow
{
    //关卡路径，关卡前缀，关卡数
    public static string levelNum = "1";
    public static string prefix = "map";
    public static string writePath = "/AssetsPackage/Datas/Map/";

    [MenuItem("mapEditor/ImportMap")]
    private static void ShowWindow()
    {
        var window = GetWindow<ImportMap>();
        window.titleContent = new GUIContent("ImportMap");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("选择地图根节点");
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            GUILayout.Label(Selection.activeGameObject.name);
        else
            GUILayout.Label("没有选中的地图节点，无法生成");

        GUILayout.Label("\n导入路径");
        writePath = GUILayout.TextField(writePath);
        GUILayout.Label("地图文件前缀");
        prefix = GUILayout.TextField(prefix);
        GUILayout.Label("关卡数字（1~N）");
        levelNum = GUILayout.TextField(levelNum);

        string fileName = writePath + prefix + levelNum + ".csv";
        GUILayout.Label(fileName + "\n");

        if (GUILayout.Button("导入地图数据"))
        {
            if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("导入地图数据生成关卡...." + fileName);
                ImportMapUtil.ImportMapDataToMapRoot(Selection.activeGameObject);
                Debug.Log("导入地图数据成功!!");
            }
        }
    }

    private void OnSelectionChange()
    {
        //重载该函数，实时显示选中的物体
        this.Repaint();
    }
}
