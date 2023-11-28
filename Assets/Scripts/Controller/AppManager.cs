using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppManager : Instance<AppManager>
{
    [Header("User Data")]
    public string username;
    public User userData;
    public List<Item> cart = new List<Item>();

    [Header("View References")]
    public TMP_Text hiText;

    [Header("Views")]
    public GameObject shopScene;
    public GameObject cartScene;
    public GameObject buyScene;
    public GameObject authScene;
    public GameObject userScene;
    public GameObject loadingScene;
    public GameObject thankScene;

    public void AddToCart(Item item){
        cart.Add(item);
        GoCartScene();
    }

    public void GoAuthScene(){
        OffAllObjects();
        authScene.SetActive(true);
    }

    public void GoThankScene(){
        OffAllObjects();
        thankScene.SetActive(true);
    }

    public void GoCartScene(){
        OffAllObjects();
        cartScene.SetActive(true);
    }

    public void GoBuyScene(Item item){
        OffAllObjects();
        buyScene.SetActive(true);
        FindAnyObjectByType<SceneBuyHandler>().UpdateView(item);
    }

    public void GoUserScene(){
        OffAllObjects();
        userScene.SetActive(true);
    }
    public void GoLoadingScene(){
        OffAllObjects();
        loadingScene.SetActive(true);
    }

    void OffAllObjects(){
        if(shopScene!=null) shopScene.SetActive(false);
        if(cartScene!=null) cartScene.SetActive(false);
        if(buyScene!=null) buyScene.SetActive(false);
        if(authScene!=null) authScene.SetActive(false);
        if(userScene!=null) userScene.SetActive(false);
        if(loadingScene!=null) loadingScene.SetActive(false);
        if(thankScene!=null) thankScene.SetActive(false);
    }

    public void TriggerAuth(){
        OffAllObjects();
        shopScene.SetActive(true);
        hiText.text = username;
    }

    public void TriggerLogOut(){
        OffAllObjects();
        shopScene.SetActive(true);
    }

}
