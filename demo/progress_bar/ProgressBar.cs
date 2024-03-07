using Godot;
using System;

public partial class ProgressBar : Godot.ProgressBar
{
	[Export]
	public double seconds;

	public override void _Process(double delta)
	{
		Value += delta / seconds * 100;
	}
}
