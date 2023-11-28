using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SceneUserHandler : MonoBehaviour
{
    public TMP_Text username;
    public TMP_Text email;
    public TMP_Text rut;
    public TMP_Text cellphone;

    public void Start(){
        username.text = AppManager.instance.userData.username;
        email.text = AppManager.instance.userData.email;
        rut.text = AppManager.instance.userData.run;
        cellphone.text = AppManager.instance.userData.phone;
    }

    public void LogOut(){
        AppManager.instance.username = "";
        AppManager.instance.hiText.text = "Inicia Sesión";
        AppManager.instance.TriggerLogOut();
    }
}
