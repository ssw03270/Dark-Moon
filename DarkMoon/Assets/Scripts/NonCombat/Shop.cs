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
        ShopCardDisplay(); // 상점에 카드 진열
    }

    public void ShopEnterButton()
    {
        shop_ui.gameObject.SetActive(true);
        shop_ui.anchoredPosition = Vector3.zero; // 상점 위치로 갖다 놓기
    }

    public void ShopExitButton()
    {
        shop_ui.anchoredPosition = Vector3.up * 1000; // 안 보이게 갖다 놓기
        shop_ui.gameObject.SetActive(false);
    }

    private void ShopCardDisplay()
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

    public void BuyCard()
    {
        GameObject card_button = EventSystem.current.currentSelectedGameObject; // 클릭한 카드 버튼 오브젝트
        int price = card_button.GetComponent<TempCardDisplay>().card.card_price; // 카드 구매 가격
        if (temp_manager.gold_amount >= price) // 구매 가능하면
        {
            Debug.Log(price);
            temp_manager.gold_amount -= price;
            temp_manager.GoldUpdate();

            card_button.SetActive(false);

            // 구매한 카드 등록 처리 (덱에 넣기)
        }
        else // 구매 불가능하면
        {
            Debug.Log("not enough money");
        }
        
    }

    public void RemoveCardBtn()
    {
        int price = 1000;

        if (temp_manager.gold_amount >= price) // 돈 있으면
        {
            Debug.Log(price);
            temp_manager.gold_amount -= price;
            temp_manager.GoldUpdate();

            // 카드 제거 UI 표시
            // 제거할 카드 선택하면
            // 덱에서 카드 제거
        }
        else // 돈 없으면
        {
            Debug.Log("not enough money");
        }
    }
}
