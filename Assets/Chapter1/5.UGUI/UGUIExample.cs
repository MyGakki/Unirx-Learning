using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UGUIExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //把对UGUI的各种UnityEvent转换成了Observable可观察对象
        Button button = transform.Find("Button").GetComponent<Button>();

        button.OnClickAsObservable()
            .Subscribe(_ => Debug.Log("点击按钮"))
            .AddTo(this);

        Toggle toggle = transform.Find("Toggle").GetComponent<Toggle>();

        toggle.OnValueChangedAsObservable()
            //.Where(isOn=>isOn == true)
            .SubscribeToInteractable(button)
            .AddTo(this);

        Image image = transform.Find("Image").GetComponent<Image>();

        image.OnBeginDragAsObservable()
            .Subscribe(eventDate => Debug.Log("Begin Darg " + eventDate.position))
            .AddTo(this);

        image.OnDragAsObservable()
            .Subscribe(eventDate => Debug.Log("Darging  " + eventDate.position))
            .AddTo(this);

        image.OnEndDragAsObservable()
            .Subscribe(eventDate => Debug.Log("End Darg " + eventDate.position))
            .AddTo(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
