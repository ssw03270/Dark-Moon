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

    public void DeckToHand(int count)
    {
        while (count > 0)
        {
            count -= 1;

            if(deck.Count <= 0)
            {
                DiscardPileToDeck(discard_pile.Count);
            }

            if(deck.Count > 0)
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

            if(hand.Count > 0)
            {
                discard_pile.Add(hand[0]);
                hand.RemoveAt(0);
            }
        }
    }
    public void DiscardPileToDeck(int count)
    {
        while(count > 0)
        {
            count -= 1;

            if (discard_pile.Count > 0)
            {
                deck.Add(discard_pile[0]);
                discard_pile.RemoveAt(0);
            }
        }
    }
}
