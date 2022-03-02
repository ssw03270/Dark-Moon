using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamage : SimpleTask
{
    FieldManager current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();

    public override void Task(bool isPlayer, int entity_position, int amount)
    {
        if (isPlayer)
        {
            if (entity_position < 0 || entity_position >= current_field.enemy_entity.Length)
            {
                Debug.Assert(true, "Wrong Entity Position");
                return;
            }
            float damage = amount + (current_field.enemy_entity[current_field.current_enemy_number].entity_strength);
            damage = (current_field.enemy_entity[current_field.current_enemy_number].entity_blessing >= 1) ? 1.5f * damage : damage;
            current_field.player_entity[entity_position].GetDamage(Mathf.RoundToInt(damage));
        }
        else
        {
            if (entity_position < 0 || entity_position >= current_field.enemy_entity.Length)
            {
                Debug.Assert(true, "Wrong Entity Position");
                return;
            }
            float damage = amount + (current_field.player_entity[current_field.current_player_number].entity_strength);
            damage = (current_field.player_entity[current_field.current_player_number].entity_blessing >= 1) ? 1.5f * damage : damage;
            current_field.enemy_entity[entity_position].GetDamage(Mathf.RoundToInt(damage));
        }

        
    }
}