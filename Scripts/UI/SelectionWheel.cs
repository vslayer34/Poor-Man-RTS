using Godot;
using System;


namespace PoorManRTS.UI;
[Tool]
public partial class SelectionWheel : Control
{
    [Export]
    private Color _backgroundColor = Colors.Gray;

    [Export]
    private int _outerRadius = 256;

    [Export]
    private int _innerRadius = 64;

    [Export]
    private int _lineWidth = 4;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Draw()
    {
        
        DrawCircle(Vector2.Zero, _outerRadius, _backgroundColor);
        // DrawCircle()
        DrawArc(Vector2.Zero, _innerRadius, 0.0f, Mathf.Tau, 128, Colors.RebeccaPurple, _lineWidth, true);
    }


    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    // Member Methods------------------------------------------------------------------------------
}
