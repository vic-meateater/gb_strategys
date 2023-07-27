using UnityEngine;
using Zenject;

public class UiModelInstaller : MonoInstaller
{
	[SerializeField] private AssetsContext _legacyContext;
	[SerializeField] private Sprite _chomperSprite;
	//[SerializeField] private Vector3Value _vector3;
	//[SerializeField] private BottomCenterView _BottomCenterView;
	public override void InstallBindings()
	{
		Container.Bind<AssetsContext>().FromInstance(_legacyContext);
		//Container.Bind<Vector3Value>().FromInstance(_vector3);

		Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
		.To<ProduceUnitCommandCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IUpgradeUnitCommand>>()
		.To<UpgradeUnitCommandCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IAttackCommand>>()
		.To<AttackCommandCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IMoveCommand>>()
		.To<MoveCommandCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IPatrolCommand>>()
		.To<PatrolCommandCommandCreator>().AsTransient();
		Container.Bind<CommandCreatorBase<IStopCommand>>()
		.To<StopCommandCommandCreator>().AsTransient();

		Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
				.To<SetRallyPointCommandCreator>().AsTransient();

		Container.Bind<float>().WithId("Chomper").FromInstance(5f);
		Container.Bind<string>().WithId("Chomper").FromInstance("Chomper");
		Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);

		Container.Bind<CommandButtonsModel>().AsTransient();
		//Container.Bind<BottomCenterModel>().AsTransient();
	}
}