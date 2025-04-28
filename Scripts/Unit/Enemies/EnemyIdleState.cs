using Godot;
using PoorManRTS.StateMachineConfig;
using System;


namespace PoorManRTS.Enemies.States;
public partial class EnemyIdleState : State
{
    protected override void EnterState(State enteredState)
    {
        base.EnterState(enteredState);
    }

    protected override void ExitState(State exitedState)
    {
        base.ExitState(exitedState);
    }


    protected override void HandleInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            _stateMachine.SwitchState<EnemyMoveState>();
        }
    }
}
