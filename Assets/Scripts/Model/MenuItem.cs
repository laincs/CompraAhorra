using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public TMP_Text value;
    public TMP_Text stock;
    public TMP_Text desc;
    public Item item;

    public void UpdateMenuItem(Item item, Sprite image, string title, string value, string desc, string stock){
        this.item = item;
        this.image.sprite = image;
        this.title.text = title;
        this.value.text = value;
        this.desc.text = desc;
        this.stock.text = $"Quedan {stock}";
    }
}
