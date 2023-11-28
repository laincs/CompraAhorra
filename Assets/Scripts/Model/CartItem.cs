using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartItem : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public TMP_Text value;
    public Item item;

    public void UpdateMenuItem(Item item, Sprite image, string title, string value){
        this.item = item;
        this.image.sprite = image;
        this.title.text = title;
        this.value.text = value;
    }

    public void RemoveItem(){
        AppManager.instance.cart.Remove(item);
        FindAnyObjectByType<SceneCartHandler>().OnEnable();
    }
}
