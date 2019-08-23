using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class LifeTimeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Subscribe(_ => Debug.Log("Update")).AddTo(this);//AddTo封装了Observable Destory Trigger
        this.UpdateAsObservable().Subscribe(_ => Debug.Log("Update"));//等价

        Observable.EveryFixedUpdate().Subscribe(_ => Debug.Log("FixedUpdate"));
        Observable.EveryLateUpdate().Subscribe(_ => Debug.Log("LateUpdate"));
        Observable.EveryEndOfFrame().Subscribe(_ => Debug.Log("EndOfFrame"));


        Observable.EveryApplicationFocus().Subscribe(_ => Debug.Log("Focus" + _));
        Observable.EveryApplicationPause().Subscribe(_ => Debug.Log("Pause" + _));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
