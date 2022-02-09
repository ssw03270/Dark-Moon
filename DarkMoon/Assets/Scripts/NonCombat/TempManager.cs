using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempManager : MonoBehaviour
{
    public int gold_amount;
    public TextMeshProUGUI gold_text;

    void Start()
    {
        GoldUpdate();
    }

    void Update()
    {

    }

    public void GoldUpdate()
    {
        gold_text.text = "Gold: " + gold_amount.ToString();
    }
}
