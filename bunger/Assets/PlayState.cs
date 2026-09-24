using UnityEngine;

public class PlayState : State
{
    [SerializeField] PlayerBehaviour _player;
    [SerializeField] SpawnScript _enemySpawner;
    [SerializeField] Enemy2D _enemy;

    public override void UpdateState()
    {
        base.UpdateState();
        _player.UpdatePlayer();
        _enemySpawner.UpdateSpawn();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState<PauseState>();
            Time.timeScale = 0;
        }
    }
}
