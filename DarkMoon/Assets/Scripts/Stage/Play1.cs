using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1 : MonoBehaviour
{

    public void BtnBack_Test(){  // test용 back button

        Map map = transform.parent.gameObject.GetComponent<Map>();
        Destroy(this.gameObject);

        map.CurrentPlay.GetComponent<PlayBtn>().StateUpdate();
        // can_play 업데이트 되도록, 색 바꾸기

        map.is_first_play = false;

    }
}
