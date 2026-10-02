using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        UpdateScoreUI();
    }
    private void Update()
    {
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        scoreText.text = "Score:" + Stats.score.ToString();
    }
}
