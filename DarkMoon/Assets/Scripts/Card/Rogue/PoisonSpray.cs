using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpray : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 7;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_poison = new Tuple<SimpleTask, int>(new SimplePoison(), 3);
        card_task.Add(simple_poison);
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
                for (int i = 0; i < current_field.enemy_entity.Length; i++)
                {
                    if (current_field.enemy_entity[i] != null)
                        task.Item1.Task(false, i, task.Item2);          // Ÿ�� ��ġ�� task ����
                }
            }
            current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);

        }
    }
}