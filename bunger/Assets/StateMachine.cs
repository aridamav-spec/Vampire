using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour
{
    public List<State> states = new List<State>();
    public State CurrentState = null;

    public void ChangeState<aState>()
    {
        foreach (State s in states)
        {
            if (s.GetType() == typeof(aState))
            {
                CurrentState?.ExitState();
                CurrentState = s;
                CurrentState.EnterState();
                break;
            }
        }
        Debug.LogWarning("State not found");
    }
    public virtual void UpdateStateMachine()
    {
       CurrentState?.UpdateState();
    }

    public bool IsState<aState>()
    {
        if (!CurrentState) return false;
        return CurrentState.GetType() == typeof(aState);
    }
}
