using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMenu : MonoBehaviour
{
    public GameObject goMap1 = null;
    public bool can_play_stage1 = true;

    public void BtnSt1(){

        if(can_play_stage1){
            goMap1.SetActive(true);
            this.gameObject.SetActive(false);   
        }
        
    }
}
