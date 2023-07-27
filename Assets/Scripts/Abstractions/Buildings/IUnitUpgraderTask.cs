public interface IUnitUpgraderTask : IIconHolder
{
	public string UpgradeName { get; }
	public float TimeLeft { get; }
	public float UpgradeTime { get; }
}
