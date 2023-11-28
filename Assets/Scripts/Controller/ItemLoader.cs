using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemLoader : MonoBehaviour
{
    public Item[] items;
    public Sprite[] sprites;
    public GameObject itemsParent;
    public GameObject itemPrefab;
    
    public void BuildArrayMenu(){
        foreach (var item in items){
            var obj = Instantiate(itemPrefab, itemsParent.transform);
            obj.GetComponent<MenuItem>().UpdateMenuItem(item, sprites.FirstOrDefault(sprite => sprite.name == item.idImage), item.itemName, $"${item.price}.990", item.description, item.stock );

        }
    }
}
