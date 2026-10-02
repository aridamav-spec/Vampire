using UnityEngine;
using UnityEngine.UI;

public class UpgradeState : State
{
    public GameObject UpgradeUI;
    public GameObject DamageButton;
    public GameObject AttackSpeedButton;
    public GameObject SpeedButton;

    public override void UpdateState()
    {
        UpgradeUI.SetActive(true);
        base.UpdateState();
    }
    public void DamageUp()
    {
        Stats.weapondamage++;
        Debug.Log("Damage " + Stats.weapondamage.ToString());
        GameManager.Instance.ChangeState<PlayState>();
    }
    public void AttackSpeed()
    {
        Stats.attackspeed -= 0.1f;
        Debug.Log("AttackSpeed " + Stats.attackspeed.ToString());
        if (Stats.attackspeed <= 0.1f)
        {
            AttackSpeedButton.SetActive(false);
        }
        GameManager.Instance.ChangeState<PlayState>();
    }
    public void PlayerSpeed()
    {
        Stats.playerspeed += 0.1f;
        Debug.Log("PlayerSpeed " + Stats.playerspeed.ToString());
        if (Stats.playerspeed >= 3)
        {
            SpeedButton.SetActive(false);
        }
        GameManager.Instance.ChangeState<PlayState>();
    }
}
