using Godot;
using Godot.Collections;
using PoorManRTS.Helper.Enums;
using System;


namespace PoorManRTS.ResourceBase;
public partial class UnitBulitStatsGResource : Resource
{
    [Export]
    public AtlasTexture UnitIcon { get; private set; }

    [Export]
    public float TimeToBuild;

    [Export]
    public Dictionary<ResourceType, int> UnitPrice = new Dictionary<ResourceType, int>()
    {
        {ResourceType.Wood, 0},
        {ResourceType.Gold, 0}
    };
}
