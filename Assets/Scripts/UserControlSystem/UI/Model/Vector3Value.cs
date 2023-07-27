using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
public class Vector3Value : StatelessScriptableObjectValueBase<Vector3>
{
}
/*public class Vector3Value : ScriptableObjectValueBase<Vector3>
{
	public new Vector3 CurrentValue { get; private set; }
	public new Action<Vector3> OnNewValue;

	public new void SetValue(Vector3 value)
	{
		CurrentValue = value;
		OnNewValue?.Invoke(value);
	}
}*/