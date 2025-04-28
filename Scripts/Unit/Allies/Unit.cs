using Godot;
using PoorManRTS.StateMachineConfig;

namespace PoorManRTS.Units.Allies;
public abstract partial class Unit : CharacterBody2D
{
    public StateMachine StateMachine { get; set; }
    public Vector2 HeadingDirection { get; set; }
}