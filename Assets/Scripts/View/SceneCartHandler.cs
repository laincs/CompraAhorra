using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class SceneCartHandler : MonoBehaviour
{
    public TMP_Text total;
    public GameObject CartObjectPrefab;
    public GameObject container;
    public void OnEnable()
    {
        ItemLoader itemLoader = FindAnyObjectByType<ItemLoader>();
        DestroyAllChildren();
        foreach (var item in AppManager.instance.cart){
            var obj = Instantiate(CartObjectPrefab, container.transform);
            obj.GetComponent<CartItem>().UpdateMenuItem(item, itemLoader.sprites.FirstOrDefault(sprite => sprite.name == item.idImage), item.itemName, $"${item.price}.990");

        }

        float totalPrice = 0;

        foreach (var item in AppManager.instance.cart){
            totalPrice+=(float.Parse(item.price)*1000);
        }

        total.text = $"Total: {totalPrice}";

    }

    void DestroyAllChildren()
    {
        foreach (Transform child in container.transform){
            Destroy(child.gameObject);
        }
    }

    public void Buy(){
        AppManager.instance.cart.Clear();
        AppManager.instance.GoThankScene();
    }
}
