using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MergeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftClickEvent = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        var rightClickEvent = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));
        //对两个事件流进行合并，任意一个事件流被触发执行回调
        Observable.Merge(leftClickEvent, rightClickEvent)
            .Subscribe(_=> Debug.Log("鼠标点击" + _))
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
