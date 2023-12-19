using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public float pointerMoveSpeed = 1f;
    [SerializeField] Text levelText;
    [SerializeField] Transform pointer, sweetSpot;
    [SerializeField] Transform startPos, endPos;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        pointer.position += Vector3.right * pointerMoveSpeed * Time.deltaTime;

        if (pointer.position.x > endPos.position.x)
            ResetPointer();
    }

    private void ResetPointer()
    {
        pointer.position = startPos.position;

        GameManager.Instance.PointerIsReset();
    }

    public void ShowOrHidePointer()
    {
        pointer.gameObject.SetActive(!pointer.gameObject.activeInHierarchy);
    }

    public bool CheckPointerIsInSweetSpot()
    {
        return MathF.Abs(pointer.position.x - sweetSpot.position.x) < 28;
    }

    public void RenewLevelText(int level)
    {
        levelText.text = "LEVEL " + level;
    }
}
