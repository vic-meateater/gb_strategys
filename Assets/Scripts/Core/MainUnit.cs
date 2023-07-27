using UnityEngine;

public class MainUnit : MonoBehaviour, ISelecatable, IAttackable, IDamageDealer, IAutomaticAttacker, IUpgradeble
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public float VisionRadius => _visionRadius;
    public int Damage => _damage;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;


    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _visionRadius = 8f;

    [SerializeField] private float _health = 100;
    private float _healthUpgrade = 25;

    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommand;

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Debug.Log("Chomper is Dead");
            Invoke(nameof(destroy), 1f);
        }
    }

    private async void destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new StopCommand());
        Destroy(gameObject);
    }

    public void ReceiveUpgrade()
    {
        _health += _healthUpgrade;
        Debug.Log("Chomper is Upgrading");
    }
}