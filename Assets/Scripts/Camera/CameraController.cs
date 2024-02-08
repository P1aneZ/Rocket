using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;//玩家的位置
    public Transform farBackground/*, middleBackground*/;//远景和中景的位置
    private Vector2 lastPos;//最后一次的相机位置

    private void Start()
    {
        lastPos = transform.position;//记录相机的初始位置
    }

    private void Update()
    {
        //将相机的位置设置为玩家的位置，但限制在一定的垂直范围内
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //计算相机在上一帧与当前帧之间移动的距离
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        //根据相机移动的距离，移动远景和中景的位置
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        //middleBackground.position += new Vector3(amountToMove.x * 0.5f, amountToMove.y * 0.5f, 0f);

        lastPos = transform.position;//保证lastPos的位置每帧刷新
    }
}
