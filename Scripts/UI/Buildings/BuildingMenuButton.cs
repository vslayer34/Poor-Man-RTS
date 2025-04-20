using Godot;
using PoorManRTS.Helper.Constants;
using PoorManRTS.ResourceBase;
using System;
using System.Threading.Tasks;


namespace PoorManRTS.UI.Bulidings;
public partial class BuildingMenuButton : Button
{
    [Export]
    private Button _unitButton;

    [Export]
    private AnimationPlayer _animPlayer;

    [Export]
    public UnitBulitStatsGResource UnitBuildStats { get; private set; }

    private bool _isMenuActive = false;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        Pressed += PlayButtonAnimation;
    }

    public override void _ExitTree()
    {
        Pressed -= PlayButtonAnimation;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (!_isMenuActive)
            {
                return;
            }

            _animPlayer.PlayBackwards(Animations.UI.UnitButton.DISPLAY_BUTTON);
            _isMenuActive = false;
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private void ShowUnitButton()
    {
        _unitButton.Visible = true;
    }

    public void PlayButtonAnimation()
    {
        _unitButton.Visible = true;
        _animPlayer.Play(Animations.UI.UnitButton.DISPLAY_BUTTON);
        _isMenuActive = true;
    }
}