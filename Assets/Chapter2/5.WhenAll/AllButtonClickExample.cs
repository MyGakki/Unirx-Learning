using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class AllButtonClickExample : MonoBehaviour
{
    Button mButtonA;
    Button mButtonB;

    // Start is called before the first frame update
    void Start()
    {
        mButtonA = transform.Find("ButtonA").GetComponent<Button>();
        mButtonB = transform.Find("ButtonB").GetComponent<Button>();

        var buttonAEvent = mButtonA.OnClickAsObservable().First();
        var buttonBEvent = mButtonB.OnClickAsObservable().First();

        Observable.WhenAll(buttonAEvent, buttonBEvent)
            .Subscribe(_ =>
            {
                Debug.Log("所有按钮都被点击了");
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
