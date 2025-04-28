using Godot;
using PoorManRTS.Helper.Constants;
using PoorManRTS.Interfaces;
using PoorManRTS.ResourceBase;
using PoorManRTS.Units.Allies;
using System.Collections.Generic;


namespace PoorManRTS.UI.Bulidings;
public partial class BuildingMenuButton : Button
{
    [Export]
    private UnitButton _unitButton;

    [Export]
    private AnimationPlayer _animPlayer;

    [Export]
    public UnitBulitStatsGResource UnitBuildStats { get; private set; }

    [Export]
    private Timer _unitTimer;

    private bool _isMenuActive = false;
    
    private int _unitsInQueue;

    private bool _alreadyBuildingUnit;

    private IBuildUnits _ownerBuilding;



    // Game Loop Methods---------------------------------------------------------------------------

    public async override void _Ready()
    {
        Pressed += PlayButtonAnimation;
        _unitButton.SetUpUnitInfo(UnitBuildStats);
        _unitTimer.WaitTime = UnitBuildStats.TimeToBuild;

        await ToSignal(Owner, SignalName.Ready);
        _ownerBuilding = GetOwner<IBuildUnits>();

        _unitButton.Pressed += AddUnitToQueue;
    }

    public override void _ExitTree()
    {
        Pressed -= PlayButtonAnimation;
        _unitButton.Pressed -= AddUnitToQueue;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (!_isMenuActive)
            {
                return;
            }
            
            if (!_ownerBuilding.HeadingBanner.BannerBeingPlaced)
            {
                _animPlayer.PlayBackwards(Animations.UI.UnitButton.DISPLAY_BUTTON);
                _isMenuActive = false;
                _ownerBuilding.IsBuldingActive = false;
            }
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private async void AddUnitToQueue()
    {
        if (!_ownerBuilding.CheckForResources(UnitBuildStats.UnitPrice))
        {
            return;
        }

        UnitsInQueue++;
        GD.Print("Before" + UnitsInQueue);

        if (_alreadyBuildingUnit)
        {
            // makes sure the while block is called once regardless of the number of clicks
            return;
        }

        while (UnitsInQueue > 0)
        {
            _alreadyBuildingUnit = true;
            _unitTimer.Start();

            UpdateProgress();

            await ToSignal(_unitTimer, Timer.SignalName.Timeout);
            _ownerBuilding.BuildUnit<Unit>();
            UnitsInQueue--;

            if (UnitsInQueue == 0)
            {
                _alreadyBuildingUnit = false;
            }
        }
    }

    private void ShowUnitButton()
    {
        _unitButton.Visible = true;
    }

    public void PlayButtonAnimation()
    {
        _unitButton.Visible = true;
        _animPlayer.Play(Animations.UI.UnitButton.DISPLAY_BUTTON);
        _isMenuActive = true;
        _ownerBuilding.IsBuldingActive = true;
    }

    private async void UpdateProgress()
    {
        float timer = 0.0f;
        float maxTime = UnitBuildStats.TimeToBuild;

        _unitButton.EnableProgressBar(true);

        while (timer < UnitBuildStats.TimeToBuild)
        {
            await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
            timer += (float)GetProcessDeltaTime();
            _unitButton.UpdatePrgressBar(timer, maxTime);
        }

        _unitButton.EnableProgressBar(false);
    }

    // Getters & Setters---------------------------------------------------------------------------

    public int UnitsInQueue
    {
        get => _unitsInQueue;
        set
        {
            _unitsInQueue = value;
            _unitButton.UpdateUnitsInQueueNumber(UnitsInQueue);
        }
    }
}