using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : PlayBase
{
    public override void PlayClear(){  // 버튼을 클릭하면 해당 play를 클리어한 것으로 간주

        Button NextStage = stage_menu.StageBtn[stage_menu.current_stage]; // 다음 스테이지의 button을 가져옴
        NextStage.GetComponent<StageBtn>().can_play_stage = true;  // can_play_stage를 true로 바꾸어 접근가능하도록 설정
        stage_menu.StageBtn[stage_menu.current_stage-1].GetComponent<StageBtn>().cleared_stage = true;  // 현재 stage를 clear된 상태로 변경

        Button bt = NextStage;  // 스테이지 해금됐을 때 색 바뀌도록
        ColorBlock colorBlock = bt.colors;
        colorBlock.normalColor = new Color(1f,1f,1f); 
        bt.colors = colorBlock;

        base.PlayClear();

    }

    public override void PlayDead(){  // play에서 사망하였을 때 실행되는 함수

        base.PlayDead();
    }
}
