using Godot;
using PoorManRTS.Interfaces;


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

        BannerButton.Pressed += PlaceBanner;
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
            }
        }
    }

    public override void _ExitTree()
    {
        // _bannerArea.InputEvent -= MoveBanner;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void PlaceBanner() => BannerBeingPlaced = true;
}
