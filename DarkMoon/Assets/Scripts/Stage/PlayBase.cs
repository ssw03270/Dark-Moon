using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBase : MonoBehaviour
{

    public List<Button> near_button = new List<Button>();
    public bool can_play;

    public GameObject PrefabPlay1;
    public Map1 current_map;

    protected void Awake()
    {
        current_map = GameObject.Find("Map1").GetComponent<Map1>();
    }

    void Update()
    {
        
    }
    
    public virtual void Play(){
            
        if(can_play){
            GameObject Play1 =  Instantiate(PrefabPlay1) as GameObject;
            Play1.transform.SetParent(GameObject.Find("Stage").transform);

            current_map.now_play = EventSystem.current.currentSelectedGameObject;
        }
    }

    public virtual void StateUpdate1(){
        
        for(int i = 0; i<near_button.Count; i++){

            PlayBtn playbtn = near_button[i].GetComponent<PlayBtn>();

            playbtn.can_play = true;

            ColorBlock colorBlock = near_button[i].colors;
            colorBlock.normalColor = new Color(1f,1f,1f); 
            near_button[i].colors = colorBlock;

        }
    }

    
}
