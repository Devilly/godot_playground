using Godot;
using System;

public partial class Segment : Node2D
{
	public override void _Draw () {
		DrawArc(Vector2.Zero, 20, 0, 2 * MathF.PI, 360, Colors.Gray, 1, true);
	}
}
