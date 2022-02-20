using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrying : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 5;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_guard = new Tuple<SimpleTask, int>(new SimpleGuard(), 10);
        card_task.Add(simple_guard);
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
                task.Item1.Task(true, current_field.current_player_number, task.Item2);          // 타겟 위치에 task 실행
            }
            current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);
        }
    }
}
