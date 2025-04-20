using Godot;
using System;
using Godot.Collections;

public partial class CameraControls : Camera2D
{
    [Export]
    private float _cameraSpeed = 10.0f;

    [Export]
    private Vector2 _minimumZoom;

    [Export]
    private Vector2 _maximumZoom;

    private Vector2 _screenMoveDirection;

    private float _screenFingerSpeed;

    private Dictionary<int, Vector2> _touchIndexes = new Dictionary<int, Vector2>();



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
                _screenFingerSpeed = Mathf.Clamp(drag.Velocity.Length(), _cameraSpeed / 5.0f, _cameraSpeed);
            }

            // GD.Print(drag.ScreenVelocity);
            // GD.Print(drag.Velocity.Length());
            

            if (drag.ScreenRelative == Vector2.Zero)
            {
                _screenMoveDirection = Vector2.Zero;
            }

            if (_touchIndexes.Count > 1)
            {
                GD.Print("Start Zoooooooooming");
                var pivotIndex = drag.Index == 1 ? 0 : 1;
                Vector2 pivotVector = _touchIndexes[pivotIndex];

                Vector2 movingFingerOldPosition = _touchIndexes[drag.Index];
                Vector2 movingFingerCurrentPosition = drag.Position;

                Vector2 oldVector = movingFingerOldPosition - pivotVector;
                Vector2 currentVector = movingFingerCurrentPosition - pivotVector;

                var deltaScale = currentVector.Length() / oldVector.Length();
                Zoom *= deltaScale;
                Zoom = Zoom.Clamp(_minimumZoom, _maximumZoom);
                _touchIndexes[drag.Index] = movingFingerCurrentPosition;
            }
        }


        if (@event is InputEventScreenTouch touch)
        {
            // GD.Print(touch.Position);
            // Reset the camera movement
            // GD.Print(touch.Index);
            if (!_touchIndexes.ContainsKey(touch.Index))
            {
                _touchIndexes.Add(touch.Index, touch.Position);
            }

            if (!touch.Pressed)
            {
                _touchIndexes.Remove(touch.Index);
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
        if (_touchIndexes.Count == 1)
        {
            MoveCamera(_screenMoveDirection, (float)delta);
        }
    }

    // Member Methods------------------------------------------------------------------------------

    private void MoveCamera(Vector2 direction, float delta)
    {
        direction = new Vector2(-direction.X, -direction.Y);
        // Position += direction.Normalized() * _cameraSpeed * delta;
        Position += direction.Normalized() *  delta * _screenFingerSpeed;
        // GD.Print(direction);
    }
}
