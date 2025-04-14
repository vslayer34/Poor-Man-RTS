using Godot;
using PoorManRTS.Allies.Units;
using System;


namespace PoorManRTS.Interfaces;
public interface IBuildUnits
{
    void BuildUnit<T>() where T : Unit;
}
