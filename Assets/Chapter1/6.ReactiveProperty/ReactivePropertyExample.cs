using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ReactivePropertyExample : MonoBehaviour
{
    public Action<int, int> OnValueChanged = null;

    public Text Text;

    private int _age = 0;
    public int Age
    {
        get { return _age; }
        set
        {
            if (_age != value)
            {
                OnValueChanged(_age, value);
                _age = value;
            }
        }
    }

    public ReactiveProperty<int> Height = new ReactiveProperty<int>(0);

    public IntReactiveProperty Weight = new IntReactiveProperty(0);

    // Start is called before the first frame update
    void Start()
    {
        OnValueChanged += (age1, age2) =>
        {
            Debug.Log(age1 + "=> " + age2);
        };

        //Height发生改变且变化后的值大于5是执行回调,回调是将Height值与Text.text绑定在一起
        Height.Where(Height=>Height > 5)
             .SubscribeToText(Text, x=>"Height:" + ((float)x/100).ToString() + "m")
             .AddTo(this);

        Age = 10;
        Height.Value = 150;

        print(JsonUtility.ToJson(Height));
        print(JsonUtility.ToJson(Weight));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class PersonView
{
    ReactivePropertyExample reactivePropertyExample;

    void Init()
    {
        reactivePropertyExample.OnValueChanged += (age1, age2) =>
        {
            Debug.Log(age1 + "->" + age2);
        };
    }
}
