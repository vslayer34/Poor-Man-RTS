using Godot;
using PoorManRTS.Helper.Structs;
using System;

namespace PoorManRTS.Managerss;
public partial class GameManager : Node2D
{
    [Signal]
    public delegate void GameStartedEventHandler();
    public GameResources OwnedResources { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        EmitSignal(SignalName.GameStarted);
    }
}
