using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    //��ҵ�����
    public Transform playerTrans;
    //��һ��ȥ��λ��
    public Vector3 firstPosition;
    //�˵�ҳ�棬���Ӧ��������
    public Vector3 menuPosition;

    [Header("�¼�����")]
    //�������������¼���ע���Ӧ����
    public SceneLoadEventSO loadEventSO;

    //�����������ʼ��Ϸ���¼�
    public VoidEventSO gameStartEvent;
    //������������á��¼�
    public VoidEventSO toSettingEvent;
    //����������˳���Ϸ���¼�
    public VoidEventSO gameEndEvent;
    //����������������˵����¼�
    public VoidEventSO backToMenuEvent;
    //����������ؿ�һ���¼�
    public VoidEventSO LevelOne;

    [Header("�¼��㲥")]
    //�㲥���뵭�����¼�
    public FadeEventSO fadeEvent;
    //�㲥������������¼�
    public VoidEventSO afterSceneLoadedEvent;
    //�㲥��ʼ��Ϸ
    public VoidEventSO beginPlayGame;

    [Header("����")]
    //�˵�����
    public GameSceneSO menuScene;
    //�ؿ�ѡ�����
    public GameSceneSO levelSelectScene;
    //���ý���
    public GameSceneSO settingScene;
    //��һ�س���
    public GameSceneSO levelOneScene;

    //��ǰ�ĳ���
    private GameSceneSO currentLoadedScene;

    //������ʱ���������¼�����ʱ��������ֵ
    private GameSceneSO sceneToLoad;
    private Vector3 positionToGo;
    private bool fadeScreen;

    [Header("���뵭��")]
    //���뵭���ĳ���ʱ��
    public float fadeDuration;
    //�ж������ǲ����ڼ�����
    private bool isLoading;

    private void Awake()
    {
        //��ǰ�ĳ������ǵ�һ�����صĳ���
        currentLoadedScene = menuScene;
        //���õ���ģʽ���첽���ص�һ������
        currentLoadedScene.sceneReference.LoadSceneAsync (LoadSceneMode.Additive);
    }

    private void Start()
    {
        //loadEventSO.RaiseLoadRequestEvent(menuScene, menuPosition, true); 
    }

    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;

        //��ť
        gameStartEvent.OnEventRaised += GameStart;
        backToMenuEvent.OnEventRaised += BackToMenu;
        LevelOne.OnEventRaised += ToLevelOne;
        toSettingEvent.OnEventRaised += ToSetting;
        gameEndEvent.OnEventRaised += ExitGame;
    }

    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
        
        //��ť
        gameStartEvent.OnEventRaised -= GameStart;
        backToMenuEvent.OnEventRaised -= BackToMenu;
        LevelOne.OnEventRaised -= ToLevelOne;
        toSettingEvent.OnEventRaised += ToSetting;
        gameEndEvent.OnEventRaised += ExitGame;
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
        yield return new WaitForSeconds(fadeDuration); 
        
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
        
        //�����ǰ�������ǲ˵�
        if(currentLoadedScene.sceneType != SceneType.Menu)
        {
            //�㲥
            afterSceneLoadedEvent.RaiseEvent();
        }
    }

    private void GameStart()
    {
        sceneToLoad = levelSelectScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, menuPosition, true);
    }

    private void BackToMenu()
    {
        sceneToLoad = menuScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, menuPosition, true);
    }

    private void ToLevelOne()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, firstPosition, true);
        beginPlayGame.RaiseEvent();
    }

    private void ToSetting()
    {
        sceneToLoad = settingScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, firstPosition, true);
    }

    private void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
