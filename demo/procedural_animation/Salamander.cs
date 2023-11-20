using Godot;
using System;
using System.Linq;

public partial class Salamander : Node2D
{
	[Export]
	public int NumberOfSegments = 17;

	[Export]
	public PackedScene Segment;

	public override void _Ready()
	{
		foreach(var value in Enumerable.Range(1, NumberOfSegments)) {
			var segment = Segment.Instantiate<Node2D>();
			segment.Position = new(200, 200);
			AddChild(segment);
		}
	}

	public override void _Process(double delta)
	{
		var userInput = Input.GetAxis("game_left", "game_right");
		
	}
}
