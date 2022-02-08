using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public GameObject GoMap1 = null;  // Btn_St1 을 클릭했을 때 이동해야할 UI를 오브젝트로 받음
    public GameObject GoMap2 = null;
    public GameObject PrefabLockedText; // 해금되지 않은 stage 클릭 시 띄워지는 text의 prefab
    public Button btn_st2;
    public Button btn_st3;

    public bool can_play_stage1 = true;  // stage1을 플레이할 수 있는 상태인지 체크할 수 있는 bool 변수
                                            //(다른 stage의 경우, 이전 stage의 보스전을 클리어 했을 때 true가 되도록 할 예정)
    public bool can_play_stage2 = false;
    public bool can_play_stage3 = false;
    public bool can_play_stage4 = false;
    public bool can_play_stage5 = false;
    public bool can_play_stage6 = false;
    public bool can_play_stage7 = false;

    public void BtnSt1(){   // Btn_St1을 클릭했을 때 실행되는 함수

        if(can_play_stage1){   // 해금이 된 스테이지일 경우
            GoMap1.SetActive(true);  // 해당 map UI를 활성화 하고
            this.gameObject.SetActive(false);   // 현재 UI는 비활성화
        }
        
    }
    public void BtnSt2(){   // Btn_St1을 클릭했을 때 실행되는 함수

        if(can_play_stage2){   // 해금이 된 스테이지일 경우
            GoMap2.SetActive(true);  // 해당 map UI를 활성화 하고 
            this.gameObject.SetActive(false);   // 현재 UI는 비활성화
        }
        else{ // 잠겨 있는 stage일 경우 'unlocked' 문구를 표시

            var clone = Instantiate(PrefabLockedText, btn_st2.transform.position + new Vector3(0 ,40 ,0), Quaternion.Euler(Vector3.zero)); // prefeb 객체 생성
            clone.transform.SetParent(this.transform);  // 현재 UI를 부모로 두도록 함
        }
    }

    
}
