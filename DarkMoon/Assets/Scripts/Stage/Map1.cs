using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map1 : MonoBehaviour
{
    public GameObject StageMenu = null;  // back을 눌렀을 때 되돌아갈 StageMenu UI
    Button bt;

    public void BtnBack(){  // Btn_Back을 눌렀을 때 실행되는 함수

        StageMenu.SetActive(true);   // StageMenu UI는 활성화
        this.gameObject.SetActive(false);  // 현재 UI는 비활성화

        // 스테이지 해금
        GameObject.Find("StageMenu").GetComponent<StageMenu>().can_play_stage2 = true;

        bt = GameObject.Find("StageMenu").GetComponent<StageMenu>().btn_st2;  // 스테이지 해금됐을 때 색 바뀌도록, 나중에 보스전 clear했을 때 위치로 이동
        ColorBlock colorBlock = bt.colors;
        colorBlock.normalColor = new Color(1f,1f,1f); 
        bt.colors = colorBlock;

    }
}
