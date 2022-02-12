using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempCardDisplay : MonoBehaviour
{
    public TempCard card;

    public TextMeshProUGUI card_name;

    public Image card_image;

    public TextMeshProUGUI card_cost;
    //public TextMeshProUGUI card_description;

    public ClassType card_classType;
    public CardRare card_rare;
    public Image card_bg;
    public Image card_rare_img; // 이미지부분 레어도
    public Image card_rare_name; // 이름부분 레어도

    public TextMeshProUGUI card_price;


    void Start()
    {
        card_name.text = card.card_name;

        card_image.sprite = card.card_image;

        card_cost.text = card.card_cost.ToString();

        card_classType = card.class_type;
        card_rare = card.card_rare;

        card_bg.sprite = Resources.Load<Sprite>(card_classType.ToString() + "BG");
        card_rare_img.sprite = Resources.Load<Sprite>(card_rare.ToString() + "_0");
        card_rare_name.sprite = Resources.Load<Sprite>(card_rare.ToString() + "_1");

        card_price.text = card.card_price.ToString();
    }

    
    void Update()
    {
        
    }
}
