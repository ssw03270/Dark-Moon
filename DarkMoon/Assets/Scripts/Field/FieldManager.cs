using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // battle ground
    public PlayerEntity[] player_entity = new PlayerEntity[3];      // 플레이어 진영 캐릭터 저장된 array
    public EntityBase[] enemy_entity = new EntityBase[4];           // 적 진영 캐릭터 저장된 array

    public int current_player_number = 0;                           // 현재 활성화된 플레이어 진영 캐릭터 번호

    public int hand_max_count = 5;                                  // 기본 최대 손패

    public int max_energy = 3;                                      // 기본 최대 에너지
    public int current_energy = 3;                                  // 현재 에너지

    public bool is_player_turn = false;                             // 플레이어 턴이면 true, 아니면 false

    // end game
    public CardBase[] get_card_list = new CardBase[3];              // 전투가 끝난 후, 플레이어가 얻게 될 카드 보상 3장

    private void Start()
    {
        NextTurn();     // 플레이어 차례부터 시작
    }

    // battle ground
    public void NextTurn()
    {
        if (is_player_turn)     // 플레이어 차례였다면 적 차례로 변경
        {
            is_player_turn = false;

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].HandToDiscardPile(player_entity[i].hand.Count);    // 손패를 버린 카드 더미로 옮김
            }
        }
        else    // 적 차례였다면 플레이어 차례로 변경
        {
            is_player_turn = true;
            current_energy = max_energy;        // 에너지는 최대로 설정

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].DeckToHand(hand_max_count);        // 덱에서 손패로 카드를 가져옴
            }
        }
    }

    // end game
    public void GetRandomCards()        // 전투 끝, 카드 보상 획득 함수
    {
        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();      // 게임 데이터 가져옴

        for(int i = 0; i < 3; i++)
        {
            int random_number = Random.Range(0, game_data.card_list.Count);             // 무작위 카드 뽑음
            string card_name = game_data.card_list[random_number]["card_name"];         // 무작위로 선택된 카드 이름
            string path = Application.dataPath + "/Prefab/" + card_name + ".prefab";    // 해당 카드의 위치 반환

            get_card_list[i] = PrefabUtility.LoadPrefabContents(path).GetComponent<CardBase>();     // 해당 카드의 prefab 정보 저장
            
            //Instantiate(get_card_list[i]);
        }
    }
    public void GetRandomGold()        // 전투 끝, 골드 보상 획득 함수
    {

    }
    public void GetRandomEXP()        // 전투 끝, 경험치 보상 획득 함수
    {

    }
}
