using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WhereExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                Debug.Log("Mouse Click");
            }).AddTo(this);//把该订阅的生命周期和这个脚本绑定起来
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
