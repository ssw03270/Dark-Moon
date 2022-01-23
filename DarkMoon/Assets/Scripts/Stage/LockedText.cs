using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedText : MonoBehaviour
{

    private float text_destory_time = 1; 

    void Update()  
    {
        text_destory_time -= Time.deltaTime;  
        
        if(text_destory_time <= 0)
            Destroy(this.gameObject);  // 1초가 지나면 오브젝트를 destory
    }
}
