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

    [SerializeField]private Interstitial interstitial;
    [SerializeField]private Rewarded rewardedAd;

    
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

        if(score%2000==0  &&  PlayerPrefs.GetInt("Noads") == 0)
        {
            int random = Random.Range(0,2);
            if(random ==0)
                interstitial.ShowAd();
            else
                rewardedAd.ShowRewardedAd();
        }

    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
