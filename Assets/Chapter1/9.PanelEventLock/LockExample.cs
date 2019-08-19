using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class LockExample : MonoBehaviour
{

    public Button BtnA;
    public Button BtnB;
    public Button BtnC;

    // Start is called before the first frame update
    void Start()
    {
        var aStream = BtnA.OnClickAsObservable().Select(_=>"A");
        var bStream = BtnB.OnClickAsObservable().Select(_=>"B");
        var cStream = BtnC.OnClickAsObservable().Select(_=>"C");

        //对三个按钮的事件流进行合并处理，并订阅同一事件
        Observable.Merge(aStream, bStream, cStream)
            .First()
            .Subscribe(_ =>
            {
                Debug.Log(_ + "按钮点击");
                Observable.Timer(TimeSpan.FromSeconds(1.0f))
                    .Subscribe(__ => Destroy(gameObject));
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
