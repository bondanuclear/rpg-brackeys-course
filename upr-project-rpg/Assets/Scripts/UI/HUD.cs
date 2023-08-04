using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image healthImage;
    [SerializeField] private float damageSpeed = 5;
    PlayerStats playerStats;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerManager>().player.GetComponent<PlayerStats>();
    }
    private void OnEnable() {
        playerStats.GetComponent<BaseStats>().HasLeveledUp += UpdateLevelHUD;
    }
    private void OnDisable() {
        playerStats.GetComponent<BaseStats>().HasLeveledUp -= UpdateLevelHUD;
    }
    private void UpdateLevelHUD()
    {
        levelText.text = "Level: " + playerStats.GetComponent<BaseStats>().CurrentLevel;
    }

    
    private void Update() {
        healthImage.fillAmount = Mathf.MoveTowards(healthImage.fillAmount,playerStats.CurrentHealth / playerStats.MaxHealth,Time.deltaTime * damageSpeed);
    }

}
