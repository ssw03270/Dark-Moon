using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : EntityBase
{
    public enum ClassType
    {
        Mage,
        Priest,
        Rogue,
        Warrior
    }

    public List<CardBase> deck = new List<CardBase>();
    public List<CardBase> hand = new List<CardBase>();
    public List<CardBase> discard_pile = new List<CardBase>();

    public List<GameObject> hand_gameobject = new List<GameObject>();

    public ClassType class_type;

    public int gold;
    public int current_exp;
    public int max_exp;

    // Start is called before the first frame update
    void Start()
    {
        entity_type = EntityType.PlayerEntity;
    }

    public void AddCardToDeck(CardBase card)
    {
        deck.Add(card);
    }

    public void ActivateHand()
    {
        foreach (CardBase card in hand)
        {
            hand_gameobject.Add(Instantiate(card, new Vector3(-7, -3, 0), Quaternion.identity).transform.gameObject);
        }
        SortingCardInHand();
    }

    public void DeactivateHand()
    {
        while(hand_gameobject.Count > 0)
        {
            Destroy(hand_gameobject[0]);
            hand_gameobject.RemoveAt(0);
        }
    }
    public void DeckToHand(int count)
    {
        while (count > 0)
        {
            count -= 1;

            if (deck.Count <= 0)
            {
                DiscardPileToDeck(discard_pile.Count);
            }

            if (deck.Count > 0)
            {
                hand.Add(deck[0]);
                
                deck.RemoveAt(0);
            }
        }
    }
    public void HandToDiscardPile(int count)
    {
        while (count > 0)
        {
            count -= 1;

            if (hand.Count > 0)
            {
                discard_pile.Add(hand[0]);
                hand.RemoveAt(0);
            }
        }
    }
    public void HandToDiscardPile(GameObject card)
    {
        int index = hand_gameobject.IndexOf(card);

        discard_pile.Add(hand[index]);
        Destroy(hand_gameobject[index]);
        hand_gameobject.RemoveAt(index);
        hand.RemoveAt(index);

        SortingCardInHand();
    }
    public void DiscardPileToDeck(int count)
    {
        while (count > 0)
        {
            count -= 1;

            if (discard_pile.Count > 0)
            {
                deck.Add(discard_pile[0]);
                discard_pile.RemoveAt(0);
            }
        }
    }
    public void SortingCardInHand()
    {
        int card_count_in_hand = hand.Count;
        List<float> card_angle_in_hand = new List<float>();

        for (int i = 0; i < card_count_in_hand; i++)
        {
            card_angle_in_hand.Add(120.0f / card_count_in_hand * i);
        }

        for (int i = 0; i < card_count_in_hand; i++)
        {
            float extra_card_angle = 60.0f / card_count_in_hand;

            card_angle_in_hand[i] += extra_card_angle;
            card_angle_in_hand[i] -= 60;
            hand_gameobject[i].transform.localEulerAngles = new Vector3(0, 0, card_angle_in_hand[i]);
            hand_gameobject[i].GetComponent<CardBase>().target_position = new Vector3(0, -6, 0) + hand_gameobject[i].transform.up * 5;
        }
    }

    protected override void Update()
    {
        base.Update();
    }
}
