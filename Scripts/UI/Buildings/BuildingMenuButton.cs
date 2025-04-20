using Godot;
using PoorManRTS.Helper.Constants;
using System;
using System.Threading.Tasks;


namespace PoorManRTS.UI.Bulidings;
public partial class BuildingMenuButton : Button
{
    [Export]
    private Button _unitButton;

    [Export]
    private AnimationPlayer _animPlayer;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        Pressed += PlayButtonAnimation;
    }

    public override void _ExitTree()
    {
        Pressed -= PlayButtonAnimation;
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
    }
}