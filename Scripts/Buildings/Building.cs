using Godot;
using PoorManRTS.Levels;

namespace PoorManRTS.Scripts.Buildings;
public abstract partial class Building : Node2D
{
    [Export]
    protected PackedScene _unitScene;

    protected LevelStats _levelManager;



    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _Ready()
    {
        await ToSignal(Owner, SignalName.Ready);
        _levelManager = GetOwner<LevelStats>();
    }
}