using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public EntityBase[] our_entity = new EntityBase[3];
    public EntityBase[] enemy_entity = new EntityBase[4];

    public int max_energy = 3;
    public int current_energy = 3;

    public bool is_our_turn = true;

    public void NextTurn()
    {
        if (is_our_turn)
        {
            is_our_turn = false;
        }
        else
        {
            is_our_turn = true;
            current_energy = max_energy;
        }
    }
}
