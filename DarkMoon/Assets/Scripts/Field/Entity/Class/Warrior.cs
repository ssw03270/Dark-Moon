using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerEntity
{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Warrior;
    }

     public void StartSpec() // 스텟을 정하는 함수
    {
        entity_max_health = Random.Range(70,101);
        entity_strength = Random.Range(60,91);
        entity_mana = Random.Range(1,3);
        entity_avoid = Random.Range(20,51);
        base.SetPlayerEntityName();        
    }

    public void SetSpec(PlayerEntityData data)
    {
        data.entity_name = entity_name;
        data.entity_max_health = entity_max_health;
        data.entity_strength = entity_strength;
        data.entity_mana = entity_mana;
        data.entity_avoid = entity_avoid;
        data.class_type = global::ClassType.Warrior;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
