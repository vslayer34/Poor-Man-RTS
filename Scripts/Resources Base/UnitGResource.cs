using Godot;
using System;


namespace PoorManRTS.ResourceBase;
public partial class UnitGResource : Resource
{
    [Export]
    public AtlasTexture UnitIcon { get; private set; }
}
