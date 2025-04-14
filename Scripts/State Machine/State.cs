using Godot;
using System;


namespace PoorManRTS.StateMachine;
public abstract partial class State : Node
{
    protected StateMachine _stateMachine;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        _stateMachine = GetParent<StateMachine>();
        _stateMachine.OnStateEntered += EnterState;
        _stateMachine.OnStateExited += ExitState;

        SetProcess(false);
        SetPhysicsProcess(false);
    }

    public override void _Input(InputEvent @event)
    {
        HandleInput(@event);
    }

    public override void _Process(double delta)
    {
        Update((float) delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        PhysicsUpdate((float) delta);
    }

    public override void _ExitTree()
    {
        _stateMachine.OnStateEntered -= EnterState;
        _stateMachine.OnStateExited -= ExitState;
    }


    // Member Methods------------------------------------------------------------------------------

    protected virtual void HandleInput(InputEvent @event)
    {

    }

    protected virtual void Update(float delta)
    {

    }

    protected virtual void PhysicsUpdate(float delta)
    {

    }

    protected virtual void EnterState(State enteredState)
    {
        if (enteredState == this)
        {
            SetProcess(true);
            SetPhysicsProcess(true);
        }
    }

    protected virtual void ExitState(State exitedState)
    {
        if (exitedState == this)
        {
            SetProcess(false);
            SetPhysicsProcess(false);
        }
    }
}