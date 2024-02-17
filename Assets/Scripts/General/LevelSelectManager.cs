using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    //�ƹܰ�ť�ĸ�����
    public GameObject levelSelect;
    //ÿ����ť������
    Button[] levelSelectButtons;
    //�����Ĺؿ���
    int unlockedLevelIndex;

    private void Start()
    {
        //��ȡ�����Ĺؿ���
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevel");
        //���������м����ؿ����Ϳ�����������
        levelSelectButtons = new Button[levelSelect.transform.childCount];
        //�Ѹ������µĹؿ���ť����ֵ����������
        for(int i = 0; i < levelSelect.transform.childCount ; i++)
        {
            levelSelectButtons[i] = levelSelect.transform.GetChild(i).GetComponent<Button>();
            //Debug.Log(i);
        }

        //���������ؿ���ť��������Ϊ���ɽ���
        for (int i = 0;i < levelSelectButtons.Length ; i++)
        {
            levelSelectButtons[i].interactable = false;
        }

        //�����ѽ����ؿ���ť������Ϊ�ɽ���
        for (int i = 0; i < unlockedLevelIndex + 1 ; i++)
        {
            levelSelectButtons[i].interactable = true;
        }
    }

}
