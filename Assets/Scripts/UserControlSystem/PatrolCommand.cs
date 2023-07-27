using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
	public Vector3 From { get; }
	public Vector3 To { get; }
	public PatrolCommand(Vector3 from, Vector3 to)
    {
		From = from;
		To = to;
	}
}
