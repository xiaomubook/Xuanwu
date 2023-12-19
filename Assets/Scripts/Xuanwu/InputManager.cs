using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if (!GameManager.Instance.isDancing)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            ArrowManager.Instance.TypeArrow(KeyCode.UpArrow);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            ArrowManager.Instance.TypeArrow(KeyCode.DownArrow);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ArrowManager.Instance.TypeArrow(KeyCode.LeftArrow);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            ArrowManager.Instance.TypeArrow(KeyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ArrowManager.isFinish&&UIManager.Instance.CheckPointerIsInSweetSpot())
            {
                GameManager.Instance.FinishWave();
            }else
            {
                GameManager.Instance.FailWave();
            }
        }
    }
}
