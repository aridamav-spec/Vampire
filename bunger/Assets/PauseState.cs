using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : State
{
    public GameObject PauseUI;
    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState<PlayState>();
            PauseUI.SetActive(false);
        }
    }
    public void Resume()
    {
        GameManager.Instance.ChangeState<PlayState>();
        PauseUI.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
