using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int currentLevel = 4;
    public bool isDancing;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        NextWave();
    }

    public void NextWave()
    {
        UIManager.Instance.RenewLevelText(currentLevel);
        UIManager.Instance.ShowOrHidePointer();
        ArrowManager.Instance.CreateWave(currentLevel);
        isDancing = true;
    }

    public void FinishWave()
    {
        currentLevel++;
        isDancing = false;
       
        ArrowManager.Instance.ClearWave();
        UIManager.Instance.ShowOrHidePointer();

    }

    public void FailWave()
    {
        isDancing = false;
       
        ArrowManager.Instance.ClearWave();
        UIManager.Instance.ShowOrHidePointer();
    }

    public void PointerIsReset()
    {
        if (isDancing)
            FailWave();
        else
            NextWave();
    }
}
