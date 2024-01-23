using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("无限地图")]
    public GameObject mainCamera;//主摄像机对象
    public float mapWidth;//地图宽度
    public float mapNums;//地图重复的次数

    private float totalWidth;//总地图宽度

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");//查找标签为“MainCamera”的对象并赋值
        mapWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;//通过SpriteRendererh获得图像宽度
        totalWidth = mapWidth * mapNums;//计算总地图宽度
    }

    private void Update()
    {
        Vector3 tempPosition = transform.position;//获取当前位置
        if(mainCamera.transform.position.x > transform.position.x + totalWidth/2)
        {
            tempPosition.x += totalWidth;//将地图向右平移一个完整的地图宽度
            transform.position = tempPosition;//更新位置
        }
        else if(mainCamera.transform.position.x < transform.position.x - totalWidth/2)
        {
            tempPosition.x -= totalWidth;//将地图向左平移一个完整地图的宽度
            transform.position = tempPosition;//更新位置
        }
    }

}
