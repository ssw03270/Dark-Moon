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
    public int entity_health;

    // 버프
    public int entity_strength;
    public int entity_avoid;
    public int entity_guard;
    public int entity_revival;
    public int entity_blessing;

    // 디버프
    public int entity_poison;
    public int entity_bleeding;
    public int entity_burn;
    public int entity_weak;
    public int entity_death;





    public TextMeshPro entity_health_text;

    private void Awake()
    {
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }
    public void GetDamage(int amount)
    {
        float damage = (entity_weak >= 1) ? 1.5f * amount : amount;
        damage = (entity_avoid >= 1) ? 0.5f * damage : damage;
        entity_health -= Mathf.RoundToInt(damage);
    }

    protected virtual void Update()
    {
        entity_health_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        entity_health_text.text = entity_health.ToString() + "/" + entity_max_health.ToString();
    }

    public void NextTurn()
    {
        if(entity_bleeding > 0)
        {
            GetDamage(entity_bleeding);
            entity_bleeding -= 1;
        }
        if (entity_poison > 0)
        {
            GetDamage(entity_poison);
            entity_poison -= 1;
        }
        if (entity_burn > 0)
        {
            GetDamage(entity_burn);
            entity_burn -= 1;
        }

        entity_avoid -= (entity_avoid > 0) ? 1 : 0;
        entity_strength -= (entity_strength > 0) ? 1 : 0;
        entity_weak -= (entity_weak > 0) ? 1 : 0;
        entity_blessing -= (entity_blessing > 0) ? 1 : 0;
        entity_death -= (entity_death > 0) ? 1 : 0;
        entity_guard = 0;
        entity_revival -= (entity_revival > 0) ? 1 : 0;
    }
}
