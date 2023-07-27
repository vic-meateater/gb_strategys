using UnityEngine;
using Zenject;
using System;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
	[SerializeField] private AssetsContext _legacyContext;
	[SerializeField] private Vector3Value _groundClicksRMB;
	[SerializeField] private AttackableValue _attackableClicksRMB;
	[SerializeField] private SelectableValue _selectables;
	//[SerializeField] private BottomCenterView _BottomCenterView;

	[SerializeField] private Sprite _chomperSprite;

	public override void InstallBindings()
	{
		Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectables/*, _BottomCenterView*/);

		Container.Bind<IAwaitable<IAttackable>>()
			.FromInstance(_attackableClicksRMB);
		Container.Bind<IAwaitable<Vector3>>()
			 .FromInstance(_groundClicksRMB);

		Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
		Container.Bind<IObservable<ISelecatable>>().FromInstance(_selectables);
	}
}
