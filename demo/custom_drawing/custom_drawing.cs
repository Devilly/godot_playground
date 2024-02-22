using Godot;
using System;

// https://docs.godotengine.org/en/stable/tutorials/2d/custom_drawing_in_2d.html

public partial class custom_drawing : Node2D
{
  public override void _Draw()
  {
    Color WHITE = new(1, 1, 1);

    DrawLine(new(200, 200), new (250, 230), WHITE, 2, true);
    DrawArc(new(100, 100), 50, 0, 2 * MathF.PI, 360, WHITE, 2, true);
    DrawCircle(new(300, 100), 30, WHITE);
    DrawPolyline(new Vector2[] { new(600, 200), new (700, 200), new(650, 300), new(600, 200)}, WHITE, 2, true);

    // This should not work after export, though I did find it functional.
    // var image = Image.LoadFromFile("res://icon.svg");
    // var texture = ImageTexture.CreateFromImage(image);

    // This one should work, also after export:
    var texture = GD.Load<Texture2D>("res://icon.svg");

    DrawPrimitive(
      new Vector2[]{ new(300, 300), new(400, 300), new(400, 400), new(300, 400) },
      new[]{ WHITE },
      new Vector2[] { new(0,0), new(0.5f,0), new(0.5f, 0.5f), new(0,.5f)},
      texture
    );
  }
}
