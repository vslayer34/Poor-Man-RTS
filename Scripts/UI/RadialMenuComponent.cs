using Godot;
using System;


namespace PoorManRTS.UI;
public partial class RadialMenuComponent : Button
{
    [Export]
    private Button _buildBtn;

    [Export]
    private SelectionWheel _selectionWheel;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        _buildBtn = GetNode<Button>(".");
        
        _buildBtn.ButtonDown += ShowSelectionWheel;
        _buildBtn.ButtonUp += DisableSelectionWheel;
    }

    public override void _ExitTree()
    {
        _buildBtn.ButtonDown -= ShowSelectionWheel;
        _buildBtn.ButtonUp -= DisableSelectionWheel;
    }

    // Member Methods------------------------------------------------------------------------------

    private void ShowSelectionWheel()
    {
        _selectionWheel.Visible = true;
    }

    private void DisableSelectionWheel()
    {
        _selectionWheel.Visible = false;
    }
}
