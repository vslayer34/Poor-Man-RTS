using Godot;
using PoorManRTS.Units.Allies;
using PoorManRTS.Helper.Constants;
using System;
using PoorManRTS.ResourceBase;
using PoorManRTS.Helper.Enums;


namespace PoorManRTS.UI.Bulidings;
public partial class UnitButton : Button
{
    [Export]
    private Label _timeToBuildLabel;

    [Export]
    private Label _goldAmountLabel;
    
    [Export]
    private Label _woodAmountLabel;

    private UnitBulitStatsGResource _unitStats;
    




    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _Ready()
    {
        await ToSignal(Owner, SignalName.Ready);
        _unitStats = GetOwner<BuildingMenuButton>().UnitBuildStats;

        SetUpUnitInfo();

    }

    // Member Methods------------------------------------------------------------------------------

    private void SetUpUnitInfo()
    {
        Icon = _unitStats.UnitIcon;
        _timeToBuildLabel.Text = _unitStats.TimeToBuild.ToString("0");
        _goldAmountLabel.Text = _unitStats.UnitPrice[ResourceType.Gold].ToString("0");
        _woodAmountLabel.Text = _unitStats.UnitPrice[ResourceType.Wood].ToString("0");
    }
    
    
    
}
