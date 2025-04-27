using Godot;
using PoorManRTS.Helper.Enums;
using PoorManRTS.Helper.Classes;
using System;


namespace PoorManRTS.UI.HUD;
public partial class ResourcesLabel : HBoxContainer
{
    [Export]
    public Label _woodLabel;

    [Export]
    public Label _goldLabel;


    
    // Game Loop Methods---------------------------------------------------------------------------
    // member Methods------------------------------------------------------------------------------

    private void UpdateWoodLabel(int amount) => _woodLabel.Text = $"Wood: {amount}";
    private void UpdateGoldLabel(int amount) => _goldLabel.Text = $"Gold: {amount}";

    public void UpdateResourcesUI(GameResources ownedResources)
    {
        UpdateWoodLabel(ownedResources.WoodAmount);
        UpdateGoldLabel(ownedResources.GoldAmount);
    }
}
