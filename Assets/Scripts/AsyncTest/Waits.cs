using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Waits : MonoBehaviour
{
    private int _taskCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        TaskLoop();

        Print<int>(50);
    }

    void Print<T>(T input)
    {
        print(input);
    }

    private async void TaskLoop()
    {
        while (true)
        {
            await Task.Delay(1000);
            _taskCounter++;
            print(_taskCounter);
        }
    }

    private async void AwaiableLoop()
    {
        while (true)
        {
            
            //await Awaitable
        }
    }

}
