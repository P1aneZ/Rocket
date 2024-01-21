using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Rendering;

public class ExportMapUtil 
{
    public static void ExportMapToFile (GameObject mapRoot,string filename)
    {
        //��һ���ļ�
        StreamWriter sw = new StreamWriter(Application.dataPath + filename);
        //д���ļ�����

        //�ļ�ͷ
        sw.WriteLine("���,��Ӧ��Դ���,λ��,����,�Ƕ�");
        sw.WriteLine("number,string,string,string,string");
        sw.WriteLine("ID,name,position,scale,eul");
        
        //����mapNode����ĺ���
        for(int i = 0; i < mapRoot.transform.childCount; i++)
        {
            GameObject mapItem = mapRoot.transform.GetChild(i).gameObject;

            string name = mapItem.name;
            Vector3 position = mapItem.transform.localPosition;
            Vector3 scale = mapItem.transform.localScale;
            Vector3 eulerAngles = mapItem.transform.localEulerAngles;

            string pos = _getNumberToFixed2(position);
            string s = _getNumberToFixed2(scale);
            string eul = _getNumberToFixed2(eulerAngles);

            string lineData = String.Format("{0},{1},\"{2}\",\"{3}\",\"{4}\"", i + 1, name, pos, s, eul);
            sw.WriteLine(lineData);
        }

        //�ر�һ���ļ�
        sw.Flush();
        sw.Close();
        //ˢ��AssetDatabase�����ܿ���ʶ��
        AssetDatabase.Refresh();
    }

    private static string _getNumberToFixed2(Vector3 data)
    {
        //������λС��
        string str = String.Format("{0:F},{1:F},{2:F}", data.x, data.y, data.z);
        return str;
    }
}
