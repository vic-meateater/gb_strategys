using System;
using Zenject;
using UniRx;
using UnityEngine;

public class BottomCenterModel
{
	public IObservable<IUnitProducer> UnitProducers { get; private set; }
	public IObservable<IUnitUpgrader> UnitUpgraders { get; private set; }

	[Inject]
	public void Init(IObservable<ISelecatable> currentlySelected)
	{
		UnitProducers = currentlySelected
			.Select(selectable => selectable as Component)
			.Select(component => component?.GetComponent<IUnitProducer>());
		UnitUpgraders = currentlySelected
			.Select(selectable => selectable as Component)
			.Select(component => component?.GetComponent<IUnitUpgrader>());
	}
}