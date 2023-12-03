using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Vector2 = Godot.Vector2;

// Start of https://twitter.com/TheRujiK/status/969581641680195585

public partial class Salamander : Node2D
{
	[Export]
	public PackedScene Segment;

	private LinkedList<Node2D> segments = new();
	private Vector2 Direction = Vector2.Up;

	public override void _Ready()
	{
		foreach(var _ in Enumerable.Range(1, 5)) {
			var segment = Segment.Instantiate<Node2D>();
			segment.Position = new(400, 400);
			segments.AddLast(segment);

			AddChild(segment);
		}
	}

	public override void _Process(double delta)
	{
		var userInput = Input.GetAxis("game_move_left", "game_move_right");		
		Direction = Direction.Rotated(Mathf.DegToRad((float) (100 * userInput * delta)));

		segments.ElementAt(0).Position += Direction * 150 * (float) delta;
		
		for(int index = 1; index < segments.Count; index++) {
			var leadingSegment = segments.ElementAt(index - 1);
			var segment = segments.ElementAt(index);

			var differenceInX = leadingSegment.Position.X - segment.Position.X;
			var differenceInY = leadingSegment.Position.Y - segment.Position.Y;

			var distance = Mathf.Sqrt(Mathf.Pow(differenceInX, 2) + Mathf.Pow(differenceInY, 2));
			var distanceToCover = Mathf.Max(distance - 40, 0);

			var angle = Mathf.Atan2(differenceInY, differenceInX);
			var xToCover = Mathf.Cos(angle) * distanceToCover;
			var yToCover = Mathf.Sin(angle) * distanceToCover;

			segment.Position += new Vector2(xToCover, yToCover);
		}
	}
}
