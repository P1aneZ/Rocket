using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class SceneLoader : MonoBehaviour
{
    [Header("�¼�����")]
    //�������������¼���ע���Ӧ����
    public SceneLoadEventSO loadEventSO;

    [Header("�¼��㲥")]
    //�㲥���뵭�����¼�
    public FadeEventSO fadeEvent;

    //��һ�����صĳ���
    public GameSceneSO firstLoadScene;
    //��ǰ�ĳ���
    public GameSceneSO currentLoadedScene;
    //��ҵ�����
    public Transform playerTrans;

    //������ʱ���������¼�����ʱ��������ֵ
    private GameSceneSO sceneToLoad;
    private Vector3 positionToGo;
    private bool fadeScreen;

    //���뵭���ĳ���ʱ��
    public float fadeDuration;
    //�ж������ǲ����ڼ�����
    private bool isLoading;

    private void Awake()
    {
        //��ǰ�ĳ������ǵ�һ�����صĳ���
        currentLoadedScene = firstLoadScene;
        //���õ���ģʽ���첽���ص�һ������
        currentLoadedScene.sceneReference.LoadSceneAsync (LoadSceneMode.Additive) ;
    }

    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
    }

    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }

    //���������������������ʱ��ִ�иú���
    private void OnLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo,bool fadeScreen)
    {
        //������ڼ��ؾͲ�ִ���������
        if (isLoading)
            return;

        //���Ϊ���ڼ���
        isLoading = true;

        //���洫������ֵ
        sceneToLoad = locationToLoad;
        positionToGo = posToGo;
        this.fadeScreen = fadeScreen;

        //�����ǰ�г���������Я��
        if (currentLoadedScene != null)
            StartCoroutine(UnLoadPreviousScene());
    }

    private IEnumerator UnLoadPreviousScene()
    {
        if(fadeScreen)
        {
            //���
            fadeEvent.FadeIn(fadeDuration);
        }

        //�ȵ��뵭����ɺ���ִ����һ��
        yield return new WaitForSeconds(fadeDuration); ;
        
        //ж�ص�ǰ����
        yield return currentLoadedScene.sceneReference.UnLoadScene(); 

        //ж���곡��֮��ص�����
        playerTrans.gameObject.SetActive(false);

        //ж�����֮��ͼ����³���
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        //�����³�������var��ס����ֵ
        var loadingOption = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        //ע�� ��ɼ��غ�Ҫִ�еĺ��� �����¼�
        loadingOption.Completed += OnLoadCompleted;
    }

    ///����������ɺ�
    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> handle)
    {
        //������ǰ����
        currentLoadedScene = sceneToLoad;
        //������ҵ�����
        playerTrans.position = positionToGo;
        //�����곡��֮��������
        playerTrans.gameObject.SetActive(true);

        //��ɵ��뵭��
        if (fadeScreen)
        {
            //��͸��
            fadeEvent.FadeOut(fadeDuration);
        }

        //���Ϊ���ؽ���
        isLoading = false;  
    }
}
