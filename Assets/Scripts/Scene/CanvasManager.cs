using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO gameStartEvent;

    private void OnEnable()
    {
        gameStartEvent.OnEventRaised += GameStart;
    }

    private void OnDisable()
    {
        gameStartEvent.OnEventRaised -= GameStart;
    }

    private void GameStart()
    {
        Destroy(this.gameObject);
    }
}
