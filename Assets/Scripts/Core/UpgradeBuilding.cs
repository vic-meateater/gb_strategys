using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour, ISelecatable, IAttackable
{
	public float Health => _health;
	public float MaxHealth => _maxHealth;
	public Sprite Icon => _icon;
	public Transform PivotPoint => _pivotPoint;

	public Vector3 RallyPoint { get; set; }


	[SerializeField] private Transform _unitsParent;
	[SerializeField] private Transform _pivotPoint;
	[SerializeField] private Sprite _icon;

	[SerializeField] private float _maxHealth = 500;

	[SerializeField] private float _health = 500;

	public void ReceiveDamage(int amount)
	{
		if (_health <= 0)
		{
			return;
		}

		_health -= amount;
		if (_health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
