using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntityBase : MonoBehaviour
{
    public enum EntityType
    {
        PlayerEntity,
        EnemyEntity
    }

    public string entity_name;
    public EntityType entity_type;
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


    public TextMeshPro entity_health_text;

    private void Awake()
    {
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }
    public void GetDamage(int amount)
    {
        entity_health -= Mathf.RoundToInt((entity_weak >= 1) ? 1.5f * amount : amount);
    }

    protected virtual void Update()
    {
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }
}
