using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour {

    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private int HP;
    [SerializeField]
    private float MaxHunger;
    [SerializeField]
    private float Hunger;
    [SerializeField]
    private float MaxWokeness;
    [SerializeField]
    private float Wokeness;

    public void UseItem(ConsumableItem item)
    {
        HP += item.HPIncrease;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        Hunger += item.HungerIncrease;
        if (Hunger > MaxHunger)
        {
            Hunger = MaxHunger;
        }
    }
}
