using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
/*public class SelectableValue : ScriptableObjectValueBase<ISelecatable>, IObservable<ISelecatable>
{
	public new ISelecatable CurrentValue { get; private set; }
	public Action<ISelecatable> OnSelected;
	//public IObservable<ISelecatable> iObservable { get; set; }
	public IDisposable Subscribe(IObserver<ISelecatable> observer) => Subscribe(observer);
	public new void SetValue(ISelecatable value)
	{
		CurrentValue = value;
		OnSelected?.Invoke(value);
	}
}
*/
public sealed class SelectableValue : StatefulScriptableObjectValueBase<ISelecatable>
{

}
