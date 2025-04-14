using Godot;
using System;
using PoorManRTS.Helper.Enums;

namespace PoorManRTS.Resources.GoldMine;
public partial class GoldMine : Node2D
{
    [Signal]
    public delegate void GoldMineStatusChangedEventHandler(MineStatus status);

    [Export]
    public MineStatus CurrentMineStatus { get; private set; } = MineStatus.Inactive;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        
        EmitSignal(SignalName.GoldMineStatusChanged);
    }
}
