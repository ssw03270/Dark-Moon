using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBleeding : MonoBehaviour
{
    Field current_field = GameObject.Find("FieldManager").GetComponent<Field>();
    public void AddBleeding(int entity_position, int amount)
    {
        if (entity_position < 0 && entity_position >= current_field.enemy_entity.Length)
        {
            Debug.Assert(entity_position < 0 && entity_position >= current_field.enemy_entity.Length, "Wrong Entity Position");
            return;
        }
        current_field.enemy_entity[entity_position].entity_bleeding += amount;
    }
}
