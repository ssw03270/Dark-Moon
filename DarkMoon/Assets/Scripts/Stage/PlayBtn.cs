using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBtn : PlayBase
{

 
    public override void Play(){

        if(current_map.is_first_play){
            can_play = true;
            base.Play();

            ColorBlock colorBlock = current_map.now_play.GetComponent<Button>().colors;
            colorBlock.normalColor = new Color(1f,1f,1f); 
            current_map.now_play.GetComponent<Button>().colors = colorBlock;

        }
        else{
            base.Play();
        }
        
    }


    public override void StateUpdate1(){
        base.StateUpdate1();
    }
    
}
