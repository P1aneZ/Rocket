using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Game Scene/GameSceneSO")]
public class GameSceneSO: ScriptableObject
{
    //�������ͣ���Ϸ��ͼ/�˵���
    public SceneType sceneType;
    //���õĳ�����Դ
    public AssetReference sceneReference;
}
