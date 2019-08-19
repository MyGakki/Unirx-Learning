using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FirstExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //该条件是指运行帧数到了300帧之后的第一次点击鼠标才被处理
        Observable.EveryUpdate()
            .First(_ => Input.GetMouseButtonDown(0) && _ > 300) //只有第一次满足条件才被处理，其他的都被过滤(_代表EveryUpdate的返回值，是运行到了第几帧)
            .Subscribe(_ =>Debug.Log("第一次点击鼠标" + _))
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
