using System;
using UnityEditor;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public BaseStatsData unitStatsData;

    public int currentHealth { get; set; }
    public int maxHealth { get; set; }
    public int currentMana { get; set; }
    public int maxMana { get; set; }
    public int currentStamina { get; set; }
    public int maxStamina { get; set; }
    public int power { get; set; }
    public int speed { get; set; }
    public int armor { get; set; }

    public void SetStats(BaseStatsData data)
    {
        maxHealth = data.health;
        currentHealth = maxHealth;
        maxMana = data.mana;
        currentMana = maxMana;
        maxStamina = data.stamina;
        currentStamina = maxStamina;
        power = data.power;
        speed = data.speed;
        armor = data.armor;
    }

    public void Start()
    {
        SetStats(unitStatsData);
    }
}

