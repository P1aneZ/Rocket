using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    //加载请求事件，调用的时候需要传这三个类型的参数↓
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    //把调用该事件封装成一个函数，让别的脚本通过SO文件广播
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo,bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, posToGo, fadeScreen);
    }

}
