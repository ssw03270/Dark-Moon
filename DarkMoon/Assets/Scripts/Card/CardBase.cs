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

    public List<SimpleTask> card_task = new List<SimpleTask>();     // simple task�� ���� �� list

    FieldManager current_field;                                     // ���� field manager�� scene���� ã�Ƽ� ����

    TextMeshPro card_cost_text;     // ī�� ����� display �� tmpro
    TextMeshPro card_name_text;     // ī�� �̸��� display �� tmpro
    TextMeshPro card_content_text;  // ī�� ������ display �� tmpro

    private void Awake()
    {
        current_field = GameObject.Find("FieldManager").GetComponent<FieldManager>();   // field manager�� scene���� ã��
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
            foreach (SimpleTask task in this.card_task) // task�� ����ִ� list���� �� task ����
            {
                task.Task(target_position, 1);          // Ÿ�� ��ġ�� task ����
            }
        }
    }
    public virtual int SelectTarget()       // Ÿ�� �����ϴ� �Լ�
    {
        int target_position = 0;            

        return target_position;
    }

}
