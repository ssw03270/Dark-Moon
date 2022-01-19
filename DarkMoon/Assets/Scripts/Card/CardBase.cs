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

    public List<SimpleTask> card_task = new List<SimpleTask>();     // simple task가 저장 될 list

    FieldManager current_field;                                     // 현재 field manager를 scene에서 찾아서 저장

    TextMeshPro card_cost_text;     // 카드 비용을 display 할 tmpro
    TextMeshPro card_name_text;     // 카드 이름을 display 할 tmpro
    TextMeshPro card_content_text;  // 카드 내용을 display 할 tmpro

    private void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();   // field manager를 scene에서 찾음
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

            int target_position = SelectTarget();       // 타겟 설정
            foreach (SimpleTask task in this.card_task) // task가 들어있는 list에서 각 task 꺼냄
            {
                task.Task(target_position, 1);          // 타겟 위치에 task 실행
            }
        }
    }
    public virtual int SelectTarget()       // 타겟 선택하는 함수
    {
        int target_position = 0;            

        return target_position;
    }

}
