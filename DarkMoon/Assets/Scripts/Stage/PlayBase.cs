using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBase : MonoBehaviour
{

    public List<Button> near_button = new List<Button>();  // 인접한 칸(button)을 담은 list
    public bool can_play;  // 접근할 수 있는 칸인지 판단하는 변수

    public GameObject PrefabPlay1;  // play될 임시 UI 프리팹
    public Map1 current_map;  // 현재 플레이 중인 map

    protected void Awake()
    {
        current_map = GameObject.Find("Map1").GetComponent<Map1>();
    }
    
    public virtual void Play(){  // 칸을 클릭할 때 실행되는 함수 
            
        if(can_play){
            GameObject Play1 =  Instantiate(PrefabPlay1) as GameObject;  // 미리 설정된 프리팹 인스턴스화
            Play1.transform.SetParent(GameObject.Find("Stage").transform);  // stage의 자식객체로 설정

            current_map.now_play = EventSystem.current.currentSelectedGameObject;  // now_play에 할당하여 현재 실행중인 play를 저장
        }
    }

    public virtual void StateUpdate(){  //  play를 클리어할 때 실행되는 함수 
        
        for(int i = 0; i<near_button.Count; i++){  // 인접한 칸들을 접근 가능한 상태로 변경

            PlayBtn playbtn = near_button[i].GetComponent<PlayBtn>();  // 각 칸의 PlayBtn 스크립트에 접근하기 위하여 미리 선언해둠

            playbtn.can_play = true;  // 접근 가능한 상태로 변경

            ColorBlock colorBlock = near_button[i].colors;  // 색을 흰색으로 변경
            colorBlock.normalColor = new Color(1f,1f,1f); 
            near_button[i].colors = colorBlock;

        }
    }

    
}
