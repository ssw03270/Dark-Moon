using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : EntityBase
{
    public int enemy_damage;    // ���� �⺻ ������ �� �� ������
    public List<Tuple<SimpleTask, int>> enemy_task = new List<Tuple<SimpleTask, int>>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public virtual void EnemyTurn()
    {
        Debug.Log("EnemyTurn");
        foreach (Tuple<SimpleTask, int> task in enemy_task) // task�� ����ִ� list���� �� task ����
        {
            task.Item1.Task(true, UnityEngine.Random.Range(0, 3), task.Item2);          // Ÿ�� ��ġ�� task ����
        }
    }
}
