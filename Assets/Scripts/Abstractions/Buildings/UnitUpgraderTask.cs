using UnityEngine;

public class UnitUpgraderTask : IUnitUpgraderTask
{
	public Sprite Icon { get; }
	public float TimeLeft { get; set; }
	public float UpgradeTime { get; }
	public string UpgradeName { get; }
	public GameObject UnitPrefab { get; }

	public UnitUpgraderTask(float time, Sprite icon, GameObject unitPrefab, string upgradeName)
	{
		Icon = icon;
		UpgradeTime = time;
		TimeLeft = time;
		UnitPrefab = unitPrefab;
		UpgradeName = upgradeName;
	}
}
