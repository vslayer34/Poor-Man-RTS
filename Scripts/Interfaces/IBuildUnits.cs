using Godot;
using Godot.Collections;
using PoorManRTS.Allies.Buildings;
using PoorManRTS.Helper.Enums;
using PoorManRTS.Units.Allies;
using System;


namespace PoorManRTS.Interfaces;
public interface IBuildUnits
{
    [Signal]
    delegate void OnActiveStateChangedEventHandler(bool isActive);
    
    bool IsBuldingActive { get; set; }

    Marker2D SpawnPoint { get; set; }

    BuildingBanner HeadingBanner { get; set; }
    void BuildUnit<T>() where T : Unit;

    bool CheckForResources(Dictionary<ResourceType, int> requiredResources);
}
