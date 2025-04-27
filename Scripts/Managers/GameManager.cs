using Godot;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using PoorManRTS.Helper.Classes;
using PoorManRTS.Levels;
using System;

namespace PoorManRTS.Managerss;
public partial class GameManager : Node2D
{
    [Signal]
    public delegate void OnResourcesChangedEventHandler();

    [Export]
    public LevelStats LoadedLevel { get; private set; }

    // public static GameManager Instance { get; private set; }

    public GameResources OwnedResources { get; private set; } = new GameResources();



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        // Instance = this;

        OwnedResources = LoadedLevel.MapResources;
        EmitSignal(SignalName.OnResourcesChanged);
    }

    // Member Methods------------------------------------------------------------------------------

    public bool ConsumeResources(Dictionary<ResourceType, int> resources)
    {
        var purchaseCompleted =  OwnedResources.RemoveProductionResources(resources, out GameResources newResources);
        OwnedResources = newResources;
        EmitSignal(SignalName.OnResourcesChanged);

        return purchaseCompleted;
    }

    public void AddWood(int amount)
    {
        OwnedResources.AddWood(amount);
        EmitSignal(SignalName.OnResourcesChanged);
    }
    
    public void AddGold(int amount)
    {
        OwnedResources.AddGold(amount);
        EmitSignal(SignalName.OnResourcesChanged);
    }

}
