using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IntroExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().//每一帧产生调用
            Where(_=>Input.GetMouseButtonDown(0))//进行过滤
            .Subscribe( _=>//对事件的订阅
            {
                Debug.Log("Mouse Clicke");
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
