using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class HumanResourceDisplay : MonoBehaviour
{
    public PlayerEntity player_entity;
    public PlayerEntityData player_entity_data; // 스텟~~
    public TextMeshProUGUI entity_name_text;

    public Image entity_image;

    public TextMeshProUGUI entity_price;

    private void Start()
    {
        entity_name_text.text = player_entity_data.entity_name;

        entity_image.sprite = Resources.Load<Sprite>(Path.Combine("Player",player_entity_data.class_type.ToString()));

        // entity_price.text = ~;
    }


}
