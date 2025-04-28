using Godot;

namespace PoorManRTS.Units.Allies;
public abstract partial class Unit : CharacterBody2D
{
    public Vector2 HeadingDirection { get; set; }
}