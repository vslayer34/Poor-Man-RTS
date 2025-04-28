using Godot;
using PoorManRTS.Interfaces;
using System;
using System.Threading.Tasks;


namespace PoorManRTS.Allies.Buildings;
public partial class BuildingBanner : Node2D
{
    private IBuildUnits _ownerBuilding;

    [Export]
    private Area2D _bannerArea;

    [Export]
    public Button BannerButton { get; private set; }

    public bool BannerBeingPlaced { get; private set; }




    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _Ready()
    {
        await ToSignal(Owner, SignalName.Ready);
        _ownerBuilding = GetParent<IBuildUnits>();

        // Set the reference and position and visibilty at the start of game
        Position = _ownerBuilding.SpawnPoint.Position;
        _ownerBuilding.HeadingBanner = this;
        Visible = false;
        BannerButton.Visible = false;

        // _bannerArea.InputEvent += MoveBanner;
        // _bannerArea.MouseEntered += () => { GD.Print("mouse entered"); BannerPressed = true; };
        // // _bannerArea.MouseExited += () => { GD.Print("mouse exited"); BannerPressed = false; };
        // GD.Print(_bannerArea.GetGlobalMousePosition());

        BannerButton.Pressed += PlaceBanner;
        // _shape.point
    }

    public override async void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touch && BannerBeingPlaced)
        {
            var touchPosition = GetViewport().CanvasTransform.AffineInverse() * touch.Position;
            GlobalPosition = touchPosition;
            BannerButton.ButtonPressed = false;

            if (!touch.Pressed)
            {
                await ToSignal(GetTree().CreateTimer(1.0f), Timer.SignalName.Timeout);
                BannerBeingPlaced = false;
                // GetViewport().SetInputAsHandled();
            }
        }
        // if (@event is InputEventScreenDrag drag && BannerBeingPlaced)
        // {
        //     var touchPosition = GetViewport().CanvasTransform.AffineInverse() * drag.Position;

        //     // if (_bannerArea.point)
        //     // BannerPressed = true;
        //     GD.PrintT(_bannerArea.GetGlobalMousePosition(), touchPosition);
        //     _isMoving = true;
        //     GlobalPosition = _bannerArea.GetGlobalMousePosition();
        // }
        // else
        // {
        //     // BannerPressed = false;
        // }
    }

    public override void _ExitTree()
    {
        // _bannerArea.InputEvent -= MoveBanner;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void MoveBanner(Node viewport, InputEvent @event, long shapeIdx)
    {
        BannerBeingPlaced = true;

        // Position = viewport.GetViewport().G
        // GD.Print("Pressed");

        // if (@event is InputEventScreenTouch touch)
        // {
        //     BannerPressed = true;
        //     if (touch.Pressed)
        //     {
        //         BannerPressed = true;

        //         GD.Print("touched");
        //     }
        //     else
        //     {
        //         GD.Print("released");
        //         BannerPressed = false;
        //     }

        // }

        // if (@event is InputEventScreenTouch drag)
        // {
        //     if (drag.Pressed)
        //     {
        //         GD.Print(drag.Position);
        //     }
        // }
        
    }

    private void PlaceBanner()
    {
        BannerBeingPlaced = true;
        // GlobalPosition = GetViewport().GetMousePosition();
    }
}
