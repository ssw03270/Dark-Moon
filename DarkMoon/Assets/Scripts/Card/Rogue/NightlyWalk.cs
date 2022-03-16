using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightlyWalk : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 8;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_avoid = new Tuple<SimpleTask, int>(new SimpleAvoid(), 1);
        card_task.Add(simple_avoid);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
