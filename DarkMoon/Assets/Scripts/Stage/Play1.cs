using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1 : MonoBehaviour
{

    public void BtnBack_Test(){  // test용 back button

        Map map = transform.parent.gameObject.GetComponent<Map>();
        StageMenu stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
        Destroy(this.gameObject);

        map.CurrentPlay.GetComponent<PlayBtn>().StateUpdate();
        
        if(map.CurrentPlay.tag == "Boss"){
            stage_menu.StageBtn[stage_menu.current_stage-1].GetComponent<StageBtn>().cleared_stage = true; // 현재 스테이지 button의 cleared_stage변수를 true로 설정
        }

        map.is_first_play = false;


    }
}
