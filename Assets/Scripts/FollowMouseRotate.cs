using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotate : MonoBehaviour
{
    private RocketMove rocketMove;
    public float mouseX;
    public float sensitivity; // ���������
                              // Start is called before the first frame update

    private void Awake()
    {
        rocketMove = GetComponent<RocketMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity;//������ȡ����ƶ�ˮƽ����
            mouseX = Mathf.Clamp(mouseX, -1, 1);//��ˮƽ������С�޶���-1��1֮��
            if(mouseX > 0)
            {
                rocketMove.rb.AddForce(transform.right * rocketMove.pushForce, ForceMode2D.Impulse);
            }
            if (mouseX < 0)
            {
                rocketMove.rb.AddForce(-transform.right * rocketMove.pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
