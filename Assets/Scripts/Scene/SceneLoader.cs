using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using Unity.VisualScripting;
using UnityEngine.tvOS;

public class SceneLoader : MonoBehaviour
{
    //��ҵ�����
    public Transform playerTrans;

    //�ؿ��Ƿ�ͨ��
    public RocketLand rocketLand;
    //��ǰ���ڵĹؿ���
    public int levelNum = 0;

    //������
    public Vector3 birthPosition;
    //�˵�ҳ�棬���Ӧ��������
    public Vector3 menuPosition;
    //��һ��ȥ��λ��
    public Vector3 firstPosition;
    //�ڶ���ȥ��λ��
    public Vector3 secondPosition;
    //������ȥ��λ��
    public Vector3 thirdPosition;
    //���ĸ�ȥ��λ��
    public Vector3 fouthPosition;
    //�����ȥ��λ��
    public Vector3 fifthPosition;
    //������ȥ��λ��
    public Vector3 sixthPosition;
    //���߸�ȥ��λ��
    public Vector3 seventhPosition;
    //�ڰ˸�ȥ��λ��
    public Vector3 eigthPosition;
    //�ھŸ�ȥ��λ��
    public Vector3 ninthPosition;

    [Header("�¼�����")]
    //�������������¼���ע���Ӧ����
    public SceneLoadEventSO loadEventSO;
    //�������ؿ�ͨ���¼���

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

    //�����������һ�ؿ����¼�
    public VoidEventSO nextLevel;
    //������������¿�ʼ���¼�
    public VoidEventSO remake;

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
    //ͨ�ؽ���
    public GameSceneSO passScene;

    //��һ�س���
    public GameSceneSO levelOneScene;
    //�ڶ���
    public GameSceneSO levelTwoScene;

    //�ڰ˾Źس���
    public GameSceneSO levelEightScene;

    //��ǰ�ĳ���
    public GameSceneSO currentLoadedScene;

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

        nextLevel.OnEventRaised += ToNextLevel;
        remake.OnEventRaised += Remake;
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

        nextLevel.OnEventRaised -= ToNextLevel;
        remake.OnEventRaised -= Remake;
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

        //���ĳ�����
        birthPosition = posToGo;


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

        levelNum = 1;
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

    public void GamePass()
    {
        //ͣ�����ƣ�����ͨ�س���
        sceneToLoad = passScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, menuPosition, true);

        //��������ͨ���ж�
        rocketLand.isLand = false;
        rocketLand.landTime = 0;
    }

    private void Remake()
    {
        switch (levelNum)
        {
            case 1:
                ToLevelOne();
                break;
            case 2:
                ToLevelTwo();
                break;
            case 3:
                ToLevelThree();
                break;
            case 4:
                ToLevelFour();
                break;
            case 5:
                ToLevelFive();
                break;
            case 6:
                ToLevelSix();
                break;
            case 7:
                ToLevelSeven();
                break;
            case 8:
                ToLevelEight();
                break;
            case 9:
                ToLevelNine();
                break;
            default:
                break;
        }
    }

    private void ToNextLevel()
    {
        Debug.Log("ȥ��һ��");
        switch (levelNum)
        {
            case 1:
                ToLevelTwo();
                break;
            case 2:
                ToLevelThree();
                break;
            case 3:
                ToLevelFour();
                break;
            case 4:
                ToLevelFive();
                break;
            case 5:
                ToLevelSix();
                break;
            case 6:
                ToLevelSeven();
                break;
            case 7:
                ToLevelEight();
                break;
            case 8:
                ToLevelNine();
                break;
            case 9:
                ToLevelOne();
                break;
            default:
                break;
        }
    }

    private void ToLevelTwo()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, secondPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 2;
    }

    private void ToLevelThree()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, thirdPosition, true);
 
        levelNum = 3;
    }

    private void ToLevelFour()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, fouthPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 4;
    }

    private void ToLevelFive()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, fifthPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 5;
    }

    private void ToLevelSix()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, sixthPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 6;
    }

    private void ToLevelSeven()
    {
        sceneToLoad = levelOneScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, seventhPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 7;
    }

    private void ToLevelEight()
    {
        sceneToLoad = levelEightScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, eigthPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 8;
    }

    private void ToLevelNine()
    {
        sceneToLoad = levelEightScene;
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, ninthPosition, true);

        //��ǰ�ǵ�һ��
        levelNum = 9;
    }

}
