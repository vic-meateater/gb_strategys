using System;
using Zenject;

public class UpgradeUnitCommandCommandCreator : CommandCreatorBase<IUpgradeUnitCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;
	protected override void classSpecificCommandCreation(Action<IUpgradeUnitCommand> creationCallback)
	{
		var upgradeUnitCommand = _context.Inject(new UpgradeUnitCommandHeir());
		_diContainer.Inject(upgradeUnitCommand);
		creationCallback?.Invoke(upgradeUnitCommand);
	}
}
