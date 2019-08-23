using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class OnCompletedExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //OnNext->Oncompleted
        Observable.Timer(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ =>
            {
                Debug.Log("On Next: After 1 Second");
            },
            ()=>
            {
                Debug.Log("On Completed");
            });

        Observable.EveryUpdate().First().Subscribe(_ =>
        {
            Debug.Log("On Next: First");
        }, () =>
        {
            Debug.Log("On Completed");
        });

        Observable.FromCoroutine(CoroutineA).Subscribe(_ =>
        {
            Debug.Log("On Next: Coroutine");
        }, () =>
        {
            Debug.Log("On Completed");
        });
    }

    IEnumerator CoroutineA()
    {
        yield return Observable.Timer(TimeSpan.FromSeconds(1.0f)).ToYieldInstruction();
        Debug.Log("Coroutine A");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
