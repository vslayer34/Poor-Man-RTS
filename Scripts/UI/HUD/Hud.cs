using Godot;
using PoorManRTS.Managerss;
using System;

namespace PoorManRTS.UI.HUD;
public partial class Hud : CanvasLayer
{
    private ResourcesLabel _resourcesLabel;
    private GameManager _gameManager;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        _resourcesLabel = GetNode<ResourcesLabel>("ResourceLabel");
        _gameManager = GetOwner<GameManager>();

        _resourcesLabel.UpdateResourcesUI(_gameManager.OwnedResources);
        
        ReadyNodeForUse();
    }

    public override void _ExitTree()
    {
        ReadyNodeForCleanUp();
    }

    // Member Methods------------------------------------------------------------------------------

    private void ReadyNodeForUse()
    {
        
    }

    private void ReadyNodeForCleanUp()
    {

    }
}
