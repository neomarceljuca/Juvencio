using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : ScriptableObject
{
    private IState currentState;
    private IState previousState;

    public void ChangeState(IState newState)
    {
        if(this.currentState != null) this.currentState.Exit();
        this.previousState = this.currentState;

        this.currentState = newState;
        this.currentState.Enter();
    }



    public void ExecuteStateUpdate()
    {
        if(this.currentState != null) this.currentState.Execute();
    }


    public void SwitchToPreviousState()
    {
        if (this.currentState != null) this.currentState.Exit();

        IState temp = this.currentState;
        this.currentState = this.previousState;
        this.previousState = temp;
        
        this.currentState.Enter();

    }

}
