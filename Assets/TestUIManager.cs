using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TestUIManager : MonoBehaviour
{
    [SerializeField] Transform targetTrans;
    [SerializeField] Image img;
    // Start is called before the first frame update
    void Start()
    {
        print(targetTrans.position);
    }

    Tweener tweener = null;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tweener != null)
                tweener.Kill();
            tweener = img.transform.DOMove(targetTrans.position,1f).SetEase(Ease.OutSine).SetLoops(-1,LoopType.Yoyo);
        }
    }
}
