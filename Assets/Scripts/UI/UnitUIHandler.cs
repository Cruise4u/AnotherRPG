using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIHandler : MonoBehaviour
{
    public GameObject worldCanvas;
    public Image healthBar;
    public bool isPlayer;

    public void DisplayFloatingText(ObjectPoolRef poolName,int damageReference)
    {
        var floatingText = ObjectPool.Instance.SpawnPoolObject(poolName, worldCanvas.transform.position);
        floatingText.transform.SetParent(worldCanvas.transform);
        floatingText.GetComponent<CombatTextToast>().ConvertDamageToText(damageReference);
    }
    
    public void UpdateHealthValue(UnitStats baseStats)
    {
        if (healthBar != null)
        {
            if(baseStats.currentHealth >= 1)
            {
                healthBar.fillAmount = baseStats.currentHealth / (float)baseStats.maxHealth;
                healthBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = baseStats.currentHealth.ToString();
            }
            else if (baseStats.currentHealth <= 0)
            {
                healthBar.fillAmount = 0;
                healthBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "0";
            }
        }
    }
}

