using Godot;
using System;


namespace PoorManRTS.UI;
public partial class RadialMenu : Container
{
    [ExportGroup("Radial Menu Properties")]
    [Export]
    private float _radius = 150.0f;

    [Export]
    private float _currentAngle;

    [Export]
    private Button _btn1;

    [Export]
    private Button _btn2;

    [Export]
    private Button _btn3;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Process(double delta)
    {
        ArrangeButtonsInCircle();
    }

    // Member Methods------------------------------------------------------------------------------

    private void ArrangeButtonsInCircle()
    {
        int numberOfChildern = 0;

        foreach (Control control in GetChildren())
        {
            if (control.Visible)
            {
                numberOfChildern++;
            }
        }

        // Set the incriment ration for the buttons acording to how many buttons are visible
        float angleIncrement = Mathf.Tau / numberOfChildern;

        float startingAngle = _currentAngle;


        for (int i = 0; i < GetChildCount(); i++)
        {
            Control control = GetChild(i) as Control;

            // If the button is visible we preform the actions on it
            if (control.Visible)
            {
                // Set the position of the button
                Vector2 controlPosition = new Vector2(_radius * Mathf.Cos(startingAngle), _radius * Mathf.Sin(startingAngle));

                // Set the buttons new position 

                // the new button position minus the buttons size to centre the button correctly
                control.Position -= control.Size / 2;

                // Update the angle for the next iteration
                startingAngle += angleIncrement;
            }
        }
    }
}
