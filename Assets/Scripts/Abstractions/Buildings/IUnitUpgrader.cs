using UniRx;

public interface IUnitUpgrader 
{
	IReadOnlyReactiveCollection<IUnitUpgraderTask> Queue { get; }
	public void Cancel(int index);
}
