using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public RectTransform shop_ui;
    public TempManager temp_manager;

    public void ShopEnterButton()
    {
        shop_ui.anchoredPosition = Vector3.zero;
    }

    public void ShopExitButton()
    {
        shop_ui.anchoredPosition = Vector3.up * 1000;
    }

    public void Buy(int price)
    {
        if (temp_manager.gold_amount >= price)
        {
            
        }
        
    }
}
