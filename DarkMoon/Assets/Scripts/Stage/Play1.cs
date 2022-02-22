using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Play1 : MonoBehaviour
{
    StageMenu stage_menu;

    void Awake(){
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
    }

    public void Play_Clear(){  // 버튼을 클릭하면 해당 play를 클리어한 것으로 간주
        
        Destroy(this.gameObject);

        Map map = transform.parent.gameObject.GetComponent<Map>();
        map.CurrentPlay.GetComponent<PlayBtn>().StateUpdate();

        if(map.CurrentPlay.tag == "Boss"){

            // 스테이지 해금
            Button NextStage = stage_menu.StageBtn[stage_menu.current_stage]; // 다음 스테이지의 button을 가져옴
            NextStage.GetComponent<StageBtn>().can_play_stage = true;  // can_play_stage를 true로 바꾸어 접근가능하도록 설정
            stage_menu.StageBtn[stage_menu.current_stage-1].GetComponent<StageBtn>().cleared_stage = true;  // 현재 stage를 clear된 상태로 변경

            Button bt = NextStage;  // 스테이지 해금됐을 때 색 바뀌도록
            ColorBlock colorBlock = bt.colors;
            colorBlock.normalColor = new Color(1f,1f,1f); 
            bt.colors = colorBlock;
    
        }

        map.is_first_play = false;

    }

    public void Play_Dead(){  // play에서 사망하였을 때 실행되는 함수
        Destroy(this.gameObject);
        Destroy(GameObject.Find("Map"+stage_menu.current_stage)); // 현재 map을 destroy

        Debug.Log("사망하였습니다");
    }
}
