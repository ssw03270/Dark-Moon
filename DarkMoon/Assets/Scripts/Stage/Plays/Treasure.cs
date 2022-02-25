using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : PlayBase  // 보물방
{
    public List<GameObject> ItemList = new List<GameObject>();  // 랜덤으로 생성될 아이템들
    public GameObject GetItem;
    public GameObject TreButton;

    public bool is_first_open;

    public void TreasureOpen()  // 보물을 열었을 때 실행되는 함수
    {   
        if(is_first_open){

            int random_number = Random.Range(0, ItemList.Count); 
            GetItem = Instantiate(ItemList[random_number], this.transform.position + new Vector3(210,0,0), Quaternion.identity);
            GetItem.transform.SetParent(GameObject.Find("Item").transform);
            
            GameObject TreButton =  GameObject.Find("TreButton");
            TreButton.transform.GetChild(0).gameObject.SetActive(true);
            TreButton.transform.GetChild(1).gameObject.SetActive(true);

            is_first_open = false;
        }
    }

    public void Get_Item(){  // 유물을 획득할 때 실행되는 함수

        for(int i = 0; i<3; i++){  // 획득한 아이템을 저장
            if(stage_menu.Items[i] == null){
                Debug.Log(stage_menu.Items[i]);
                stage_menu.Items[i] = GetItem;
                break;
            }
        }
        GetItem.SetActive(false);  // 생성된 유물을 보이지 않도록 설정
        base.PlayClear();

    }

    public void Waste_Item(){  // 유물을 획득하지 않을 때 실행되는 함수

        GetItem.SetActive(false);
        base.PlayClear();
    }
}
