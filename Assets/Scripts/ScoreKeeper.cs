using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    int score = 0;

    UIDisplay uiDisplay;

    public static ScoreKeeper GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
        uiDisplay = FindObjectOfType<UIDisplay>();
        if (uiDisplay != null)
        {
            uiDisplay.UpdateScoreText(score);
        }
    }

    void ManageSingleton()
    {
        if (ScoreKeeper.GetInstance() != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int amount)
    {
        score = Mathf.Max(score += amount, 0);
        FindObjectOfType<UIDisplay>().UpdateScoreText(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
