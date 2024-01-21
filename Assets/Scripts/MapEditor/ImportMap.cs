using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImportMap : EditorWindow
{
    //�ؿ�·�����ؿ�ǰ׺���ؿ���
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
        GUILayout.Label("ѡ���ͼ���ڵ�");
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            GUILayout.Label(Selection.activeGameObject.name);
        else
            GUILayout.Label("û��ѡ�еĵ�ͼ�ڵ㣬�޷�����");

        GUILayout.Label("\n����·��");
        writePath = GUILayout.TextField(writePath);
        GUILayout.Label("��ͼ�ļ�ǰ׺");
        prefix = GUILayout.TextField(prefix);
        GUILayout.Label("�ؿ����֣�1~N��");
        levelNum = GUILayout.TextField(levelNum);

        string fileName = writePath + prefix + levelNum + ".csv";
        GUILayout.Label(fileName + "\n");

        if (GUILayout.Button("�����ͼ����"))
        {
            if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("�����ͼ�������ɹؿ�...." + fileName);
                ImportMapUtil.ImportMapDataToMapRoot(Selection.activeGameObject);
                Debug.Log("�����ͼ���ݳɹ�!!");
            }
        }
    }

    private void OnSelectionChange()
    {
        //���ظú�����ʵʱ��ʾѡ�е�����
        this.Repaint();
    }
}
