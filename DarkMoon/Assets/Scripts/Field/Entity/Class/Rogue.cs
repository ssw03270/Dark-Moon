using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : PlayerEntity
{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Mage;
    }

    public void StartSpec() // 스텟을 정하는 함수
    {
        entity_max_health = Random.Range(40,71);
        entity_strength = Random.Range(50,81);
        entity_mana = Random.Range(1,4);
        entity_avoid = Random.Range(80,101);        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
