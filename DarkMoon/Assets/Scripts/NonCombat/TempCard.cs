using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType { Mage, Warrior, Priest, Rogue, Normal }

public enum CardRare { Bronze, Silver, Gold }

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class TempCard : ScriptableObject
{
    [Header("Card Info")]
    public ClassType class_type;
    public CardRare card_rare;
    public string card_name;
    public string card_content;
    public int card_cost;
    
    [Header("Unique Image")]
    public Sprite card_image;
    
    [Header("Shop")]
    public int card_price;
}
