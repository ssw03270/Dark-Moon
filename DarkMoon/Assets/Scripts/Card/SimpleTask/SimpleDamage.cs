using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamage : SimpleTask
{
    FieldManager current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    public override void Task(int entity_position, int amount)
    {
        if (entity_position < 0 || entity_position >= current_field.enemy_entity.Length)
        {
            Debug.Assert(true, "Wrong Entity Position");
            return;
        }
        current_field.enemy_entity[entity_position].entity_health -= amount;
    }
}