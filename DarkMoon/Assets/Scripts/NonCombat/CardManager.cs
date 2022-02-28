using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class Card
    {
        public string card_name;
        public string class_type;
        public int card_cost;
        public string card_content;

    }

    [System.Serializable]
    public class CardList
    {
        public Card[] card;
    }

    public CardList jsonCardList = new CardList();
    
    public List<TempCard> cards = new List<TempCard>(); // 게임 내 카드 목록
    private void Awake()
    {
        jsonCardList = JsonUtility.FromJson<CardList>(textJSON.text);

        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].card_name = jsonCardList.card[i].card_name;
            cards[i].card_cost = jsonCardList.card[i].card_cost;
            cards[i].card_content = jsonCardList.card[i].card_content;

            switch (jsonCardList.card[i].class_type)
            {
                case "Mage":
                    cards[i].class_type = ClassType.Mage;
                    break;
                case "Warrior":
                    cards[i].class_type = ClassType.Warrior;
                    break;
                case "Rogue":
                    cards[i].class_type = ClassType.Rogue;
                    break;
                case "Priest":
                    cards[i].class_type = ClassType.Priest;
                    break;
                case "Normal":
                    cards[i].class_type = ClassType.Normal;
                    break;
            }


        }
    }

}
