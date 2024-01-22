using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    //调用事件，场景加载
    public SceneLoadEventSO loadEventSO;
    //下一个要传送去的场景
    public GameSceneSO sceneToGo;
    //玩家下一个要去的坐标点（下一个场景的出生点）
    public Vector3 positionToGo;

    //当点击下一关的时候执行这个事件！
    public void TriggerAction()
    {
        Debug.Log("下一关！");

        loadEventSO.RaiseLoadRequestEvent(sceneToGo, positionToGo, true);
    }
}
