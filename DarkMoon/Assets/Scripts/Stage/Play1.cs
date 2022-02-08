using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1 : MonoBehaviour
{
    
     public void BtnBack_Test(){  // test용 back button

        Destroy(this.gameObject);

        GameObject now = GameObject.Find("Map1").GetComponent<Map1>().now_play;
        now.GetComponent<PlayBtn>().StateUpdate1();
        // can_play 업데이트 되도록, 색 바꾸기

        GameObject.Find("Map1").GetComponent<Map1>().is_first_play = false;

    }
}
