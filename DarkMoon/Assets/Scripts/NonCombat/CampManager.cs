using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    public List<PlayerEntityData> player_data_list;     // 용병 리스트
    public PlayerList playerList = new PlayerList();    // JSON 변환용
    public TextAsset player_list_JSON;

    public RectTransform camp_ui; // 캠프 UI
    public RectTransform camp_slots; // 캠프 슬롯 부모

    public int player_count;   // 용병 수

    private void Awake()
    {
        PlayerListLoadFromJSON();

        CampDisplay();
        
    }

    public void CampEnterButton()
    {
        //camp_ui.gameObject.SetActive(true);
        CampDisplay();

        camp_ui.anchoredPosition = Vector3.zero;
    }

    public void CampExitButton()
    {
        camp_ui.anchoredPosition = Vector3.right * 2000; // 안 보이게 갖다 놓기
        //camp_ui.gameObject.SetActive(false);
    }


    // 리스트 참조해서 플레이어 수 만큼 버튼 활성화하고 정보 넣기
    public void CampDisplay()
    {
        //PlayerListLoadFromJSON();

        for (int i = 0; i < player_count; ++i)
        {
            camp_slots.GetChild(i).gameObject.SetActive(true);

            camp_slots.GetChild(i).GetComponent<CampDisplay>().player_entity_data = playerList.playerEntityData[i];

            camp_slots.GetChild(i).GetComponent<CampDisplay>().Display();
        }
    }

    public void PlayerListLoadFromJSON()
    // 플레이어 리스트 JSON으로부터 불러오기
    {
        
        playerList = JsonUtility.FromJson<PlayerList>(player_list_JSON.text); // 플레이어 리스트 정보 불러오기
        
        if(playerList.playerEntityData != null)
        {
            for (int i = 0; i < playerList.playerEntityData.Length; ++i)
            {
                player_data_list.Add(playerList.playerEntityData[i]);   // 불러온 정보 리스트에 넣기
            }

            player_count = playerList.playerEntityData.Length;
        }
    }

    public void CheckPlayerListJSON()
    // 디버깅 버튼용 (임시)
    {
        playerList = JsonUtility.FromJson<PlayerList>(player_list_JSON.text);

        Debug.Log("playerList Length: " + playerList.playerEntityData.Length);
    }

}
