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

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
