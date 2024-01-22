using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    //���������¼������õ�ʱ����Ҫ�����������͵Ĳ�����
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    //�ѵ��ø��¼���װ��һ���������ñ�Ľű�ͨ��SO�ļ��㲥
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo,bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, posToGo, fadeScreen);
    }

}
