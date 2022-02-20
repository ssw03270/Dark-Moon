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

    public override void UseCard()   // ī���� ����� ���ʷ� ����ϴ� �Լ�
    {
        if (current_field.current_energy >= card_cost)   // �������� ��뺸�� ���ų� ���ٸ�
        {
            current_field.current_energy -= card_cost;  // ��븸ŭ ������ �Һ�
            foreach (Tuple<SimpleTask, int> task in card_task) // task�� ����ִ� list���� �� task ����
            {
                task.Item1.Task(true, current_field.current_player_number, task.Item2);          // Ÿ�� ��ġ�� task ����
            }
            current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);
        }
    }
}
