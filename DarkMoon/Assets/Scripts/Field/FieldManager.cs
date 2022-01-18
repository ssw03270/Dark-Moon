using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    // battle ground
    public PlayerEntity[] player_entity = new PlayerEntity[3];
    public EntityBase[] enemy_entity = new EntityBase[4];

    public int current_player_number = 0;

    public int hand_max_count = 5;

    public int max_energy = 3;
    public int current_energy = 3;

    public bool is_player_turn = false;

    // end game
    public CardBase[] get_card_list = new CardBase[3];

    private void Start()
    {
        NextTurn();
    }

    // battle ground
    public void NextTurn()
    {
        if (is_player_turn)
        {
            is_player_turn = false;

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].HandToDiscardPile(player_entity[i].hand.Count);
            }
        }
        else
        {
            is_player_turn = true;
            current_energy = max_energy;

            for(int i = 0; i < 3; i++)
            {
                player_entity[i].DeckToHand(hand_max_count);
            }
        }
    }

    // end game
    public void GetRandomCards()
    {
        GameData game_data = GameObject.Find("GameData").GetComponent<GameData>();

        for(int i = 0; i < 3; i++)
        {
            int random_number = Random.Range(0, game_data.card_list.Count);
            string card_name = game_data.card_list[random_number]["card_name"];
            string path = Application.dataPath + "/Prefab/" + card_name + ".prefab";

            get_card_list[i] = PrefabUtility.LoadPrefabContents(path).GetComponent<CardBase>();
            Instantiate(get_card_list[i]);
        }
    }
    public void GetRandomGold()
    {

    }
    public void GetRandomEXP()
    {

    }
}
