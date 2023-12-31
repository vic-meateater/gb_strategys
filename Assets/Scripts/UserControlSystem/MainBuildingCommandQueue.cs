using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;

    public void Clear()
    {
    }

    public ICommand CurrentCommand => default;

    public async void EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
    }
}