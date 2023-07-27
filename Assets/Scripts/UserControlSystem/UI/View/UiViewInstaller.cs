using UnityEngine;
using Zenject;

public class UiViewInstaller : MonoInstaller
{
	//[SerializeField] private BottomCenterView _BottomCenterView;
	public override void InstallBindings()
	{
		//Container.BindInstances (_BottomCenterView);

		Container
		.Bind<BottomCenterView>()
		.FromComponentInHierarchy()
		.AsSingle();
	}
}