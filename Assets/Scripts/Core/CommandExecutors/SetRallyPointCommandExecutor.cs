using System.Threading.Tasks;
using UnityEngine;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
{
	public override Task ExecuteSpecificCommand(ISetRallyPointCommand command)
	{
		Debug.Log($"{name} is SetRallyPointCommand!");
		GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
		return Task.CompletedTask;
	}
}