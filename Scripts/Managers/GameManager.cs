using Godot;
using PoorManRTS.Helper.Structs;
using PoorManRTS.Levels;
using System;

namespace PoorManRTS.Managerss;
public partial class GameManager : Node2D
{
    [Signal]
    public delegate void OnResourcesChangedEventHandler();

    [Export]
    public LevelStats LoadedLevel { get; private set; }
    public GameResources OwnedResources { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        OwnedResources = LoadedLevel.MapResources;
        EmitSignal(SignalName.OnResourcesChanged);
        GD.Print(OwnedResources.goldAmount);
    }
}
