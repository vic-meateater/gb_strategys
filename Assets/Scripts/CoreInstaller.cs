using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
	[SerializeField] private GameStatus _gameStatus;
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
		Container.BindInterfacesAndSelfTo<BottomCenterModel>().AsSingle();
		Container.Bind<IGameStatus>().FromInstance(_gameStatus);
	}
}