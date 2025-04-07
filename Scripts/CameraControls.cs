using Godot;
using System;

public partial class CameraControls : Camera2D
{
    [Export]
    private float _cameraSpeed = 10.0f;

    private Vector2 _x;



    // Game Loop MEthods---------------------------------------------------------------------------
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenDrag drag)
        {
            _x = drag.Relative;
        }


        if (@event is InputEventScreenTouch tocuh)
        {
            // GD.Print("Touch");
            if (!tocuh.Canceled)
            {
                GD.Print("CAncelled");
                _x = Vector2.Zero;
            }
        }
    }

    public override void _Process(double delta)
    {
        MoveCamera(_x, (float)delta);
    }

    // Member Methods------------------------------------------------------------------------------

    private void MoveCamera(Vector2 direction, float delta)
    {
        Position += direction.Normalized() * _cameraSpeed * delta;
        // GD.Print(direction);
    }
}
