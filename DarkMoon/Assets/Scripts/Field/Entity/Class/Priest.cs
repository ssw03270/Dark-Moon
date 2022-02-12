using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : PlayerEntity
{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Mage;
    }

    public void StartSpec() // 스텟을 정하는 함수
    {
        entity_max_health = Random.Range(40,71);
        entity_strength = Random.Range(30,61);
        entity_mana = Random.Range(2,5);
        entity_avoid = Random.Range(50,101);        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
