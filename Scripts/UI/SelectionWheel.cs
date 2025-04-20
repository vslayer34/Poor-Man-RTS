using Godot;
using System;
using Godot.Collections;


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

    [Export]
    private Node[] _options = new Node[1];



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Draw()
    {
        
        DrawCircle(Vector2.Zero, _outerRadius, _backgroundColor);
        // DrawCircle()
        DrawArc(Vector2.Zero, _innerRadius, 0.0f, Mathf.Tau, 128, Colors.RebeccaPurple, _lineWidth, true);

        if (_options.Length > 1)
        {
            for (int i = 0; i < _options.Length; i++)
            {
                var rad = Mathf.Tau * i / _options.Length;
                var point = Vector2.FromAngle(rad);

                DrawLine(point * _innerRadius, point * _outerRadius, Colors.RebeccaPurple, _lineWidth, true);
            }
        }
    }


    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    // Member Methods------------------------------------------------------------------------------
}
