using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowing : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 9;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_damage = new Tuple<SimpleTask, int>(new SimpleDamage(), 3);
        card_task.Add(simple_damage);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
