using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State state;

    public void Set(State newState, bool forceReset = false)
    {
        if(state != newState || forceReset)
        {
            state?.ExitState();
            state = newState;
            state.Initialize();
            state.EnterState();
        }
    }

    //Try using this to set the enter, perform, and exit states
}
