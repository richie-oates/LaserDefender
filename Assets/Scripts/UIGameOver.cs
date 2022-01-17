using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "You scored:\n" + ScoreKeeper.GetInstance().GetScore().ToString("000000000");
    }
}
