using UnityEngine;
using UnityEngine.UI;

public class ResponsiveView : MonoBehaviour
{
    public GameObject[] vertical;
    public GameObject[] horizontal;

    public GridLayoutGroup Auth;
    void Update()
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        foreach (var item in vertical)
        {
            item.SetActive(aspectRatio <= 1f);
        }
        
        foreach (var item in horizontal)
        {
            item.SetActive(aspectRatio > 1f);
        }

        if(aspectRatio > 1f){
            Auth.padding.top = 100;
        }else{
            Auth.padding.top = 0;
        }
    }
}
