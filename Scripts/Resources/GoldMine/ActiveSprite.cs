using Godot;
using System;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using System.Threading.Tasks;


namespace PoorManRTS.Resources.GoldMine;

public partial class ActiveSprite : Sprite2D
{
    private GoldMine _goldmine;
    private Sprite2D _activeSprite;

    [Export]
    private Dictionary<MineStatus, Texture2D> _validSprites = new Dictionary<MineStatus, Texture2D>();



    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _Ready()
    {
        await ToSignal(Owner, SignalName.Ready);

        ReadyNodeForUse();
        ChangeMineSprite(_goldmine.CurrentMineStatus);
    }

    public override void _ExitTree()
    {
        ReadyNodeForCleanUp();
    }

    // Member Methods------------------------------------------------------------------------------

    private void ReadyNodeForUse()
    {
        _goldmine = GetParent<GoldMine>();
        _activeSprite = GetNode<Sprite2D>(".");

        _goldmine.GoldMineStatusChanged += ChangeMineSprite;
    }

    private void ReadyNodeForCleanUp()
    {
        _goldmine.GoldMineStatusChanged -= ChangeMineSprite;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void ChangeMineSprite(MineStatus status)
    {
        foreach (var pair in _validSprites)
        {
            if (pair.Key.Equals(status))
            {
                _activeSprite.Texture = pair.Value;

                return;
            }
        }
    }
}
