using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public RectTransform shop_ui; // 상점 UI
    public RectTransform shop_slots; // 상점 슬롯 부모
    public TempManager temp_manager; // 골드 관리용 게임매니저(임시)

    public List<TempCard> shop_cards = new List<TempCard>(); // 상점에 진열할 카드 목록

    private void Awake()
    {
        ShopDisplay();
    }

    public void ShopEnterButton()
    {
        shop_ui.anchoredPosition = Vector3.zero; // 상점 위치로 갖다 놓기
    }

    public void ShopExitButton()
    {
        shop_ui.anchoredPosition = Vector3.up * 1000; // 안 보이게 갖다 놓기
    }

    private void ShopDisplay()
    // 상점에 카드 진열 함수
    {
        if (shop_slots.childCount == shop_cards.Count)
        {
            for (int i = 0; i < shop_cards.Count; ++i)
            {
                shop_slots.GetChild(i).GetComponent<TempCardDisplay>().card = shop_cards[i];
            }
        }
    }

    public void Buy()
    {
        int price = EventSystem.current.currentSelectedGameObject.GetComponent<TempCardDisplay>().card.card_price;
        if (temp_manager.gold_amount >= price)
        {
            Debug.Log(price);
            temp_manager.gold_amount -= price;
            temp_manager.GoldUpdate();

            // 구매한 아이템 등록 처리
        }
        else
        {
            Debug.Log("not enough money");
        }
        
    }
}
