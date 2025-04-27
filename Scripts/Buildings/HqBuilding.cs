using Godot;
using PoorManRTS.Units.Allies;
using PoorManRTS.Interfaces;
using System;
using PoorManRTS.Managerss;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using System.Threading.Tasks;
using PoorManRTS.Levels;

namespace PoorManRTS.Allies.Buildings;
public partial class HqBuilding : Node2D, IBuildUnits
{
    private Marker2D _spawnPoint;

    [Export]
    private PackedScene _unitScene;

    private LevelStats _levelManager;



    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _Ready()
    {
        base._Ready();
        _spawnPoint = GetNode<Marker2D>("SpawnPoint");

        await ToSignal(Owner, SignalName.Ready);
        GD.Print(GetOwner().Name);
        _levelManager = GetOwner<LevelStats>();

    }


    // Interface Methods---------------------------------------------------------------------------

    public void BuildUnit<T>() where T : Unit
    {
        GD.Print("Build Peasent");
        var newPeasnt = _unitScene.Instantiate<Peasant>();
        GetOwner().AddChild(newPeasnt);
        newPeasnt.Position = _spawnPoint.GlobalPosition;
        GD.Print(GetOwner().Name);
    }

    public bool CheckForResources(Dictionary<ResourceType, int> requiredResources)
    {
        return _levelManager.GameManager.ConsumeResources(requiredResources);
    }
}
