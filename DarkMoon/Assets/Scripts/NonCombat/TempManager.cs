using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempManager : MonoBehaviour
{
    public int gold_amount;
    public TextMeshProUGUI gold_text;

    //public List<TempCard> card_data = new List<TempCard>(); // 임시용

    void Start()
    {

    }

    void Update()
    {
        //GoldUpdate();
    }

    public void GoldUpdate()
    {
        gold_text.text = "Gold: " + gold_amount.ToString();
    }
}
