using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Game Scene/GameSceneSO")]
public class GameSceneSO: ScriptableObject
{
    //场景类型（游戏地图/菜单）
    public SceneType sceneType;
    //引用的场景资源
    public AssetReference sceneReference;
}
