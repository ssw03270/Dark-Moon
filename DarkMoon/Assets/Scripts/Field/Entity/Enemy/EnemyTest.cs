using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : EnemyEntity
{
    // Start is called before the first frame update
    void Start()
    {
        Tuple<SimpleTask, int> simple_damage = new Tuple<SimpleTask, int>(new SimpleDamage(), 3);
        enemy_task.Add(simple_damage);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
