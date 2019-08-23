using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Register : MonoBehaviour
{

    Button mRegister;
    InputField mUsername;
    InputField mPassword;
    InputField mConfrimPassword;

    // Start is called before the first frame update
    void Start()
    {
        mRegister = transform.Find("Register").GetComponent<Button>();

        mUsername = transform.Find("Username").GetComponent<InputField>();
        mPassword = transform.Find("Password").GetComponent<InputField>();
        mConfrimPassword = transform.Find("ConfirmPassword").GetComponent<InputField>();

        mUsername.OnEndEditAsObservable().Subscribe(_ =>
        {
            mPassword.Select();
        });

        mPassword.OnEndEditAsObservable().Subscribe(_ =>
        {
            mConfrimPassword.Select();
        });

        mConfrimPassword.OnEndEditAsObservable().Subscribe(_ =>
        {
            mRegister.onClick.Invoke();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
