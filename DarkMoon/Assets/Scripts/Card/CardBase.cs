using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBase : MonoBehaviour
{
    public enum ClassType   // 각 카드에 저장 될 직업 종류
    {
        Mage,               // 마법사
        Priest,             // 사제
        Rogue,              // 도적
        Warrior,            // 전사
        Normal              // 일반
    }

    public string card_name;        // 카드 이름
    public int card_cost;           // 카드 비용
    public string card_content;     // 카드 내용
    public ClassType class_type;    // 직업 카드 정보
    private int target_entitiy_position;
    
    public List<Tuple<SimpleTask, int>> card_task = new List<Tuple<SimpleTask, int>>();     // simple task가 저장 될 list

    FieldManager current_field;     // 현재 field manager를 scene에서 찾아서 저장

    TextMeshPro card_cost_text;     // 카드 비용을 display 할 tmpro
    TextMeshPro card_name_text;     // 카드 이름을 display 할 tmpro
    TextMeshPro card_content_text;  // 카드 내용을 display 할 tmpro

    public bool is_active_card;
    public Vector2 target_position;
    float draw_speed = 10f;

    public virtual void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();   // field manager를 scene에서 찾음

        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();      // 게임 데이터 가져옴
        Dictionary<string, string> card = game_data.card_list[0];
        card_name = card["card_name"];
        card_cost = int.Parse(card["card_cost"]);
        card_content = card["card_content"];

        target_position = transform.position;
    }
    protected void SetCardText()    // 카드 text를 설정하는 함수
    {
        if (transform.childCount <= 0)  // 자식이 없다면 text 표시가 안되기 때문에 에러 반환
        {
            Debug.Assert(transform.childCount < 0, "Can't Find Card Text");
            return;
        }
        // 아래는 각 text 저장 후 display
        card_cost_text = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        card_cost_text.text = card_cost.ToString();

        card_name_text = transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
        card_name_text.text = card_name;

        card_content_text = transform.GetChild(2).gameObject.GetComponent<TextMeshPro>();
        card_content_text.text = card_content;
    }
    public virtual void UseCard()   // 카드의 기능을 차례로 사용하는 함수
    {
        if(current_field.current_energy >= card_cost)   // 에너지가 비용보다 많거나 같다면
        {
            current_field.current_energy -= card_cost;  // 비용만큼 에너지 소비

            foreach (Tuple<SimpleTask, int> task in card_task) // task가 들어있는 list에서 각 task 꺼냄
            {
                task.Item1.Task(target_entitiy_position, task.Item2);          // 타겟 위치에 task 실행
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
                    if (hit.collider.gameObject == current_field.enemy_entity[0].gameObject)
                    {
                        target_entitiy_position = 0;
                        UseCard();
                    }
                    else if (hit.collider.gameObject == current_field.enemy_entity[1].gameObject)
                    {
                        target_entitiy_position = 1;
                        UseCard();
                    }
                    else if (hit.collider.gameObject == current_field.enemy_entity[2].gameObject)
                    {
                        target_entitiy_position = 2;
                        UseCard();
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
