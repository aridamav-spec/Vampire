using UnityEngine;

public class PlayState : State
{
    [SerializeField] PlayerBehaviour _player;
    [SerializeField] SpawnScript _enemySpawner;
    [SerializeField] Enemy2D _enemy;
    public GameObject PauseUI;

    public override void UpdateState()
    {
        PauseUI.SetActive(false);
        base.UpdateState();
        _player.UpdatePlayer();
        _enemySpawner.UpdateSpawn();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState<PauseState>();
            PauseUI.SetActive(true);
        }
    }
}
