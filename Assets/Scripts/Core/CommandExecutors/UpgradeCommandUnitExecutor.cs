using UniRx;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Threading.Tasks;

public class UpgradeCommandUnitExecutor : CommandExecutorBase<IUpgradeUnitCommand>, IUnitUpgrader
{
    public IReadOnlyReactiveCollection<IUnitUpgraderTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private int _addHealth = 50;
    [SerializeField] private int _addDamage = 15;
    private FactionMember _factionMember;
    private int _factionNumber;

    [Inject] private DiContainer _diContainer;

    private ReactiveCollection<IUnitUpgraderTask> _queue = new ReactiveCollection<IUnitUpgraderTask>();

    private void Start()
    {
        _factionMember = GetComponent<FactionMember>();
        _factionNumber = _factionMember.FactionId;
    }
    private void Update()
    {
        if (_queue.Count == 0)
        {
            return;
        }

        var innerTask = (UnitUpgraderTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            removeTaskAtIndex(0);
            var _chomper = innerTask.UnitPrefab;
            if (_chomper.GetComponent<FactionMember>().FactionId == _factionNumber) _chomper.GetComponent<MainUnit>().ReceiveUpgrade();
        }
    }

    public void Cancel(int index) => removeTaskAtIndex(index);

    private void removeTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
        {
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(_queue.Count - 1);
    }

    public override Task ExecuteSpecificCommand(IUpgradeUnitCommand command)
    {
        _queue.Add(new UnitUpgraderTask(command.UpgradeTime, command.Icon, command.UnitPrefab, command.UpgradeName));
        return Task.CompletedTask;
    }
}
