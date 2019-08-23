using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class LoginExample : MonoBehaviour
{

    InputField mUserName;
    InputField mPassWord;
    Button mLogin;
    Button mRegister;

    // Start is called before the first frame update
    void Start()
    {
        mUserName = transform.Find("Username").GetComponent<InputField>();
        mPassWord = transform.Find("Password").GetComponent<InputField>();
        mLogin = transform.Find("Login").GetComponent<Button>();
        mRegister = transform.Find("Register").GetComponent<Button>();

        mLogin.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("login btn click");
        });

        mUserName.OnEndEditAsObservable().Subscribe(_ =>
        {
            mPassWord.Select();
        });

        mPassWord.OnEndEditAsObservable().Subscribe(_ =>
        {
            mLogin.onClick.Invoke();
        });

        mRegister.OnClickAsObservable().Subscribe(_ =>{
            Debug.Log("Register");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
