using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

public class ExportMap : EditorWindow
{
    //�ؿ�·�����ؿ�ǰ׺���ؿ���
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
        GUILayout.Label("ѡ���ͼ���ڵ�");
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            GUILayout.Label(Selection.activeGameObject.name);
        else
            GUILayout.Label("û��ѡ�еĵ�ͼ�ڵ㣬�޷�����");

        GUILayout.Label("\n���·��");
        writePath = GUILayout.TextField (writePath);
        GUILayout.Label("��ͼ�ļ�ǰ׺");
        prefix = GUILayout.TextField(prefix);
        GUILayout.Label("���ùؿ�����1~N��");
        levelNum = GUILayout.TextField(levelNum);

        string fileName = writePath + prefix + levelNum + ".csv";
        GUILayout.Label(fileName + "\n");

        if(GUILayout.Button("���ɵ�ͼ�ļ�"))
        {
            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("�������ɵ�ͼ�ļ�....");
                ExportMapUtil.ExportMapToFile(Selection.activeGameObject, fileName);
                Debug.Log("���ɵ�ͼ�ļ��ɹ�");
            }
        }
        if(GUILayout.Button("�����ͼ"))
        {
            if(Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MapEditorRoot>() != null)
            {
                Debug.Log("���������ͼ....");
                ClearMapUtil.clearMapRoot(Selection.activeGameObject);
                //ʹ�ô��������泡��
                EditorApplication.SaveScene(EditorApplication.currentScene);
                Debug.Log("�����ͼ�ɹ�!!");
            }
        }
    }

    private void OnSelectionChange()
    {
        //���ظú�����ʵʱ��ʾѡ�е�����
        this.Repaint();
    }
}
