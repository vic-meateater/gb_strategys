public interface IAttackCommand: ICommand
{
    public IAttackable Target { get; }
}