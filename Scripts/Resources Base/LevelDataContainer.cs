using Godot;
using System;


namespace PoorManRTS.ResourceBase;
public partial class LevelDataContainer : Resource
{
    [Export]
    public int GoldAmount { get; private set; }

    [Export]
    public int WoodAmount { get; private set; }
}
