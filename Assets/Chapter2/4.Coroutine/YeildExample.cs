using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class YeildExample : MonoBehaviour
{
    IEnumerator CoroutineB()
    {
        //把事件流转化成挂起对象
        yield return Observable.Timer(TimeSpan.FromSeconds(1.0f)).ToYieldInstruction();
        Debug.Log("B End");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoroutineB());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
