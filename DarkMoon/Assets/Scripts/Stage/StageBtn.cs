using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBtn : MonoBehaviour  // 각 stage button에 적용되는 script
{

    public int stage_number;  // 몇 번째 stage인지 판단하는 변수
    public bool can_play_stage;  // 접근할 수 있는 stage인지 판단하는 변수
    public bool cleared_stage;  // 이미 클리어한 stage인지 판단 -> clear 했다면 이미 생성된 map 불러오기
    public GameObject PrefabLockedText; // 해금되지 않은 stage 클릭 시 띄워지는 text의 prefab

    StageMenu stagemenu;

    void Awake()
    {
        stagemenu = transform.parent.gameObject.GetComponent<StageMenu>();
    }

    public void BtnSt()  // 버튼을 클릭할 때 실행
    {

        if(can_play_stage){   // 해금이 된 스테이지일 경우 map을 생성
            int map_index = Random.Range(0, stagemenu.MapPrefab.Length);  // 랜덤하게 index 선정
            GameObject Map1 =  Instantiate(stagemenu.MapPrefab[map_index]) as GameObject;  // stagemenu에 저장된 map prefab을 인스턴스화
            Map1.name = "Map" + stage_number;  // 오브젝트의 이름을 "Map" + 현재 스테이지 번호로 설정
            Map1.transform.SetParent(GameObject.Find("Map").transform);  // Map(빈 오브젝트)의 자식 객체로 설정

            stagemenu.current_stage = stage_number;

        }
        else{ // 잠겨 있는 stage일 경우 'unlocked' 문구를 표시

            var clone = Instantiate(PrefabLockedText, this.transform.position + new Vector3(0 ,40 ,0), Quaternion.Euler(Vector3.zero)); // prefeb 객체 생성
            clone.transform.SetParent(this.transform);  // 현재 버튼의 자식객체로 설정
        }
    }
}
