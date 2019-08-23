using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class WhenAllExample : MonoBehaviour
{

    IEnumerator CoroutineA()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("A");
    }

    IEnumerator CoroutineB()
    {
        yield return Observable.Timer(TimeSpan.FromSeconds(2.0f)).ToYieldInstruction();
        Debug.Log("B");
    }
    // Start is called before the first frame update
    void Start()
    {
        var aStream = Observable.FromCoroutine(_ => CoroutineA());
        var bStream = Observable.FromCoroutine(_ => CoroutineB());

        //两个协程都执行完就结束
        Observable.WhenAll(aStream, bStream)
            .Subscribe(_ =>
            {
                Debug.Log("协程执行完毕");
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
