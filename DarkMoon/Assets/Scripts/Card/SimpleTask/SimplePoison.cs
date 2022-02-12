using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePoison : SimpleTask
{
    FieldManager current_field;

    public override void Task(int entity_position, int amount)
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
        if (entity_position < 0 || entity_position >= current_field.enemy_entity.Length)
        {
            Debug.Assert(true, "Wrong Entity Position");
            return;
        }
        current_field.enemy_entity[entity_position].entity_poison += amount;
    }
}
