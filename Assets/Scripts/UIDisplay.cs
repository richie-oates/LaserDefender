using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;

    private void Awake()
    {
        healthBar.maxValue = playerHealth.GetHealth();
        healthBar.value = healthBar.maxValue;
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString("000000000");
    }

    public void UpdateHealthBar(float health)
    {
        healthBar.value = health;
    }
}
