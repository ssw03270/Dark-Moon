using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassType { Mage, Priest, Rogue, Warrior, Normal}

public enum CardRare { Bronze, Silver, Gold }

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class TempCard : ScriptableObject
{
    public ClassType class_type;
    public CardRare card_rare;
    public string card_name;
    public Sprite card_image;
    public int card_cost;
    public int card_price;


    public Sprite card_bg;

    public Sprite card_rare_img; // 이미지부분 레어도
    public Sprite card_rare_name; // 이름부분 레어도
    
}
