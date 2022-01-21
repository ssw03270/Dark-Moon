using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBase : MonoBehaviour
{
    public enum ClassType   // �� ī�忡 ���� �� ���� ����
    {
        Mage,               // ������
        Priest,             // ����
        Rogue,              // ����
        Warrior,            // ����
        Normal              // �Ϲ�
    }

    public string card_name;        // ī�� �̸�
    public int card_cost;           // ī�� ���
    public string card_content;     // ī�� ����
    public ClassType class_type;    // ���� ī�� ����
    
    public List<Tuple<SimpleTask, int>> card_task = new List<Tuple<SimpleTask, int>>();     // simple task�� ���� �� list

    FieldManager current_field;     // ���� field manager�� scene���� ã�Ƽ� ����

    TextMeshPro card_cost_text;     // ī�� ����� display �� tmpro
    TextMeshPro card_name_text;     // ī�� �̸��� display �� tmpro
    TextMeshPro card_content_text;  // ī�� ������ display �� tmpro

    public Vector2 target_position;
    float draw_speed = 10f;

    public virtual void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();   // field manager�� scene���� ã��

        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();      // ���� ������ ������
        Dictionary<string, string> card = game_data.card_list[0];
        card_name = card["card_name"];
        card_cost = int.Parse(card["card_cost"]);
        card_content = card["card_content"];

        target_position = transform.position;
    }
    protected void SetCardText()    // ī�� text�� �����ϴ� �Լ�
    {
        if (transform.childCount <= 0)  // �ڽ��� ���ٸ� text ǥ�ð� �ȵǱ� ������ ���� ��ȯ
        {
            Debug.Assert(transform.childCount < 0, "Can't Find Card Text");
            return;
        }
        // �Ʒ��� �� text ���� �� display
        card_cost_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        card_cost_text.text = card_cost.ToString();

        card_name_text = transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
        card_name_text.text = card_name;

        card_content_text = transform.GetChild(2).gameObject.GetComponent<TextMeshPro>();
        card_content_text.text = card_content;
    }
    public virtual void UseCard()   // ī���� ����� ���ʷ� ����ϴ� �Լ�
    {
        if(current_field.current_energy >= card_cost)   // �������� ��뺸�� ���ų� ���ٸ�
        {
            current_field.current_energy -= card_cost;  // ��븸ŭ ������ �Һ�

            int target_position = SelectTarget();       // Ÿ�� ����
            foreach (Tuple<SimpleTask, int> task in card_task) // task�� ����ִ� list���� �� task ����
            {
                task.Item1.Task(target_position, task.Item2);          // Ÿ�� ��ġ�� task ����
            }
        }
    }
    public virtual int SelectTarget()       // Ÿ�� �����ϴ� �Լ�
    {
        int target_position = 0;            

        return target_position;
    }

    protected virtual void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target_position, Time.deltaTime * draw_speed);
    }
}
