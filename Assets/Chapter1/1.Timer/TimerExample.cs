using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimerExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(5.0f)) //到达指定事件戳后执行订阅事件
            .Subscribe(_ =>
            {
                Debug.Log("do sth");
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
