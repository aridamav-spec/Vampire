using UnityEngine;

public class UpgradeState : State
{
    public GameObject UpgradeUI;
    public override void UpdateState()
    {
        UpgradeUI.SetActive(true);
        base.UpdateState();
    }
    public void DamageUp()
    {
        Weapon.damage++;
        GameManager.Instance.ChangeState<PlayState>();
    }
    public void AttackSpeed()
    {
        PlayerBehaviour.timeBetweenAttacks -= 0.1f;
        GameManager.Instance.ChangeState<PlayState>();
    }
    public void PlayerSpeed()
    {
        PlayerBehaviour.playerSpeed += 0.1f;
        GameManager.Instance.ChangeState<PlayState>();
    }
}
