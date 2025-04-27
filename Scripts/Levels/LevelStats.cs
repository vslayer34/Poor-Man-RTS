using Godot;
using PoorManRTS.Helper.Classes;
using PoorManRTS.Managerss;
using PoorManRTS.ResourceBase;
using System;


namespace PoorManRTS.Levels;
public partial class LevelStats : Node2D
{
    [Signal]
    public delegate void LevelLoadedEventHandler();

    [Export]
    public LevelDataContainer LevelData { get; private set; }
    public GameResources MapResources { get; private set; }


    public GameManager GameManager { get; private set; }


    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        MapResources = new GameResources{ GoldAmount = LevelData.GoldAmount, WoodAmount = LevelData.WoodAmount };
        GameManager = GetOwner<GameManager>();
    }
}
