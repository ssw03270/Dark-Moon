using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAvoid : SimpleTask
{
    FieldManager current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    public override void Task(int entity_position, int amount)
    {
        if (entity_position < 0 || entity_position >= current_field.our_entity.Length)
        {
            Debug.Assert(true, "Wrong Entity Position");
            return;
        }
        current_field.our_entity[entity_position].entity_avoid += amount;
    }
}