using Godot;
using PoorManRTS.Units.Allies;
using System;


namespace PoorManRTS.Interfaces;
public interface IBuildUnits
{
    void BuildUnit<T>() where T : Unit;

    bool CheckForResources();
}
