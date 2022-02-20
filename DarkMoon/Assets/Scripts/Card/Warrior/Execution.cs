using System;
using System.Collections.Generic;
using UnityEngine;

public class Execution : CardBase
{
    // Start is called before the first frame update
    public override void Awake()
    {
        card_number = 2;

        base.Awake();
        base.SetCardText();

        Tuple<SimpleTask, int> simple_damage = new Tuple<SimpleTask, int>(new SimpleDamage(), 9999);
        card_task.Add(simple_damage);
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
            if(current_field.enemy_entity[target_entitiy_position].entity_health < current_field.enemy_entity[target_entitiy_position].entity_max_health / 10)
            {
                current_field.current_energy -= card_cost;  // ��븸ŭ ������ �Һ�
                foreach (Tuple<SimpleTask, int> task in card_task) // task�� ����ִ� list���� �� task ����
                {
                    task.Item1.Task(target_entitiy_position, task.Item2);          // Ÿ�� ��ġ�� task ����
                }
                current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);
            }
        }
    }
}
