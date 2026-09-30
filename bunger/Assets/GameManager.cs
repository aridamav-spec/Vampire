using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }   
    private void Start()
    {
        Weapon.damage = 5;
        ChangeState<PlayState>();
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}
