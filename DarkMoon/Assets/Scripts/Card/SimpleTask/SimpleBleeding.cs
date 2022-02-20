using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBleeding : SimpleTask
{
    FieldManager current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    public override void Task(bool isPlayer, int entity_position, int amount)
    {
        if (isPlayer)
        {
            if (entity_position < 0 || entity_position >= current_field.player_entity.Length)
            {
                Debug.Assert(true, "Wrong Entity Position");
                return;
            }
            current_field.player_entity[entity_position].entity_bleeding += amount;
        }
        else
        {
            if (entity_position < 0 || entity_position >= current_field.enemy_entity.Length)
            {
                Debug.Assert(true, "Wrong Entity Position");
                return;
            }
            current_field.enemy_entity[entity_position].entity_bleeding += amount;
        }
    }
}