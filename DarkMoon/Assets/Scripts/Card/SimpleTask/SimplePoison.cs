using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePoison : SimpleTask
{
<<<<<<< HEAD
    FieldManager current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    public override void Task(int entity_position, int amount)
=======
    Field current_field = GameObject.Find("FieldManager").GetComponent<Field>();
    public void AddPoison(int entity_position_start, int entity_position_end, int amount)
>>>>>>> fd04b1025c0b7a23bfac64a01619feac52a99c76
    {
        if (entity_position_start > entity_position_end || entity_position_start < 0 || entity_position_end >= current_field.entity_list.Length)
        {
            Debug.Assert(true, "Wrong Entity Position");
            return;
        }
        for (int i = entity_position_start; i <= entity_position_end; i++)
        {
            current_field.entity_list[i].entity_poison += amount;
        }
    }
}
