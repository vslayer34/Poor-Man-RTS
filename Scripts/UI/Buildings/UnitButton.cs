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
    private Label _unitsInQueue;

    [Export]
    private Label _goldAmountLabel;
    
    [Export]
    private Label _woodAmountLabel;

    [Export]
    private ProgressBar _progressBar;

    [Export]
    private TextureProgressBar _textureProgressBar;





    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        EnableProgressBar(false);
    }

    // Member Methods------------------------------------------------------------------------------

    public void SetUpUnitInfo(UnitBulitStatsGResource unitStats)
    {
        Icon = unitStats.UnitIcon;
        _timeToBuildLabel.Text = unitStats.TimeToBuild.ToString("0");
        _goldAmountLabel.Text = unitStats.UnitPrice[ResourceType.Gold].ToString("0");
        _woodAmountLabel.Text = unitStats.UnitPrice[ResourceType.Wood].ToString("0");
        _unitsInQueue.Visible = false;
    }


    public void UpdatePrgressBar(float currentTIme, float maxTime)
    {
        float value = currentTIme / maxTime * 100;
        _progressBar.Value = value;
        _textureProgressBar.Value = value;
    }

    public void EnableProgressBar(bool enabled)
    {
        _progressBar.Visible = enabled;
        _textureProgressBar.Visible = enabled;
    }

    public void UpdateUnitsInQueueNumber(int numOfUnits = 0)
    {
        if (numOfUnits <= 0)
        {
            _unitsInQueue.Visible = false;
        }
        else
        {
            _unitsInQueue.Visible = true;
            _unitsInQueue.Text = numOfUnits.ToString();
        }
    }
}
