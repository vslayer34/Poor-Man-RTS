using Godot;
using PoorManRTS.StateMachine;
using System;
using System.Threading.Tasks;

public partial class PeasantIdleState : State
{
    protected override async void EnterState(State enteredState)
    {
        base.EnterState(enteredState);
        await StartAutoGather();
    }

    protected override void ExitState(State exitedState)
    {
        base.ExitState(exitedState);
    }



    // Member Methods------------------------------------------------------------------------------

    private async Task StartAutoGather()
    {
        await ToSignal(GetTree().CreateTimer(3.0f), Timer.SignalName.Timeout);
        GD.Print("Switch State");
    }
}
