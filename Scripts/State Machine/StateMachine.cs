using Godot;
using Godot.Collections;

namespace PoorManRTS.StateMachine;
public partial class StateMachine : Node
{
    [Signal]
    public delegate void OnStateEnteredEventHandler(State enteredState);

    [Signal]
    public delegate void OnStateExitedEventHandler(State exitedState);

    [Export]
    public State InitialState { get; private set; }

    private State _activeState;
    private State _nextState;

    [Export]
    private Array<State> _states;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        InitialState = InitialState == null ? GetChild(0) as State : InitialState;
        _activeState = InitialState;

        foreach (var state in GetChildren())
        {
            _states.Add(state as State);
        }

        EmitSignal(SignalName.OnStateEntered, _activeState);
    }

    // Member Methods------------------------------------------------------------------------------

    public void SwitchState<T>() where T : State
    {
        _nextState = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                _nextState = state;
                break;
            }
        }

        if (_nextState != null && _nextState != _activeState)
        {
            EmitSignal(SignalName.OnStateExited, _activeState);
            
            _activeState = _nextState;

            EmitSignal(SignalName.OnStateEntered, _activeState);
        }
    }
}
