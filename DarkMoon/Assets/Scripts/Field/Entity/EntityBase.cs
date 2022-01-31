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
    // 초기 스펙 엔티티
    public int entity_max_health;
    public int entity_strength;
    public int entity_mana;
    public int entity_avoid;
    
    //변화하는 엔티티
    public int entity_health;
    public int entity_guard;
    public int entity_revival;
    public int entity_blessing;

    //상태이상
    public int entity_poison;
    public int entity_bleeding;
    public int entity_burn;
    public int entity_weak;
    
    public int entity_death;
   



    TextMeshPro entity_health_text;

    private void Awake()
    {
        if (transform.childCount <= 0)
        {
            Debug.Assert(transform.childCount < 0, "Can't Find Entity Health Text");
            return;
        }
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }
    public void GetDamage(int amount)
    {
        entity_health -= Mathf.RoundToInt((entity_weak >= 1) ? 1.5f * amount : amount);
    }
}
