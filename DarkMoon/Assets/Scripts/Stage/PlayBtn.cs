using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBtn : PlayBase  // map에서 진행되는 전투, 비전투 관련 script
{

 
    public override void Play(){  // 칸을 클릭할 때 실행되는 함수 

        if(current_map.is_first_play){   // 현재 map에서 첫번째 플레이일 경우, 아무 곳에서나 시작 가능
            can_play = true;  // 접근 가능한 칸으로 변경
            base.Play();

            ColorBlock colorBlock = current_map.now_play.GetComponent<Button>().colors;  // 버튼 흰색으로 변경
            colorBlock.normalColor = new Color(1f,1f,1f); 
            current_map.now_play.GetComponent<Button>().colors = colorBlock;

        }
        else{
            base.Play();
        }
        
    }


    public override void StateUpdate(){  //  play를 클리어할 때 실행되는 함수 
        base.StateUpdate();
    }
    
}
