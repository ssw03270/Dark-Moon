using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public RectTransform shop_ui;

    public void ShopEnterButton()
    {
        shop_ui.anchoredPosition = Vector3.zero;
    }

    public void ShopExitButton()
    {
        shop_ui.anchoredPosition = Vector3.up * 500;
    }
}
