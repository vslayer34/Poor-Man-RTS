using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace PoorManRTS.Units.Allies;
public abstract partial class Unit : CharacterBody2D
{
    public Vector2 HeadingDirection { get; set; }
}