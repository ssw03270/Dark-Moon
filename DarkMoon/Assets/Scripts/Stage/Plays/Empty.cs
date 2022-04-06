using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empty : PlayBase
{
    private float text_destory_time = 1.5f;  // 1.5초 후 UI destroy

    void Update()
    {
        text_destory_time -= Time.deltaTime;  
        
        if(text_destory_time <= 0){
            
            Map map = transform.parent.gameObject.GetComponent<Map>();

            ColorBlock colorBlock = map.CurrentPlay.GetComponent<Button>().colors;  // 현재 칸의 색 변경
            colorBlock.selectedColor = Color.white;
            map.CurrentPlay.GetComponent<Button>().colors = colorBlock;

            base.PlayClear();
            
        }
    }
    
}
