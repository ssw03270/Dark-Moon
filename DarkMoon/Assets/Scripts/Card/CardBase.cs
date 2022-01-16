using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public string card_name;
    public int card_cost;
    public string card_content;

    public List<SimpleTask> card_task = new List<SimpleTask>();

    FieldManager current_field;
    private void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    }
    public virtual void UseCard()
    {
        if(current_field.current_energy >= card_cost)
        {
            current_field.current_energy -= card_cost;

            int target_position = SelectTarget();
            foreach (SimpleTask task in this.card_task)
            {
                task.Task(target_position, 1);
            }
        }
    }
    public virtual int SelectTarget()
    {
        int target_position = 0;

        return target_position;
    }

}
