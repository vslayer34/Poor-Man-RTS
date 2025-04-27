using Godot;
using PoorManRTS.Units.Allies;
using PoorManRTS.Interfaces;
using System;

namespace PoorManRTS.Allies.Buildings;
public partial class HqBuilding : Node2D, IBuildUnits
{
    private Marker2D _spawnPoint;

    [Export]
    private PackedScene _unitScene;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        base._Ready();
        _spawnPoint = GetNode<Marker2D>("SpawnPoint");
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

    public bool CheckForResources()
    {
        return true;
    }
}
