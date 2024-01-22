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
    [Header("事件监听")]
    //监听场景加载事件，注册对应函数
    public SceneLoadEventSO loadEventSO;

    [Header("事件广播")]
    //广播淡入淡出的事件
    public FadeEventSO fadeEvent;

    //第一个加载的场景
    public GameSceneSO firstLoadScene;
    //当前的场景
    public GameSceneSO currentLoadedScene;
    //玩家的坐标
    public Transform playerTrans;

    //创建临时变量保存事件监听时传进来的值
    private GameSceneSO sceneToLoad;
    private Vector3 positionToGo;
    private bool fadeScreen;

    //淡入淡出的持续时间
    public float fadeDuration;
    //判断现在是不是在加载中
    private bool isLoading;

    private void Awake()
    {
        //当前的场景就是第一个加载的场景
        currentLoadedScene = firstLoadScene;
        //采用叠加模式，异步加载第一个场景
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

    //当监听到场景加载请求的时候，执行该函数
    private void OnLoadRequestEvent(GameSceneSO locationToLoad,Vector3 posToGo,bool fadeScreen)
    {
        //如果正在加载就不执行下面的了
        if (isLoading)
            return;

        //标记为正在加载
        isLoading = true;

        //保存传进来的值
        sceneToLoad = locationToLoad;
        positionToGo = posToGo;
        this.fadeScreen = fadeScreen;

        //如果当前有场景，调用携程
        if (currentLoadedScene != null)
            StartCoroutine(UnLoadPreviousScene());
    }

    private IEnumerator UnLoadPreviousScene()
    {
        if(fadeScreen)
        {
            //变黑
            fadeEvent.FadeIn(fadeDuration);
        }

        //等淡入淡出完成后再执行下一步
        yield return new WaitForSeconds(fadeDuration); ;
        
        //卸载当前场景
        yield return currentLoadedScene.sceneReference.UnLoadScene(); 

        //卸载完场景之后关掉人物
        playerTrans.gameObject.SetActive(false);

        //卸载完成之后就加载新场景
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        //加载新场景，用var存住返回值
        var loadingOption = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        //注册 完成加载后，要执行的函数 到该事件
        loadingOption.Completed += OnLoadCompleted;
    }

    ///场景加载完成后
    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> handle)
    {
        //更换当前场景
        currentLoadedScene = sceneToLoad;
        //更改玩家的坐标
        playerTrans.position = positionToGo;
        //加载完场景之后开启人物
        playerTrans.gameObject.SetActive(true);

        //完成淡入淡出
        if (fadeScreen)
        {
            //变透明
            fadeEvent.FadeOut(fadeDuration);
        }

        //标记为加载结束
        isLoading = false;  
    }
}
