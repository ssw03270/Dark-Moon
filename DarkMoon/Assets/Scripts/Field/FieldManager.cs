using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // battle ground
    public PlayerEntity[] player_entity = new PlayerEntity[3];      // �÷��̾� ���� ĳ���� ����� array
    public EntityBase[] enemy_entity = new EntityBase[4];           // �� ���� ĳ���� ����� array

    public int current_player_number = 0;                           // ���� Ȱ��ȭ�� �÷��̾� ���� ĳ���� ��ȣ

    public int hand_max_count = 5;                                  // �⺻ �ִ� ����

    public int max_energy = 3;                                      // �⺻ �ִ� ������
    public int current_energy = 3;                                  // ���� ������

    public bool is_player_turn = false;                             // �÷��̾� ���̸� true, �ƴϸ� false

    // end game
    public CardBase[] get_card_list = new CardBase[3];              // ������ ���� ��, �÷��̾ ��� �� ī�� ���� 3��

    private void Start()
    {
        NextTurn();     // �÷��̾� ���ʺ��� ����
    }

    // battle ground
    public void NextTurn()
    {
        if (is_player_turn)     // �÷��̾� ���ʿ��ٸ� �� ���ʷ� ����
        {
            is_player_turn = false;

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].HandToDiscardPile(player_entity[i].hand.Count);    // ���и� ���� ī�� ���̷� �ű�
            }  
        }
        else    // �� ���ʿ��ٸ� �÷��̾� ���ʷ� ����
        {
            is_player_turn = true;
            current_energy = max_energy;        // �������� �ִ�� ����

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].DeckToHand(hand_max_count);        // ������ ���з� ī�带 ������
            }
        }
    }

    // end game
    public void GetRandomCards()        // ���� ��, ī�� ���� ȹ�� �Լ�
    {
        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();      // ���� ������ ������

        for(int i = 0; i < 3; i++)
        {
            int random_number = Random.Range(0, game_data.card_list.Count);             // ������ ī�� ����
            string card_name = game_data.card_list[random_number]["card_name"];         // �������� ���õ� ī�� �̸�
            string path = Application.dataPath + "/Prefab/" + card_name + ".prefab";    // �ش� ī���� ��ġ ��ȯ

            get_card_list[i] = PrefabUtility.LoadPrefabContents(path).GetComponent<CardBase>();     // �ش� ī���� prefab ���� ����
            
            //Instantiate(get_card_list[i]);
        }
    }
    public void GetRandomGold()        // ���� ��, ��� ���� ȹ�� �Լ�
    {

    }
    public void GetRandomEXP()        // ���� ��, ����ġ ���� ȹ�� �Լ�
    {

    }
}
