using Godot;
using PoorManRTS.Allies.Units;
using PoorManRTS.Interfaces;
using System;

namespace PoorManRTS.Allies.Buildings;
public partial class HqBuilding : Node2D, IBuildUnits
{

    // Interface Methods---------------------------------------------------------------------------

    public void BuildUnit<T>() where T : Unit
    {
        
    }
}
