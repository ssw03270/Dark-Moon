using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAvoid : MonoBehaviour
{
    Field current_field = GameObject.Find("FieldManager").GetComponent<Field>();
    public void AddAvoid(int entity_position_start, int entity_position_end, int amount)
    {
        if (entity_position_start > entity_position_end || entity_position_start < 0 || entity_position_end >= current_field.entity_list.Length)
        {
            Debug.Assert(true, "Wrong Entity Position");
            return;
        }
        for (int i = entity_position_start; i <= entity_position_end; i++)
        {
            current_field.entity_list[i].entity_avoid += amount;
        }
    }
}
