using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalAttack : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 6;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_damage = new Tuple<SimpleTask, int>(new SimpleDamage(), 2);
        Tuple<SimpleTask, int> simple_weak = new Tuple<SimpleTask, int>(new SimpleWeak(), 2);
        card_task.Add(simple_damage);
        card_task.Add(simple_weak);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
