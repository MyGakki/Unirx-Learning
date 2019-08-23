using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using System;

public class ThreadExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //开启一个线程
        var threadAStream = Observable.Start(()=>{
            Thread.Sleep(TimeSpan.FromSeconds(1f));
            return 10;
        });

        var threadBStream = Observable.Start(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(2f));
            return 10;
        });

        //两个线程都结束之后回到主线程，执行订阅
        Observable.WhenAll(threadAStream, threadBStream)
            .ObserveOnMainThread()
            .Subscribe(results =>
            {
                Debug.Log(results[0] + " " + results[1]);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
