using Godot;
using System;

public partial class CameraControls : Camera2D
{
    [Export]
    private float _cameraSpeed = 10.0f;

    private Vector2 _screenMoveDirection;

    private float _screenFingerSpeed;



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventScreenDrag drag)
        {
            // GD.Print(drag.Relative);
            // GD.Print(drag.IsCanceled());
            // GD.Print(drag.ScreenVelocity);
            Vector2 deadZone = new Vector2(7.0f, 7.0f);

            if (drag.ScreenRelative.LengthSquared() > deadZone.LengthSquared())
            {
                _screenMoveDirection = drag.ScreenRelative;
            }

            // GD.Print(drag.ScreenVelocity);
            GD.Print(drag.Velocity.Length());
            _screenFingerSpeed = Mathf.Clamp(drag.Velocity.Length(), _cameraSpeed / 10.0f, _cameraSpeed);

            if (drag.ScreenRelative == Vector2.Zero)
            {
                _screenMoveDirection = Vector2.Zero;
            }
        }


        if (@event is InputEventScreenTouch touch)
        {
            // GD.Print(touch.Position);
            // Reset the camera movement
            // GD.Print(touch.Index);
            GD.Print(touch.IsCanceled());

            if (touch.IsCanceled())
            {
                
            }
            _screenMoveDirection = Vector2.Zero;
            // if (!tocuh.Canceled)
            // {
            //     GD.Print("CAncelled");
            //     _x = Vector2.Zero;
            // }
        }
    }

    public override void _Process(double delta)
    {
        MoveCamera(_screenMoveDirection, (float)delta);
    }

    // Member Methods------------------------------------------------------------------------------

    private void MoveCamera(Vector2 direction, float delta)
    {
        direction = new Vector2(-direction.X, -direction.Y);
        // Position += direction.Normalized() * _cameraSpeed * delta * _screenFingerSpeed;
        Position += direction.Normalized() *  delta * _screenFingerSpeed;
        // GD.Print(direction);
    }
}
