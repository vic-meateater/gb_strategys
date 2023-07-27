using UnityEngine;

public class MoveCommand : IMoveCommand
{
	public Vector3 Target { get; }

	public MoveCommand(Vector3 target)
	{
		Debug.Log("I MOVE");
		Target = target;
	}
}