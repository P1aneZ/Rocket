using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;//��ҵ�λ��
    public Transform farBackground/*, middleBackground*/;//Զ�����о���λ��
    private Vector2 lastPos;//���һ�ε����λ��

    private void Start()
    {
        lastPos = transform.position;//��¼����ĳ�ʼλ��
    }

    private void Update()
    {
        //�������λ������Ϊ��ҵ�λ�ã���������һ���Ĵ�ֱ��Χ��
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //�����������һ֡�뵱ǰ֮֡���ƶ��ľ���
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        //��������ƶ��ľ��룬�ƶ�Զ�����о���λ��
        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        //middleBackground.position += new Vector3(amountToMove.x * 0.5f, amountToMove.y * 0.5f, 0f);

        lastPos = transform.position;//��֤lastPos��λ��ÿ֡ˢ��
    }
}
