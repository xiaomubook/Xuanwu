using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] Sprite[] arrowSprites;
    [SerializeField] Image _img;

    public int arrowDir;
    public Color finishColor;



    public void Setup(int dir)
    {
        arrowDir = dir;

        _img.sprite = arrowSprites[dir];
        _img.SetNativeSize();
    }

    public void SetFinish()
    {
        _img.color = finishColor;
    }

}
