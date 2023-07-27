using Zenject;
using UnityEngine;

public class UpgradeUnitCommand : IUpgradeUnitCommand
{
	[Inject(Id = "Chomper")] public string UpgradeName { get; }
	[Inject(Id = "Chomper")] public Sprite Icon { get; }
	[Inject(Id = "Chomper")] public float UpgradeTime { get; }

	public GameObject UnitPrefab => _unitPrefab;
	[InjectAsset("Chomper")] private GameObject _unitPrefab;
}
