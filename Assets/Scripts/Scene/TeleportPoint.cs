using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    //�����¼�����������
    public SceneLoadEventSO loadEventSO;
    //��һ��Ҫ����ȥ�ĳ���
    public GameSceneSO sceneToGo;
    //�����һ��Ҫȥ������㣨��һ�������ĳ����㣩
    public Vector3 positionToGo;

    //�������һ�ص�ʱ��ִ������¼���
    public void TriggerAction()
    {
        Debug.Log("��һ�أ�");

        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }
}
