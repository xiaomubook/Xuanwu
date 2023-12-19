using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;

public class UniRxLesson : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] Toggle toggle;
    [SerializeField] Image img;
    public ReactiveProperty<int> Age = new ReactiveProperty<int>();

    private void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .First()
            .Subscribe(_ => print("mouse down"))
            .AddTo(this);

        btn.OnClickAsObservable()
            .Subscribe(_ => { print("btn clicked..."); })
            .AddTo(this);
        toggle.OnValueChangedAsObservable()
            .Where(isOn => isOn)
            .Subscribe(_ => print("toggle isOn"))
            .AddTo(this);

        img.OnBeginDragAsObservable().Subscribe(_ => { });
        img.OnDragAsObservable().Subscribe(eventArga => { img.transform.position = eventArga.position; });


        Age.Subscribe(age =>
        {
            print("age changed...");
        });




    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Age.Value++;
        }
    }
}
