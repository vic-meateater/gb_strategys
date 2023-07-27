using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
public class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
{

}
/*public class AttackableValue : ScriptableObjectValueBase<IAttackable>
{
	public new IAttackable CurrentValue { get; private set; }
	public Action<IAttackable> OnSelected;

	public new void SetValue(IAttackable value)
	{
		CurrentValue = value;
		OnSelected?.Invoke(value);
	}
}*/
