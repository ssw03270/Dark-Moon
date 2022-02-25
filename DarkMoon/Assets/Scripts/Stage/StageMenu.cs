using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    
    public GameObject[] MapPrefab;  // map들의 prefab -> 이 중에서 random생성
    public Button[] StageBtn;  // stage buttons
    public GameObject[] Maps;
    public GameObject[] Items;
    
  //  public List<GameObject> Items = new List<GameObject>();

    public int current_stage;  // 현재 플레이 중인 스테이지

    
}
