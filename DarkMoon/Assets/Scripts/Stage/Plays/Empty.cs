using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empty : MonoBehaviour
{
    private float text_destory_time = 1.5f; 
    StageMenu stage_menu;

    void Awake(){
        stage_menu = GameObject.Find("StageMenu").GetComponent<StageMenu>();
    }

    void Update()
    {
        text_destory_time -= Time.deltaTime;  
        
        if(text_destory_time <= 0){
            Destroy(this.gameObject);  // 1.5초가 지나면 오브젝트를 destory

            Map map = transform.parent.gameObject.GetComponent<Map>();

            ColorBlock colorBlock = map.CurrentPlay.GetComponent<Button>().colors;  // 색 변경
            colorBlock.selectedColor = Color.white;
            map.CurrentPlay.GetComponent<Button>().colors = colorBlock;

            PlayBtn playbtn = map.CurrentPlay.GetComponent<PlayBtn>();
            playbtn.cleared_play = true; // 현재 play에 해당하는 칸을 clear된 상태로 변경
            playbtn.StateUpdate();
            
        }
    }

    
}
