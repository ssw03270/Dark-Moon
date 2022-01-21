using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public GameObject goMap1 = null;  // Btn_St1 을 클릭했을 때 이동해야할 UI를 오브젝트로 받음
    public GameObject goMap2 = null;
    public Button btn_st1;
    public bool can_play_stage1 = true;  // stage1을 플레이할 수 있는 상태인지 체크할 수 있는 bool 변수
                                            //(다른 stage의 경우, 이전 stage의 보스전을 클리어 했을 때 true가 되도록 할 예정)
    public bool can_play_stage2 = false;


    public void BtnSt1(){   // Btn_St1을 클릭했을 때 실행되는 함수

        if(can_play_stage1){   // 해금이 된 스테이지일 경우
            goMap1.SetActive(true);  // 해당 map UI를 활성화 하고 
            this.gameObject.SetActive(false);   // 현재 UI는 비활성화
        }
    }
    public void BtnSt2(){   // Btn_St1을 클릭했을 때 실행되는 함수

        if(can_play_stage2){   // 해금이 된 스테이지일 경우
            goMap2.SetActive(true);  // 해당 map UI를 활성화 하고 
            this.gameObject.SetActive(false);   // 현재 UI는 비활성화
        }
    }

    
}
