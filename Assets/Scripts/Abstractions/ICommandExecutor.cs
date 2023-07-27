public interface ICommandExecutor
{
}

public interface ICommandExecutor<T> where T : ICommand
{
}
