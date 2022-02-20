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

    public enum TargetType
    {
        Player,             // �÷��̾ �����ϴ� ī��
        Enemy               // ���� �����ϴ� ī��
    }

    public int card_number;         // ī�� ��ȣ
    public string card_name;        // ī�� �̸�
    public int card_cost;           // ī�� ���
    public string card_content;     // ī�� ����
    public ClassType class_type;    // ���� ī�� ����
    public TargetType target_type; // Ÿ�� ����
    public int target_entitiy_position;  // Ÿ�� ��ġ
    
    public List<Tuple<SimpleTask, int>> card_task = new List<Tuple<SimpleTask, int>>();     // simple task�� ���� �� list

    protected FieldManager current_field;     // ���� field manager�� scene���� ã�Ƽ� ����

    TextMeshPro card_cost_text;     // ī�� ����� display �� tmpro
    TextMeshPro card_name_text;     // ī�� �̸��� display �� tmpro
    TextMeshPro card_content_text;  // ī�� ������ display �� tmpro

    public bool is_active_card;
    public Vector2 target_position;
    float draw_speed = 10f;

    public virtual void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();   // field manager�� scene���� ã��

        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();      // ���� ������ ������
        Dictionary<string, string> card = game_data.card_list[card_number];
        card_name = card["card_name"];
        card_cost = int.Parse(card["card_cost"]);
        card_content = card["card_content"];

        switch (card["class_type"])
        {
            case "Mage":
                class_type = ClassType.Mage;
                break;
            case "Priest":
                class_type = ClassType.Priest;
                break;
            case "Rogue":
                class_type = ClassType.Rogue;
                break;
            case "Warrior":
                class_type = ClassType.Warrior;
                break;
            case "Normal":
                class_type = ClassType.Normal;
                break;
        }

        switch (card["target_type"])
        {
            case "Player":
                target_type = TargetType.Player;
                break;
            case "Enemy":
                target_type = TargetType.Enemy;
                break;
        }

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

            foreach (Tuple<SimpleTask, int> task in card_task) // task�� ����ִ� list���� �� task ����
            {
                task.Item1.Task(target_entitiy_position, task.Item2);          // Ÿ�� ��ġ�� task ����
            }
            current_field.player_entity[current_field.current_player_number].HandToDiscardPile(this.gameObject);

        }
    }

    protected void Active()
    {
        if (is_active_card)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouse_position_2d = new Vector2(mouse_position.x, mouse_position.y);

                RaycastHit2D hit = Physics2D.Raycast(mouse_position_2d, Vector2.zero);
                if (hit.collider != null)
                {
                    if(target_type == TargetType.Enemy)
                    {
                        for (int i = 0; i < current_field.enemy_entity.Length; i++)
                        {
                            if (current_field.enemy_entity[i] != null)
                            {
                                if (hit.collider.gameObject == current_field.enemy_entity[i].gameObject)
                                {
                                    target_entitiy_position = i;
                                    UseCard();
                                }
                            }
                        }
                    }
                    else if (target_type == TargetType.Player)
                    {
                        for (int i = 0; i < current_field.player_entity.Length; i++)
                        {
                            if (current_field.player_entity[i] != null)
                            {
                                if (hit.collider.gameObject == current_field.player_entity[i].gameObject)
                                {
                                    target_entitiy_position = i;
                                    UseCard();
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected virtual void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target_position + (is_active_card ? new Vector2(this.transform.up.x, this.transform.up.y) : new Vector2(0, 0)), Time.deltaTime * draw_speed);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_position_2d = new Vector2(mouse_position.x, mouse_position.y);

            RaycastHit2D hit = Physics2D.Raycast(mouse_position_2d, Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    is_active_card = !is_active_card;
                    if (is_active_card)
                    {
                        foreach(GameObject card in current_field.player_entity[current_field.current_player_number].hand_gameobject)
                        {
                            if(card != this.gameObject)
                            {
                                card.GetComponent<CardBase>().is_active_card = false;
                            }
                        }
                        
                    }
                }
            }
        }

        Active();
    }
}
