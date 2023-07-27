using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeUnitCommand : ICommand, IIconHolder
{
	float UpgradeTime { get; }
	GameObject UnitPrefab { get; }
	string UpgradeName { get; }
}
