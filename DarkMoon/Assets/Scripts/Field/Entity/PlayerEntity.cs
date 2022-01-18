using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : EntityBase
{
    public List<CardBase> deck = new List<CardBase>();
    public List<CardBase> hand = new List<CardBase>();
    public List<CardBase> discard_pile = new List<CardBase>();

    public int deck_count;

    public int gold;

    // Start is called before the first frame update
    void Start()
    {
        entity_type = EntityType.PlayerEntity;
        deck_count = deck.Count;
    }

    public void AddCardToDeck(CardBase card)
    {
        deck.Add(card);
        deck_count += 1;
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
