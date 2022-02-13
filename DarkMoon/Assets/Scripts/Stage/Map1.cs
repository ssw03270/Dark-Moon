using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map1 : MonoBehaviour
{

    public bool is_first_play;  // 현재 map에서 첫번째 플레이인지 판단하는 변수
    public GameObject StageMenu = null;  // back을 눌렀을 때 되돌아갈 StageMenu UI
    public GameObject now_play = null;  // 현재 진행중인 play를 저장


    StageMenu stage_menu;

    void Start(){
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
    }

    public void BtnBack(){  // Btn_Back을 눌렀을 때 실행되는 함수

        StageMenu.SetActive(true);   // StageMenu UI는 활성화
        this.gameObject.SetActive(false);  // 현재 UI는 비활성화

        // 스테이지 해금
        stage_menu.can_play_stage2 = true;

        Button bt = stage_menu.btn_st2;  // 스테이지 해금됐을 때 색 바뀌도록, 나중에 보스전 clear했을 때 위치로 이동
        ColorBlock colorBlock = bt.colors;
        colorBlock.normalColor = new Color(1f,1f,1f); 
        bt.colors = colorBlock;

    }


}
