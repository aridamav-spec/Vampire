using UnityEngine;

public class PauseState : State
{
    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState<PlayState>();
            Time.timeScale = 1;
        }
    }
}
