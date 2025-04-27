using Godot;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using PoorManRTS.Units.Allies;
using System;


namespace PoorManRTS.Interfaces;
public interface IBuildUnits
{
    void BuildUnit<T>() where T : Unit;

    bool CheckForResources(Dictionary<ResourceType, int> requiredResources);
}
