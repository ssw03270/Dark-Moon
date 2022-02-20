using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 1;
        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_damage = new Tuple<SimpleTask, int>(new SimpleDamage(), 6);
        card_task.Add(simple_damage);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void UseCard()   // 카드의 기능을 차례로 사용하는 함수
    {
        if (current_field.current_energy >= card_cost)   // 에너지가 비용보다 많거나 같다면
        {
            current_field.current_energy -= card_cost;  // 비용만큼 에너지 소비

            foreach (Tuple<SimpleTask, int> task in card_task) // task가 들어있는 list에서 각 task 꺼냄
            {
                for(int i = 0; i < current_field.enemy_entity.Length; i++)
                {
                    if(current_field.enemy_entity[i] != null)
                        task.Item1.Task(false, i, task.Item2);          // 타겟 위치에 task 실행
                }
            }
            current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);

        }
    }
}
