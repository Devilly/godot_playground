using Godot;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

public struct Frame
{
	public IList<Body> bodies { get; init; }
}

public struct Body
{
	public int bodyIndex { get; init; }
	public bool tracked { get; init; }
	public IList<Joint> joints { get; init; }
}

public struct Joint
{
	public int jointType { get; init; }
	public float cameraX { get; init; }
	public float cameraY { get; init; }
	public float cameraZ { get; init; }
}

[GlobalClass]
public partial class GlobalClass : Node
{
	[Export]
	public Sprite2D Head;
	public void ReceiveFrame(string frame)
	{
		var json = JsonSerializer.Deserialize<Frame>(frame);
		IEnumerable<Joint> trackedHeads =
			from body in json.bodies
			where body.tracked == true
			from joint in body.joints
			where joint.jointType == 3
			select joint;


		if (trackedHeads.Count() > 0)
		{
			var head = trackedHeads.First();

			var viewportSize = GetViewport().GetVisibleRect().Size;
			Head.Position = new Vector2()
			{
				X = viewportSize.X / 2 + head.cameraX * 1000,
				Y = viewportSize.Y / 2 - head.cameraY * 1000
			};
		}
	}
}
