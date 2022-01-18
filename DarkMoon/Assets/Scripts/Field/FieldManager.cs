using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public PlayerEntity[] player_entity = new PlayerEntity[3];
    public EntityBase[] enemy_entity = new EntityBase[4];

    public int current_player_number = 0;

    public int hand_max_count = 5;

    public int max_energy = 3;
    public int current_energy = 3;

    public bool is_player_turn = false;
    private void Start()
    {
        NextTurn();
    }
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
}
