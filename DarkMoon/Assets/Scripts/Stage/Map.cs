using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public bool is_first_play;  // 현재 map에서 첫번째 플레이인지 판단하는 변수
    public GameObject StageMenu = null;  // back을 눌렀을 때 되돌아갈 StageMenu UI
    public GameObject CurrentPlay = null;  // 현재 진행중인 칸을 저장
    public List<GameObject> PlayPrefab = new List<GameObject>();
    public List<GameObject> BossList = new List<GameObject>();


    StageMenu stage_menu;

    void Awake(){
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
        BossRoomSelect();
    }

    public void BtnBack(){  // Btn_Back을 눌렀을 때 실행되는 함수

        this.gameObject.SetActive(false);  // 현재 UI는 비활성화


    }
    public void BossRoomSelect(){
        
        int boss_index = Random.Range(0, BossList.Count);
        BossList[boss_index].tag = "Boss";
    }

}
