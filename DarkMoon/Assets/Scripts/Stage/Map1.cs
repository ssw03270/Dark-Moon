using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour
{
    public GameObject StageMenu = null;

    public void BtnBack(){
        StageMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
