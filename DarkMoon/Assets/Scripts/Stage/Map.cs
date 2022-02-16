using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public bool is_first_play;  // 현재 map에서 첫번째 플레이인지 판단하는 변수
    public GameObject StageMenu = null;  // back을 눌렀을 때 되돌아갈 StageMenu UI
    public GameObject CurrentPlay = null;  // 현재 진행중인 play를 저장


    StageMenu stage_menu;

    void Awake(){
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
    }

    public void BtnBack(){  // Btn_Back을 눌렀을 때 실행되는 함수

        this.gameObject.SetActive(false);  // 현재 UI는 비활성화


        // 스테이지 해금 -> stage를 클리어했을 때 실행될 코드
        Button NextStage = stage_menu.StageBtn[stage_menu.current_stage]; // 다음 스테이지의 button을 가져옴
        NextStage.GetComponent<StageBtn>().can_play_stage = true;  // can_play_stage를 true로 바꾸어 접근가능하도록 설정

        Button bt = NextStage;  // 스테이지 해금됐을 때 색 바뀌도록
        ColorBlock colorBlock = bt.colors;
        colorBlock.normalColor = new Color(1f,1f,1f); 
        bt.colors = colorBlock;

    }

}
