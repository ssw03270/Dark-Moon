using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBase : MonoBehaviour  // map에서 진행되는 play 관련 script
{

    public List<Button> near_button = new List<Button>();  // 인접한 칸(button)을 담은 list
    public bool can_play;  // 접근할 수 있는 칸인지 판단하는 변수


    public GameObject PrefabPlay1;  // play될 임시 UI 프리팹
    public Map current_map;  // 현재 플레이 중인 map

    protected void Awake()
    {
        current_map = transform.parent.gameObject.GetComponent<Map>();  // 현재 객체의 부모(Map)의 정보 가져옴
    }
 
    public virtual void Play(){  // 칸을 클릭할 때 실행되는 함수 
            
        if(can_play){

            GameObject current_button = EventSystem.current.currentSelectedGameObject;

            if(current_button.tag == "Battle"){
                GameObject Play1 =  Instantiate(current_map.PlayPrefab[0]) as GameObject;  // 미리 설정된 프리팹 인스턴스화
                Play1.transform.SetParent(current_map.transform);  // 현재 map의 자식객체로 설정
            }
            else if(current_button.tag == "Treasure"){
                GameObject Play1 =  Instantiate(current_map.PlayPrefab[1]) as GameObject; 
                Play1.transform.SetParent(current_map.transform);  
            }
            else if(current_button.tag == "Trap"){
                GameObject Play1 =  Instantiate(current_map.PlayPrefab[2]) as GameObject;  
                Play1.transform.SetParent(current_map.transform);  
            }
            else if(current_button.tag == "Boss"){
                GameObject Play1 =  Instantiate(current_map.PlayPrefab[4]) as GameObject;  
                Play1.transform.SetParent(current_map.transform);  
            }
            else {
                GameObject Play1 =  Instantiate(current_map.PlayPrefab[3]) as GameObject;  
                Play1.transform.SetParent(current_map.transform);  
            }

            current_map.CurrentPlay = current_button;  // now_play에 할당하여 현재 실행중인 play를 저장
        }
    }

    public virtual void StateUpdate(){  //  play를 클리어할 때 실행되는 함수 
        
        for(int i = 0; i<near_button.Count; i++){  // 인접한 칸들을 접근 가능한 상태로 변경

            Button playbtn = near_button[i];  // 각 칸의 PlayBtn 스크립트에 접근하기 위하여 미리 선언해둠

            playbtn.GetComponent<PlayBtn>().can_play = true;  // 접근 가능한 상태로 변경

            ColorBlock colorBlock = playbtn.colors;  // 색 변경
            if(playbtn.tag == "Boss")
                colorBlock.normalColor = new Color(1f,0f,0f);
            else
                colorBlock.normalColor = new Color(1f,1f,1f);
            playbtn.colors = colorBlock;

        }
    }
    
}
