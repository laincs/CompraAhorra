using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerHandler : MonoBehaviour
{
    public void TriggerUserButton(){
        if(AppManager.instance.username == ""){
            AppManager.instance.GoAuthScene();
        }else{
            AppManager.instance.GoUserScene();
        }
    }
}
