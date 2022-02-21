using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerEntity

{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Mage;    // ����: ������
    }

    public void StartSpec() // ������ ���ϴ� �Լ�
    {
        entity_max_health = Random.Range(40,71);
        entity_strength = Random.Range(10,31);
        entity_mana = Random.Range(3,6);
        entity_avoid = Random.Range(50,101);
        base.SetPlayerEntityName();
    }

    public void SetSpec(PlayerEntityData data)  // PlayerEntityData에 능력치 세팅 함수
    {
        data.entity_name = entity_name;
        data.entity_max_health = entity_max_health;
        data.entity_strength = entity_strength;
        data.entity_mana = entity_mana;
        data.entity_avoid = entity_avoid;
        data.class_type = global::ClassType.Mage;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
