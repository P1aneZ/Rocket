using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotate : MonoBehaviour
{
    public float mouseX;
    public float sensitivity; // 鼠标灵敏度
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity;//持续获取鼠标移动水平分量
            mouseX = Mathf.Clamp(mouseX, -1, 1);//将水平分量大小限定在-1到1之间
            transform.Rotate(0, 0, -mouseX);//绕z轴旋转
        }
    }
}
