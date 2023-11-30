using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Slider experienceBar;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider healthBar;

    void Update()
    {
        experienceBar.value = player.currentExp / player.maxExp;

        levelText.text = $"LV {player.level}";

        healthBar.value = player.currentHealth / player.maxHealth;
    }
}
