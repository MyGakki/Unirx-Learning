using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;

public class UIBehaviourExample : MonoBehaviour
{
    Image Image;

    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();

        Image.OnBeginDragAsObservable().Subscribe(_ => { Debug.Log("Begin Drag"); });
        Image.OnDragAsObservable().Subscribe(_ => { Debug.Log("Dragging"); });
        Image.OnEndDragAsObservable().Subscribe(_ => { Debug.Log("End Drag"); });

        Image.OnPointerClickAsObservable().Subscribe(_ => { Debug.Log("Point Click"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
