using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class CampDisplay : MonoBehaviour
{
    public PlayerEntityData player_entity_data;
    public TextMeshProUGUI entity_name_text;
    public Image entity_image;

    private void Start()
    {
        Display();
    }

    public void Display()
    {
        entity_name_text.text = player_entity_data.entity_name;

        entity_image.sprite = Resources.Load<Sprite>(Path.Combine("Player",player_entity_data.class_type.ToString()));
    }
}
