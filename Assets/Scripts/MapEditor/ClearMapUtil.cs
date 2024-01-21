using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ClearMapUtil 
{
    public static void clearMapRoot(GameObject mapRoot)
    {
        int count = mapRoot.transform.childCount;
        for(int i = 0; i < count; i++)
        {
            GameObject item = mapRoot.transform.GetChild(i).gameObject;
            GameObject.DestroyImmediate(item);
        }
    }
}
