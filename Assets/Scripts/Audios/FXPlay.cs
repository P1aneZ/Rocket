using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FXPlay : MonoBehaviour
{
    [Header("ÊÂ¼þ¹ã²¥")]
    public VoidEventSO ClickDown;
    public VoidEventSO Pass;
    public VoidEventSO Fail;

    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "PassScene")
            Pass.RaiseEvent();
        if (SceneManager.GetActiveScene().name == "FailScene")
            Fail.RaiseEvent();
    }

    public void PlayClick()
    {
        ClickDown.RaiseEvent();
    }
}
