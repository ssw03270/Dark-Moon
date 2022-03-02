using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : EntityBase
{
    public int enemy_damage;    // 적이 기본 공격을 할 때 데미지
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
        foreach (Tuple<SimpleTask, int> task in enemy_task) // task가 들어있는 list에서 각 task 꺼냄
        {
            task.Item1.Task(true, UnityEngine.Random.Range(0, 3), task.Item2);          // 타겟 위치에 task 실행
        }
    }
}
