using Godot;
using PoorManRTS.Units.Allies;
using PoorManRTS.Helper.Constants;
using System;
using System.Threading.Tasks;
using PoorManRTS.ResourceBase;


namespace PoorManRTS.UI.Bulidings;
public partial class UnitButton : Button
{
    [Export]
    private Label _timeToBuildLabel;

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
    }
    
    
    
}
