using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerEntity
{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Mage;
    }

     public void StartSpec() // 스텟을 정하는 함수
    {
        entity_max_health = Random.Range(70,101);
        entity_strength = Random.Range(60,91);
        entity_mana = Random.Range(1,3);
        entity_avoid = Random.Range(20,51);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
