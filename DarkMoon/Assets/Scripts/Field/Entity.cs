using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Entity : MonoBehaviour
{
    public string entity_name;
    public int entity_health;
    public int entity_max_health;
    public int entity_poison;
    public int entity_bleeding;
    public int entity_burn;
    public int entity_avoid;
    public int entity_strength;
    public int entity_weak;
    public int entity_blessing;
    public int entity_death;
    public int entity_guard;
    public int entity_revival;

    TextMeshPro entity_health_text;

    private void Start()
    {
        if (transform.childCount <= 0)
        {
            Debug.Assert(transform.childCount < 0, "Can't Find Entity Health Text");
            return;
        }
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }
}
