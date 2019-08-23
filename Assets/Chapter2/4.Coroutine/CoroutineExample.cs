using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoroutineExample : MonoBehaviour
{

    IEnumerator CoroutineA()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("A End");
    }

    // Start is called before the first frame update
    void Start()
    {
        //把协程转换成事件流
        Observable.FromCoroutine(_ => CoroutineA()).Subscribe(_ => { Debug.Log("After End Coroutine A"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
