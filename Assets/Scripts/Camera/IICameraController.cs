using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IICameraController : MonoBehaviour
{
    [Header("�¼�����")]
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
        Destroy(this);
    }
}
