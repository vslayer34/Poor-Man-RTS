using Godot;
using PoorManRTS.Units.Allies;
using PoorManRTS.Interfaces;
using System;
using PoorManRTS.Managerss;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using System.Threading.Tasks;
using PoorManRTS.Levels;
using PoorManRTS.Scripts.Buildings;

namespace PoorManRTS.Allies.Buildings;
public partial class HqBuilding : Building, IBuildUnits
{

    public Marker2D SpawnPoint { get; set; }
    public BuildingBanner HeadingBanner { get; set; }

    private bool _isBuldingActive;
    public bool IsBuldingActive
    {
        get => _isBuldingActive;
        set
        {
            _isBuldingActive = value;
            HeadingBanner.Visible = _isBuldingActive;
            HeadingBanner.BannerButton.Visible = _isBuldingActive;
        }
    }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        base._Ready();
        SpawnPoint = GetNode<Marker2D>("SpawnPoint");
    }


    // Interface Methods---------------------------------------------------------------------------

    public void BuildUnit<T>() where T : Unit
    {
        var newPeasnt = _unitScene.Instantiate<Peasant>();
        GetOwner().AddChild(newPeasnt);
        newPeasnt.Position = SpawnPoint.GlobalPosition;
        newPeasnt.HeadingDirection = HeadingBanner.GlobalPosition;
    }

    public bool CheckForResources(Dictionary<ResourceType, int> requiredResources)
    {
        return _levelManager.GameManager.ConsumeResources(requiredResources);
    }
}
