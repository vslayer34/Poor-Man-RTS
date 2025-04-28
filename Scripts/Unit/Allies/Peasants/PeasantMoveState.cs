using Godot;
using PoorManRTS.StateMachineConfig;
using System;

public partial class PeasantMoveState : State
{

    protected override void PhysicsUpdate(float delta)
    {
        base.Update(delta);
        MoveToDestination();
        GD.Print("Move State");

        _stateMachine.ParentUnit.MoveAndSlide();
    }


    // Member Methods------------------------------------------------------------------------------

    private void MoveToDestination()
    {
        _stateMachine.ParentUnit.GlobalPosition += _stateMachine.ParentUnit.HeadingDirection.Normalized();
    }
}
