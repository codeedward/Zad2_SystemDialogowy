using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100;
    public int Mana = 0;
    public int Strength = 45;


    public void AddHealth(int amount)
    {
        Debug.Log("Health added");
    }
    public void AddHealthAndMana(int amount)
    {
        Debug.Log("Health and mana added");
    }
    public void AddHealthAndStrength(int amount)
    {
        Debug.Log("You are even stronger");
    }
}
