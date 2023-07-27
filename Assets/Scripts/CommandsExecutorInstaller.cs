using Zenject;

public class CommandsExecutorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var executors = gameObject.GetComponents<ICommandExecutor>();
        foreach (var executor in executors)
        {
            var baseType = executor.GetType().BaseType;
            Container.Bind(baseType).FromInstance(executor);
        }
    }
}