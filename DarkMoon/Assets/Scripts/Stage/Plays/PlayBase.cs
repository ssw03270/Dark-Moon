using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBase : MonoBehaviour
{

    protected StageMenu stage_menu;

    void Awake()
    {
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
    }

    public virtual void PlayDead()  // 플레이어가 원정을 실패하였을 때
    {
        Destroy(GameObject.Find("Map"+stage_menu.current_stage)); // 현재 map을 destroy
        Destroy(this.gameObject);
        Debug.Log("사망하였습니다");
    }

    public virtual void PlayClear() // 플레이어가 해당 play를 끝냈을 때
    {
        Destroy(this.gameObject);
        Map map = transform.parent.gameObject.GetComponent<Map>();
        PlayBtn playbtn = map.CurrentPlay.GetComponent<PlayBtn>();
        
        map.is_first_play = false;  // 이제 첫 플레이가 아니므로 false로 설정
        playbtn.cleared_play = true;  // 해당 칸을 클리어한 상태로 표시
        playbtn.StateUpdate();
    }
}
