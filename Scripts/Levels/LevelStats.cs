using Godot;
using PoorManRTS.Helper.Structs;
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


    private GameManager _gameManager;


    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        MapResources = new GameResources{ goldAmount = LevelData.GoldAmount, woodAmount = LevelData.WoodAmount };
        _gameManager = GetOwner<GameManager>();
    }
}
