using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
	public CancellationTokenSource CancellationTokenSource { get; set; }

	public override Task ExecuteSpecificCommand(IStopCommand command)
	{
		Debug.Log("I STOP");
		CancellationTokenSource?.Cancel();
		return Task.CompletedTask;
	}
}