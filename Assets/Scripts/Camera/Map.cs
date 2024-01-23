using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("���޵�ͼ")]
    public GameObject mainCamera;//�����������
    public float mapWidth;//��ͼ���
    public float mapNums;//��ͼ�ظ��Ĵ���

    private float totalWidth;//�ܵ�ͼ���

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");//���ұ�ǩΪ��MainCamera���Ķ��󲢸�ֵ
        mapWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;//ͨ��SpriteRendererh���ͼ����
        totalWidth = mapWidth * mapNums;//�����ܵ�ͼ���
    }

    private void Update()
    {
        Vector3 tempPosition = transform.position;//��ȡ��ǰλ��
        if(mainCamera.transform.position.x > transform.position.x + totalWidth/2)
        {
            tempPosition.x += totalWidth;//����ͼ����ƽ��һ�������ĵ�ͼ���
            transform.position = tempPosition;//����λ��
        }
        else if(mainCamera.transform.position.x < transform.position.x - totalWidth/2)
        {
            tempPosition.x -= totalWidth;//����ͼ����ƽ��һ��������ͼ�Ŀ��
            transform.position = tempPosition;//����λ��
        }
    }

}
