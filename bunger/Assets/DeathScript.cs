using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public Text scoreText;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player Exited The Game");
    }
    private void Update()
    {
        ShowScoreUI();
    }
    void ShowScoreUI()
    {
        scoreText.text = "Score:" + Stats.score.ToString();
    }
}
