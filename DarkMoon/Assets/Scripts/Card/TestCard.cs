using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : CardBase
{
    // Start is called before the first frame update
    void Awake()
    {
        card_name = "Test Card";
        card_cost = 1;
        card_content = "this card is for testing";

        base.SetCardText();

        SimplePoison simple_poison = new SimplePoison();
        card_task.Add(simple_poison);
    }

    public override void UseCard()
    {
        base.UseCard();
    }
}
