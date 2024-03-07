using Godot;
using System;

public partial class TextureProgressBar : Godot.TextureProgressBar
{
	[Export]
	public double seconds;

	public override void _Process(double delta)
	{
		Value += delta / seconds * 100;
	}
}
