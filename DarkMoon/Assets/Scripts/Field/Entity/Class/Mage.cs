using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Random;

public class Mage : PlayerEntity

{
    // Start is called before the first frame update
    void Start()
    {
        class_type = ClassType.Mage;    // 직업: 마법사
    }

    public void StartSpec() // 스텟을 정하는 함수
    {
        entity_max_health = Random.Range(40,71);
        entity_strength = Random.Range(10,31);
        entity_mana = Random.Range(3,6);
        entity_avoid = Random.Range(50,101);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
