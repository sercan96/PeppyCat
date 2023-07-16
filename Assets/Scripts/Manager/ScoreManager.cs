using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private static string pointKey = "Point";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("ScoreManager instance already exists. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
    }
    
    private void Start()
    {
        score = 0;
        UpdateScoreText();
        GetPoint();
    }

    private static int GetPoint()
    {
        if (PlayerPrefs.HasKey(pointKey))
        {
            return PlayerPrefs.GetInt(pointKey);
        }
        else
        {
            return 0;
        }
    }

    private static void SetPoint(int point)
    {
        PlayerPrefs.SetInt(pointKey, point);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        SetPoint(score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
