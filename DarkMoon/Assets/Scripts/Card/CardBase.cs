using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBase : MonoBehaviour
{
    public string card_name;
    public int card_cost;
    public string card_content;

    public List<SimpleTask> card_task = new List<SimpleTask>();

    FieldManager current_field;

    TextMeshPro card_cost_text;
    TextMeshPro card_name_text;
    TextMeshPro card_content_text;

    private void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();
    }
    protected void SetCardText()
    {
        if (transform.childCount <= 0)
        {
            Debug.Assert(transform.childCount < 0, "Can't Find Card Text");
            return;
        }
        card_cost_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        card_cost_text.text = card_cost.ToString();
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
