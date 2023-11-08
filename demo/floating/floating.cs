using Godot;
using System;

public partial class floating : Sprite2D
{
    [Export]
    public Vector2 Placement;

    [Export]
    public int Oscilliation;

    public override void _Ready() {
        Position = Placement;
    }

    public override void _Process(double delta)
    {
        Position = Placement with { Y = Placement.Y + ((float) Math.Sin(Time.GetTicksMsec() / 1000f) * Oscilliation) };
    }
}
