using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UpdateExmaple : MonoBehaviour
{
    bool mButtonClicked = false;

    enum ButtonState
    {
        None,
        Clicked,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("左键点击");
                }
            });

        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("右键点击");
                }
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
