using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowsHolder;
    public static bool isFinish;


    Queue<Arrow> arrows = new Queue<Arrow>();
    Arrow currentArrow;

    private void Awake()
    {
        Instance = this;
    }

    public void CreateWave(int length)
    {
        arrows = new Queue<Arrow>();
        isFinish = false;

        for (int i = 0; i < length; i++)
        {
            Arrow arrow = Instantiate(arrowPrefab, arrowsHolder).GetComponent<Arrow>();

            int randomDir = Random.Range(0, 4);

            arrow.Setup(randomDir);

            arrows.Enqueue(arrow);
        }

        currentArrow = arrows.Dequeue();
    }

    public void ClearWave()
    {
        arrows = new Queue<Arrow>();
        foreach (Transform arrow in arrowsHolder)
        {
            Destroy(arrow.gameObject);
        }

    }

    public void TypeArrow(KeyCode inputKey)
    {
        if (ConvertKeyCodeToInt(inputKey) == currentArrow.arrowDir)
        {
            currentArrow.SetFinish();

            if (arrows.Count > 0)
            {
                currentArrow = arrows.Dequeue();
            }else
            {
                isFinish = true;
            }
        }else
        {
            GameManager.Instance.FailWave();
        }
    }

    int ConvertKeyCodeToInt(KeyCode key)
    {
        int result = -1;

        switch (key)
        {
            case KeyCode.UpArrow:
                result = 0;
                break;

            case KeyCode.DownArrow:
                result = 1;
                break;

            case KeyCode.LeftArrow:
                result = 2;
                break;

            case KeyCode.RightArrow:
                result = 3;
                break;
        }

        return result;
    }

}
