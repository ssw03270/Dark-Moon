using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : CardBase
{
    // Start is called before the first frame update
    void Start()
    {
        this.card_name = "Test Card";
        this.card_cost = 1;
        this.card_content = "this card is for testing";

        base.SetCardText();

        this.card_task.Add(new SimplePoison());
    }

    public override void UseCard()
    {
        base.UseCard();
    }
}
