using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class SceneAuthHandler : MonoBehaviour
{
    [Header("Login Ref")]
    public TMP_InputField login_username;
    public TMP_InputField login_password;

    [Header("Register Ref")]
    public TMP_InputField register_username;
    public TMP_InputField register_email;
    public TMP_InputField register_rut;
    public TMP_InputField register_cellphone;
    public TMP_InputField register_password;


    public void TryLogin(){
        AppManager.instance.GoLoadingScene();
        if (login_username.text != "" && login_password.text != ""){
            DBConnection.instance.StartCoroutine(DBConnection.instance.LoginUser(login_username.text, login_password.text));
        }

    }

    public void TryRegister(){
        AppManager.instance.GoLoadingScene();
        if (register_username.text != "" && register_email.text != "" && register_rut.text != "" && register_cellphone.text != "" && register_password.text != "" ){
            DBConnection.instance.StartCoroutine(DBConnection.instance.RegisterUser(register_username.text, register_rut.text, register_email.text, register_password.text, register_cellphone.text));
        }
    }
}
