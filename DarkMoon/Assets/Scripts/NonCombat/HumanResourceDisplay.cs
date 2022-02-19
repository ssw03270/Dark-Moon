using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HumanResourceDisplay : MonoBehaviour
{
    public PlayerEntity player_entity;
    public TextMeshProUGUI entity_name;

    public Image entity_image;

    // 스텟~~
    
    public TextMeshProUGUI entity_price;

    private void Start()
    {
        entity_name.text = player_entity.entity_name;

        entity_image.sprite = player_entity.GetComponent<SpriteRenderer>().sprite;

        // entity_price;
    }


}
