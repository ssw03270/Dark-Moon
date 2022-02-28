using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    public List<PlayerEntityData> player_data_list;
    public PlayerList playerList = new PlayerList();
    public TextAsset player_list_JSON;

    private int player_count;

    private void Awake()
    {
        playerList = JsonUtility.FromJson<PlayerList>(player_list_JSON.text); // 플레이어 리스트 정보 불러오기
        
        if(playerList.playerEntityData != null)
        {
            for (int i = 0; i < playerList.playerEntityData.Length; ++i)
            {
                player_data_list.Add(playerList.playerEntityData[i]);
            }

            player_count = playerList.playerEntityData.Length;
        }
        
    }

}
