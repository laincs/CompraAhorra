using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SceneBuyHandler : MonoBehaviour
{
    public Item item;
    public Image image;
    public TMP_Text TMP_Title;
    public TMP_Text TMP_Desc;
    public TMP_Text TMP_Price;
    public TMP_Text TMP_Stock;

    public void UpdateView(Item newItem){
        item = newItem;
        image.sprite = FindAnyObjectByType<ItemLoader>().sprites.FirstOrDefault(sprite => sprite.name == item.idImage);
        TMP_Title.text = item.itemName;
        TMP_Desc.text = item.description;
        TMP_Price.text = $"{item.price}.000";
        TMP_Stock.text = $"+{item.stock} Unidades";
    }

}